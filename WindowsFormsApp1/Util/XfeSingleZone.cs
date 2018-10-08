using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransferControl.Management;

namespace Adam.Util
{
    /// <summary>
    /// 單區傳送, 可同時兩 Robot 獨立跑
    /// </summary>
    class XfeSingleZone
    {
        private StringBuilder cLog = new StringBuilder();
        private static readonly ILog logger = LogManager.GetLogger(typeof(XfeSingleZone));
        private TransferRecipe recipe { get; set; }
        private TransferWafer[] wafers { get; set; }
        private string sourcePort { get; set; }
        private Boolean isExeFail = false;
        Boolean isPutWithoutBack;
        //int preTimeout = 600000;
        //int postTimeout = 600000;
        int preTimeout = 60000;
        int postTimeout = 60000;
        public XfeSingleZone(string sourcePort, TransferWafer[] wafers, TransferRecipe recipe)
        {
            this.sourcePort = sourcePort;
            this.recipe = recipe;
            this.wafers = wafers;
        }
        public Boolean doTransfer()
        {
            Boolean result = false;
            try
            {
                string[] aligners = recipe.ROB1_ALIGNER.Split(',');
                int idx = 0;
                TransferWafer wafer1;
                TransferWafer wafer2;
                while (!isExeFail && idx < 25)
                {
                    int waferCnt = 0;
                    TransferState.processCntR1 = 0;

                    #region  Step0 => Look for the WAFER to be processed
                    wafer1 = getNextWafer(wafers, idx);
                    if (wafer1 != null)
                    {
                        waferCnt++;
                        idx = wafer1.Source_Slot;// change index to next new slot
                        wafer2 = getNextWafer(wafers, idx);
                        if (wafer2 != null)
                        {
                            waferCnt++;
                            idx = wafer2.Source_Slot;// change index to next new slot
                        }
                    }
                    else// No wafer waiting to be processed
                    {
                        closePort(sourcePort);// close load port
                        break;
                    }
                    #endregion
                    #region Step1 => GET From Port
                    if (wafer2 == null)
                    {
                        getFromPort(wafer1, "ARM1");//上臂單取第一片
                        wafer1.Location = "ARM1";
                    }
                    else if (wafer2.Source_Slot == wafer1.Source_Slot + 1 && recipe.ROB1_DOUBLE_ARM.Equals("Y"))
                    {
                        getFromPort(wafer2, "ARM3");//雙取, 上臂取第二片, 下臂取第一片
                        wafer2.Location = "ARM1";
                        wafer1.Location = "ARM2";
                    }
                    else
                    {
                        getFromPort(wafer2, "ARM1");//上臂單取第二片
                        wafer2.Location = "ARM1";
                        getFromPort(wafer1, "ARM2");//下臂單取第一片
                        wafer1.Location = "ARM2";
                    }
                    #endregion
                    SpinWait.SpinUntil(() => TransferState.checkRule["R1_GET_OPT0_PORT_FIN"] == true, 30000);//確保所有片數已處理完
                    #region Step2 =>  Put to Align & Process & Get From Aligner
                    isPutWithoutBack = ((wafer2 == null) || aligners.Length == 1) ? true : false;
                    System.Threading.WaitCallback callExecAlign = new WaitCallback(execAlign);
                    if (wafer2 == null) //只有一片
                    {
                        putToAligner(wafer1, aligners[0], "ARM1", isPutWithoutBack);
                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer1);
                        getFromAligner(wafer1, aligners[0], "ARM1");
                    }
                    else if (aligners.Length == 1)// 有兩片, 只有一個 Aligner
                    {
                        //wafer 2
                        putToAligner(wafer2, aligners[0], "ARM1", isPutWithoutBack);
                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer2);
                        getFromAligner(wafer2, aligners[0], "ARM1");
                        //wafer 1
                        putToAligner(wafer1, aligners[0], "ARM2", isPutWithoutBack);
                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer1);
                        getFromAligner(wafer1, aligners[0], "ARM2");
                    }
                    else if (aligners.Length == 2)// 有兩片, 有兩個 Aligner
                    {
                        //wafer 2
                        putToAligner(wafer2, aligners[0], "ARM1", false);
                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer2);
                        string rule = aligners[0].Equals("ALIGNER01")?"R1_PUT_OPT3_A1_FIN": "R1_PUT_OPT3_A2_FIN";
                        SpinWait.SpinUntil(() => TransferState.checkRule[rule], preTimeout);// 等待前置條件成立
                        if (!TransferState.checkRule[rule])
                        {
                            addLog("Check: " + rule + " timeout\n");
                        }
                        //wafer 1
                        putToAligner(wafer1, aligners[1], "ARM2", false);
                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer1);
                        rule = aligners[1].Equals("ALIGNER01") ? "R1_PUT_OPT3_A1_FIN" : "R1_PUT_OPT3_A2_FIN";
                        SpinWait.SpinUntil(() => TransferState.checkRule[rule], preTimeout);// 等待前置條件成立
                        if (!TransferState.checkRule[rule])
                        {
                            addLog("Check: " + rule + " timeout\n");
                        }
                        //wafer 2
                        getFromAligner(wafer2, aligners[0], "ARM1");
                        //wafer 1
                        getFromAligner(wafer1, aligners[1], "ARM2");

                    }
                    #endregion
                    SpinWait.SpinUntil(() => TransferState.processCntR1 == waferCnt, 3000);//確保所有片數已處理完
                    if (TransferState.processCntR1 != waferCnt)
                    {
                        addLog(" 等待完成片數 Timeout");
                        break;//exit while
                    }
                    #region Step 3 => Put to port
                    if (wafer2 == null)
                    {
                        checkAlignerHome(aligners);
                        putToPort(wafer1, "ARM1");//上臂單放第一片
                    }
                    else if (wafer2.Target == wafer1.Target && wafer2.Target_Slot == wafer1.Target_Slot + 1 && recipe.ROB1_DOUBLE_ARM.Equals("Y") )
                    {
                        checkAlignerHome(aligners);
                        putToPort(wafer2, "ARM3");//雙放, 第一片在下臂, 第二片在上臂
                    }
                    else
                    {
                        checkAlignerHome(aligners);
                        putToPort(wafer2, "ARM1");//上臂單放第二片
                        putToPort(wafer1, "ARM2");//下臂單放第一片
                    }
                    #endregion
                }//end while
                addLog(" Do Transfer End\n\n\n");
                //Console.Write(" Do Transfer End");
                logger.Error("\n\n\n" + cLog.ToString());
            }
            catch(Exception e)
            {
                logger.Error(e.StackTrace + ":" + e.Message);
            }
            return result;
        }

        private void execAlign(object data)
        {
            TransferWafer wafer = (TransferWafer)data;
            string useOCR = recipe.USE_OCR;
            string methodName = "*** execAlign *** ";
            //init state
            string target = wafer.Location; // ALIGNER01 or ALIGNER02
            string tagAligner;
            if (target.Equals("ALIGNER01"))
            {
                tagAligner = "A1";
            }
            else if (target.Equals("ALIGNER02"))
            {
                tagAligner = "A2";
            }
            else
            {
                return; // do nothing
            }
            string chkPreRule1_1 = tagAligner + "_HOLD_FIN" ;
            string chkPreRule1_2 = isPutWithoutBack ? "R1_PUT_OPT2_" + tagAligner  + "_FIN" : "R1_PUT_OPT3_" + tagAligner  + "_FIN";
            string chkPostRule1 = tagAligner + "_ALIGN1_FIN";//1st Align
            string chkPostRule2 = target.Equals("ALIGNER01") ? "OCR1_READ_FIN" : "OCR2_READ_FIN";
            string chkPostRule3 = tagAligner + "_HOME_FIN";
            string chkPostRule4 = tagAligner + "_ALIGN2_FIN";//second align
            string chkPostRule5 = tagAligner + "_RELEASE_FIN";
            string ocr_name = target.Equals("ALIGNER01") ? "OCR01" : "OCR02";
            TransferState.checkRule[chkPostRule1] = false;
            TransferState.checkRule[chkPostRule2] = false;
            TransferState.checkRule[chkPostRule3] = false;
            TransferState.checkRule[chkPostRule4] = false;
            TransferState.checkRule[chkPostRule5] = false;

            string aligner = target;
            string ocr = ocr_name;
            CommandJob[] cmds = new CommandJob[5];
            Transaction[] txn = new Transaction[5];
            //txn 1 : Aligner Align
            txn[0] = new Transaction();
            txn[0].FormName = chkPostRule1.Replace("_FIN", "").Replace("_ACK", "");
            txn[0].Method = Transaction.Command.AlignerType.Align;
            txn[0].Value = "120"; // kuma hard code
            cmds[0] = new CommandJob(txn[0], aligner, methodName);
            cmds[0].setPreCheckRules(new string[] { chkPreRule1_1, chkPreRule1_2 }); // !!! wafer hold & Put 結束後才能 Align
            cmds[0].setPostCheckRule(chkPostRule1);
            //txn 2 : OCR
            txn[1] = new Transaction();
            txn[1].FormName = chkPostRule2.Replace("_FIN", "").Replace("_ACK", "");
            txn[1].Method = Transaction.Command.OCRType.Read; //OCR Read
            cmds[1] = new CommandJob(txn[1], ocr, methodName);
            cmds[1].setPostCheckRule(chkPostRule2);
            //txn 3 : Aligner HOME
            txn[2] = new Transaction();
            txn[2].FormName = chkPostRule3.Replace("_FIN", "").Replace("_ACK", "");
            txn[2].Method = Transaction.Command.AlignerType.AlignerHome; //Aligner Home
            cmds[2] = new CommandJob(txn[2], aligner, methodName);
            cmds[2].setPostCheckRule(chkPostRule3);
            //txn 4 : Aligner Align
            txn[3] = new Transaction();
            txn[3].FormName = chkPostRule4.Replace("_FIN", "").Replace("_ACK", "");
            txn[3].Method = Transaction.Command.AlignerType.Align;
            txn[3].Value = "23"; // kuma hard code
            cmds[3] = new CommandJob(txn[3], aligner, methodName);
            cmds[3].setPostCheckRule(chkPostRule4);
            //txn 5 : Wafer Release
            txn[4] = new Transaction();
            txn[4].FormName = chkPostRule5.Replace("_FIN", "").Replace("_ACK", "");
            txn[4].Method = Transaction.Command.AlignerType.WaferRelease;
            cmds[4] = new CommandJob(txn[4], aligner, methodName);
            cmds[4].setPostCheckRule(chkPostRule5);

            if (useOCR != null && useOCR.Trim().Equals("Y"))
                runCommands(cmds);
            else
                runCommands(new CommandJob[] { cmds[0], cmds[4] });// Align => Wafer release
            wafer.Location = target;
        }

        private void putToPort(TransferWafer wafer, string arm)
        {
            TransferState.checkRule["R1_PUT_OPT0_PORT_FIN"] = false;
            string methodName = "*** putToPort *** ";
            string position = "";
            if (wafer.Target.StartsWith("P1"))
                position = "LOADPORT01";
            else if (wafer.Target.StartsWith("P2"))
                position = "LOADPORT02";
            else if (wafer.Target.StartsWith("P3"))
                position = "LOADPORT03";
            else if (wafer.Target.StartsWith("P4"))
                position = "LOADPORT04";
            else
                position = wafer.Target;

            string robot = "ROBOT01";
            Transaction txn = new Transaction();

            txn.FormName = "R1_PUT_OPT0_PORT";
            txn.Method = Transaction.Command.RobotType.Put;
            txn.Position = position;
            txn.Arm = SanwaUtil.GetArmID(arm);
            txn.Slot = wafer.Source_Slot.ToString();
            //txn.Value = "";

            CommandJob cmd = new CommandJob(txn, robot, methodName);
            cmd.setPostCheckRule("R1_PUT_OPT0_PORT_FIN");

            runCommands(new CommandJob[] { cmd });
            wafer.Location = wafer.Target;

        }


        private void putToAligner(TransferWafer wafer, string target, string arm, Boolean isPutWithoutBack)
        {
            //init state
            switch (target)
            {
                case "ALIGNER01":
                    TransferState.checkRule["R1_PUT_OPT1_A1_FIN"] = false;//isPutToA1Opt1Fin
                    TransferState.checkRule["R1_PUT_OPT2_A1_FIN"] = false;//isPutToA1Opt2Fin
                    TransferState.checkRule["R1_PUT_OPT3_A1_FIN"] = false;//isPutToA1Opt3Fin
                    TransferState.checkRule["R1_PUT_OPT1_A1_ACK"] = false;//isPutToA1Opt1Fin
                    TransferState.checkRule["R1_PUT_OPT2_A1_ACK"] = false;//isPutToA1Opt2Fin
                    TransferState.checkRule["R1_PUT_OPT3_A1_ACK"] = false;//isPutToA1Opt3Fin
                    putToAligner1(wafer, arm, isPutWithoutBack);
                    break;
                case "ALIGNER02":
                    TransferState.checkRule["R1_PUT_OPT1_A2_FIN"] = false;//isPutToA1Opt1Fin
                    TransferState.checkRule["R1_PUT_OPT2_A2_FIN"] = false;//isPutToA1Opt2Fin
                    TransferState.checkRule["R1_PUT_OPT3_A2_FIN"] = false;//isPutToA1Opt3Fin
                    TransferState.checkRule["R1_PUT_OPT1_A2_ACK"] = false;//isPutToA1Opt1Fin
                    TransferState.checkRule["R1_PUT_OPT2_A2_ACK"] = false;//isPutToA1Opt2Fin
                    TransferState.checkRule["R1_PUT_OPT3_A2_ACK"] = false;//isPutToA1Opt3Fin
                    putToAligner2(wafer, arm, isPutWithoutBack);
                    break;
            }
            wafer.Location = target;
        }

        private void putToAligner1(TransferWafer wafer, string arm, Boolean isPutWithoutBack)
        {
            string methodName = "*** putToAligner1 *** ";
            string target = "ALIGNER01";
            string robot = "ROBOT01";
            string aligner = target;
            CommandJob[] cmds = new CommandJob[3];
            Transaction[] txn = new Transaction[3];
            //txn 1 : robot put option1
            txn[0] = new Transaction();
            txn[0].FormName = "R1_PUT_OPT1_A1";
            txn[0].Method = Transaction.Command.RobotType.WaitBeforePut;//Put option 1
            txn[0].Position = target;
            txn[0].Arm = SanwaUtil.GetArmID(arm);
            txn[0].Slot = "1";
            cmds[0] = new CommandJob(txn[0], robot, methodName);
            cmds[0].setPostCheckRule("R1_PUT_OPT1_A1_FIN");

            //txn 2 : aligner wafer hold
            txn[1] = new Transaction();
            txn[1].FormName = "A1_HOLD";
            txn[1].Method = Transaction.Command.AlignerType.WaferHold; //Wafer Hold
            cmds[1] = new CommandJob(txn[1], aligner, methodName);
            //cmds[1].postCheckRules = ""; // wafer hold 不需要等待

            //txn 3 : robot continue put : option2 or option3
            txn[2] = new Transaction();
            txn[2].FormName = isPutWithoutBack ? "R1_PUT_OPT2_A1" : "R1_PUT_OPT3_A1";
            //Put option 2 or option 3
            txn[2].Method = isPutWithoutBack ? Transaction.Command.RobotType.PutWithoutBack : Transaction.Command.RobotType.PutBack;
            txn[2].Position = target;
            txn[2].Arm = SanwaUtil.GetArmID(arm);
            txn[2].Slot = "1";
            cmds[2] = new CommandJob(txn[2], robot, methodName);
            //cmds[2].setPostCheckRule(isPutWithoutBack ? "R1_PUT_OPT2_FIN" : "R1_PUT_OPT3_FIN");//不用等結束, 由下一動作自行 precheck

            runCommands(cmds);
            wafer.Location = "ALIGNER01";
        }

        private void putToAligner2(TransferWafer wafer, string arm, Boolean isPutWithoutBack)
        {
            string methodName = "*** putToAligner2 *** ";
            string target = "ALIGNER02";
            //Node robot = NodeManagement.Get("ROBOT01");
            //Node aligner = NodeManagement.Get(target);
            string robot = "ROBOT01";
            string aligner = target;
            CommandJob[] cmds = new CommandJob[3];
            Transaction[] txn = new Transaction[3];
            //txn 1 : robot put option1
            txn[0] = new Transaction();
            txn[0].FormName = "R1_PUT_OPT1_A2";
            txn[0].Method = Transaction.Command.RobotType.WaitBeforePut;//Put option 1
            txn[0].Position = target;
            txn[0].Arm = SanwaUtil.GetArmID(arm);
            txn[0].Slot = "1";
            cmds[0] = new CommandJob(txn[0], robot, methodName);
            cmds[0].setPostCheckRule("R1_PUT_OPT1_A2_FIN");

            //txn 2 : aligner wafer hold
            txn[1] = new Transaction();
            txn[1].FormName = "A2_HOLD";
            txn[1].Method = Transaction.Command.AlignerType.WaferHold; //Put option 1
            cmds[1] = new CommandJob(txn[1], aligner, methodName);
            //cmds[1].postCheckRules = ""; // wafer hold 不需要等待

            //txn 3 : robot continue put : option2 or option3
            txn[2] = new Transaction();
            txn[2].FormName = isPutWithoutBack ? "R1_PUT_OPT2_A2" : "R1_PUT_OPT3_A2";
            //Put option 2 or option 3
            txn[2].Method = isPutWithoutBack ? Transaction.Command.RobotType.PutWithoutBack : Transaction.Command.RobotType.PutBack;
            txn[2].Position = target;
            txn[2].Arm = SanwaUtil.GetArmID(arm);
            txn[2].Slot = "1";
            cmds[2] = new CommandJob(txn[2], robot, methodName);
            //cmds[2].setPostCheckRule(isPutWithoutBack ? "R1_PUT_OPT2_FIN" : "R1_PUT_OPT3_FIN");//不用等結束, 由下一動作自行 precheck

            runCommands(cmds);
            wafer.Location = "ALIGNER02";
        }

        private void getFromAligner(TransferWafer wafer, string source, string arm)
        {
            string methodName = "*** getFromAligner *** ";
            string tagAligner = "";
            string postChkRule1 = "";
            if (source.Equals("ALIGNER01"))
            {
                tagAligner = "A1";
            }
            else if (source.Equals("ALIGNER02"))
            {
                tagAligner = "A2";
            }
            else
            {
                return; // do nothing
            }
            TransferState.checkRule["R1_GET_WAIT_" + tagAligner + "_FIN"] = false;
            TransferState.checkRule["R1_GET_OPT0_" + tagAligner + "_FIN"] = false;
            TransferState.checkRule["R1_GET_OPT3_" + tagAligner + "_FIN"] = false;
            TransferState.checkRule[tagAligner + "_HOME_FIN"] = false;

            string position = source;
            string robot = "ROBOT01";
            string aligner = source;
            // R1_PUT_OPT2_A1_FIN , R1_PUT_OPT2_A2_FIN, R1_GET_WAIT_A1_FIN, R1_GET_WAIT_A2_FIN
            string preCheckRule1 = isPutWithoutBack ? "R1_PUT_OPT2_" + tagAligner + "_FIN" : "R1_GET_WAIT_" + tagAligner + "_FIN"; 
            string preCheckRule2 = tagAligner + "_RELEASE_FIN"; // A1_RELEASE_FIN or A2_RELEASE_FIN
            string[] preCheckRules = new string[] { preCheckRule1 , preCheckRule2 };

            #region TXN1: Get wait to the aligner
            Transaction txn1 = new Transaction();
            txn1.FormName = "R1_GET_WAIT_" + tagAligner;
            txn1.Method = Transaction.Command.RobotType.GetWait;
            txn1.Position = position;
            txn1.Arm = SanwaUtil.GetArmID(arm);
            txn1.Slot = "1";
            CommandJob cmd1 = new CommandJob(txn1, robot, methodName);
            cmd1.setPostCheckRule("R1_GET_WAIT_" + tagAligner  + "_FIN");
            #endregion

            #region TXN2: Get Wafer from aligner
            Transaction txn2 = new Transaction();
            txn2.Position = position;
            txn2.Arm = SanwaUtil.GetArmID(arm);
            txn2.Slot = "1";
            if (isPutWithoutBack)
            {
                txn2.FormName = "R1_GET_OPT3_" + tagAligner;
                txn2.Method = Transaction.Command.RobotType.GetAfterWait;
                postChkRule1 = "R1_GET_OPT3_" + tagAligner  +  "_FIN";
            }
            else
            {
                txn2.FormName = "R1_GET_OPT0_" + tagAligner;
                txn2.Method = Transaction.Command.RobotType.Get;
                postChkRule1 = "R1_GET_OPT0_" + tagAligner + "_FIN";
            }
            CommandJob cmd2 = new CommandJob(txn2, robot, methodName);
            cmd2.setPreCheckRules(preCheckRules);
            cmd2.setPostCheckRule(postChkRule1);
            #endregion

            #region TXN3: Aligner Home
            Transaction txn3 = new Transaction();
            txn3.FormName = source.Equals("ALIGNER01") ? "A1_HOME" : "A2_HOME";
            txn3.Method = Transaction.Command.AlignerType.AlignerHome;
            CommandJob cmd3 = new CommandJob(txn3, aligner, methodName);
            //cmd3.setPostCheckRule(source.Equals("ALIGNER01") ? "A1_HOME_FIN" : "A2_HOME_FIN"); 改在 putToPort Check
            #endregion

            if (isPutWithoutBack)
                runCommands(new CommandJob[] { cmd2, cmd3 }); //Arm 在下方等時, 不需要 GET Wait
            else
                runCommands(new CommandJob[] { cmd1, cmd2, cmd3 });

            //SpinWait.SpinUntil(() => TransferState.isJobFin, 3000);
            wafer.Location = arm;
            TransferState.processCntR1++;
        }
        private void getFromPort(TransferWafer wafer, string arm)
        {
            string methodName = " *** getFromPort *** ";
            TransferState.checkRule["R1_GET_OPT0_PORT_FIN"] = false;
            string position = "";
            if (wafer.Location.StartsWith("P1"))
                position = "LOADPORT01";
            else if (wafer.Location.StartsWith("P2"))
                position = "LOADPORT02";
            else if (wafer.Location.StartsWith("P3"))
                position = "LOADPORT03";
            else if (wafer.Location.StartsWith("P4"))
                position = "LOADPORT04";
            else
                position = wafer.Location;
            string robot = "ROBOT01";
            Transaction txn = new Transaction();

            txn.FormName = "R1_GET_OPT0_PORT";
            txn.Method = Transaction.Command.RobotType.Get;
            txn.Position = position;
            txn.Arm = SanwaUtil.GetArmID(arm);
            txn.Slot = wafer.Source_Slot.ToString();
            CommandJob cmd = new CommandJob(txn, robot, methodName);
            //cmd.preCheckRules = "";
            cmd.setPostCheckRule("R1_GET_OPT0_PORT_FIN");
            runCommands(new CommandJob[] { cmd });
        }

        private void runCommands(object data)
        {
            //TransferState.isJobFin = false;
            CommandJob[] cmds = (CommandJob[])data;

            foreach (CommandJob cmd in cmds)
            {
                if (cmd.nodeName.StartsWith("OCR") || cmd.nodeName.ToUpper().Equals("ALIGNER01"))
                {
                    TransferState.setState(cmd.txn.FormName + "_ACK", true); //2018 Add by Steven for Transfer Job check rule
                    Thread.Sleep(100);//假裝等一下
                    TransferState.setState(cmd.txn.FormName + "_FIN", true); //2018 Add by Steven for Transfer Job check rule
                    Thread.Sleep(100);//假裝等一下
                    continue;// OCR,Aligner1 先跳過不做 kuma
                }

                Node node = NodeManagement.Get(cmd.nodeName);
                Boolean needChkPreRule = (cmd.preCheckRules != null && cmd.preCheckRules.Length > 0) ? true : false;
                Boolean needChkPostRule = (cmd.postCheckRules != null && cmd.postCheckRules.Length > 0) ? true : false;
                //pre check
                if (needChkPreRule)
                {
                    foreach (string rule in cmd.preCheckRules)
                    {
                        addLog("Pre Check: " + rule + "\n");
                        SpinWait.SpinUntil(() => TransferState.checkRule[rule], preTimeout);// 等待前置條件成立
                        if (!TransferState.checkRule[rule])
                        {
                            addLog("Check: " + rule + " timeout\n");
                        }
                    }
                }
                cmd.txn.RecipeID = "300MM"; //hard code
                string msg = DateTime.Now.TimeOfDay + "" + cmd.methodName + " Form:" + cmd.txn.FormName + " Method: " + cmd.txn.Method + " Position:" + cmd.txn.Position + " Arm:" + cmd.txn.Arm + " Slot:" + cmd.txn.Slot + " Node:" + cmd.nodeName;
                addLog(msg + "\n");
                node.SendCommand(cmd.txn);
                //post check
                if (needChkPostRule)
                {
                    foreach (string rule in cmd.postCheckRules)
                    {
                        //SpinWait.SpinUntil(() => TransferState.getState(rule).checkRule[rule], postTimeout);// 等待後置條件成立
                        addLog("Post Check: " + rule + "\n");
                        SpinWait.SpinUntil(() => TransferState.getState(rule), postTimeout);// 等待後置條件成立
                        if (!TransferState.checkRule[rule])
                        {
                            addLog("Check: " + rule + " timeout\n");
                        }
                    }
                }
            }
        }

        private void addLog(string msg)
        {
            //return;
            logger.Error(msg);
            cLog.Append(msg);
        }
        private void closePort(string sourcePort)
        {
            addLog("Close Port" + sourcePort);
            addLog("*** closePort ***\n");
            Node port = NodeManagement.Get(sourcePort);
            Transaction txn = new Transaction();
            txn.Method = Transaction.Command.LoadPortType.Unload;
            //port.SendCommand(txn); // 暫時不執行 kuma
        }

        private TransferWafer getNextWafer(TransferWafer[] targets, int idx)
        {
            TransferWafer result = null;
            for (int i = idx; i < targets.Length; i++)
            {
                if (targets[i] != null && targets[i].Target != null)
                {
                    return targets[i]; //find wafer
                }
            }
            return result;
        }
        /// <summary>
        /// 確保所有Aligner 都回 HOME
        /// </summary>
        /// <param name="aligners"></param>
        /// <returns></returns>
        private Boolean checkAlignerHome(string[] aligners)
        {
            foreach(string aligner in aligners)
            {
                string rule = "";
                if (aligner.Equals("ALIGNER01"))
                {
                    rule = "A1_HOME_FIN";
                }else if (aligner.Equals("ALIGNER02"))
                {
                    rule = "A2_HOME_FIN";
                }else
                {
                    addLog("Aligner: " + aligner + " Data Error\n");
                    return false;
                }

                SpinWait.SpinUntil(() => TransferState.checkRule[rule], postTimeout);
                if (!TransferState.checkRule[rule])
                {
                    addLog("Check: " + rule + " timeout\n");
                    return false;
                }
            }
            return true;
        }
    }
}

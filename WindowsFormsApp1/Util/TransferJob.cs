//using log4net;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using TransferControl.Management;

//namespace Adam.Util
//{

//    class CommandJob
//    {
//        public Node node { get; set; }
//        public string nodeName { get; set; }
//        public string methodName { get; set; }
//        public Transaction txn { get; set; }
//        public string[] preCheckRules { get; set; }
//        public string[] postCheckRules { get; set; }
//        //public string new_location { get; set; }
//        //public CommandJob(Transaction txn, Node node)
//        //{
//        //    this.node = node;
//        //    this.txn = txn;
//        //}
//        public CommandJob(Transaction txn, string nodeName, string methodName)
//        {
//            this.nodeName = nodeName;
//            this.txn = txn;
//            this.methodName = methodName;
//        }
//        public void setPreCheckRule(string rule)
//        {
//            preCheckRules = new string[] { rule};
//        }
//        public void setPreCheckRules(string[] rules)
//        {
//            preCheckRules = rules;
//        }
//        public void setPostCheckRule(string rule)
//        {
//            postCheckRules = new string[] { rule };
//        }
//        public void setPostCheckRules(string[] rules)
//        {
//            postCheckRules = rules;
//        }
//    }
//    class Wafer
//    {
//        public string Location { get; set; } = "";
//        public string Source { get; set; } = "";
//        public string Target { get; set; } = "";
//        public string Wafer_id { get; set; } = "";
//        public int Source_Slot { get; set; }
//        public int Target_Slot { get; set; }
//        public enum State { WAIT_GET_FROM_PORT, WAIT_PUT_TO_ALIGNER, WAIT_TO_PROCESS, WAIT_GET_PROM_ALIGNER, WAIT_PUT_TO_PORT, COMPLETE, NONE };
//        public State Wafer_state { get; set; }
//        public Wafer(string source, int source_slot, string target, int target_slot)
//        {
//            this.Location = source;//目前位置
//            this.Source = source;//來源位置
//            this.Source_Slot = source_slot;//來源 Slot
//            if (target!= null && !target.Trim().Equals(""))
//            {
//                this.Wafer_state = State.WAIT_GET_FROM_PORT;
//                this.Target = target;//目標位置
//                this.Target_Slot = target_slot;//目標 Slot
//            }
//            else
//            {
//                this.Wafer_state = State.NONE;
//            }

//        }
//    }
//    class TransferRecipe
//    {
//        public string ROB1_DOUBLE_ARM { get; set; } = "Y";
//        public string ROB2_DOUBLE_ARM { get; set; } = "Y";
//        //public string ROB1_ALIGNER { get; set; } = "ALIGNER01,ALIGNER02";
//        //public string ROB2_ALIGNER { get; set; } = "ALIGNER01,ALIGNER02";
//        public string ROB1_ALIGNER { get; set; } = "ALIGNER02";
//        public string ROB2_ALIGNER { get; set; } = "ALIGNER02";
//        public string USE_OCR { get; set; } = "Y";
//        public TransferRecipe(string fileName)
//        {
//            //parseFile and set Parameters
//        }
//        public TransferRecipe()
//        {
//            //use default Parameters 
//        }
//    }
//    class TransferJob
//    {
//        public StringBuilder cLog = new StringBuilder();
//        private static readonly ILog logger = LogManager.GetLogger(typeof(TransferJob));
//        public Boolean isAligner1ＷaitPut = false; // init success (Home completed)
//        public Boolean isAligner1ＷaitGet = false; // wafer release
//        public Boolean isAligner2ＷaitPut = false; // init success (Home completed)
//        public Boolean isAligner2ＷaitGet = false; // wafer release
//        public Boolean isExeFail = false; // wafer release
//        TransferRecipe recipe = new TransferRecipe();
//        Wafer[] targets = new Wafer[25];
//        string[] aligners ;
//        string sourcePort;
//        Boolean isPutWithoutBack;
//        //int preTimeout = 600000;
//        //int postTimeout = 600000;
//        int preTimeout = 60000;
//        int postTimeout = 60000;
//        //string useOCR = 
//        public void doTransfer()
//        {
//            try
//            {
//                string[] aligners = recipe.ROB1_ALIGNER.Split(',');
//                int idx = 0;
//                Wafer wafer1;
//                Wafer wafer2;
//                while (!isExeFail && idx < 25)
//                {
//                    int waferCnt = 0;
//                    TransferState.processCnt = 0;

//                    #region  Step0 => Look for the WAFER to be processed
//                    wafer1 = getNextWafer(targets, idx);
//                    if (wafer1 != null)
//                    {
//                        waferCnt++;
//                        idx = wafer1.Source_Slot;// change index to next new slot
//                        wafer2 = getNextWafer(targets, idx);
//                        if (wafer2 != null)
//                        {
//                            waferCnt++;
//                            idx = wafer2.Source_Slot;// change index to next new slot
//                        }
//                    }
//                    else// No wafer waiting to be processed
//                    {
//                        closePort(sourcePort);// close load port
//                        break;
//                    }
//                    #endregion
//                    #region Step1 => GET From Port
//                    if (wafer2 == null)
//                    {
//                        getFromPort(wafer1, "ARM1");//上臂單取第一片
//                        wafer1.Location = "ARM1";
//                    }
//                    else if (wafer2.Source_Slot == wafer1.Source_Slot + 1 && recipe.ROB1_DOUBLE_ARM.Equals("Y"))
//                    {
//                        getFromPort(wafer2, "ARM3");//雙取, 上臂取第二片, 下臂取第一片
//                        wafer2.Location = "ARM1";
//                        wafer1.Location = "ARM2";
//                    }
//                    else
//                    {
//                        getFromPort(wafer2, "ARM1");//上臂單取第二片
//                        wafer2.Location = "ARM1";
//                        getFromPort(wafer1, "ARM2");//下臂單取第一片
//                        wafer1.Location = "ARM2";
//                    }
//                    #endregion
//                    SpinWait.SpinUntil(() => TransferState.checkRule["R1_GET_OPT0_FIN"] == true, 30000);//確保所有片數已處理完
//                    #region Step2 =>  Put to Align & Process & Get From Aligner

//                    isPutWithoutBack = ((wafer2 == null) || aligners.Length == 1) ? true : false;
//                    System.Threading.WaitCallback callExecAlign = new WaitCallback(execAlign);
//                    if (wafer2 == null) //只有一片
//                    {
//                        putToAligner(wafer1, aligners[0], "ARM1", isPutWithoutBack);
//                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer1);
//                        getFromAligner(wafer1, aligners[0], "ARM1");
//                    }
//                    else if (aligners.Length == 1)// 有兩片, 只有一個 Aligner
//                    {
//                        //wafer 2
//                        putToAligner(wafer2, aligners[0], "ARM1", isPutWithoutBack);
//                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer2);
//                        //SpinWait.SpinUntil(() => TransferState.checkRule["A2_RELEASE_FIN"] == true, 300000);
//                        getFromAligner(wafer2, aligners[0], "ARM1");
//                        //wafer 1
//                        putToAligner(wafer1, aligners[0], "ARM2", isPutWithoutBack);
//                        //SpinWait.SpinUntil(() => TransferState.checkRule["A2_RELEASE_FIN"] == true, 300000);
//                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer1);
//                        getFromAligner(wafer1, aligners[0], "ARM2");
//                    }
//                    else if (aligners.Length == 2)// 有兩片, 有兩個 Aligner
//                    {
//                        //wafer 2
//                        putToAligner(wafer2, aligners[0], "ARM1", false);
//                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer2);
//                        string rule = "R1_PUT_OPT3_FIN";
//                        SpinWait.SpinUntil(() => TransferState.checkRule[rule], preTimeout);// 等待前置條件成立
//                        if (!TransferState.checkRule[rule])
//                        {
//                            cLog.Append("Check: " + rule + " timeout\n");
//                        }
//                        //wafer 1
//                        putToAligner(wafer1, aligners[1], "ARM2", false);
//                        ThreadPool.QueueUserWorkItem(callExecAlign, wafer1);
//                        //wafer 2
//                        getFromAligner(wafer2, aligners[0], "ARM1");
//                        //wafer 1
//                        getFromAligner(wafer1, aligners[1], "ARM2");

//                    }
//                    #endregion
//                    SpinWait.SpinUntil(() => TransferState.processCnt == waferCnt, 3000);//確保所有片數已處理完
//                    if (TransferState.processCnt != waferCnt)
//                    {
//                        cLog.Append(" 等待完成片數 Timeout");
//                        break;//exit while
//                    }
//                    #region Step 3 => Put to port
//                    if (wafer2 == null)
//                    {
//                        putToPort(wafer1, "ARM1");//上臂單取第一片
//                    }
//                    else if (wafer2.Target_Slot == wafer1.Target_Slot + 1 && recipe.ROB1_DOUBLE_ARM.Equals("Y"))
//                    {
//                        putToPort(wafer2, "ARM3");//雙取, 第一片在下臂, 第二片在上臂
//                    }
//                    else
//                    {
//                        putToPort(wafer2, "ARM1");//上臂單放第二片
//                        putToPort(wafer1, "ARM2");//下臂單放第一片
//                    }
//                    #endregion
//                }//end while
//                cLog.Append(" Do Transfer End\n\n\n");
//                //Console.Write(" Do Transfer End");
//                logger.Error("\n\n\n" + cLog.ToString());
//            }
//            catch (Exception e)
//            {
//                logger.Error(e.StackTrace + ":" + e.Message);
//            }
//        }

//        public TransferJob(string sourcePort, string recipeFile)
//        {
//            try
//            {
//                //parse recipe File and set Parameters
//                if (recipeFile != null && !recipeFile.Equals(""))
//                    recipe = new TransferRecipe(recipeFile);
//                targets = getWafers(sourcePort);
//                aligners = recipe.ROB1_ALIGNER.Split(',');
//                this.sourcePort = sourcePort;
//            }
//            catch(Exception e)
//            {
//                logger.Error(e.StackTrace + ":" + e.Message);
//            }
            
//        }

//        private void execAlign(object data)
//        {
//            Wafer wafer = (Wafer) data;
//            string useOCR = recipe.USE_OCR;
//            string methodName = "*** execAlign *** ";
//            //init state
//            string target = wafer.Location; // ALIGNER01 or ALIGNER02
//            string chkPreRule1_1 = target.Equals("ALIGNER01") ? "A1_HOLD_FIN" : "A2_HOLD_FIN";
//            string chkPreRule1_2 = isPutWithoutBack ? "R1_PUT_OPT2_FIN" : "R1_PUT_OPT3_FIN";
//            string chkPostRule1 = target.Equals("ALIGNER01") ? "A1_ALIGN1_FIN" : "A2_ALIGN1_FIN";//1st Align
//            string chkPostRule2 = target.Equals("ALIGNER01") ? "OCR1_READ_FIN" : "OCR2_READ_FIN";
//            string chkPostRule3 = target.Equals("ALIGNER01") ? "A1_HOME_FIN" : "A2_HOME_FIN";
//            string chkPostRule4 = target.Equals("ALIGNER01") ? "A1_ALIGN2_FIN" : "A2_ALIGN2_FIN";//second align
//            string chkPostRule5 = target.Equals("ALIGNER01") ? "A1_RELEASE_FIN" : "A2_RELEASE_FIN";
//            string ocr_name = target.Equals("ALIGNER01") ? "OCR01" : "OCR02";
//            TransferState.checkRule[chkPostRule1] = false;
//            TransferState.checkRule[chkPostRule2] = false;
//            TransferState.checkRule[chkPostRule3] = false;
//            TransferState.checkRule[chkPostRule4] = false;
//            TransferState.checkRule[chkPostRule5] = false;

//            //System.Threading.WaitCallback thread = new WaitCallback(runCommands);
//            //Node aligner = NodeManagement.Get(target);
//            //Node ocr = NodeManagement.Get(ocr_name);
//            string aligner = target;
//            string ocr = ocr_name;
//            CommandJob[] cmds = new CommandJob[5];
//            Transaction[] txn = new Transaction[5];
//            //txn 1 : Aligner Align
//            txn[0] = new Transaction();
//            txn[0].FormName = chkPostRule1.Replace("_FIN","").Replace("_ACK", "");
//            txn[0].Method = Transaction.Command.AlignerType.Align;
//            txn[0].Value = "120"; // kuma hard code
//            cmds[0] = new CommandJob(txn[0], aligner, methodName);
//            cmds[0].setPreCheckRules(new string[] { chkPreRule1_1, chkPreRule1_2 }); // !!! wafer hold & Put 結束後才能 Align
//            cmds[0].setPostCheckRule(chkPostRule1); 
//            //txn 2 : OCR
//            txn[1] = new Transaction();
//            txn[1].FormName = chkPostRule2.Replace("_FIN", "").Replace("_ACK", "");
//            txn[1].Method = Transaction.Command.OCRType.Read; //OCR Read
//            cmds[1] = new CommandJob(txn[1], ocr, methodName);
//            cmds[1].setPostCheckRule(chkPostRule2);
//            //txn 3 : Aligner HOME
//            txn[2] = new Transaction();
//            txn[2].FormName = chkPostRule3.Replace("_FIN", "").Replace("_ACK", "");
//            txn[2].Method = Transaction.Command.AlignerType.AlignerHome; //Aligner Home
//            cmds[2] = new CommandJob(txn[2], aligner, methodName);
//            cmds[2].setPostCheckRule(chkPostRule3);
//            //txn 4 : Aligner Align
//            txn[3] = new Transaction();
//            txn[3].FormName = chkPostRule4.Replace("_FIN", "").Replace("_ACK", "");
//            txn[3].Method = Transaction.Command.AlignerType.Align;
//            txn[3].Value = "23"; // kuma hard code
//            cmds[3] = new CommandJob(txn[3], aligner, methodName);
//            cmds[3].setPostCheckRule(chkPostRule4);
//            //txn 5 : Wafer Release
//            txn[4] = new Transaction();
//            txn[4].FormName = chkPostRule5.Replace("_FIN", "").Replace("_ACK", "");
//            txn[4].Method = Transaction.Command.AlignerType.WaferRelease;
//            cmds[4] = new CommandJob(txn[4], aligner, methodName);
//            cmds[4].setPostCheckRule(chkPostRule5);

//            if (useOCR!= null && useOCR.Trim().Equals("Y"))
//                //ThreadPool.QueueUserWorkItem(thread, cmds);
//                runCommands(cmds);
//            else
//                //ThreadPool.QueueUserWorkItem(thread, new CommandJob[] { cmds[0] , cmds[4] });// Align => Wafer release
//                runCommands(new CommandJob[] { cmds[0], cmds[4] });// Align => Wafer release
//            wafer.Location = target;
//        }

//        private void putToPort(Wafer wafer, string arm)
//        {
//            string methodName = "*** putToPort *** ";
//            if (arm != wafer.Location)
//                return;
//            //System.Threading.WaitCallback thread = new WaitCallback(runCommands);
//            string position = "";
//            if (wafer.Target.StartsWith("P1"))
//                position = "LOADPORT01";
//            else if (wafer.Target.StartsWith("P2"))
//                position = "LOADPORT02";
//            else if (wafer.Target.StartsWith("P3"))
//                position = "LOADPORT03";
//            else if (wafer.Target.StartsWith("P4"))
//                position = "LOADPORT04";
//            else 
//                position = wafer.Target;

//            //Node robot = NodeManagement.Get("ROBOT01");
//            string robot = "ROBOT01";
//            Transaction txn = new Transaction();

//            txn.FormName = "R1_PUT_OPT0";
//            txn.Method = Transaction.Command.RobotType.Put;
//            txn.Position = position;
//            txn.Arm = SanwaUtil.GetArmID(arm);
//            txn.Slot = wafer.Source_Slot.ToString();
//            //txn.Value = "";

//            CommandJob cmd = new CommandJob(txn, robot, methodName);
//            //cmd.preCheckRules = "";
//            cmd.setPostCheckRule("R1_PUT_OPT0_FIN");

//            //ThreadPool.QueueUserWorkItem(thread, new CommandJob[] { cmd });
//            runCommands(new CommandJob[] { cmd });
//            //SpinWait.SpinUntil(() => TransferState.isJobFin, 3000);
//            wafer.Location = wafer.Target;

//        }

        
//        private void putToAligner(Wafer wafer, string target, string arm, Boolean isPutWithoutBack)
//        {
//            //init state
//            TransferState.checkRule["R1_PUT_OPT1_FIN"] = false;//isPutToA1Opt1Fin
//            TransferState.checkRule["R1_PUT_OPT2_FIN"] = false;//isPutToA1Opt2Fin
//            TransferState.checkRule["R1_PUT_OPT3_FIN"] = false;//isPutToA1Opt3Fin
//            TransferState.checkRule["R1_PUT_OPT1_ACK"] = false;//isPutToA1Opt1Fin
//            TransferState.checkRule["R1_PUT_OPT2_ACK"] = false;//isPutToA1Opt2Fin
//            TransferState.checkRule["R1_PUT_OPT3_ACK"] = false;//isPutToA1Opt3Fin
//            switch (target)
//            {
//                case "ALIGNER01":
//                    putToAligner1(wafer, arm, isPutWithoutBack);
//                    break;
//                case "ALIGNER02":
//                    putToAligner2(wafer, arm, isPutWithoutBack);
//                    break;
//            }
//            wafer.Location = target;
//        }

//        private void putToAligner1(Wafer wafer, string arm, Boolean isPutWithoutBack)
//        {
//            string methodName = "*** putToAligner1 *** ";
//            string target = "ALIGNER01";
//            //Node robot = NodeManagement.Get("ROBOT01");
//            string robot = "ROBOT01";
//            //Node aligner = NodeManagement.Get(target);
//            string aligner = target;
//            CommandJob[] cmds = new CommandJob[3];
//            Transaction[] txn = new Transaction[3];
//            //txn 1 : robot put option1
//            txn[0] = new Transaction();
//            txn[0].FormName = "R1_PUT_OPT1";
//            txn[0].Method = Transaction.Command.RobotType.WaitBeforePut;//Put option 1
//            txn[0].Position = target;
//            txn[0].Arm = SanwaUtil.GetArmID(arm);
//            txn[0].Slot = "1";
//            cmds[0] = new CommandJob(txn[0], robot, methodName);
//            cmds[0].setPostCheckRule("R1_PUT_OPT1_FIN");

//            //txn 2 : aligner wafer hold
//            txn[1] = new Transaction();
//            txn[1].FormName = "A1_HOLD";
//            txn[1].Method = Transaction.Command.AlignerType.WaferHold; //Wafer Hold
//            cmds[1] = new CommandJob(txn[1], aligner, methodName);
//            //cmds[1].postCheckRules = ""; // wafer hold 不需要等待

//            //txn 3 : robot continue put : option2 or option3
//            txn[2] = new Transaction();
//            txn[2].FormName = isPutWithoutBack ? "R1_PUT_OPT2" : "R1_PUT_OPT3";
//            //Put option 2 or option 3
//            txn[2].Method = isPutWithoutBack? Transaction.Command.RobotType.PutWithoutBack : Transaction.Command.RobotType.PutBack; 
//            txn[2].Position = target;
//            txn[2].Arm = SanwaUtil.GetArmID(arm);
//            txn[2].Slot = "1";
//            cmds[2] = new CommandJob(txn[2], robot, methodName);
//            //cmds[2].setPostCheckRule(isPutWithoutBack ? "R1_PUT_OPT2_FIN" : "R1_PUT_OPT3_FIN");//也許不用

//            runCommands(cmds);
//            wafer.Location = "ALIGNER01";
//        }

//        private void putToAligner2(Wafer wafer, string arm, Boolean isPutWithoutBack)
//        {
//            string methodName = "*** putToAligner2 *** ";
//            string target = "ALIGNER02";
//            //Node robot = NodeManagement.Get("ROBOT01");
//            //Node aligner = NodeManagement.Get(target);
//            string robot = "ROBOT01";
//            string aligner = target;
//            CommandJob[] cmds = new CommandJob[3];
//            Transaction[] txn = new Transaction[3];
//            //txn 1 : robot put option1
//            txn[0] = new Transaction();
//            txn[0].FormName = "R1_PUT_OPT1";
//            txn[0].Method = Transaction.Command.RobotType.WaitBeforePut;//Put option 1
//            txn[0].Position = target;
//            txn[0].Arm = SanwaUtil.GetArmID(arm);
//            txn[0].Slot = "1";
//            cmds[0] = new CommandJob(txn[0], robot, methodName);
//            cmds[0].setPostCheckRule("R1_PUT_OPT1_FIN");

//            //txn 2 : aligner wafer hold
//            txn[1] = new Transaction();
//            txn[1].FormName = "A2_HOLD";
//            txn[1].Method = Transaction.Command.AlignerType.WaferHold; //Put option 1
//            cmds[1] = new CommandJob(txn[1], aligner, methodName);
//            //cmds[1].postCheckRules = ""; // wafer hold 不需要等待

//            //txn 3 : robot continue put : option2 or option3
//            txn[2] = new Transaction();
//            txn[2].FormName = isPutWithoutBack ? "R1_PUT_OPT2" : "R1_PUT_OPT3";
//            //Put option 2 or option 3
//            txn[2].Method = isPutWithoutBack ? Transaction.Command.RobotType.PutWithoutBack : Transaction.Command.RobotType.PutBack;
//            txn[2].Position = target;
//            txn[2].Arm = SanwaUtil.GetArmID(arm);
//            txn[2].Slot = "1";
//            cmds[2] = new CommandJob(txn[2], robot, methodName);
//            //cmds[2].setPostCheckRule(isPutWithoutBack ? "R1_PUT_OPT2_FIN" : "R1_PUT_OPT3_FIN");//也許不用

//            runCommands(cmds);
//            wafer.Location = "ALIGNER02";
//        }

//        private void getFromAligner(Wafer wafer, string source, string arm)
//        {
//            string methodName = "*** getFromAligner *** ";
//            TransferState.checkRule["R1_GET_OPT0_FIN"] = false;
//            TransferState.checkRule["R1_GET_OPT3_FIN"] = false;
//            string position = source;
//            string robot = "ROBOT01";
//            string aligner = source;
//            if(source.Equals("ALIGNER01"))
//            {
//                TransferState.checkRule["A1_RELEASE_FIN"] = false;
//            }
//            if (source.Equals("ALIGNER02"))
//            {
//                TransferState.checkRule["A2_RELEASE_FIN"] = false;
//            }

//            // Get wait to the aligner
//            Transaction txn0 = new Transaction();
//            txn0.FormName = "R1_GET_WAIT";
//            txn0.Method = Transaction.Command.RobotType.GetWait;
//            txn0.Position = position;
//            txn0.Arm = SanwaUtil.GetArmID(arm);
//            txn0.Slot = "1";
//            CommandJob cmd0 = new CommandJob(txn0, robot, methodName);
//            cmd0.setPostCheckRule("R1_GET_WAIT_FIN");
//            // Get Wafer from aligner
//            Transaction txn1 = new Transaction();
//            txn1.FormName = isPutWithoutBack? "R1_GET_OPT3":"R1_GET_OPT0";
//            txn1.Method = isPutWithoutBack ? Transaction.Command.RobotType.GetAfterWait: Transaction.Command.RobotType.Get; 
//            txn1.Position = position;
//            txn1.Arm = SanwaUtil.GetArmID(arm);
//            txn1.Slot = "1";
//            CommandJob cmd1 = new CommandJob(txn1, robot, methodName);
//            cmd1.setPreCheckRule(source.Equals("ALIGNER01") ? "A1_RELEASE_FIN" : "A2_RELEASE_FIN");
//            cmd1.setPostCheckRule(isPutWithoutBack ? "R1_GET_OPT3_FIN":"R1_GET_OPT0_FIN");
//            // Aligner Home
//            Transaction txn2 = new Transaction();
//            txn2.FormName = source.Equals("ALIGNER01") ? "A1_HOME" : "A2_HOME";
//            txn2.Method = Transaction.Command.AlignerType.AlignerHome;
//            CommandJob cmd2 = new CommandJob(txn2, aligner, methodName);
//            //cmd2.preCheckRules = "";
//            cmd2.setPostCheckRule(source.Equals("ALIGNER01") ? "A1_HOME_FIN" : "A2_HOME_FIN");

//            if(isPutWithoutBack)
//                runCommands(new CommandJob[] { cmd1, cmd2 }); //Arm 在下方等時, 不需要 GET Wait
//            else
//                runCommands(new CommandJob[] { cmd0, cmd1, cmd2 });

//            //SpinWait.SpinUntil(() => TransferState.isJobFin, 3000);
//            wafer.Location = arm;
//            TransferState.processCnt ++;
//        }
//        private void getFromPort(Wafer wafer, string arm)
//        {
//            string methodName = " *** getFromPort *** ";
//            TransferState.checkRule["R1_GET_OPT0_FIN"] = false;
//            string position = "";
//            if (wafer.Location.StartsWith("P1"))
//                position = "LOADPORT01";
//            else if (wafer.Location.StartsWith("P2"))
//                position = "LOADPORT02";
//            else if (wafer.Location.StartsWith("P3"))
//                position = "LOADPORT03";
//            else if (wafer.Location.StartsWith("P4"))
//                position = "LOADPORT04";
//            else
//                position = wafer.Location;
//            string robot = "ROBOT01";
//            Transaction txn = new Transaction();

//            txn.FormName = "R1_GET_OPT0";
//            txn.Method = Transaction.Command.RobotType.Get;
//            txn.Position = position;
//            txn.Arm = SanwaUtil.GetArmID(arm);
//            txn.Slot = wafer.Source_Slot.ToString();
//            CommandJob cmd = new CommandJob(txn, robot, methodName);
//            //cmd.preCheckRules = "";
//            cmd.setPostCheckRule("R1_GET_OPT0_FIN");
//            runCommands(new CommandJob[] { cmd });
//        }

//        private void runCommands(object data)
//        {
//            //TransferState.isJobFin = false;
//            CommandJob[] cmds = (CommandJob[])data;
//            string Message = "";
//            foreach (CommandJob cmd in cmds)
//            {
//                if (cmd.nodeName.StartsWith("OCR"))
//                {
//                    TransferState.setState(cmd.txn.FormName + "_FIN", true); //2018 Add by Steven for Transfer Job check rule
//                    TransferState.setState(cmd.txn.FormName + "_ACK", true); //2018 Add by Steven for Transfer Job check rule
//                    continue;// OCR 先跳過不做
//                }
                    
//                Node node = NodeManagement.Get(cmd.nodeName);
//                Boolean needChkPreRule = (cmd.preCheckRules != null && cmd.preCheckRules.Length > 0) ? true: false;
//                Boolean needChkPostRule = (cmd.postCheckRules != null && cmd.postCheckRules.Length > 0) ? true: false;
//                //pre check
//                if (needChkPreRule)
//                {
//                    foreach(string rule in cmd.preCheckRules)
//                    {
//                        SpinWait.SpinUntil(() => TransferState.checkRule[rule], preTimeout);// 等待前置條件成立
//                        if (!TransferState.checkRule[rule])
//                        {
//                            logger.Error("Check: " + rule + " timeout\n");
//                            cLog.Append("Check: " + rule + " timeout\n");
//                        }
//                    }
//                }
//                cmd.txn.RecipeID = "300MM"; //hard code
//                string msg = cmd.methodName + " Form:" + cmd.txn.FormName + " Method: " + cmd.txn.Method + " Position:" + cmd.txn.Position + " Arm:" + cmd.txn.Arm + " Slot:" + cmd.txn.Slot + " Node:" + cmd.nodeName;
//                cLog.Append(msg + "\n");
//                logger.Error(msg);
//                node.SendCommand(cmd.txn, out Message);
//                //post check
//                if (needChkPostRule)
//                {
//                    foreach (string rule in cmd.postCheckRules)
//                    {
//                        //SpinWait.SpinUntil(() => TransferState.getState(rule).checkRule[rule], postTimeout);// 等待後置條件成立
//                        SpinWait.SpinUntil(() => TransferState.getState(rule), postTimeout);// 等待後置條件成立
//                        if (!TransferState.checkRule[rule])
//                        {
//                            logger.Error("Check: " + rule + " timeout\n");
//                            cLog.Append("Check: " + rule + " timeout\n");
//                        }
//                    }
//                }
//            }
//        }

//        private void closePort(string sourcePort)
//        {
//            cLog.Append("*** closePort ***\n");
//            //kuma 待加指令
//            logger.Info("Close Port" + sourcePort);
//        }

//        private Wafer getNextWafer(Wafer[] targets, int idx)
//        {
//            Wafer result = null;
//            for(int i = idx; i< targets.Length; i++)
//            {
//                if(targets[i]!= null && targets[i].Wafer_state == Wafer.State.WAIT_GET_FROM_PORT)
//                {
//                    return targets[i]; //find wafer
//                }
//            }
//            return result;
//        }

//        public Wafer[] getWafers(string sourcePort)
//        {
//            Wafer[] result = new Wafer[25];
//            string targetPort = "LOADPORT03";
//            //dummy data
//            result[0] = new Wafer(sourcePort , 1, targetPort, 1); //slot1
//            //result[1] = new Wafer(sourcePort , 2, targetPort, 2); //slot2
//            result[2] = new Wafer(sourcePort , 3, targetPort, 3); //slot3
//            result[3] = new Wafer(sourcePort , 4, targetPort, 4); //slot4
//            //result[4] = new Wafer(sourcePort , 5, targetPort, 5); //slot5
//            //result[5] = new Wafer(sourcePort , 6, targetPort, 6); //slot6
//            //result[6] = new Wafer(sourcePort , 7, targetPort, 7); //slot7
//            //result[7] = new Wafer(sourcePort , 8, targetPort, 8); //slot8
//            //result[8] = new Wafer(sourcePort , 9, targetPort, 9); //slot9
//            //result[9] = new Wafer(sourcePort , 10, targetPort, 10); //slot10
//            //result[10] = new Wafer(sourcePort , 11, targetPort, 11); //slot11
//            //result[11] = new Wafer(sourcePort , 12, targetPort, 12); //slot12
//            //result[12] = new Wafer(sourcePort , 13, targetPort, 13); //slot13
//            //result[13] = new Wafer(sourcePort , 14, targetPort, 14); //slot14
//            //result[14] = new Wafer(sourcePort , 15, targetPort, 15); //slot15
//            //result[15] = new Wafer(sourcePort , 16, targetPort, 16); //slot16
//            //result[16] = new Wafer(sourcePort , 17, targetPort, 17); //slot17
//            //result[17] = new Wafer(sourcePort , 18, targetPort, 18); //slot18
//            //result[18] = new Wafer(sourcePort , 19, targetPort, 19); //slot19
//            //result[19] = new Wafer(sourcePort , 20, targetPort, 20); //slot20
//            //result[20] = new Wafer(sourcePort , 21, targetPort, 21); //slot21
//            //result[21] = new Wafer(sourcePort , 22, targetPort, 22); //slot22
//            //result[22] = new Wafer(sourcePort , 23, targetPort, 23); //slot23
//            //result[23] = new Wafer(sourcePort , 24, targetPort, 24); //slot24
//            //result[24] = new Wafer(sourcePort , 25, targetPort, 25); //slot25
//            return result;
//        }
//    }
//}

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
    /// 跨區傳送, 一個Robot 負責取, 一個Robot 負責放
    /// </summary>
    class XfeCrossZone
    {

        private StringBuilder cLog1 = new StringBuilder();
        private static readonly ILog logger = LogManager.GetLogger(typeof(XfeCrossZone));
        private TransferRecipe recipe { get; set; }
        private TransferWafer[] wafers { get; set; }
        private string sourcePort { get; set; }
        private Boolean isExeFail = false;
        private int procTtlWaitCnt { get; set; }
        private int procGetFinCnt { get; set; }
        private int procPutFinCnt { get; set; }
        private Boolean isGetFinish = false;
        private Boolean isPutFinish = false;

        Boolean isPutWithoutBack;
        //int preTimeout = 600000;
        //int postTimeout = 600000;
        int preTimeout = 60000;
        int postTimeout = 60000;
        public XfeCrossZone(string sourcePort, TransferWafer[] wafers, TransferRecipe recipe)
        {
            this.sourcePort = sourcePort;
            this.recipe = recipe;
            this.wafers = wafers;
            this.procTtlWaitCnt = getProcWaitCnt(wafers);
            this.procGetFinCnt = 0;
            this.procPutFinCnt = 0;
        }

        private int getProcWaitCnt(TransferWafer[] wafers)
        {
            int result = 0;
            foreach (TransferWafer wafer in wafers)
            {
                if (wafer != null  && wafer.Target_Slot >=1 && wafer.Target_Slot <= 25)
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// 跨區傳送
        /// </summary>
        /// <param name="getRobot">從 Load port 取片的 Robot</param>
        /// <param name="putRobot">放片到  Load port 的 Robot</param>
        /// <returns></returns>
        public Boolean doTransfer(string getRobot, string putRobot)
        {
            Boolean result = false;
            try
            {
                string[] aligners = recipe.ROB1_ALIGNER.Split(',');
                System.Threading.WaitCallback callProcGetRobot = new WaitCallback(procGetRobot);
                System.Threading.WaitCallback callProcPutRobot = new WaitCallback(procPutRobot);
                System.Threading.WaitCallback callExecAlign1 = new WaitCallback(execAlign1);//aligner 1
                System.Threading.WaitCallback callExecAlign2 = new WaitCallback(execAlign2);//aligner 2
                
                ThreadPool.QueueUserWorkItem(callProcGetRobot, getRobot);
                ThreadPool.QueueUserWorkItem(callProcPutRobot, putRobot);

                SpinWait.SpinUntil(() => isGetFinish && isPutFinish, 86400000);// 等待所有工作都做完(timeout 1 day)
                addLog(" Do Transfer End\n\n\n");
                logger.Error("\n\n\n" + cLog1.ToString());
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace + ":" + e.Message);
            }
            return result;
        }
        private void procGetRobot(object data)
        {
            TransferWafer wafer1;
            TransferWafer wafer2;
            int idx = 0;
            while (!isExeFail && idx < 25)
            {

            }
                //TransferWafer wafer = (TransferWafer)data;
        }
        private void procPutRobot(object data)
        {
            string robot = (string) data;
            TransferWafer wafer1;
            TransferWafer wafer2;
            string[] aligners = recipe.ROB1_ALIGNER.Split(',');
            int idx = 0;
            while (!isExeFail && idx < 25 && procPutFinCnt < procTtlWaitCnt)
            {
                int waferCnt = 0;
                //TransferState.processCnt = 0;

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
                #region Step2 =>  Put to Align & Process & Get From Aligner

                isPutWithoutBack = false; // 跨區不會有 Put robot 在下面等的 Case , 所以給 false
                if (wafer2 == null) //只有一片
                {
                    getFromAligner(wafer1, aligners[0], "ARM1", robot);
                }
                else if (aligners.Length == 1)// 有兩片, 只有一個 Aligner
                {
                    getFromAligner(wafer2, aligners[0], "ARM1", robot);
                    getFromAligner(wafer1, aligners[0], "ARM2", robot);
                }
                else if (aligners.Length == 2)// 有兩片, 有兩個 Aligner
                {
                    //wafer 2
                    getFromAligner(wafer2, aligners[0], "ARM1", robot);
                    //wafer 1
                    getFromAligner(wafer1, aligners[1], "ARM2", robot);
                }
                #endregion
                SpinWait.SpinUntil(() => TransferState.processCntR1 == waferCnt, 86400000);//確保所有片數已處理完 timeout: 1 days
                if (TransferState.processCntR1 != waferCnt)
                {
                    addLog(" 等待完成片數 Timeout");
                    break;//exit while
                }
                #region Step 3 => Put to port
                if (wafer2 == null)
                {
                    checkAlignerHome(aligners);
                    putToPort(wafer1, "ARM1", robot);//上臂單放第一片
                }
                else if ( wafer2.Target == wafer1.Target && wafer2.Target_Slot == wafer1.Target_Slot + 1 && recipe.ROB1_DOUBLE_ARM.Equals("Y") )
                {
                    checkAlignerHome(aligners);
                    putToPort(wafer2, "ARM3", robot);//雙放, 第一片在下臂, 第二片在上臂
                }
                else
                {
                    checkAlignerHome(aligners);
                    putToPort(wafer2, "ARM1", robot);//上臂單放第二片
                    putToPort(wafer1, "ARM2", robot);//下臂單放第一片
                }
                #endregion
            }//end while

            //TransferWafer wafer = (TransferWafer)data;
        }
        private void execAlign1(object data)
        {
            //TransferWafer wafer = (TransferWafer)data;
        }
        private void execAlign2(object data)
        {
            //TransferWafer wafer = (TransferWafer)data;
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

        private void closePort(string sourcePort)
        {
            addLog("*** closePort " + sourcePort +" ***\n" );
            Node port = NodeManagement.Get(sourcePort);
            Transaction txn = new Transaction();
            txn.Method = Transaction.Command.LoadPortType.Unload;
            //port.SendCommand(txn); // 暫時不執行 kuma
        }

        private void getFromAligner(TransferWafer wafer, string aligner, string arm, string robot)
        {
            string methodName = "*** getFromAligner *** ";
            string preCheckRule1 = aligner.Equals("ALIGNER01") ? "A1_RELEASE_FIN" : "A2_RELEASE_FIN";
            string position = aligner;
            string preRobot = "";
            string tagAligner = "";
            if (robot.Equals("ROBOT01"))
            {
                preRobot = "R1";
            }else if (robot.Equals("ROBOT02"))
            {
                preRobot = "R2";
            }
            else
            {
                return;//do nothing
            }
            if (aligner.Equals("ALIGNER01"))
            {
                tagAligner = "A1";
            }
            else if (aligner.Equals("ALIGNER02"))
            {
                tagAligner = "A2";
            }
            else
            {
                return;//do nothing
            }
            TransferState.checkRule[ preRobot + "_GET_WAIT_" + + "_FIN"] = false;
            TransferState.checkRule[ preRobot + "_GET_OPT0_FIN"] = false;
            TransferState.checkRule[ preRobot + "_GET_OPT3_FIN"] = false;
            TransferState.checkRule[ tagAligner + "_HOME_FIN"] = false;
            string[] preCheckRules = isPutWithoutBack ? new string[] { preRobot + "_PUT_OPT2_FIN", preCheckRule1 } : new string[] { preRobot + "_GET_WAIT_FIN", preCheckRule1 };

            // Get wait to the aligner
            Transaction txn1 = new Transaction();
            txn1.FormName = preRobot + "_GET_WAIT";
            txn1.Method = Transaction.Command.RobotType.GetWait;
            txn1.Position = position;
            txn1.Arm = SanwaUtil.GetArmID(arm);
            txn1.Slot = "1";
            CommandJob cmd1 = new CommandJob(txn1, robot, methodName);
            cmd1.setPostCheckRule(preRobot + "_GET_WAIT_FIN");

            // Get Wafer from aligner
            Transaction txn2 = new Transaction();
            txn2.FormName = preRobot + "_GET_OPT1";
            txn2.Method = isPutWithoutBack ? Transaction.Command.RobotType.GetAfterWait : Transaction.Command.RobotType.Get;
            txn2.Position = position;
            txn2.Arm = SanwaUtil.GetArmID(arm);
            txn2.Slot = "1";
            CommandJob cmd2 = new CommandJob(txn2, robot, methodName);
            cmd2.setPreCheckRules(preCheckRules);
            cmd2.setPostCheckRule(txn2.FormName + "_FIN");

            // Get Wafer from aligner
            Transaction txn3 = new Transaction();
            txn3.FormName = isPutWithoutBack ? preRobot + "_GET_OPT3" : preRobot + "_GET_OPT0";
            txn3.Method = isPutWithoutBack ? Transaction.Command.RobotType.GetAfterWait : Transaction.Command.RobotType.Get;
            txn3.Position = position;
            txn3.Arm = SanwaUtil.GetArmID(arm);
            txn3.Slot = "1";
            CommandJob cmd3 = new CommandJob(txn3, robot, methodName);
            cmd3.setPreCheckRules(preCheckRules);
            cmd3.setPostCheckRule(isPutWithoutBack ? preRobot + "_GET_OPT3_FIN" : preRobot + "_GET_OPT0_FIN");

            // Aligner Home
            Transaction txn4 = new Transaction();
            txn4.FormName = tagAligner + "_HOME";//A1_HOME or A2_HOME
            txn4.Method = Transaction.Command.AlignerType.AlignerHome;
            CommandJob cmd4 = new CommandJob(txn4, aligner, methodName);
            //cmd2.preCheckRules = "";
            cmd4.setPostCheckRule(tagAligner + "_HOME_FIN");//A1_HOME_FIN or A2_HOME_FIN

            runCommands(new CommandJob[] { cmd1, cmd3, cmd4 });

            //SpinWait.SpinUntil(() => TransferState.isJobFin, 3000);
            wafer.Location = arm;
            TransferState.addProcCnt(robot);
        }

        private void putToPort(TransferWafer wafer, string arm, string robot)
        {
            TransferState.checkRule["R1_PUT_OPT0_FIN"] = false;
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

            Transaction txn = new Transaction();

            txn.FormName = "R1_PUT_OPT0";
            txn.Method = Transaction.Command.RobotType.Put;
            txn.Position = position;
            txn.Arm = SanwaUtil.GetArmID(arm);
            txn.Slot = wafer.Source_Slot.ToString();
            //txn.Value = "";

            CommandJob cmd = new CommandJob(txn, robot, methodName);
            cmd.setPostCheckRule("R1_PUT_OPT0_FIN");

            runCommands(new CommandJob[] { cmd });
            wafer.Location = wafer.Target;

        }

        private void addLog(string msg)
        {
            //return;
            logger.Error(msg);
            cLog1.Append(msg);
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
                        SpinWait.SpinUntil(() => TransferState.checkRule[rule], preTimeout);// 等待前置條件成立
                        if (!TransferState.checkRule[rule])
                        {
                            addLog("Check: " + rule + " timeout\n");
                        }
                    }
                }
                cmd.txn.RecipeID = "300MM"; //hard code
                string msg = cmd.methodName + " Form:" + cmd.txn.FormName + " Method: " + cmd.txn.Method + " Position:" + cmd.txn.Position + " Arm:" + cmd.txn.Arm + " Slot:" + cmd.txn.Slot + " Node:" + cmd.nodeName;
                addLog(msg + "\n");
                logger.Error(msg);
                node.SendCommand(cmd.txn);
                //post check
                if (needChkPostRule)
                {
                    foreach (string rule in cmd.postCheckRules)
                    {
                        //SpinWait.SpinUntil(() => TransferState.getState(rule).checkRule[rule], postTimeout);// 等待後置條件成立
                        SpinWait.SpinUntil(() => TransferState.getState(rule), postTimeout);// 等待後置條件成立
                        if (!TransferState.checkRule[rule])
                        {
                            addLog("Check: " + rule + " timeout\n");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 確保所有Aligner 都回 HOME
        /// </summary>
        /// <param name="aligners"></param>
        /// <returns></returns>
        private Boolean checkAlignerHome(string[] aligners)
        {
            foreach (string aligner in aligners)
            {
                string rule = "";
                if (aligner.Equals("ALIGNER01"))
                {
                    rule = "A1_HOME_FIN";
                }
                else if (aligner.Equals("ALIGNER02"))
                {
                    rule = "A2_HOME_FIN";
                }
                else
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

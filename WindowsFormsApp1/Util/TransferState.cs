﻿//using log4net;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Adam.Util
//{
//    class TransferState
//    {
//        private static readonly ILog logger = LogManager.GetLogger(typeof(TransferJob));
//        public static int processCntR1 { get; set; } = 0;
//        public static int processCntR2 { get; set; } = 0;
//        public static Boolean isCmdFin = true;
//        public static Boolean isR1JobFin = false;
//        public static Boolean isR2JobFin = false;
//        public static Boolean isA1JobFin = false;
//        public static Boolean isA2JobFin = false;
//        public static Boolean getState(string rule)
//        {
//            Boolean result = false;
//            try
//            {
//                //          {"OCR1_READ_FIN", false},
//                //          {"OCR2_READ_FIN", false},
//            }
//            catch (Exception)
//            {
//                result = false;
//                logger.Error("TransferState get rule:" + rule + " fail!!");
//            }
//            return result;
//        }
//        public static void setState(string rule, Boolean state)
//        {
//            try
//            {
//                if(checkRule.ContainsKey(rule))
//                    checkRule[rule] = state;
//                logger.Error("TransferState set rule:" + rule + " Success!!");
//            }
//            catch (Exception)
//            {
//                logger.Error("TransferState set rule:" + rule + " fail!!"); 
//            }
//        }
//        public static void addProcCnt(string robot)
//        {
//            if (robot.Equals("ROBOT1"))
//                processCntR1++;
//            else if (robot.Equals("ROBOT2"))
//                processCntR2++;
//    } 
//        public static Dictionary<string, Boolean> checkRule = new Dictionary<string, Boolean>()
//        {
//          {"A1_ALIGN1_FIN", false},
//          {"A1_ALIGN2_FIN", false},
//          {"A2_ALIGN1_FIN", false},
//          {"A2_ALIGN2_FIN", false},
//          {"A1_HOME_FIN", false},
//          {"A2_HOME_FIN", false},
//          {"A1_HOLD_FIN", false},
//          {"A2_HOLD_FIN", false},
//          {"A1_RELEASE_FIN", false},
//          {"A2_RELEASE_FIN", false},

//          {"OCR1_READ_FIN", false},
//          {"OCR2_READ_FIN", false},

//          {"R1_PUT_OPT0_A1_ACK", false},
//          {"R1_PUT_OPT1_A1_ACK", false},
//          {"R1_PUT_OPT2_A1_ACK", false},
//          {"R1_PUT_OPT3_A1_ACK", false},
//          {"R1_GET_OPT0_A1_ACK", false},
//          {"R1_GET_OPT1_A1_ACK", false},
//          {"R1_GET_OPT2_A1_ACK", false},
//          {"R1_GET_OPT3_A1_ACK", false},
//          {"R1_GET_WAIT_A1_ACK", false},
//          {"R1_PUT_OPT0_A1_FIN", false},
//          {"R1_PUT_OPT1_A1_FIN", false},
//          {"R1_PUT_OPT2_A1_FIN", false},
//          {"R1_PUT_OPT3_A1_FIN", false},
//          {"R1_GET_OPT0_A1_FIN", false},
//          {"R1_GET_OPT1_A1_FIN", false},
//          {"R1_GET_OPT2_A1_FIN", false},
//          {"R1_GET_OPT3_A1_FIN", false},
//          {"R1_GET_WAIT_A1_FIN", false},

//          {"R1_PUT_OPT0_A2_ACK", false},
//          {"R1_PUT_OPT1_A2_ACK", false},
//          {"R1_PUT_OPT2_A2_ACK", false},
//          {"R1_PUT_OPT3_A2_ACK", false},
//          {"R1_GET_OPT0_A2_ACK", false},
//          {"R1_GET_OPT1_A2_ACK", false},
//          {"R1_GET_OPT2_A2_ACK", false},
//          {"R1_GET_OPT3_A2_ACK", false},
//          {"R1_GET_WAIT_A2_ACK", false},
//          {"R1_PUT_OPT0_A2_FIN", false},
//          {"R1_PUT_OPT1_A2_FIN", false},
//          {"R1_PUT_OPT2_A2_FIN", false},
//          {"R1_PUT_OPT3_A2_FIN", false},
//          {"R1_GET_OPT0_A2_FIN", false},
//          {"R1_GET_OPT1_A2_FIN", false},
//          {"R1_GET_OPT2_A2_FIN", false},
//          {"R1_GET_OPT3_A2_FIN", false},
//          {"R1_GET_WAIT_A2_FIN", false},

//          {"R1_GET_OPT0_PORT_ACK", false},
//          {"R1_PUT_OPT0_PORT_ACK", false},
//          {"R1_GET_OPT0_PORT_FIN", false},
//          {"R1_PUT_OPT0_PORT_FIN", false},

//          {"R2_PUT_OPT0_A1_ACK", false},
//          {"R2_PUT_OPT1_A1_ACK", false},
//          {"R2_PUT_OPT2_A1_ACK", false},
//          {"R2_PUT_OPT3_A1_ACK", false},
//          {"R2_GET_OPT0_A1_ACK", false},
//          {"R2_GET_OPT1_A1_ACK", false},
//          {"R2_GET_OPT2_A1_ACK", false},
//          {"R2_GET_OPT3_A1_ACK", false},
//          {"R2_GET_WAIT_A1_ACK", false},
//          {"R2_PUT_OPT0_A1_FIN", false},
//          {"R2_PUT_OPT1_A1_FIN", false},
//          {"R2_PUT_OPT2_A1_FIN", false},
//          {"R2_PUT_OPT3_A1_FIN", false},
//          {"R2_GET_OPT0_A1_FIN", false},
//          {"R2_GET_OPT1_A1_FIN", false},
//          {"R2_GET_OPT2_A1_FIN", false},
//          {"R2_GET_OPT3_A1_FIN", false},
//          {"R2_GET_WAIT_A1_FIN", false},

//          {"R2_PUT_OPT0_A2_ACK", false},
//          {"R2_PUT_OPT1_A2_ACK", false},
//          {"R2_PUT_OPT2_A2_ACK", false},
//          {"R2_PUT_OPT3_A2_ACK", false},
//          {"R2_GET_OPT0_A2_ACK", false},
//          {"R2_GET_OPT1_A2_ACK", false},
//          {"R2_GET_OPT2_A2_ACK", false},
//          {"R2_GET_OPT3_A2_ACK", false},
//          {"R2_GET_WAIT_A2_ACK", false},
//          {"R2_PUT_OPT0_A2_FIN", false},
//          {"R2_PUT_OPT1_A2_FIN", false},
//          {"R2_PUT_OPT2_A2_FIN", false},
//          {"R2_PUT_OPT3_A2_FIN", false},
//          {"R2_GET_OPT0_A2_FIN", false},
//          {"R2_GET_OPT1_A2_FIN", false},
//          {"R2_GET_OPT2_A2_FIN", false},
//          {"R2_GET_OPT3_A2_FIN", false},
//          {"R2_GET_WAIT_A2_FIN", false},

//          {"R2_GET_OPT0_ACK", false},
//          {"R2_PUT_OPT0_ACK", false},
//          {"R2_GET_OPT0_FIN", false},
//          {"R2_PUT_OPT0_FIN", false}
//        };        
//    }
//}

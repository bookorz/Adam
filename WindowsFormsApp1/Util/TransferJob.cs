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

    class CommandJob
    {
        public Node node { get; set; }
        public string nodeName { get; set; }
        public string methodName { get; set; }
        public Transaction txn { get; set; }
        public string[] preCheckRules { get; set; }
        public string[] postCheckRules { get; set; }

        public CommandJob(Transaction txn, string nodeName, string methodName)
        {
            this.nodeName = nodeName;
            this.txn = txn;
            this.methodName = methodName;
        }
        public void setPreCheckRule(string rule)
        {
            preCheckRules = new string[] { rule};
        }
        public void setPreCheckRules(string[] rules)
        {
            preCheckRules = rules;
        }
        public void setPostCheckRule(string rule)
        {
            postCheckRules = new string[] { rule };
        }
        public void setPostCheckRules(string[] rules)
        {
            postCheckRules = rules;
        }
    }
    class TransferWafer
    {
        public string Location { get; set; } = "";
        public string Source { get; set; } = "";
        public string Target { get; set; } = "";
        public string Wafer_id { get; set; } = "";
        public int Source_Slot { get; set; }
        public int Target_Slot { get; set; }
        public TransferWafer(string source, int source_slot, string target, int target_slot)
        {
            this.Location = source;//目前位置
            this.Source = source;//來源位置
            this.Source_Slot = source_slot;//來源 Slot
            if (target!= null && !target.Trim().Equals(""))
            {
                this.Target = target;//目標位置
                this.Target_Slot = target_slot;//目標 Slot
            }
            else
            {
                this.Target = null;
            }

        }
    }
    class TransferRecipe
    {
        public string ROB1_DOUBLE_ARM { get; set; } = "Y";
        public string ROB2_DOUBLE_ARM { get; set; } = "Y";
        public string ROB1_ALIGNER { get; set; } = "ALIGNER02,ALIGNER01";
        //public string ROB2_ALIGNER { get; set; } = "ALIGNER01,ALIGNER02";
        //public string ROB1_ALIGNER { get; set; } = "ALIGNER02";
        public string ROB2_ALIGNER { get; set; } = "ALIGNER02";
        public string USE_OCR { get; set; } = "Y";
        public TransferRecipe(string fileName)
        {
            //parseFile and set Parameters
        }
        public TransferRecipe()
        {
            //use default Parameters 
        }
    }
    class TransferJob
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(TransferJob));
        //public Boolean isAligner1ＷaitPut = false; // init success (Home completed)
        //public Boolean isAligner1ＷaitGet = false; // wafer release
        //public Boolean isAligner2ＷaitPut = false; // init success (Home completed)
        //public Boolean isAligner2ＷaitGet = false; // wafer release
        
        TransferRecipe recipe = new TransferRecipe();
        TransferWafer[] wafers = new TransferWafer[25];
        string[] aligners ;
        string sourcePort;
        public void doTransfer()
        {
            try
            {
                XfeSingleZone job = new XfeSingleZone(sourcePort, wafers, recipe);
                job.doTransfer();
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace + ":" + e.Message);
            }
        }

        public TransferJob(string sourcePort, string recipeFile)
        {
            try
            {
                //parse recipe File and set Parameters
                if (recipeFile != null && !recipeFile.Equals(""))
                    recipe = new TransferRecipe(recipeFile);
                wafers = getWafers(sourcePort);
                aligners = recipe.ROB1_ALIGNER.Split(',');
                this.sourcePort = sourcePort;
            }
            catch(Exception e)
            {
                logger.Error(e.StackTrace + ":" + e.Message);
            }
            
        }

        public TransferWafer[] getWafers(string sourcePort)
        {
            TransferWafer[] result = new TransferWafer[25];
            string targetPort1 = "LOADPORT03";
            string targetPort2 = "LOADPORT04";
            //dummy data
            //result[0] = new TransferWafer(sourcePort , 1, targetPort1, 1); //slot1
            //result[1] = new TransferWafer(sourcePort , 2, targetPort2, 2); //slot2
            //result[2] = new TransferWafer(sourcePort , 3, targetPort1, 3); //slot3
            //result[3] = new TransferWafer(sourcePort, 4, targetPort2, 4); //slot4
            //result[4] = new TransferWafer(sourcePort, 5, targetPort1, 5); //slot5
            //result[5] = new TransferWafer(sourcePort, 6, targetPort2, 6); //slot6
            //result[6] = new TransferWafer(sourcePort, 7, targetPort1, 7); //slot7
            //result[7] = new TransferWafer(sourcePort, 8, targetPort2, 8); //slot8
            //result[8] = new TransferWafer(sourcePort, 9, targetPort1, 9); //slot9
            result[9] = new TransferWafer(sourcePort, 10, targetPort1, 10); //slot10
            result[10] = new TransferWafer(sourcePort, 11, targetPort1, 11); //slot11
            result[11] = new TransferWafer(sourcePort, 12, targetPort1, 12); //slot12
            result[12] = new TransferWafer(sourcePort, 13, targetPort1, 13); //slot13
            result[13] = new TransferWafer(sourcePort, 14, targetPort1, 14); //slot14
            //result[14] = new TransferWafer(sourcePort, 15, targetPort1, 15); //slot15
            //result[15] = new TransferWafer(sourcePort, 16, targetPort1, 16); //slot16
            //result[16] = new TransferWafer(sourcePort, 17, targetPort1, 17); //slot17
            //result[17] = new TransferWafer(sourcePort, 18, targetPort1, 18); //slot18
            //result[18] = new TransferWafer(sourcePort, 19, targetPort1, 19); //slot19
            //result[19] = new TransferWafer(sourcePort, 20, targetPort1, 20); //slot20
            //result[20] = new TransferWafer(sourcePort, 21, targetPort1, 21); //slot21
            //result[21] = new TransferWafer(sourcePort, 22, targetPort1, 22); //slot22
            //result[22] = new TransferWafer(sourcePort, 23, targetPort1, 23); //slot23
            //result[23] = new TransferWafer(sourcePort, 24, targetPort1, 24); //slot24
            //result[24] = new TransferWafer(sourcePort, 25, targetPort1, 25); //slot25
            return result;
        }
    }
}

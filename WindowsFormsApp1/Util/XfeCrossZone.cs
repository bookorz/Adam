using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransferControl.Engine;
using TransferControl.Management;


namespace Adam.Util
{
    public class XfeCrossZone
    {
        private static ILog logger = LogManager.GetLogger(typeof(XfeCrossZone));
        public static bool Running = false;
        public static bool IsInitialize = false;
        public static string LDRobot = "";
        public static string LDRobot_Arm = "";
        public static string ULDRobot = "";
        public static string ULDRobot_Arm = "";
        public static string LD = "";
        public static string ULD = "";

        private static void Initialize()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Engine), "ROBOT01");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Engine), "ROBOT02");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Engine), "ALIGNER01");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Engine), "ALIGNER02");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Engine), "OCR01");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Engine), "OCR02");
        }

        public static bool Start()
        {

            if (!IsInitialize)
            {
                Initialize();
                IsInitialize = true;
            }

            //開始前先重設
            foreach (Node each in NodeManagement.GetList())
            {
                each.RequestQueue.Clear();
                each.LockOn = "";
            }
     LDRobot = "";
LDRobot_Arm = "";
 ULDRobot = "";
       ULDRobot_Arm = "";
     LD = "";
ULD = "";
        //找到LD & ULD
        Node LROB = null;
            if ((LROB = FindAvailableLoadport("ROBOT01")) != null)
            {
                LDRobot = "ROBOT01";
                ULDRobot = "ROBOT02";
                Node.ActionRequest request = new Node.ActionRequest();
                request.TaskName = "GET_LOADPORT";
                if (!LROB.RequestQueue.ContainsKey(request.TaskName))
                {
                    LROB.RequestQueue.Add(request.TaskName, request);
                }
                Running = true;
            }
            else if ((LROB = FindAvailableLoadport("ROBOT01")) != null)
            {
                LDRobot = "ROBOT02";
                ULDRobot = "ROBOT01";
                Node.ActionRequest request = new Node.ActionRequest();
                request.TaskName = "GET_LOADPORT";
                if (!LROB.RequestQueue.ContainsKey(request.TaskName))
                {
                    LROB.RequestQueue.Add(request.TaskName, request);
                }
                Running = true;
            }
            else
            {
                Running = false;
            }
            return Running;
        }

        public static void Stop()
        {
            Running = false;
        }


        private static void Engine(object NodeName)
        {
            try
            {
                Node Target = NodeManagement.Get(NodeName.ToString());

                while (true)
                {
                    while (Target.RequestQueue.Count() == 0 && Running)
                    {
                        SpinWait.SpinUntil(() => Target.RequestQueue.Count() != 0 || !Running, 99999999);
                    }
                    if (Running)
                    {
                        string Message = "";
                        string id = Guid.NewGuid().ToString();
                        List<Node.ActionRequest> RequestQueue = Target.RequestQueue.Values.ToList();
                        if (!Target.LockOn.Equals(""))
                        {//當ROBOT正在存取某個，必須收回手臂才能對另一台動作
                            logger.Debug(NodeName + " LockOn:" + Target.LockOn);
                            var find = from Request in RequestQueue
                                       where Request.Position.Equals(Target.LockOn)
                                       select Request;
                            RequestQueue = find.ToList();
                        }

                        RequestQueue.Sort((x, y) => { return x.TimeStamp.CompareTo(y.TimeStamp); });
                        Node.ActionRequest req = RequestQueue.First();
                        Target.RequestQueue.Remove(req.TaskName);
                        logger.Debug(NodeName + " 開始執行:" + req.TaskName);
                        Node nodeLD;
                       
                        switch (Target.Type)
                        {
                            case "ROBOT":
                                switch (req.TaskName)
                                {
                                    case "GET_LOADPORT":
                                        //從Loadport取片要求，需要決定Position Slot Arm
                                        //等待有Loadport準備完成

                                        if (Target.JobList.Count == 2)
                                        {
                                            req.TaskName = "PUT_ALIGNER";
                                            continue;
                                        }
                                        else
                                        {
                                            //logger.Debug(NodeName + " 等待可用Loadport");
                                            //while (FindAvailableLoadport(Target.Name) == null && Running)
                                            //{
                                            //    SpinWait.SpinUntil(() => FindAvailableLoadport(Target.Name) != null || !Running, 99999999);
                                            //}
                                            //if (!Running)
                                            //{
                                            //    logger.Debug(NodeName + " 運作停止");
                                            //    continue;
                                            //}
                                            logger.Debug(NodeName + " 找到可用Loadport");
                                            nodeLD = FindAvailableLoadport(Target.Name);
                                            Target.LockOn = nodeLD.Name;//鎖定PORT
                                            req.Position = nodeLD.Name;

                                            var AvailableSlots = from eachSlot in nodeLD.JobList.Values.ToList()
                                                                 where eachSlot.ProcessFlag
                                                                 select eachSlot;
                                            if (AvailableSlots.Count() != 0)
                                            {
                                                List<Job> AvailableSlotsList = AvailableSlots.ToList();
                                                AvailableSlotsList.Sort((x, y) => { return x.Slot.CompareTo(y.Slot); });
                                                Job j;
                                                if (AvailableSlotsList.Count == 1)//Port剩下一片
                                                {
                                                    j = AvailableSlotsList.First();
                                                    req.Slot = j.Slot;
                                                    if (!Target.JobList.ContainsKey("1") && Target.RArmActive)//R沒片且R為可用狀態
                                                    {
                                                        req.Arm = "1";
                                                    }
                                                    else if (!Target.JobList.ContainsKey("2") && Target.LArmActive)//L沒片且L為可用狀態
                                                    {
                                                        req.Arm = "2";
                                                    }
                                                    else
                                                    {
                                                        //無法再取片
                                                        if (Target.JobList.Count() != 0)
                                                        {//開始放片至Aligner
                                                            Node.ActionRequest request = new Node.ActionRequest();

                                                            foreach (Job wafer in Target.JobList.Values)
                                                            {
                                                                foreach (Node Aligner in NodeManagement.GetAlignerList())
                                                                {
                                                                    if (Aligner.JobList.Count == 0)
                                                                    {
                                                                        //佇列裡面沒有才加
                                                                        request.TaskName = "PUT_" + Aligner.Name;
                                                                        //request.Arm = wafer.Slot;
                                                                        if (!Target.RequestQueue.ContainsKey(request.TaskName))
                                                                        {
                                                                            Target.RequestQueue.Add(request.TaskName, request);
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                            Target.LockOn = "";//解除鎖定
                                                            continue;

                                                        }
                                                    }
                                                }
                                                else//Port 有兩片以上
                                                {
                                                    bool AllowDoubleArm = false;
                                                    if (Convert.ToInt32(AvailableSlotsList[1].Slot) - Convert.ToInt32(AvailableSlotsList[0].Slot) == 1)
                                                    {
                                                        AllowDoubleArm = true;//連續Slot才能雙取
                                                    }

                                                    if (!Target.JobList.ContainsKey("1") && !Target.JobList.ContainsKey("2") && nodeLD.DoubleArmActive && nodeLD.RArmActive && nodeLD.LArmActive && AllowDoubleArm)//當可以雙取
                                                    {//RL全為空 & RL都可用 & 雙取啟動 & 兩片為連續Slot
                                                        //雙取要用第二片的Slot
                                                        req.Slot = AvailableSlotsList[1].Slot;
                                                        req.Slot2 = AvailableSlotsList[0].Slot;
                                                        req.TaskName = "GET_LOADPORT_2ARM";
                                                    }
                                                    else//只能單取
                                                    {
                                                        j = AvailableSlotsList.First();
                                                        req.Slot = j.Slot;
                                                        if (!Target.JobList.ContainsKey("1") && Target.RArmActive)//R沒片且R為可用狀態
                                                        {
                                                            req.Arm = "1";
                                                        }
                                                        else if (!Target.JobList.ContainsKey("2") && Target.LArmActive)//L沒片且L為可用狀態
                                                        {
                                                            req.Arm = "2";
                                                        }
                                                        else
                                                        {
                                                            //無法再取片
                                                            if (Target.JobList.Count() != 0)
                                                            {//開始放片至Aligner
                                                                Node.ActionRequest request = new Node.ActionRequest();

                                                                foreach (Job wafer in Target.JobList.Values)
                                                                {
                                                                    foreach (Node Aligner in NodeManagement.GetAlignerList())
                                                                    {
                                                                        if (Aligner.JobList.Count == 0)
                                                                        {
                                                                            //佇列裡面沒有才加
                                                                            request.TaskName = "PUT_" + Aligner.Name;
                                                                            //request.Arm = wafer.Slot;
                                                                            if (!Target.RequestQueue.ContainsKey(request.TaskName))
                                                                            {
                                                                                Target.RequestQueue.Add(request.TaskName, request);
                                                                            }
                                                                        }
                                                                    }
                                                                }

                                                                Target.LockOn = "";//解除鎖定
                                                                continue;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                logger.Debug(NodeName + " Loadport沒有片可處理");
                                                nodeLD.Fetchable = false;
                                            }
                                        }
                                        break;
                                    case "PUT_ALIGNER01":
                                    case "PUT_ALIGNER02":
                                    case "PUTW_ALIGNER01":
                                    case "PUTW_ALIGNER02":
                                        //決定要放R或L
                                        if (LDRobot_Arm.Equals(""))
                                        {
                                            foreach (Job wafer in Target.JobList.Values)
                                            {
                                                LDRobot_Arm = wafer.Slot;

                                                break;
                                            }
                                        }
                                        req.Arm = LDRobot_Arm;
                                        break;
                                    case "GET_ALIGNER01":
                                    case "GET_ALIGNER02":
                                    case "GETW_ALIGNER01":
                                    case "GETW_ALIGNER02":
                                        //決定要用R或L取
                                        if (ULDRobot_Arm.Equals(""))
                                        {
                                            if (!Target.JobList.ContainsKey("1") && Target.RArmActive)//R沒片且R為可用狀態
                                            {
                                                ULDRobot_Arm = "1";
                                            }
                                            else if (!Target.JobList.ContainsKey("2") && Target.LArmActive)//L沒片且L為可用狀態
                                            {
                                                ULDRobot_Arm = "2";
                                            }
                                        }
                                        req.Arm = ULDRobot_Arm;
                                        break;
                                    case "PUT_UNLOADPORT":
                                        //檢查目前狀態是否要去放
                                        
                                        Node nodeLDRobot = NodeManagement.Get(LDRobot);
                                        if (Target.JobList.Count != 2 && nodeLDRobot.JobList.Count!=0)
                                        {
                                            //還有片要處裡
                                            Target.LockOn = "";
                                            continue;
                                        }
                                        if (!Target.DoubleArmActive && Target.JobList.Count==2)
                                        {//支援雙放
                                            if(Target.JobList["1"].Destination.Equals(Target.JobList["2"].Destination) && Convert.ToInt32(Target.JobList["1"].DestinationSlot)- Convert.ToInt32(Target.JobList["2"].DestinationSlot) == 1)
                                            {//目的地Slot連續且順序正確
                                             //雙放要用R的Slot
                                                req.Arm = "3";
                                                req.Slot = Target.JobList["1"].DestinationSlot;
                                                req.Slot2 = Target.JobList["2"].DestinationSlot;
                                                req.TaskName = "PUT_UNLOADPORT_2ARM";
                                            }
                                            else
                                            {//目的地不同 OR Slot不連續，只能單放
                                                //先前置放R手臂
                                                req.Position = Target.JobList["1"].Destination;
                                                req.Arm = "1";
                                                req.Slot = Target.JobList["1"].DestinationSlot;
                                            }
                                        }
                                        else
                                        {//只能單放
                                            if (Target.JobList.ContainsKey("1"))
                                            {//放R
                                                req.Position = Target.JobList["1"].Destination;
                                                req.Arm = "1";
                                                req.Slot = Target.JobList["1"].DestinationSlot;
                                            }
                                            else if(Target.JobList.ContainsKey("2"))
                                            {//放L
                                                req.Position = Target.JobList["2"].Destination;
                                                req.Arm = "2";
                                                req.Slot = Target.JobList["2"].DestinationSlot;
                                            }
                                            else
                                            {//沒東西放了
                                                Target.LockOn = "";
                                                continue;
                                            }

                                        }
                                        Target.LockOn = req.Position;
                                        break;
                                }
                                break;
                            case "ALIGNER":

                                break;
                            case "OCR":

                                break;
                        }
                        Dictionary<string, string> param = new Dictionary<string, string>();

                        param.Add("@Target", NodeName.ToString());
                        param.Add("@Slot", req.Slot);
                        param.Add("@Slot2", req.Slot2);
                        param.Add("@Arm", req.Arm);
                        param.Add("@Value", req.Value);
                        param.Add("@Position", req.Position);
                        param.Add("@LDRobot", LDRobot);
                        param.Add("@ULDRobot", ULDRobot);
                        TaskJobManagment.CurrentProceedTask Task;
                        RouteControl.Instance.TaskJob.Excute(id, out Message, out Task, req.TaskName, param);
                        //這邊要卡住直到Task完成
                        logger.Debug(NodeName + " 等待Task完成");
                        while (!Task.Finished && Running)
                        {
                            SpinWait.SpinUntil(() => Task.Finished || !Running, 99999999);
                        }
                        if (Running)
                        {
                            logger.Debug(NodeName + " Task完成");
                        }
                        else
                        {
                            logger.Debug(NodeName + " 運作停止");
                            continue;
                        }
                    }
                    else
                    {
                        logger.Debug(NodeName + " 暫停監控RequestQueue");
                        while (!Running)
                        {
                            SpinWait.SpinUntil(() => Running, 99999999);
                        }
                        logger.Debug(NodeName + " 開始監控RequestQueue");
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        private static Node FindAvailableLoadport(string RobotName)
        {
            Node result = null;

            var find = from eachPort in NodeManagement.GetLoadPortList()
                       where eachPort.Fetchable && eachPort.Associated_Node.Equals(RobotName)
                       select eachPort;
            if (find.Count() != 0)
            {
                List<Node> pList = find.ToList();
                pList.Sort((x, y) => { return x.LoadTime.CompareTo(y.LoadTime); });
                result = pList.First();
            }

            return result;
        }
    }
}

using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.Controller;
using TransferControl.Management;

namespace Adam.Util
{
    class StateUtil
    {
        class ConnectState
        {

            public string Device_ID { get; set; }
            public string Connection_Status { get; set; }
        }
        static ILog logger = LogManager.GetLogger(typeof(StateUtil));
        static public Dictionary<string, object> device = new Dictionary<string, object>();
        //static private Dictionary<string, AlignerState> aligner = new Dictionary<string, AlignerState>();
        //static private Dictionary<string, LoadPortState> port = new Dictionary<string, LoadPortState>();
        static private RobotState robot1 = new RobotState("ROBOT01");
        static private RobotState robot2 = new RobotState("ROBOT02");
        static private AlignerState aligner1 = new AlignerState("ALIGNER01");
        static private AlignerState aligner2 = new AlignerState("ALIGNER02");
        static private LoadPortState loadPort1 = new LoadPortState("LOADPORT01");
        static private LoadPortState loadPort2 = new LoadPortState("LOADPORT02");
        static private LoadPortState loadPort3 = new LoadPortState("LOADPORT03");
        static private LoadPortState loadPort4 = new LoadPortState("LOADPORT04");
        static private LoadPortState loadPort5 = new LoadPortState("LOADPORT05");
        static private LoadPortState loadPort6 = new LoadPortState("LOADPORT06");
        static private LoadPortState loadPort7 = new LoadPortState("LOADPORT07");
        static private LoadPortState loadPort8 = new LoadPortState("LOADPORT08");

        public static void Init()
        {
            device.Clear();
            device.Add("ROBOT01", robot1);
            device.Add("ROBOT02", robot2);
            device.Add("ALIGNER01", aligner1);
            device.Add("ALIGNER02", aligner2);
            device.Add("LOADPORT01", loadPort1);
            device.Add("LOADPORT02", loadPort2);
            device.Add("LOADPORT03", loadPort3);
            device.Add("LOADPORT04", loadPort4);
            device.Add("LOADPORT05", loadPort5);
            device.Add("LOADPORT06", loadPort6);
            device.Add("LOADPORT07", loadPort7);
            device.Add("LOADPORT08", loadPort8);

        }
        public static void UpdateSTS(string device, string msg)
        {
            switch (device)
            {
                case "ROBOT01":
                    robot1.State = msg;
                    if (msg.Length == 32)
                    {
                        robot1.Servo = msg.Substring(10 - 1, 1).Equals("1") ? "ON" : "OFF";// 10 Servo On 0 = Servo off 1 = Servo On
                    }
                    break;
                case "ROBOT02":
                    robot2.State = msg;
                    if (msg.Length == 32)
                    {
                        robot2.Servo = msg.Substring(10 - 1, 1).Equals("1") ? "ON" : "OFF";// 10 Servo On 0 = Servo off 1 = Servo On
                    }
                    break;
                case "ALIGNER01":
                    aligner1.State = msg;
                    if (msg.Length == 32)
                    {
                        aligner1.Servo = msg.Substring(10 - 1, 1).Equals("1") ? "ON" : "OFF";// 10 Servo On 0 = Servo off 1 = Servo On
                    }
                    break;
                case "ALIGNER02":
                    aligner2.State = msg;
                    if (msg.Length == 32)
                    {
                        aligner2.Servo = msg.Substring(10 - 1, 1).Equals("1") ? "ON" : "OFF";// 10 Servo On 0 = Servo off 1 = Servo On
                    }
                    break;
                case "LOADPORT01":
                    loadPort1.State = msg;
                    break;
                case "LOADPORT02":
                    loadPort2.State = msg;
                    break;
                case "LOADPORT03":
                    loadPort3.State = msg;
                    break;
                case "LOADPORT04":
                    loadPort4.State = msg;
                    break;
                case "LOADPORT05":
                    loadPort5.State = msg;
                    break;
                case "LOADPORT06":
                    loadPort6.State = msg;
                    break;
                case "LOADPORT07":
                    loadPort8.State = msg;
                    break;
                case "LOADPORT08":
                    loadPort8.State = msg;
                    break;
            }
        }
        public static void UpdateCombineStatus(string device, string combineStatus)
        {
            RobotState robot = null;
            AlignerState aligner = null;
            switch (device)
            {
                case "ROBOT01":
                    robot = robot1;
                    break;
                case "ROBOT02":
                    robot = robot2;
                    break;
                case "ALIGNER01":
                    aligner = aligner1;
                    break;
                case "ALIGNER02":
                    aligner = aligner2;
                    break;
                default:
                    return;
            }
            if (robot == null && aligner == null)
                return;
            if (combineStatus == null || combineStatus.IndexOf(",") < 0)
                return;
            string[] result = combineStatus.Split(',');

            if (robot != null)
            {
                //robot status 
                switch (result[3])//<001,Success,R1,[Rdy],H1,REL,U,H2,REL,U>
                {
                    case "Rdy":
                        robot.Status = "Ready";
                        robot.Servo = "ON";
                        break;
                    case "Bsy":
                        robot.Status = "Busy";
                        robot.Servo = "ON";
                        break;
                    case "Off":
                        robot.Status = "Servo OFF";
                        robot.Servo = "OFF";
                        break;
                    case "Err":
                        robot.Status = "Error";
                        robot.Servo = "N/A";
                        break;
                    case "Tch":
                        robot.Status = "Teach";
                        robot.Servo = "N/A";
                        break;
                }
                //H1 ChuckCode
                switch (result[5])//<001,Success,R1,Rdy,H1,[REL],U,H2,REL,U>
                {
                    case "HLD"://Vacuum ON
                        robot.Vacuum_L = "1";
                        break;
                    case "REL"://Vacuum OFF
                        robot.Vacuum_L = "0";
                        break;
                    case "UKN"://Unknown
                        robot.Vacuum_L = "N/A";
                        break;
                }
                //H1 SenseCode
                switch (result[6])//<001,Success,R1,Rdy,H1,REL,[U],H2,REL,U>
                {
                    case "0"://Wafer absence
                        robot.Present_L = result[6];
                        break;
                    case "1"://Wafer presence
                        robot.Present_L = result[6];
                        break;
                    case "U"://Wafer unknown
                        robot.Present_L = result[6];
                        break;
                    case "E"://sensor failure
                        robot.Present_L = result[6];
                        break;
                }//H2 ChuckCode
                switch (result[8])//<001,Success,R1,Rdy,H1,REL,U,H2,[REL],U>
                {
                    case "HLD"://Vacuum ON
                        robot.Vacuum_R = "1";
                        break;
                    case "REL"://Vacuum OFF
                        robot.Vacuum_R = "0";
                        break;
                    case "UKN"://Unknown
                        robot.Vacuum_R = "N/A";
                        break;
                }
                //H2 SenseCode
                switch (result[9])//<001,Success,R1,Rdy,H1,REL,U,H2,REL,[U]>
                {
                    case "0"://Wafer absence
                        robot.Present_R = result[6];
                        break;
                    case "1"://Wafer presence
                        robot.Present_R = result[6];
                        break;
                    case "U"://Wafer unknown
                        robot.Present_R = result[6];
                        break;
                    case "E"://sensor failure
                        robot.Present_R = result[6];
                        break;
                }
            }
            if (aligner != null)
            {
                //Aligner status
                switch (result[3])//<049,Success,A1,[Rdy],AL,REL,U>
                {
                    case "Rdy":
                        aligner.Status = "Ready";
                        aligner.Servo = "ON";
                        break;
                    case "Bsy":
                        aligner.Status = "Busy";
                        aligner.Servo = "ON";
                        break;
                    case "Off":
                        aligner.Status = "Servo OFF";
                        aligner.Servo = "OFF";
                        break;
                    case "Err":
                        aligner.Status = "Error";
                        aligner.Servo = "N/A";
                        break;
                    case "Tch":
                        aligner.Status = "Teach";
                        aligner.Servo = "N/A";
                        break;
                }
                //AL ChuckCode
                switch (result[5])//<049,Success,A1,Rdy,AL,[REL],U>
                {
                    case "HLD"://Vacuum ON
                        aligner.Vacuum = "1";
                        break;
                    case "REL"://Vacuum OFF
                        aligner.Vacuum = "0";
                        break;
                    case "UKN"://Unknown
                        aligner.Vacuum = "N/A";
                        break;
                }
                //AL SenseCode
                switch (result[6])//<049,Success,A1,Rdy,AL,REL,[U]>
                {
                    case "0"://Wafer absence
                        aligner.Present = result[6];
                        break;
                    case "1"://Wafer presence
                        aligner.Present = result[6];
                        break;
                    case "U"://Wafer unknown
                        aligner.Present = result[6];
                        break;
                    case "E"://sensor failure
                        aligner.Present = result[6];
                        break;
                }
            }


        }
        public static void UpdateError(string device, string msg)
        {
            switch (device)
            {
                case "ROBOT01":
                    robot1.Error = msg;
                    break;
                case "ROBOT02":
                    robot2.Error = msg;
                    break;
                case "ALIGNER01":
                    aligner1.Error = msg;
                    break;
                case "ALIGNER02":
                    aligner2.Error = msg;
                    break;
            }
        }

        public static void UpdateMode(string device, string msg)
        {
            switch (device)
            {
                case "ROBOT01":
                    robot1.Mode = msg;
                    break;
                case "ROBOT02":
                    robot2.Mode = msg;
                    break;
                case "ALIGNER01":
                    aligner1.Mode = msg;
                    break;
                case "ALIGNER02":
                    aligner2.Mode = msg;
                    break;
            }
        }

        public static void UpdateRIO(string device, string msg)
        {
            RobotState robot = null;
            AlignerState aligner = null;
            switch (device)
            {
                case "ROBOT01":
                    robot = robot1;
                    break;
                case "ROBOT02":
                    robot = robot2;
                    break;
                case "ALIGNER01":
                    aligner = aligner1;
                    break;
                case "ALIGNER02":
                    aligner = aligner2;
                    break;
                default:
                    return;
            }
            if (msg == null || msg.IndexOf(",") < 0)
                return;
            string[] result = msg.Split(',');
            switch (result[0])
            {
                case "004":
                    if (robot != null)
                        robot.Present_R = result[1];
                    if (aligner != null)
                        aligner.Present = result[1];
                    break;
                case "005":
                    if (robot != null)
                        robot.Present_L = result[1];
                    break;
            }
        }

        public static void UpdateSV(string device, string msg)
        {
            RobotState robot = null;
            AlignerState aligner = null;
            switch (device)
            {
                case "ROBOT01":
                    robot = robot1;
                    break;
                case "ROBOT02":
                    robot = robot2;
                    break;
                case "ALIGNER01":
                    aligner = aligner1;
                    break;
                case "ALIGNER02":
                    aligner = aligner2;
                    break;
                default:
                    return;
            }
            if (msg == null || msg.IndexOf(",") < 0)
                return;
            string[] result = msg.Split(',');
            switch (result[0])
            {
                case "01":
                    if (robot != null)
                        robot.Vacuum_R = result[1];
                    if (aligner != null)
                        aligner.Vacuum = result[1];
                    break;
                case "02":
                    if (robot != null)
                        robot.Vacuum_L = result[1];
                    break;
            }
        }

        public static void UpdateSP(string device, string msg)
        {
            switch (device)
            {
                case "ROBOT01":
                    robot1.Speed = msg;
                    break;
                case "ROBOT02":
                    robot2.Speed = msg;
                    break;
                case "ALIGNER01":
                    aligner1.Speed = msg;
                    break;
                case "ALIGNER02":
                    aligner2.Speed = msg;
                    break;
            }
        }

        public static object GetDeviceState(string name)
        {
            return device[name];
        }

    }

    class LoadPortState
    {
        public string Name { get; set; }
        public string State { get; set; }

        public LoadPortState(string name)
        {
            Node robot = NodeManagement.Get(name);
            this.Name = name;
            this.State = "".PadLeft(20);
        }

    }
    class RobotState
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string CombineStatus { get; set; }
        public string State { get; set; }
        public string Servo { get; set; }
        public string Present_R { get; set; }
        public string Present_L { get; set; }
        public string Vacuum_L { get; set; }
        public string Vacuum_R { get; set; }
        public string Speed { get; set; }
        public string Mode { get; set; }
        public string Error { get; set; }

        public RobotState(string name)
        {
            Node robot = NodeManagement.Get(name);
            this.Name = name;
            this.Status = robot != null ? robot.State : "N/A";
            if (this.Status.Equals("N/A") && ControllerManagement.Get(name) != null)
                this.Status = ControllerManagement.Get(name).Status;// 如果 NODE 無狀態，改抓 Controller 的狀態
            this.State = "".PadLeft(32);
            this.Present_L = "";
            this.Present_R = "";
            this.Vacuum_L = "";
            this.Vacuum_R = "";
            this.Speed = "";
            this.Mode = "";
            this.Error = "";
        }

    }
    class AlignerState
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string CombineStatus { get; set; }
        public string State { get; set; }
        public string Servo { get; set; }
        public string Present { get; set; }
        public string Vacuum { get; set; }
        public string Speed { get; set; }
        public string Mode { get; set; }
        public string Error { get; set; }
        public AlignerState(string name)
        {
            Node aligner = NodeManagement.Get(name);
            this.Name = name;
            this.Status = aligner != null ? aligner.State : "N/A";
            this.State = "".PadLeft(32);
            this.Present = "";
            this.Vacuum = "";
            this.Speed = "";
            this.Mode = "";
            this.Error = "";
        }
    }
}

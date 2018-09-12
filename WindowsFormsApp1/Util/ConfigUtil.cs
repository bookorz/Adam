using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adam
{
    static class ConfigUtil
    {
        public class digitState
        {
            public string state_name;
            public Dictionary<string, string> define;
            public digitState(string state_name, Dictionary<string, string> define)
            {
                this.state_name = state_name;
                this.define = define;
            }
        }
        static public Color GetStatusColor(string device_type, string vendor, string status)
        {
            Color color = Color.White;
            switch (status)
            {
                case "0":
                    color = Color.LightGray;
                    break;
                case "1":
                    color = Color.LightPink;
                    break;
                case "2":
                    color = Color.Yellow;
                    break;
                case "3":
                    color = Color.DimGray;
                    break;
                case "4":
                    color = Color.DarkViolet;
                    break;
                case "5":
                    color = Color.LightGreen;
                    break;
                case "?":
                    color = Color.Gray;
                    break;
            }
            return color;
        }
        //Combobox 使用
        static public List<KeyValuePair<string, int>> GetPointList()
        {
            var list = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Port1", 1201),
                new KeyValuePair<string, int>("Port2", 1202),
                new KeyValuePair<string, int>("Port3", 1203),
                new KeyValuePair<string, int>("Port4", 1204),
                new KeyValuePair<string, int>("Port5", 1205),
                new KeyValuePair<string, int>("Port6", 1206),
                new KeyValuePair<string, int>("Port7", 1207),
                new KeyValuePair<string, int>("Port8", 1208),
                new KeyValuePair<string, int>("Aligner1", 121),
                new KeyValuePair<string, int>("Aligner2", 122),
            };
            return list;
        }
        static public string GetArmID(string arm)
        {
            Dictionary<string, string> armMap = new Dictionary<string, string>();
            armMap["Upper"] = "1";
            armMap["Lower"] = "2";
            armMap["Both"] = "3";
            armMap["R"] = "1";
            armMap["L"] = "2";
            return armMap[arm];
        }
    }
}

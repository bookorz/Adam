using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam.Util
{
    public class UIHandle
    {
        private static ILog logger = LogManager.GetLogger(typeof(UIHandle));

        delegate void UpdateComponent(string FormName, string Id, string Attribute, string Value);

        public class UIAttribute
        {
            public const string Text = "Text";
            public const string Checked = "Checked";
            public const string Enabled = "Enabled";
            public const string BackColor = "BackColor";
        }

        public class SetValue
        {
            public const string True = "True";
            public const string False = "False";
            public const string None = "None";
            public const string Color_Red = "Red";
            public const string Color_Yellow = "Yellow";
        }

        public static void Update(string FormName, string Id, string Attribute, string Value)
        {
            try
            {
                Form form = Application.OpenForms[FormName];

                if (form == null)
                {
                    logger.Error("FormName:" + FormName + " not exist!");
                    return;
                }


                object cpt = form.Controls.Find(Id, true).FirstOrDefault();
                if (cpt == null)
                {
                    logger.Error("FormName:" + FormName + " Id:" + Id + " not exist!");
                    return;
                }
                string Type = cpt.GetType().Name;
                switch (Type)
                {
                    case "CheckBox":
                        CheckBox ckb = cpt as CheckBox;
                        if (ckb.InvokeRequired)
                        {
                            UpdateComponent ph = new UpdateComponent(Update);

                            ckb.BeginInvoke(ph, FormName, Id, Attribute, Value);
                        }
                        else
                        {
                            switch (Attribute)
                            {
                                case UIAttribute.Enabled:
                                    switch (Value)
                                    {
                                        case SetValue.True:
                                            ckb.Enabled = true;
                                            break;
                                        case SetValue.False:
                                            ckb.Enabled = false;
                                            break;
                                    }
                                    break;
                                case UIAttribute.Checked:
                                    switch (Value)
                                    {
                                        case SetValue.True:
                                            ckb.Checked = true;
                                            break;
                                        case SetValue.False:
                                            ckb.Checked = false;
                                            break;
                                    }
                                    break;
                                default:
                                    logger.Error("Attribute is not supported");
                                    break;
                            }
                        }
                        break;
                    case "Label":
                        Label lb = cpt as Label;
                        if (lb.InvokeRequired)
                        {
                            UpdateComponent ph = new UpdateComponent(Update);

                            lb.BeginInvoke(ph, FormName, Id, Type, Attribute, Value);
                        }
                        else
                        {
                            switch (Attribute)
                            {
                                case UIAttribute.Enabled:
                                    switch (Value)
                                    {
                                        case SetValue.True:
                                            lb.Enabled = true;
                                            break;
                                        case SetValue.False:
                                            lb.Enabled = false;
                                            break;
                                    }
                                    break;
                                case UIAttribute.Text:
                                    lb.Text = Value;
                                    break;
                                case UIAttribute.BackColor:
                                    lb.BackColor = Color.FromName(Value);
                                    break;
                                default:
                                    logger.Error("Attribute is not supported");
                                    break;
                            }
                        }
                        break;
                    case "RichTextBox":
                        RichTextBox rtb = cpt as RichTextBox;
                        if (rtb.InvokeRequired)
                        {
                            UpdateComponent ph = new UpdateComponent(Update);

                            rtb.BeginInvoke(ph, FormName, Id, Type, Attribute, Value);
                        }
                        else
                        {
                            switch (Attribute)
                            {
                                case UIAttribute.Enabled:
                                    switch (Value)
                                    {
                                        case SetValue.True:
                                            rtb.Enabled = true;
                                            break;
                                        case SetValue.False:
                                            rtb.Enabled = false;
                                            break;
                                    }
                                    break;
                                case UIAttribute.Text:
                                    rtb.Text = Value;
                                    break;
                                default:
                                    logger.Error("Attribute is not supported");
                                    break;
                            }
                        }
                        break;
                    case "TextBox":
                        TextBox tb = cpt as TextBox;
                        if (tb.InvokeRequired)
                        {
                            UpdateComponent ph = new UpdateComponent(Update);

                            tb.BeginInvoke(ph, FormName, Id, Type, Attribute, Value);
                        }
                        else
                        {
                            switch (Attribute)
                            {
                                case UIAttribute.Enabled:
                                    switch (Value)
                                    {
                                        case SetValue.True:
                                            tb.Enabled = true;
                                            break;
                                        case SetValue.False:
                                            tb.Enabled = false;
                                            break;
                                    }
                                    break;
                                case UIAttribute.Text:
                                    tb.Text = Value;
                                    break;
                                default:
                                    logger.Error("Attribute is not supported");
                                    break;
                            }
                        }
                        break;
                    default:
                        logger.Error("Type is not supported");
                        break;
                }



            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }


        }
    }
}

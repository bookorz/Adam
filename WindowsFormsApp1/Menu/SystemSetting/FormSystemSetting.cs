using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Adam.Menu.SystemSetting
{
    public partial class FormSystemSetting : Form
    {
        private FormAccountSetting accountSetting = new FormAccountSetting();
        private FormAlarmEventSet formAlarm = new FormAlarmEventSet();
        private FormCommandScript configuration = new FormCommandScript();
        private FormDeviceManager deviceManager = new FormDeviceManager();
        private FormOnlineSettings onlineSettings = new FormOnlineSettings();
        private FormSECSSet sECSSet = new FormSECSSet();
        private FormCodeSetting codeSetting = new FormCodeSetting();
        private FormSignalTower formSignalTower = new FormSignalTower();
        private FormDIOSetting formDIOSetting = new FormDIOSetting();

        public FormSystemSetting()
        {
            InitializeComponent();
        }

        private void tbcSystemSetting_DrawItem(object sender, DrawItemEventArgs e)
        {

            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tbcSystemSetting.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tbcSystemSetting.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                //_textBrush = new SolidBrush(Color.DarkGray);
                //g.FillRectangle(Brushes.Transparent, e.Bounds);
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                g.FillRectangle(Brushes.SkyBlue, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("微軟正黑體", (float)18.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));

        }

        private void FormSystemSetting_Load(object sender, EventArgs e)
        {
            try
            {
                accountSetting.TopLevel = false;
                formAlarm.TopLevel = false;
                configuration.TopLevel = false;
                deviceManager.TopLevel = false;
                onlineSettings.TopLevel = false;
                sECSSet.TopLevel = false;
                codeSetting.TopLevel = false;
                formSignalTower.TopLevel = false;
                formDIOSetting.TopLevel = false;

                tbpAccountSetting.Controls.Add(accountSetting);
                tbpAlarmEventSet.Controls.Add(formAlarm);
                tbpCommandScript.Controls.Add(configuration);
                tbpDeviceManager.Controls.Add(deviceManager);
                tbpOnlineSettings.Controls.Add(onlineSettings);
                tbpSECSSetting.Controls.Add(sECSSet);
                tbpCodeSetting.Controls.Add(codeSetting);
                tbpSignalTtower.Controls.Add(formSignalTower);
                tbpDIOSetting.Controls.Add(formDIOSetting);

                accountSetting.Show();
                formAlarm.Show();
                configuration.Show();
                deviceManager.Show();
                onlineSettings.Show();
                sECSSet.Show();
                codeSetting.Show();
                formSignalTower.Show();
                formDIOSetting.Show();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void tbcSystemSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbcSystemSetting.SelectedTab == tbcSystemSetting.TabPages["tbpAccountSetting"])
                {
                    tbpAccountSetting.Controls.Clear();
                    accountSetting.Close();
                    accountSetting.Dispose();
                    accountSetting = new FormAccountSetting();
                    accountSetting.TopLevel = false;
                    tbpAccountSetting.Controls.Add(accountSetting);
                    accountSetting.Show();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

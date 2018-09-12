using log4net;
using Newtonsoft.Json;
using SANWA.Utility.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TransferControl.Management;
using System.Linq;
using Adam.UI_Update.OCR;

namespace Adam.Menu.OCR
{
    public partial class FormOCR : Adam.Menu.FormFrame
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        delegate void AssignUI(object param);
        IntPtr appWin2;

        private static readonly ILog logger = LogManager.GetLogger(typeof(FormOCR));
        public FormOCR()
        {
            InitializeComponent();
        }

        private void FormOCR_Load(object sender, EventArgs e)
        {

            OCRUpdate.AssignForm();


        }

        

        private void FormOCR_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Process p in Process.GetProcessesByName("VB9BReaderForm"))
            {
                p.Kill();
            }
            foreach (Process p in Process.GetProcessesByName("WaferID"))
            {
                p.Kill();
            }
        }

        private void Reload_btn_Click(object sender, EventArgs e)
        {
            Reload_btn.Enabled = false;
            OCRUpdate.AssignForm();
        }
    }
}

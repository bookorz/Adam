using log4net;
using SANWA.Utility;
using SANWA.Utility.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.Engine;
using TransferControl.Management;

namespace Adam.UI_Update.OCR
{
    class OCRUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(OCRUpdate));
        delegate void UpdateOCR(string OCRName, string In, Job Job);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        private const int GWL_STYLE = -16;
        private const int WS_CHILD = 0x40000000;//设置窗口属性为child

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        delegate void AssignUI(object param);
        delegate void ReAssignUI();
        static IntPtr appWin2;
        static int pCnt = 0;



        public static void UpdateOCRRead(string OCRName, string WaferID, Job Job)
        {
            try
            {
                Form form = Application.OpenForms["FormMonitoring"];
                TextBox Tb_OCRRead;
                if (form == null)
                    return;

                Tb_OCRRead = form.Controls.Find(OCRName + "Read_Tb", true).FirstOrDefault() as TextBox;
                if (Tb_OCRRead == null)
                    return;

                if (Tb_OCRRead.InvokeRequired)
                {
                    UpdateOCR ph = new UpdateOCR(UpdateOCRRead);
                    Tb_OCRRead.BeginInvoke(ph, OCRName, WaferID, Job);
                }
                else
                {
                    string save = "";
                    string src = "";
                    string OCRResult = WaferID;
                    if (WaferID.IndexOf("*") != -1)
                    {
                        WaferID = "Failed";
                    }
                    switch (OCRName)
                    {
                        case "OCR01":
                            save = SystemConfig.Get().OCR1ImgToJpgPath;
                            src = SystemConfig.Get().OCR1ImgSourcePath;
                            break;
                        case "OCR02":
                            save = SystemConfig.Get().OCR2ImgToJpgPath;
                            src = SystemConfig.Get().OCR2ImgSourcePath;
                            break;
                    }

                    Thread.Sleep(500);
                    Node OCR = NodeManagement.Get(OCRName);
                    if (OCR != null)
                    {

                        if (!Directory.Exists(save))
                        {
                            Directory.CreateDirectory(save);
                        }
                        string saveTmpPath = save + "/" + WaferID + "_" + DateTime.Now.ToString("yyyy_mm_dd_HH_MM_ss") + ".bmp";
                        string FileName = WaferID + "_" + DateTime.Now.ToString("yyyy_mm_dd_HH_MM_ss") + ".jpg";
                        string savePath = save +"/"+ FileName;

                        if (savePath != "")
                        {
                            switch (OCR.Brand)
                            {
                                case "COGNEX":
                                    string[] ocrResult = OCRResult.Replace("[", "").Replace("]", "").Split(',');
                                    string info = ocrResult[0];
                                    if (ocrResult.Length >= 2)
                                    {
                                        info += " Score:" + ocrResult[1];
                                    }
                                    else
                                    {
                                        info += " Score:0";
                                    }
                                    Tb_OCRRead.Text = info;
                                    FTP ftp = new FTP("192.168.0.5","21","","admin","");
                                    string imgPath = ftp.Get("image.jpg", FileName, save);
                                    PictureBox Pic_OCR = form.Controls.Find(OCRName + "_Pic", true).FirstOrDefault() as PictureBox;
                                    if (Pic_OCR == null)
                                        return;
                                    Bitmap t = new Bitmap(Image.FromFile(savePath), new Size(320, 240));
                                    Pic_OCR.Image = t;
                                    Pic_OCR.Tag = Job;
                                    Job.OCRImgPath = savePath;
                                    Job.OCRScore = ocrResult[1];
                                    ProcessRecord.updateSubstrateOCR(NodeManagement.Get(Job.FromPort).PrID, Job);
                                    break;
                                case "HST":
                                    ocrResult = OCRResult.Replace("[", "").Replace("]", "").Split(',');
                                    WaferID = ocrResult[0];
                                    if (ocrResult.Length >= 2)
                                    {
                                        WaferID += " Score:" + ocrResult[1];
                                    }
                                    else
                                    {
                                        WaferID += " Score:0";
                                    }
                                    Tb_OCRRead.Text = WaferID;

                                    string[] files = Directory.GetFiles(src);
                                    List<string> fileList = files.ToList();
                                    if (fileList.Count != 0)
                                    {
                                        fileList.Sort((x, y) => { return -File.GetLastWriteTime(x).CompareTo(File.GetLastWriteTime(y)); });
                                        File.Copy(fileList[0], saveTmpPath);
                                        Image bmp = Image.FromFile(saveTmpPath);

                                        bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        bmp.Dispose();
                                        Pic_OCR = form.Controls.Find(OCRName + "_Pic", true).FirstOrDefault() as PictureBox;
                                        File.Delete(saveTmpPath);
                                        if (Pic_OCR == null)
                                            return;
                                        t = new Bitmap(Image.FromFile(savePath), new Size(320, 240));
                                        Pic_OCR.Image = t;
                                        Pic_OCR.Tag = Job;
                                        Job.OCRImgPath = savePath;
                                        Job.OCRScore = ocrResult[1];
                                        ProcessRecord.updateSubstrateOCR(NodeManagement.Get(Job.FromPort).PrID, Job);
                                    }
                                    break;
                            }

                        }
                    }
                }


            }
            catch(Exception e)
            {
                logger.Error("UpdateOCRRead: Update fail.");
            }
        }

        public static void AssignForm()
        {
            pCnt = 0;
            foreach (Process p in Process.GetProcessesByName("VB9BReaderForm"))
            {
                p.Kill();
            }
            foreach (Process p in Process.GetProcessesByName("WaferID"))
            {
                p.Kill();
            }

            ReAssign();

        }

        private static void ReAssign()
        {
            try
            {
                Form form = Application.OpenForms["FormOCR"];
                TabControl tabControl1;
                if (form == null)
                    return;

                tabControl1 = form.Controls.Find("tabControl1", true).FirstOrDefault() as TabControl;
                if (tabControl1 == null)
                    return;
                if (tabControl1.InvokeRequired)
                {
                    ReAssignUI ph = new ReAssignUI(ReAssign);
                    tabControl1.BeginInvoke(ph);
                }
                else
                {

                    tabControl1.TabPages.Clear();
                    var ocrs = from ocr in NodeManagement.GetList()
                               where ocr.Type.Equals("OCR")
                               select ocr;
                    bool IsCognexInit = false;
                    foreach (Node ocr in ocrs)
                    {
                        switch (ocr.Brand)
                        {
                            case "HST":
                                pCnt++;
                                Process p1 = Process.Start(new ProcessStartInfo("C:/Program Files (x86)/HST Vision/e-Reader8000/VB9BReaderForm.exe", ocr.AdrNo));
                                //ThreadPool.QueueUserWorkItem(new WaitCallback(LoadHST), ocr);


                                break;
                            case "COGNEX":
                                if (!IsCognexInit)
                                {
                                    pCnt++;
                                    IsCognexInit = true;
                                    Process p2 = Process.Start(new ProcessStartInfo("C:/Program Files (x86)/Cognex/In-Sight/In-Sight Explorer Wafer 4.5.0/WaferID.exe"));
                                    //ThreadPool.QueueUserWorkItem(new WaitCallback(LoadCOGNEX), ocr);
                                }
                                //ControllerManagement.Get(ocr.Controller).Connect();
                                break;
                        }
                    }

                }
            }
            catch(Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        private static void LoadHST(object param)
        {
            try
            {
                Node OCR = param as Node;
                Form form = Application.OpenForms["FormOCR"];
                TabControl tabControl1;
                if (form == null)
                    return;

                tabControl1 = form.Controls.Find("tabControl1", true).FirstOrDefault() as TabControl;
                if (tabControl1 == null)
                    return;

                // SpinWait.SpinUntil(() => false, 1000);


                SpinWait.SpinUntil(() => (from prs in Process.GetProcessesByName("VB9BReaderForm").OfType<Process>().ToList()
                                          where prs.MainWindowTitle.Equals("[" + OCR.AdrNo + "]Wafer Reader Version 4.3.1.0")
                                          select prs).Count() != 0, 60000);
                SpinWait.SpinUntil(() => false, 2000);
                // Put it into this form
                if (tabControl1.InvokeRequired)
                {
                    AssignUI ph = new AssignUI(LoadHST);
                    tabControl1.BeginInvoke(ph, param);
                }
                else
                {
                    var ps = from prs in Process.GetProcessesByName("VB9BReaderForm").OfType<Process>().ToList()
                             where prs.MainWindowTitle.Equals("[" + OCR.AdrNo + "]Wafer Reader Version 4.3.1.0")
                             select prs;
                    if (ps.Count() != 0)
                    {

                        tabControl1.TabPages.Add(OCR.Name, OCR.Name);
                        Process p2 = ps.First();
                        appWin2 = p2.MainWindowHandle;
                        SetParent(p2.MainWindowHandle, tabControl1.TabPages[OCR.Name].Handle);
                        MoveWindow(p2.MainWindowHandle, 0, -30, tabControl1.TabPages[OCR.Name].Width, tabControl1.TabPages[OCR.Name].Height + 30, true);
                        var s = GetWindowLong(p2.MainWindowHandle, GWL_STYLE);
                        SetWindowLong(p2.MainWindowHandle, GWL_STYLE, s | WS_CHILD);
                    }
                    //ControllerManagement.Get(OCR.Controller).Connect();
                    pCnt--;
                    if (pCnt == 0)
                    {
                        Button Reload = form.Controls.Find("Reload_btn", true).FirstOrDefault() as Button;
                        Reload.Enabled = true;
                    }
                }


            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        private static void LoadCOGNEX(object param)
        {
            try
            {
                Node OCR = param as Node;
                //SpinWait.SpinUntil(() => false, 1000);

                //Cognex Wafer ID - 4.5.0
                SpinWait.SpinUntil(() => Process.GetProcessesByName("WaferID")[0].MainWindowTitle.Equals("Cognex Wafer ID - 4.5.0"), 60000);
                SpinWait.SpinUntil(() => false, 2000);
                //SpinWait.SpinUntil(() => Process.GetProcessesByName("WaferID").Length != 0, 60000);

                //logger.Debug("1" + Process.GetProcessesByName("WaferID")[0].MainWindowTitle);
                //SpinWait.SpinUntil(() => false, 3000);
                //logger.Debug("2");
                Form form = Application.OpenForms["FormOCR"];
                TabControl tabControl1;
                if (form == null)
                    return;

                tabControl1 = form.Controls.Find("tabControl1", true).FirstOrDefault() as TabControl;
                if (tabControl1 == null)
                    return;


                if (tabControl1.InvokeRequired)
                {
                    AssignUI ph = new AssignUI(LoadCOGNEX);
                    tabControl1.BeginInvoke(ph, param);
                }
                else
                {
                    tabControl1.TabPages.Add("COGNEX", "COGNEX");
                    Process p2 = Process.GetProcessesByName("WaferID")[0];
                    appWin2 = p2.MainWindowHandle;
                    SetParent(p2.MainWindowHandle, tabControl1.TabPages["COGNEX"].Handle);
                    MoveWindow(p2.MainWindowHandle, 0, -30, tabControl1.TabPages["COGNEX"].Width, tabControl1.TabPages["COGNEX"].Height + 30, true);
                    var s = GetWindowLong(p2.MainWindowHandle, GWL_STYLE);
                    SetWindowLong(p2.MainWindowHandle, GWL_STYLE, s | WS_CHILD);
                    pCnt--;
                    if (pCnt == 0)
                    {
                        Button Reload = form.Controls.Find("Reload_btn", true).FirstOrDefault() as Button;
                        Reload.Enabled = true;
                    }
                }

            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        //public static void UpdateOCRStatus(string OCRName, string Status)
        //{
        //    try
        //    {
        //        Form form = Application.OpenForms["FormOCR"];
        //        Button Btn_OCROnline;
        //        if (form == null)
        //            return;

        //        Btn_OCROnline = form.Controls.Find(OCRName+"Online_Btn", true).FirstOrDefault() as Button;
        //        if (Btn_OCROnline == null)
        //            return;
        //        Button Btn_OCROffline = form.Controls.Find(OCRName + "Offline_Btn", true).FirstOrDefault() as Button;
        //        if (Btn_OCROffline == null)
        //            return;
        //        if (Btn_OCROnline.InvokeRequired)
        //        {
        //            UpdateOCR ph = new UpdateOCR(UpdateOCRStatus);
        //            Btn_OCROnline.BeginInvoke(ph, OCRName, Status);
        //        }
        //        else
        //        {
        //            switch (Status)
        //            {
        //                case "1":
        //                    Btn_OCROnline.Enabled = false;
        //                    Btn_OCROffline.Enabled = true;
        //                    break;
        //                case "0":
        //                    Btn_OCROnline.Enabled = true;
        //                    Btn_OCROffline.Enabled = false;
        //                    break;
        //            }
        //        }


        //    }
        //    catch
        //    {
        //        logger.Error("UpdateOCRStatus: Update fail.");
        //    }
        //}
    }
}

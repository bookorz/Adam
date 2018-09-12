namespace Adam.Menu.RunningScreen
{
    partial class FormRunningScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.WPH_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Start_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RunningSpeed_cb = new System.Windows.Forms.ComboBox();
            this.LapsedWfCount_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LapsedLotCount_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LapsedTime_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TransCount_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.WPH_tb);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Start_btn);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.LapsedWfCount_tb);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LapsedLotCount_tb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LapsedTime_tb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TransCount_tb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(555, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 736);
            this.panel1.TabIndex = 1;
            // 
            // WPH_tb
            // 
            this.WPH_tb.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WPH_tb.Location = new System.Drawing.Point(134, 374);
            this.WPH_tb.Name = "WPH_tb";
            this.WPH_tb.Size = new System.Drawing.Size(151, 35);
            this.WPH_tb.TabIndex = 17;
            this.WPH_tb.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(129, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 27);
            this.label6.TabIndex = 16;
            this.label6.Text = "WPH";
            // 
            // Start_btn
            // 
            this.Start_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Start_btn.Location = new System.Drawing.Point(118, 572);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(181, 80);
            this.Start_btn.TabIndex = 15;
            this.Start_btn.Text = "Start Running";
            this.Start_btn.UseVisualStyleBackColor = false;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(146, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 27);
            this.label5.TabIndex = 12;
            this.label5.Text = "Speed";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.RunningSpeed_cb);
            this.panel2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel2.Location = new System.Drawing.Point(134, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 87);
            this.panel2.TabIndex = 11;
            // 
            // RunningSpeed_cb
            // 
            this.RunningSpeed_cb.FormattingEnabled = true;
            this.RunningSpeed_cb.Items.AddRange(new object[] {
            "100%",
            "90%",
            "80%",
            "70%",
            "60%",
            "50%",
            "40%",
            "30%",
            "20%",
            "10%"});
            this.RunningSpeed_cb.Location = new System.Drawing.Point(16, 40);
            this.RunningSpeed_cb.Name = "RunningSpeed_cb";
            this.RunningSpeed_cb.Size = new System.Drawing.Size(85, 35);
            this.RunningSpeed_cb.TabIndex = 0;
            this.RunningSpeed_cb.Text = "50%";
            this.RunningSpeed_cb.TextChanged += new System.EventHandler(this.RunningSpeed_cb_TextChanged);
            // 
            // LapsedWfCount_tb
            // 
            this.LapsedWfCount_tb.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LapsedWfCount_tb.Location = new System.Drawing.Point(134, 218);
            this.LapsedWfCount_tb.Name = "LapsedWfCount_tb";
            this.LapsedWfCount_tb.Size = new System.Drawing.Size(151, 35);
            this.LapsedWfCount_tb.TabIndex = 9;
            this.LapsedWfCount_tb.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(129, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "LapsedWfCount";
            // 
            // LapsedLotCount_tb
            // 
            this.LapsedLotCount_tb.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LapsedLotCount_tb.Location = new System.Drawing.Point(134, 293);
            this.LapsedLotCount_tb.Name = "LapsedLotCount_tb";
            this.LapsedLotCount_tb.Size = new System.Drawing.Size(151, 35);
            this.LapsedLotCount_tb.TabIndex = 7;
            this.LapsedLotCount_tb.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(129, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "LapsedLotCnt.";
            // 
            // LapsedTime_tb
            // 
            this.LapsedTime_tb.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LapsedTime_tb.Location = new System.Drawing.Point(134, 143);
            this.LapsedTime_tb.Name = "LapsedTime_tb";
            this.LapsedTime_tb.Size = new System.Drawing.Size(151, 35);
            this.LapsedTime_tb.TabIndex = 5;
            this.LapsedTime_tb.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(129, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lapsed time";
            // 
            // TransCount_tb
            // 
            this.TransCount_tb.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TransCount_tb.Location = new System.Drawing.Point(134, 68);
            this.TransCount_tb.Name = "TransCount_tb";
            this.TransCount_tb.Size = new System.Drawing.Size(151, 35);
            this.TransCount_tb.TabIndex = 1;
            this.TransCount_tb.Text = "9999999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(129, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trans. Count";
            // 
            // FormRunningScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 760);
            this.Controls.Add(this.panel1);
            this.Name = "FormRunningScreen";
            this.Text = "FormTestMode";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox RunningSpeed_cb;
        private System.Windows.Forms.TextBox LapsedWfCount_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LapsedLotCount_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LapsedTime_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TransCount_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WPH_tb;
        private System.Windows.Forms.Label label6;
    }
}
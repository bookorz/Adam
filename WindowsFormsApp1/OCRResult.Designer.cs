namespace Adam
{
    partial class OCRResult
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
            this.WaferID = new System.Windows.Forms.Label();
            this.OCR_Score = new System.Windows.Forms.Label();
            this.OCR_Img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.OCR_Img)).BeginInit();
            this.SuspendLayout();
            // 
            // WaferID
            // 
            this.WaferID.AutoSize = true;
            this.WaferID.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WaferID.Location = new System.Drawing.Point(12, 765);
            this.WaferID.Name = "WaferID";
            this.WaferID.Size = new System.Drawing.Size(227, 48);
            this.WaferID.TabIndex = 1;
            this.WaferID.Text = "WAFERID";
            // 
            // OCR_Score
            // 
            this.OCR_Score.AutoSize = true;
            this.OCR_Score.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OCR_Score.Location = new System.Drawing.Point(976, 765);
            this.OCR_Score.Name = "OCR_Score";
            this.OCR_Score.Size = new System.Drawing.Size(166, 48);
            this.OCR_Score.TabIndex = 2;
            this.OCR_Score.Text = "SCORE";
            // 
            // OCR_Img
            // 
            this.OCR_Img.Location = new System.Drawing.Point(12, 12);
            this.OCR_Img.Name = "OCR_Img";
            this.OCR_Img.Size = new System.Drawing.Size(1287, 741);
            this.OCR_Img.TabIndex = 0;
            this.OCR_Img.TabStop = false;
            // 
            // OCRResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 822);
            this.Controls.Add(this.OCR_Score);
            this.Controls.Add(this.WaferID);
            this.Controls.Add(this.OCR_Img);
            this.Name = "OCRResult";
            this.Text = "OCRResult";
            this.Load += new System.EventHandler(this.OCRResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OCR_Img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OCR_Img;
        private System.Windows.Forms.Label WaferID;
        private System.Windows.Forms.Label OCR_Score;
    }
}
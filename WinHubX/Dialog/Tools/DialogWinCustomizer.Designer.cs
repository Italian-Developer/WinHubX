namespace WinHubX.Dialog.Tools
{
    partial class DialogWinCustomizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogWinCustomizer));
            imgTool = new PictureBox();
            lblInfoTool = new Label();
            btnClose = new Button();
            btnDownload = new Button();
            ((System.ComponentModel.ISupportInitialize)imgTool).BeginInit();
            SuspendLayout();
            // 
            // imgTool
            // 
            imgTool.Image = Properties.Resources.extWinCustomizer;
            imgTool.Location = new Point(200, 30);
            imgTool.Name = "imgTool";
            imgTool.Size = new Size(400, 150);
            imgTool.TabIndex = 0;
            imgTool.TabStop = false;
            // 
            // lblInfoTool
            // 
            lblInfoTool.AutoSize = true;
            lblInfoTool.Font = new Font("Product Sans", 15F);
            lblInfoTool.ForeColor = Color.Coral;
            lblInfoTool.Location = new Point(106, 191);
            lblInfoTool.Name = "lblInfoTool";
            lblInfoTool.Size = new Size(588, 224);
            lblInfoTool.TabIndex = 74;
            lblInfoTool.Text = resources.GetString("lblInfoTool.Text");
            lblInfoTool.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.pngClose;
            btnClose.Location = new Point(733, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(55, 55);
            btnClose.TabIndex = 75;
            btnClose.UseMnemonic = false;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnDownload
            // 
            btnDownload.Cursor = Cursors.Hand;
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Product Sans Black", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(218, 417);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(360, 70);
            btnDownload.TabIndex = 76;
            btnDownload.Text = "Download ~5MB";
            btnDownload.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // DialogWinCustomizer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(800, 500);
            Controls.Add(btnDownload);
            Controls.Add(btnClose);
            Controls.Add(lblInfoTool);
            Controls.Add(imgTool);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DialogWinCustomizer";
            Text = "DialogWinCustomizer";
            ((System.ComponentModel.ISupportInitialize)imgTool).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imgTool;
        private Label lblInfoTool;
        private Button btnClose;
        private Button btnDownload;
    }
}
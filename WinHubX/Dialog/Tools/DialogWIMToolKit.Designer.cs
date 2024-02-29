namespace WinHubX.Dialog.Tools
{
    partial class DialogWIMToolKit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogWIMToolKit));
            btnDownload = new Button();
            btnClose = new Button();
            lblInfoTool = new Label();
            imgTool = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imgTool).BeginInit();
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.Cursor = Cursors.Hand;
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Product Sans Black", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(190, 417);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(420, 70);
            btnDownload.TabIndex = 80;
            btnDownload.Text = "Download ~400MB";
            btnDownload.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
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
            btnClose.TabIndex = 79;
            btnClose.UseMnemonic = false;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblInfoTool
            // 
            lblInfoTool.Font = new Font("Product Sans", 15F);
            lblInfoTool.ForeColor = Color.Coral;
            lblInfoTool.Location = new Point(150, 189);
            lblInfoTool.Name = "lblInfoTool";
            lblInfoTool.Size = new Size(500, 225);
            lblInfoTool.TabIndex = 78;
            lblInfoTool.Text = "Il nostro tool completo per \r\npersonalizzare le ISO di Windows\r\n- Rimozione Package e App Preinstallate\r\n- Bypass requisiti Windows 11\r\n- Aggiunta Driver\r\n- Aggiunta DaRT\r\n- Rimozione WinRe\r\n";
            lblInfoTool.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imgTool
            // 
            imgTool.Image = Properties.Resources.extWIMToolkit;
            imgTool.Location = new Point(250, 30);
            imgTool.Name = "imgTool";
            imgTool.Size = new Size(300, 150);
            imgTool.TabIndex = 77;
            imgTool.TabStop = false;
            // 
            // DialogWIMToolKit
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
            Name = "DialogWIMToolKit";
            Text = "DialogWIMToolKit";
            ((System.ComponentModel.ISupportInitialize)imgTool).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDownload;
        private Button btnClose;
        private Label lblInfoTool;
        private PictureBox imgTool;
    }
}
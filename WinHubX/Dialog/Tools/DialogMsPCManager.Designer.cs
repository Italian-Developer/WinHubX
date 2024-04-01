namespace WinHubX.Dialog.Tools
{
    partial class DialogMsPCManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogMsPCManager));
            btnDownload = new Button();
            btnClose = new Button();
            lblInfoTool = new Label();
            imgTool = new PictureBox();
            label1 = new Label();
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
            btnDownload.Location = new Point(218, 417);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(360, 70);
            btnDownload.TabIndex = 80;
            btnDownload.Text = "Installa";
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
            lblInfoTool.AutoSize = true;
            lblInfoTool.Font = new Font("Product Sans", 15F);
            lblInfoTool.ForeColor = Color.Coral;
            lblInfoTool.Location = new Point(106, 191);
            lblInfoTool.Name = "lblInfoTool";
            lblInfoTool.Size = new Size(597, 192);
            lblInfoTool.TabIndex = 78;
            lblInfoTool.Text = resources.GetString("lblInfoTool.Text");
            lblInfoTool.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imgTool
            // 
            imgTool.Image = Properties.Resources.pngMPM;
            imgTool.Location = new Point(207, 50);
            imgTool.Name = "imgTool";
            imgTool.Size = new Size(103, 110);
            imgTool.TabIndex = 77;
            imgTool.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Product Sans Black", 25.8F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(312, 50);
            label1.Name = "label1";
            label1.Size = new Size(283, 110);
            label1.TabIndex = 81;
            label1.Text = "Microsoft PC\r\nManager";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DialogMsPCManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(800, 500);
            Controls.Add(label1);
            Controls.Add(btnDownload);
            Controls.Add(btnClose);
            Controls.Add(lblInfoTool);
            Controls.Add(imgTool);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DialogMsPCManager";
            Text = "DialogMsPCManager";
            ((System.ComponentModel.ISupportInitialize)imgTool).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDownload;
        private Button btnClose;
        private Label lblInfoTool;
        private PictureBox imgTool;
        private Label label1;
    }
}
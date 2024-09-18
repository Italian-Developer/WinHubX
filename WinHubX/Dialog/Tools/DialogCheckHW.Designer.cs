namespace WinHubX.Dialog.Tools
{
    partial class DialogCheckHW
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblInfoTool;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogCheckHW));

            this.label1 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblInfoTool = new System.Windows.Forms.Label();

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Product Sans Black", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(174, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check Hardware Tool";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // btnDownload
            // 
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Product Sans Black", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(215, 417);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(370, 70);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Check Hardware";
            this.btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);

            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(733, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 55);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // lblInfoTool
            // 
            this.lblInfoTool.AutoSize = true;
            this.lblInfoTool.Font = new System.Drawing.Font("Product Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfoTool.ForeColor = System.Drawing.Color.Coral;
            this.lblInfoTool.Location = new System.Drawing.Point(77, 138);
            this.lblInfoTool.Name = "lblInfoTool";
            this.lblInfoTool.Size = new System.Drawing.Size(645, 224);
            this.lblInfoTool.TabIndex = 3;
            this.lblInfoTool.Text = resources.GetString("lblInfoTool.Text");

            // 
            // DialogCheckHW
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(37, 38, 39);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblInfoTool);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogCheckHW";
            this.Text = "DialogCheckHW";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

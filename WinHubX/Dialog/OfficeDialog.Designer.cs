namespace WinHubX.Dialog
{
    partial class OfficeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfficeDialog));
            btnOfficeOnline64 = new Button();
            btnOfficeOnline32 = new Button();
            lblOnline = new Label();
            SuspendLayout();
            // 
            // btnOfficeOnline64
            // 
            btnOfficeOnline64.Cursor = Cursors.Hand;
            btnOfficeOnline64.FlatAppearance.BorderSize = 0;
            btnOfficeOnline64.FlatStyle = FlatStyle.Flat;
            btnOfficeOnline64.Font = new Font("Product Sans Black", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOfficeOnline64.ForeColor = Color.White;
            btnOfficeOnline64.Location = new Point(300, 170);
            btnOfficeOnline64.Name = "btnOfficeOnline64";
            btnOfficeOnline64.Size = new Size(156, 71);
            btnOfficeOnline64.TabIndex = 74;
            btnOfficeOnline64.Text = "64bit";
            btnOfficeOnline64.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOfficeOnline64.UseVisualStyleBackColor = true;
            btnOfficeOnline64.MouseUp += btnOfficeOnline64_MouseUp;
            // 
            // btnOfficeOnline32
            // 
            btnOfficeOnline32.Cursor = Cursors.Hand;
            btnOfficeOnline32.FlatAppearance.BorderSize = 0;
            btnOfficeOnline32.FlatStyle = FlatStyle.Flat;
            btnOfficeOnline32.Font = new Font("Product Sans Black", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOfficeOnline32.ForeColor = Color.White;
            btnOfficeOnline32.Location = new Point(300, 80);
            btnOfficeOnline32.Name = "btnOfficeOnline32";
            btnOfficeOnline32.Size = new Size(156, 71);
            btnOfficeOnline32.TabIndex = 75;
            btnOfficeOnline32.Text = "32bit";
            btnOfficeOnline32.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOfficeOnline32.UseVisualStyleBackColor = true;
            btnOfficeOnline32.MouseUp += btnOfficeOnline32_MouseUp;
            // 
            // lblOnline
            // 
            lblOnline.Font = new Font("Product Sans Black", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOnline.ForeColor = Color.White;
            lblOnline.Image = Properties.Resources.pngOnline;
            lblOnline.ImageAlign = ContentAlignment.MiddleLeft;
            lblOnline.Location = new Point(50, 180);
            lblOnline.Name = "lblOnline";
            lblOnline.Size = new Size(211, 71);
            lblOnline.TabIndex = 76;
            lblOnline.Text = "Online";
            lblOnline.TextAlign = ContentAlignment.MiddleRight;
            // 
            // OfficeDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(500, 340);
            Controls.Add(lblOnline);
            Controls.Add(btnOfficeOnline32);
            Controls.Add(btnOfficeOnline64);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OfficeDialog";
            Text = "OfficeDialog";
            ResumeLayout(false);
        }

        #endregion
        private Button btnOfficeOnline64;
        private Button btnOfficeOnline32;
        private Label lblOnline;
    }
}
namespace WinHubX
{
    partial class FormWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWin));
            btnWin7 = new Button();
            btnWin8dot1 = new Button();
            btnWin11 = new Button();
            btnWin10 = new Button();
            btnWinLive = new Button();
            btnWin12 = new Button();
            lblInfoWin12 = new Label();
            btnAttivaWin = new Button();
            btnCambioEdizione = new Button();
            SuspendLayout();
            // 
            // btnWin7
            // 
            btnWin7.Cursor = Cursors.Hand;
            btnWin7.FlatAppearance.BorderSize = 0;
            btnWin7.FlatStyle = FlatStyle.Flat;
            btnWin7.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin7.ForeColor = Color.White;
            btnWin7.Image = Properties.Resources.pngWin7;
            btnWin7.Location = new Point(74, 20);
            btnWin7.Margin = new Padding(3, 2, 3, 2);
            btnWin7.Name = "btnWin7";
            btnWin7.Size = new Size(304, 68);
            btnWin7.TabIndex = 5;
            btnWin7.Text = "Windows 7";
            btnWin7.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin7.UseVisualStyleBackColor = true;
            btnWin7.Click += btnWin7_Click;
            // 
            // btnWin8dot1
            // 
            btnWin8dot1.Cursor = Cursors.Hand;
            btnWin8dot1.FlatAppearance.BorderSize = 0;
            btnWin8dot1.FlatStyle = FlatStyle.Flat;
            btnWin8dot1.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin8dot1.ForeColor = Color.White;
            btnWin8dot1.Image = Properties.Resources.pngWin8dot1;
            btnWin8dot1.Location = new Point(524, 17);
            btnWin8dot1.Margin = new Padding(3, 2, 3, 2);
            btnWin8dot1.Name = "btnWin8dot1";
            btnWin8dot1.Size = new Size(313, 75);
            btnWin8dot1.TabIndex = 6;
            btnWin8dot1.Text = "Windows 8.1";
            btnWin8dot1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin8dot1.UseVisualStyleBackColor = true;
            btnWin8dot1.Click += btnWin8dot1_Click;
            // 
            // btnWin11
            // 
            btnWin11.Cursor = Cursors.Hand;
            btnWin11.FlatAppearance.BorderSize = 0;
            btnWin11.FlatStyle = FlatStyle.Flat;
            btnWin11.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin11.ForeColor = Color.White;
            btnWin11.Image = (Image)resources.GetObject("btnWin11.Image");
            btnWin11.Location = new Point(524, 120);
            btnWin11.Margin = new Padding(3, 2, 3, 2);
            btnWin11.Name = "btnWin11";
            btnWin11.Size = new Size(304, 66);
            btnWin11.TabIndex = 8;
            btnWin11.Text = "Windows 11";
            btnWin11.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin11.UseVisualStyleBackColor = true;
            btnWin11.Click += btnWin11_Click;
            // 
            // btnWin10
            // 
            btnWin10.Cursor = Cursors.Hand;
            btnWin10.FlatAppearance.BorderSize = 0;
            btnWin10.FlatStyle = FlatStyle.Flat;
            btnWin10.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin10.ForeColor = Color.White;
            btnWin10.Image = Properties.Resources.pngWin10;
            btnWin10.Location = new Point(74, 120);
            btnWin10.Margin = new Padding(3, 2, 3, 2);
            btnWin10.Name = "btnWin10";
            btnWin10.Size = new Size(304, 68);
            btnWin10.TabIndex = 7;
            btnWin10.Text = "Windows 10";
            btnWin10.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin10.UseVisualStyleBackColor = true;
            btnWin10.Click += btnWin10_Click;
            // 
            // btnWinLive
            // 
            btnWinLive.Cursor = Cursors.Hand;
            btnWinLive.FlatAppearance.BorderSize = 0;
            btnWinLive.FlatStyle = FlatStyle.Flat;
            btnWinLive.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWinLive.ForeColor = Color.White;
            btnWinLive.Image = Properties.Resources.pngWinLive;
            btnWinLive.Location = new Point(74, 220);
            btnWinLive.Margin = new Padding(3, 2, 3, 2);
            btnWinLive.Name = "btnWinLive";
            btnWinLive.Size = new Size(304, 90);
            btnWinLive.TabIndex = 9;
            btnWinLive.Text = "Windows\r\nLive\r\n";
            btnWinLive.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWinLive.UseVisualStyleBackColor = true;
            btnWinLive.Click += btnWinLive_Click;
            // 
            // btnWin12
            // 
            btnWin12.Cursor = Cursors.Hand;
            btnWin12.Enabled = false;
            btnWin12.FlatAppearance.BorderSize = 0;
            btnWin12.FlatStyle = FlatStyle.Flat;
            btnWin12.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin12.ForeColor = Color.White;
            btnWin12.Image = Properties.Resources.pngWinWhat;
            btnWin12.Location = new Point(524, 231);
            btnWin12.Margin = new Padding(3, 2, 3, 2);
            btnWin12.Name = "btnWin12";
            btnWin12.Size = new Size(304, 68);
            btnWin12.TabIndex = 10;
            btnWin12.Text = "Windows 12";
            btnWin12.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin12.UseVisualStyleBackColor = true;
            // 
            // lblInfoWin12
            // 
            lblInfoWin12.AutoSize = true;
            lblInfoWin12.Font = new Font("Microsoft Sans Serif", 23.9999981F, FontStyle.Italic);
            lblInfoWin12.ForeColor = Color.Coral;
            lblInfoWin12.Location = new Point(589, 301);
            lblInfoWin12.Name = "lblInfoWin12";
            lblInfoWin12.Size = new Size(209, 37);
            lblInfoWin12.TabIndex = 79;
            lblInfoWin12.Text = "coming soon!\r\n";
            lblInfoWin12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAttivaWin
            // 
            btnAttivaWin.Cursor = Cursors.Hand;
            btnAttivaWin.FlatAppearance.BorderSize = 0;
            btnAttivaWin.FlatStyle = FlatStyle.Flat;
            btnAttivaWin.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAttivaWin.ForeColor = Color.White;
            btnAttivaWin.Image = (Image)resources.GetObject("btnAttivaWin.Image");
            btnAttivaWin.Location = new Point(516, 364);
            btnAttivaWin.Margin = new Padding(3, 2, 3, 2);
            btnAttivaWin.Name = "btnAttivaWin";
            btnAttivaWin.Size = new Size(366, 66);
            btnAttivaWin.TabIndex = 81;
            btnAttivaWin.Text = "Attiva Windows";
            btnAttivaWin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAttivaWin.UseVisualStyleBackColor = true;
            btnAttivaWin.Click += btnAttivaWin_Click;
            // 
            // btnCambioEdizione
            // 
            btnCambioEdizione.Cursor = Cursors.Hand;
            btnCambioEdizione.FlatAppearance.BorderSize = 0;
            btnCambioEdizione.FlatStyle = FlatStyle.Flat;
            btnCambioEdizione.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCambioEdizione.ForeColor = Color.White;
            btnCambioEdizione.Image = (Image)resources.GetObject("btnCambioEdizione.Image");
            btnCambioEdizione.Location = new Point(95, 364);
            btnCambioEdizione.Margin = new Padding(3, 2, 3, 2);
            btnCambioEdizione.Name = "btnCambioEdizione";
            btnCambioEdizione.Size = new Size(389, 66);
            btnCambioEdizione.TabIndex = 82;
            btnCambioEdizione.Text = "Cambio Edizione";
            btnCambioEdizione.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCambioEdizione.UseVisualStyleBackColor = true;
            btnCambioEdizione.Click += btnCambioEdizione_Click;
            // 
            // FormWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
            Controls.Add(btnCambioEdizione);
            Controls.Add(btnAttivaWin);
            Controls.Add(lblInfoWin12);
            Controls.Add(btnWin12);
            Controls.Add(btnWinLive);
            Controls.Add(btnWin11);
            Controls.Add(btnWin10);
            Controls.Add(btnWin8dot1);
            Controls.Add(btnWin7);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormWin";
            Text = "FormWin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnWin7;
        private Button btnWin8dot1;
        private Button btnWin11;
        private Button btnWin10;
        private Button btnWinLive;
        private Button btnWin12;
        private Label lblInfoWin12;
        private Button btnAttivaWin;
        private Button btnCambioEdizione;
    }
}
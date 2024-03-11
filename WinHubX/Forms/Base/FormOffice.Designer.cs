namespace WinHubX
{
    partial class FormOffice
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
            lblHashInfo = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            lblOffice2019 = new Label();
            btn2019Online = new Button();
            btn2019Offline = new Button();
            btn2021Offline = new Button();
            btn2021Online = new Button();
            lblOffice2021 = new Label();
            btn2024Offline = new Button();
            btn2024Online = new Button();
            lblOffice2024 = new Label();
            btn365Offline = new Button();
            btn365Online = new Button();
            lblOffice365 = new Label();
            lblInfoOffice2024 = new Label();
            btnAttivaOffice = new Button();
            btnScrubber = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblHashInfo
            // 
            lblHashInfo.AutoSize = true;
            lblHashInfo.Font = new Font("Microsoft Sans Serif", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHashInfo.ForeColor = Color.Coral;
            lblHashInfo.Location = new Point(292, 539);
            lblHashInfo.Name = "lblHashInfo";
            lblHashInfo.Size = new Size(453, 20);
            lblHashInfo.TabIndex = 64;
            lblHashInfo.Text = "usa il tasto destro sui bottoni per copiare il codice SHA256!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.pngOffice;
            pictureBox1.Location = new Point(951, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(67, 69);
            pictureBox1.TabIndex = 63;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.png365;
            pictureBox2.Location = new Point(878, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(67, 69);
            pictureBox2.TabIndex = 65;
            pictureBox2.TabStop = false;
            // 
            // lblOffice2019
            // 
            lblOffice2019.AutoSize = true;
            lblOffice2019.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOffice2019.ForeColor = Color.White;
            lblOffice2019.Image = Properties.Resources.pngOffice;
            lblOffice2019.ImageAlign = ContentAlignment.MiddleLeft;
            lblOffice2019.Location = new Point(37, 117);
            lblOffice2019.Name = "lblOffice2019";
            lblOffice2019.Size = new Size(225, 102);
            lblOffice2019.TabIndex = 66;
            lblOffice2019.Text = "       Office\r\n       2019";
            lblOffice2019.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn2019Online
            // 
            btn2019Online.Cursor = Cursors.Hand;
            btn2019Online.FlatAppearance.BorderSize = 0;
            btn2019Online.FlatStyle = FlatStyle.Flat;
            btn2019Online.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn2019Online.ForeColor = Color.White;
            btn2019Online.Image = Properties.Resources.pngOnline;
            btn2019Online.ImageAlign = ContentAlignment.MiddleLeft;
            btn2019Online.Location = new Point(37, 240);
            btn2019Online.Name = "btn2019Online";
            btn2019Online.Size = new Size(211, 71);
            btn2019Online.TabIndex = 67;
            btn2019Online.Text = "   Online";
            btn2019Online.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn2019Online.UseVisualStyleBackColor = true;
            btn2019Online.MouseUp += btn2019Online_MouseUp;
            // 
            // btn2019Offline
            // 
            btn2019Offline.Cursor = Cursors.Hand;
            btn2019Offline.FlatAppearance.BorderSize = 0;
            btn2019Offline.FlatStyle = FlatStyle.Flat;
            btn2019Offline.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn2019Offline.ForeColor = Color.White;
            btn2019Offline.Image = Properties.Resources.pngOffline;
            btn2019Offline.Location = new Point(37, 317);
            btn2019Offline.Name = "btn2019Offline";
            btn2019Offline.Size = new Size(211, 71);
            btn2019Offline.TabIndex = 68;
            btn2019Offline.Text = "   Offline";
            btn2019Offline.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn2019Offline.UseVisualStyleBackColor = true;
            btn2019Offline.MouseUp += btn2019Offline_MouseUp;
            // 
            // btn2021Offline
            // 
            btn2021Offline.Cursor = Cursors.Hand;
            btn2021Offline.FlatAppearance.BorderSize = 0;
            btn2021Offline.FlatStyle = FlatStyle.Flat;
            btn2021Offline.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn2021Offline.ForeColor = Color.White;
            btn2021Offline.Image = Properties.Resources.pngOffline;
            btn2021Offline.Location = new Point(285, 317);
            btn2021Offline.Name = "btn2021Offline";
            btn2021Offline.Size = new Size(211, 71);
            btn2021Offline.TabIndex = 71;
            btn2021Offline.Text = "   Offline";
            btn2021Offline.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn2021Offline.UseVisualStyleBackColor = true;
            btn2021Offline.MouseUp += btn2021Offline_MouseUp;
            // 
            // btn2021Online
            // 
            btn2021Online.Cursor = Cursors.Hand;
            btn2021Online.FlatAppearance.BorderSize = 0;
            btn2021Online.FlatStyle = FlatStyle.Flat;
            btn2021Online.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn2021Online.ForeColor = Color.White;
            btn2021Online.Image = Properties.Resources.pngOnline;
            btn2021Online.ImageAlign = ContentAlignment.MiddleLeft;
            btn2021Online.Location = new Point(285, 240);
            btn2021Online.Name = "btn2021Online";
            btn2021Online.Size = new Size(211, 71);
            btn2021Online.TabIndex = 70;
            btn2021Online.Text = "   Online";
            btn2021Online.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn2021Online.UseVisualStyleBackColor = true;
            btn2021Online.Click += btn2021Online_Click;
            btn2021Online.MouseUp += btn2021Online_MouseUp;
            // 
            // lblOffice2021
            // 
            lblOffice2021.AutoSize = true;
            lblOffice2021.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOffice2021.ForeColor = Color.White;
            lblOffice2021.Image = Properties.Resources.pngOffice;
            lblOffice2021.ImageAlign = ContentAlignment.MiddleLeft;
            lblOffice2021.Location = new Point(285, 117);
            lblOffice2021.Name = "lblOffice2021";
            lblOffice2021.Size = new Size(225, 102);
            lblOffice2021.TabIndex = 69;
            lblOffice2021.Text = "       Office\r\n       2021";
            lblOffice2021.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn2024Offline
            // 
            btn2024Offline.Cursor = Cursors.Hand;
            btn2024Offline.Enabled = false;
            btn2024Offline.FlatAppearance.BorderSize = 0;
            btn2024Offline.FlatStyle = FlatStyle.Flat;
            btn2024Offline.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn2024Offline.ForeColor = Color.White;
            btn2024Offline.Image = Properties.Resources.pngOffline;
            btn2024Offline.Location = new Point(782, 317);
            btn2024Offline.Name = "btn2024Offline";
            btn2024Offline.Size = new Size(211, 71);
            btn2024Offline.TabIndex = 77;
            btn2024Offline.Text = "   Offline";
            btn2024Offline.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn2024Offline.UseVisualStyleBackColor = true;
            btn2024Offline.MouseUp += btn2024Offline_MouseUp;
            // 
            // btn2024Online
            // 
            btn2024Online.Cursor = Cursors.Hand;
            btn2024Online.Enabled = false;
            btn2024Online.FlatAppearance.BorderSize = 0;
            btn2024Online.FlatStyle = FlatStyle.Flat;
            btn2024Online.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn2024Online.ForeColor = Color.White;
            btn2024Online.Image = Properties.Resources.pngOnline;
            btn2024Online.ImageAlign = ContentAlignment.MiddleLeft;
            btn2024Online.Location = new Point(782, 240);
            btn2024Online.Name = "btn2024Online";
            btn2024Online.Size = new Size(211, 71);
            btn2024Online.TabIndex = 76;
            btn2024Online.Text = "   Online";
            btn2024Online.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn2024Online.UseVisualStyleBackColor = true;
            btn2024Online.MouseUp += btn2024Online_MouseUp;
            // 
            // lblOffice2024
            // 
            lblOffice2024.AutoSize = true;
            lblOffice2024.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOffice2024.ForeColor = Color.White;
            lblOffice2024.Image = Properties.Resources.pngOffice;
            lblOffice2024.ImageAlign = ContentAlignment.MiddleLeft;
            lblOffice2024.Location = new Point(782, 117);
            lblOffice2024.Name = "lblOffice2024";
            lblOffice2024.Size = new Size(225, 102);
            lblOffice2024.TabIndex = 75;
            lblOffice2024.Text = "       Office\r\n       2024";
            lblOffice2024.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn365Offline
            // 
            btn365Offline.Cursor = Cursors.Hand;
            btn365Offline.FlatAppearance.BorderSize = 0;
            btn365Offline.FlatStyle = FlatStyle.Flat;
            btn365Offline.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn365Offline.ForeColor = Color.White;
            btn365Offline.Image = Properties.Resources.pngOffline;
            btn365Offline.Location = new Point(534, 317);
            btn365Offline.Name = "btn365Offline";
            btn365Offline.Size = new Size(211, 71);
            btn365Offline.TabIndex = 74;
            btn365Offline.Text = "   Offline";
            btn365Offline.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn365Offline.UseVisualStyleBackColor = true;
            btn365Offline.MouseUp += btn365Offline_MouseUp;
            // 
            // btn365Online
            // 
            btn365Online.Cursor = Cursors.Hand;
            btn365Online.FlatAppearance.BorderSize = 0;
            btn365Online.FlatStyle = FlatStyle.Flat;
            btn365Online.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn365Online.ForeColor = Color.White;
            btn365Online.Image = Properties.Resources.pngOnline;
            btn365Online.ImageAlign = ContentAlignment.MiddleLeft;
            btn365Online.Location = new Point(534, 240);
            btn365Online.Name = "btn365Online";
            btn365Online.Size = new Size(211, 71);
            btn365Online.TabIndex = 73;
            btn365Online.Text = "   Online";
            btn365Online.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn365Online.UseVisualStyleBackColor = true;
            btn365Online.MouseUp += btn365Online_MouseUp;
            // 
            // lblOffice365
            // 
            lblOffice365.AutoSize = true;
            lblOffice365.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOffice365.ForeColor = Color.White;
            lblOffice365.Image = Properties.Resources.png365;
            lblOffice365.ImageAlign = ContentAlignment.MiddleLeft;
            lblOffice365.Location = new Point(534, 117);
            lblOffice365.Name = "lblOffice365";
            lblOffice365.Size = new Size(225, 102);
            lblOffice365.TabIndex = 72;
            lblOffice365.Text = "       Office\r\n       365";
            lblOffice365.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblInfoOffice2024
            // 
            lblInfoOffice2024.AutoSize = true;
            lblInfoOffice2024.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfoOffice2024.ForeColor = Color.Coral;
            lblInfoOffice2024.Location = new Point(799, 391);
            lblInfoOffice2024.Name = "lblInfoOffice2024";
            lblInfoOffice2024.Size = new Size(193, 36);
            lblInfoOffice2024.TabIndex = 78;
            lblInfoOffice2024.Text = "coming soon!\r\n";
            lblInfoOffice2024.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAttivaOffice
            // 
            btnAttivaOffice.Cursor = Cursors.Hand;
            btnAttivaOffice.FlatAppearance.BorderSize = 0;
            btnAttivaOffice.FlatStyle = FlatStyle.Flat;
            btnAttivaOffice.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btnAttivaOffice.ForeColor = Color.White;
            btnAttivaOffice.Image = Properties.Resources.pngOnline;
            btnAttivaOffice.ImageAlign = ContentAlignment.MiddleLeft;
            btnAttivaOffice.Location = new Point(562, 455);
            btnAttivaOffice.Name = "btnAttivaOffice";
            btnAttivaOffice.Size = new Size(313, 71);
            btnAttivaOffice.TabIndex = 79;
            btnAttivaOffice.Text = "   Attiva Office";
            btnAttivaOffice.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAttivaOffice.UseVisualStyleBackColor = true;
            btnAttivaOffice.Click += btnAttivaOffice_Click;
            // 
            // btnScrubber
            // 
            btnScrubber.Cursor = Cursors.Hand;
            btnScrubber.FlatAppearance.BorderSize = 0;
            btnScrubber.FlatStyle = FlatStyle.Flat;
            btnScrubber.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btnScrubber.ForeColor = Color.White;
            btnScrubber.Image = Properties.Resources.pngOnline;
            btnScrubber.ImageAlign = ContentAlignment.MiddleLeft;
            btnScrubber.Location = new Point(148, 455);
            btnScrubber.Name = "btnScrubber";
            btnScrubber.Size = new Size(383, 71);
            btnScrubber.TabIndex = 80;
            btnScrubber.Text = "   Disinstalla Office";
            btnScrubber.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnScrubber.UseVisualStyleBackColor = true;
            btnScrubber.Click += btnScrubber_Click;
            // 
            // FormOffice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1030, 570);
            Controls.Add(btnScrubber);
            Controls.Add(btnAttivaOffice);
            Controls.Add(lblInfoOffice2024);
            Controls.Add(btn2024Offline);
            Controls.Add(btn2024Online);
            Controls.Add(lblOffice2024);
            Controls.Add(btn365Offline);
            Controls.Add(btn365Online);
            Controls.Add(lblOffice365);
            Controls.Add(btn2021Offline);
            Controls.Add(btn2021Online);
            Controls.Add(lblOffice2021);
            Controls.Add(btn2019Offline);
            Controls.Add(btn2019Online);
            Controls.Add(lblOffice2019);
            Controls.Add(pictureBox2);
            Controls.Add(lblHashInfo);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormOffice";
            Text = "FormOffice";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHashInfo;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblOffice2019;
        private Button btn2019Online;
        private Button btn2019Offline;
        private Button btn2021Offline;
        private Button btn2021Online;
        private Label lblOffice2021;
        private Button btn2024Offline;
        private Button btn2024Online;
        private Label lblOffice2024;
        private Button btn365Offline;
        private Button btn365Online;
        private Label lblOffice365;
        private Label lblInfoOffice2024;
        private Button btnAttivaOffice;
        private Button btnScrubber;
    }
}
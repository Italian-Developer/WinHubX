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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOffice));
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
            btnAttivaOffice = new Button();
            btnScrubber = new Button();
            pictureBox3 = new PictureBox();
            btnPersonalizzaOffice = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lblHashInfo
            // 
            lblHashInfo.AutoSize = true;
            lblHashInfo.Font = new Font("Microsoft Sans Serif", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHashInfo.ForeColor = Color.Coral;
            lblHashInfo.Location = new Point(256, 420);
            lblHashInfo.Name = "lblHashInfo";
            lblHashInfo.Size = new Size(379, 17);
            lblHashInfo.TabIndex = 64;
            lblHashInfo.Text = "usa il tasto destro sui bottoni per copiare il codice SHA256!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.pngOffice;
            pictureBox1.Location = new Point(847, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 63;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.png365;
            pictureBox2.Location = new Point(793, 9);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 53);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
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
            lblOffice2019.Location = new Point(32, 93);
            lblOffice2019.Name = "lblOffice2019";
            lblOffice2019.Size = new Size(185, 78);
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
            btn2019Online.Location = new Point(32, 180);
            btn2019Online.Margin = new Padding(3, 2, 3, 2);
            btn2019Online.Name = "btn2019Online";
            btn2019Online.Size = new Size(185, 63);
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
            btn2019Offline.Location = new Point(32, 238);
            btn2019Offline.Margin = new Padding(3, 2, 3, 2);
            btn2019Offline.Name = "btn2019Offline";
            btn2019Offline.Size = new Size(185, 63);
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
            btn2021Offline.Location = new Point(249, 243);
            btn2021Offline.Margin = new Padding(3, 2, 3, 2);
            btn2021Offline.Name = "btn2021Offline";
            btn2021Offline.Size = new Size(185, 63);
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
            btn2021Online.Location = new Point(249, 180);
            btn2021Online.Margin = new Padding(3, 2, 3, 2);
            btn2021Online.Name = "btn2021Online";
            btn2021Online.Size = new Size(185, 63);
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
            lblOffice2021.Location = new Point(249, 93);
            lblOffice2021.Name = "lblOffice2021";
            lblOffice2021.Size = new Size(185, 78);
            lblOffice2021.TabIndex = 69;
            lblOffice2021.Text = "       Office\r\n       2021";
            lblOffice2021.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn2024Offline
            // 
            btn2024Offline.Cursor = Cursors.Hand;
            btn2024Offline.FlatAppearance.BorderSize = 0;
            btn2024Offline.FlatStyle = FlatStyle.Flat;
            btn2024Offline.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn2024Offline.ForeColor = Color.White;
            btn2024Offline.Image = Properties.Resources.pngOffline;
            btn2024Offline.Location = new Point(684, 243);
            btn2024Offline.Margin = new Padding(3, 2, 3, 2);
            btn2024Offline.Name = "btn2024Offline";
            btn2024Offline.Size = new Size(185, 58);
            btn2024Offline.TabIndex = 77;
            btn2024Offline.Text = "   Offline";
            btn2024Offline.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn2024Offline.UseVisualStyleBackColor = true;
            btn2024Offline.MouseUp += btn2024Offline_MouseUp;
            // 
            // btn2024Online
            // 
            btn2024Online.Cursor = Cursors.Hand;
            btn2024Online.FlatAppearance.BorderSize = 0;
            btn2024Online.FlatStyle = FlatStyle.Flat;
            btn2024Online.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btn2024Online.ForeColor = Color.White;
            btn2024Online.Image = Properties.Resources.pngOnline;
            btn2024Online.ImageAlign = ContentAlignment.MiddleLeft;
            btn2024Online.Location = new Point(684, 185);
            btn2024Online.Margin = new Padding(3, 2, 3, 2);
            btn2024Online.Name = "btn2024Online";
            btn2024Online.Size = new Size(185, 59);
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
            lblOffice2024.Image = (Image)resources.GetObject("lblOffice2024.Image");
            lblOffice2024.ImageAlign = ContentAlignment.MiddleLeft;
            lblOffice2024.Location = new Point(684, 93);
            lblOffice2024.Name = "lblOffice2024";
            lblOffice2024.Size = new Size(185, 78);
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
            btn365Offline.Location = new Point(467, 243);
            btn365Offline.Margin = new Padding(3, 2, 3, 2);
            btn365Offline.Name = "btn365Offline";
            btn365Offline.Size = new Size(185, 63);
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
            btn365Online.Location = new Point(467, 185);
            btn365Online.Margin = new Padding(3, 2, 3, 2);
            btn365Online.Name = "btn365Online";
            btn365Online.Size = new Size(185, 58);
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
            lblOffice365.Location = new Point(467, 93);
            lblOffice365.Name = "lblOffice365";
            lblOffice365.Size = new Size(185, 78);
            lblOffice365.TabIndex = 72;
            lblOffice365.Text = "       Office\r\n       365";
            lblOffice365.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnAttivaOffice
            // 
            btnAttivaOffice.Cursor = Cursors.Hand;
            btnAttivaOffice.FlatAppearance.BorderSize = 0;
            btnAttivaOffice.FlatStyle = FlatStyle.Flat;
            btnAttivaOffice.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btnAttivaOffice.ForeColor = Color.White;
            btnAttivaOffice.Image = (Image)resources.GetObject("btnAttivaOffice.Image");
            btnAttivaOffice.ImageAlign = ContentAlignment.MiddleLeft;
            btnAttivaOffice.Location = new Point(481, 348);
            btnAttivaOffice.Margin = new Padding(3, 2, 3, 2);
            btnAttivaOffice.Name = "btnAttivaOffice";
            btnAttivaOffice.Size = new Size(274, 53);
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
            btnScrubber.Image = (Image)resources.GetObject("btnScrubber.Image");
            btnScrubber.ImageAlign = ContentAlignment.MiddleLeft;
            btnScrubber.Location = new Point(119, 348);
            btnScrubber.Margin = new Padding(3, 2, 3, 2);
            btnScrubber.Name = "btnScrubber";
            btnScrubber.Size = new Size(335, 53);
            btnScrubber.TabIndex = 80;
            btnScrubber.Text = "   Disinstalla Office";
            btnScrubber.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnScrubber.UseVisualStyleBackColor = true;
            btnScrubber.Click += btnScrubber_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(734, 9);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(53, 53);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 81;
            pictureBox3.TabStop = false;
            // 
            // btnPersonalizzaOffice
            // 
            btnPersonalizzaOffice.Cursor = Cursors.Hand;
            btnPersonalizzaOffice.FlatAppearance.BorderSize = 0;
            btnPersonalizzaOffice.FlatStyle = FlatStyle.Flat;
            btnPersonalizzaOffice.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold);
            btnPersonalizzaOffice.ForeColor = Color.White;
            btnPersonalizzaOffice.Image = (Image)resources.GetObject("btnPersonalizzaOffice.Image");
            btnPersonalizzaOffice.ImageAlign = ContentAlignment.MiddleLeft;
            btnPersonalizzaOffice.Location = new Point(32, 9);
            btnPersonalizzaOffice.Margin = new Padding(3, 2, 3, 2);
            btnPersonalizzaOffice.Name = "btnPersonalizzaOffice";
            btnPersonalizzaOffice.Size = new Size(369, 53);
            btnPersonalizzaOffice.TabIndex = 82;
            btnPersonalizzaOffice.Text = "   Personalizza Office";
            btnPersonalizzaOffice.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPersonalizzaOffice.UseVisualStyleBackColor = true;
            btnPersonalizzaOffice.Click += btnPersonalizzaOffice_Click;
            // 
            // FormOffice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
            Controls.Add(btnPersonalizzaOffice);
            Controls.Add(pictureBox3);
            Controls.Add(btnScrubber);
            Controls.Add(btnAttivaOffice);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormOffice";
            Text = "FormOffice";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
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
        private Button btnAttivaOffice;
        private Button btnScrubber;
        private PictureBox pictureBox3;
        private Button btnPersonalizzaOffice;
    }
}
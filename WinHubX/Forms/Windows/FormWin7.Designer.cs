namespace WinHubX
{
    partial class FormWin7
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
            btnBack = new Button();
            pictureBox1 = new PictureBox();
            lblWin7AiO = new Label();
            btnWin7AIO64 = new Button();
            btnWin7AIO32 = new Button();
            lblInfoWin7AIO = new Label();
            lblInfoWin7Lite = new Label();
            btnWin7Lite64 = new Button();
            btnWin7Lite32 = new Button();
            lblWin7Lite = new Label();
            btnInfoWin7Lite = new Label();
            lblHashInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Location = new Point(10, 9);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(48, 41);
            btnBack.TabIndex = 5;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.pngWin7;
            pictureBox1.Location = new Point(832, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(59, 59);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // lblWin7AiO
            // 
            lblWin7AiO.AutoSize = true;
            lblWin7AiO.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWin7AiO.ForeColor = Color.White;
            lblWin7AiO.Location = new Point(245, 58);
            lblWin7AiO.Name = "lblWin7AiO";
            lblWin7AiO.Size = new Size(369, 39);
            lblWin7AiO.TabIndex = 12;
            lblWin7AiO.Text = "Windows 7 Stock AiO";
            // 
            // btnWin7AIO64
            // 
            btnWin7AIO64.Cursor = Cursors.Hand;
            btnWin7AIO64.FlatAppearance.BorderSize = 0;
            btnWin7AIO64.FlatStyle = FlatStyle.Flat;
            btnWin7AIO64.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin7AIO64.ForeColor = Color.White;
            btnWin7AIO64.Location = new Point(472, 159);
            btnWin7AIO64.Margin = new Padding(3, 2, 3, 2);
            btnWin7AIO64.Name = "btnWin7AIO64";
            btnWin7AIO64.Size = new Size(136, 53);
            btnWin7AIO64.TabIndex = 17;
            btnWin7AIO64.Text = "64bit";
            btnWin7AIO64.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin7AIO64.UseVisualStyleBackColor = true;
            btnWin7AIO64.MouseUp += btnWin7AIO64_MouseUp;
            // 
            // btnWin7AIO32
            // 
            btnWin7AIO32.Cursor = Cursors.Hand;
            btnWin7AIO32.FlatAppearance.BorderSize = 0;
            btnWin7AIO32.FlatStyle = FlatStyle.Flat;
            btnWin7AIO32.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin7AIO32.ForeColor = Color.White;
            btnWin7AIO32.Location = new Point(292, 159);
            btnWin7AIO32.Margin = new Padding(3, 2, 3, 2);
            btnWin7AIO32.Name = "btnWin7AIO32";
            btnWin7AIO32.Size = new Size(136, 53);
            btnWin7AIO32.TabIndex = 16;
            btnWin7AIO32.Text = "32bit";
            btnWin7AIO32.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin7AIO32.UseVisualStyleBackColor = true;
            btnWin7AIO32.MouseUp += btnWin7AIO32_MouseUp;
            // 
            // lblInfoWin7AIO
            // 
            lblInfoWin7AIO.AutoSize = true;
            lblInfoWin7AIO.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfoWin7AIO.ForeColor = Color.Coral;
            lblInfoWin7AIO.Location = new Point(180, 100);
            lblInfoWin7AIO.Name = "lblInfoWin7AIO";
            lblInfoWin7AIO.Size = new Size(497, 58);
            lblInfoWin7AIO.TabIndex = 18;
            lblInfoWin7AIO.Text = "Edizioni incluse: HomeBasic, HomePremium,\r\nProfessional, Enterprise e Ultimate";
            lblInfoWin7AIO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInfoWin7Lite
            // 
            lblInfoWin7Lite.AutoSize = true;
            lblInfoWin7Lite.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfoWin7Lite.ForeColor = Color.Coral;
            lblInfoWin7Lite.Location = new Point(187, 294);
            lblInfoWin7Lite.Name = "lblInfoWin7Lite";
            lblInfoWin7Lite.Size = new Size(448, 29);
            lblInfoWin7Lite.TabIndex = 22;
            lblInfoWin7Lite.Text = "Per il dettaglio su questa versione, clicca";
            // 
            // btnWin7Lite64
            // 
            btnWin7Lite64.Cursor = Cursors.Hand;
            btnWin7Lite64.FlatAppearance.BorderSize = 0;
            btnWin7Lite64.FlatStyle = FlatStyle.Flat;
            btnWin7Lite64.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin7Lite64.ForeColor = Color.White;
            btnWin7Lite64.Location = new Point(472, 325);
            btnWin7Lite64.Margin = new Padding(3, 2, 3, 2);
            btnWin7Lite64.Name = "btnWin7Lite64";
            btnWin7Lite64.Size = new Size(136, 53);
            btnWin7Lite64.TabIndex = 21;
            btnWin7Lite64.Text = "64bit";
            btnWin7Lite64.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin7Lite64.UseVisualStyleBackColor = true;
            btnWin7Lite64.MouseUp += btnWin7Lite64_MouseUp;
            // 
            // btnWin7Lite32
            // 
            btnWin7Lite32.Cursor = Cursors.Hand;
            btnWin7Lite32.FlatAppearance.BorderSize = 0;
            btnWin7Lite32.FlatStyle = FlatStyle.Flat;
            btnWin7Lite32.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin7Lite32.ForeColor = Color.White;
            btnWin7Lite32.Location = new Point(292, 325);
            btnWin7Lite32.Margin = new Padding(3, 2, 3, 2);
            btnWin7Lite32.Name = "btnWin7Lite32";
            btnWin7Lite32.Size = new Size(136, 53);
            btnWin7Lite32.TabIndex = 20;
            btnWin7Lite32.Text = "32bit";
            btnWin7Lite32.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin7Lite32.UseVisualStyleBackColor = true;
            btnWin7Lite32.MouseUp += btnWin7Lite32_MouseUp;
            // 
            // lblWin7Lite
            // 
            lblWin7Lite.AutoSize = true;
            lblWin7Lite.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWin7Lite.ForeColor = Color.White;
            lblWin7Lite.Location = new Point(225, 255);
            lblWin7Lite.Name = "lblWin7Lite";
            lblWin7Lite.Size = new Size(412, 39);
            lblWin7Lite.TabIndex = 19;
            lblWin7Lite.Text = "Windows 7 Ultimate Lite";
            // 
            // btnInfoWin7Lite
            // 
            btnInfoWin7Lite.AutoSize = true;
            btnInfoWin7Lite.Cursor = Cursors.Hand;
            btnInfoWin7Lite.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnInfoWin7Lite.ForeColor = Color.Coral;
            btnInfoWin7Lite.Location = new Point(666, 294);
            btnInfoWin7Lite.Name = "btnInfoWin7Lite";
            btnInfoWin7Lite.Size = new Size(46, 29);
            btnInfoWin7Lite.TabIndex = 25;
            btnInfoWin7Lite.Text = "qui";
            btnInfoWin7Lite.Click += infoWin7Lite_Click;
            // 
            // lblHashInfo
            // 
            lblHashInfo.AutoSize = true;
            lblHashInfo.Font = new Font("Microsoft Sans Serif", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHashInfo.ForeColor = Color.Coral;
            lblHashInfo.Location = new Point(257, 416);
            lblHashInfo.Name = "lblHashInfo";
            lblHashInfo.Size = new Size(379, 17);
            lblHashInfo.TabIndex = 26;
            lblHashInfo.Text = "usa il tasto destro sui bottoni per copiare il codice SHA256!";
            // 
            // FormWin7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
            Controls.Add(lblHashInfo);
            Controls.Add(btnInfoWin7Lite);
            Controls.Add(lblInfoWin7Lite);
            Controls.Add(btnWin7Lite64);
            Controls.Add(btnWin7Lite32);
            Controls.Add(lblWin7Lite);
            Controls.Add(lblInfoWin7AIO);
            Controls.Add(btnWin7AIO64);
            Controls.Add(btnWin7AIO32);
            Controls.Add(lblWin7AiO);
            Controls.Add(pictureBox1);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormWin7";
            Text = "FormWin7";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private PictureBox pictureBox1;
        private Label lblWin7AiO;
        private Button btnWin7AIO64;
        private Button btnWin7AIO32;
        private Label lblInfoWin7AIO;
        private Label lblInfoWin7Lite;
        private Button btnWin7Lite64;
        private Button btnWin7Lite32;
        private Label lblWin7Lite;
        private Label btnInfoWin7Lite;
        private Label lblHashInfo;
    }
}
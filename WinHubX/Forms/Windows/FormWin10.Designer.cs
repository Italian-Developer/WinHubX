
namespace WinHubX.Forms.Windows
{
    partial class FormWin10
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
            btnInfoWin10Lite = new Label();
            lblInfoWin10Lite = new Label();
            btnWin10Lite64 = new Button();
            btnWin10Lite32 = new Button();
            lblWin10Lite = new Label();
            lblInfoWin10AIO = new Label();
            btnWin10AIO64 = new Button();
            btnWin10AIO32 = new Button();
            lblWin10AIO = new Label();
            pictureBox1 = new PictureBox();
            btnBack = new Button();
            label1 = new Label();
            btnWin10ARM64 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblHashInfo
            // 
            lblHashInfo.AutoSize = true;
            lblHashInfo.Font = new Font("Microsoft Sans Serif", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHashInfo.ForeColor = Color.Coral;
            lblHashInfo.Location = new Point(255, 415);
            lblHashInfo.Name = "lblHashInfo";
            lblHashInfo.Size = new Size(379, 17);
            lblHashInfo.TabIndex = 50;
            lblHashInfo.Text = "usa il tasto destro sui bottoni per copiare il codice SHA256!";
            // 
            // btnInfoWin10Lite
            // 
            btnInfoWin10Lite.AutoSize = true;
            btnInfoWin10Lite.Cursor = Cursors.Hand;
            btnInfoWin10Lite.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnInfoWin10Lite.ForeColor = Color.Coral;
            btnInfoWin10Lite.Location = new Point(671, 311);
            btnInfoWin10Lite.Name = "btnInfoWin10Lite";
            btnInfoWin10Lite.Size = new Size(46, 29);
            btnInfoWin10Lite.TabIndex = 49;
            btnInfoWin10Lite.Text = "qui";
            btnInfoWin10Lite.Click += btnInfoWin10Lite_Click;
            // 
            // lblInfoWin10Lite
            // 
            lblInfoWin10Lite.AutoSize = true;
            lblInfoWin10Lite.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfoWin10Lite.ForeColor = Color.Coral;
            lblInfoWin10Lite.Location = new Point(187, 282);
            lblInfoWin10Lite.Name = "lblInfoWin10Lite";
            lblInfoWin10Lite.Size = new Size(448, 58);
            lblInfoWin10Lite.TabIndex = 48;
            lblInfoWin10Lite.Text = "      Edizioni incluse: LTSC\r\nPer il dettaglio su questa versione, clicca";
            lblInfoWin10Lite.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnWin10Lite64
            // 
            btnWin10Lite64.Cursor = Cursors.Hand;
            btnWin10Lite64.FlatAppearance.BorderSize = 0;
            btnWin10Lite64.FlatStyle = FlatStyle.Flat;
            btnWin10Lite64.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin10Lite64.ForeColor = Color.White;
            btnWin10Lite64.Location = new Point(474, 337);
            btnWin10Lite64.Margin = new Padding(3, 2, 3, 2);
            btnWin10Lite64.Name = "btnWin10Lite64";
            btnWin10Lite64.Size = new Size(136, 53);
            btnWin10Lite64.TabIndex = 47;
            btnWin10Lite64.Text = "64bit";
            btnWin10Lite64.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin10Lite64.UseVisualStyleBackColor = true;
            btnWin10Lite64.MouseUp += btnWin10Lite64_MouseUp;
            // 
            // btnWin10Lite32
            // 
            btnWin10Lite32.Cursor = Cursors.Hand;
            btnWin10Lite32.FlatAppearance.BorderSize = 0;
            btnWin10Lite32.FlatStyle = FlatStyle.Flat;
            btnWin10Lite32.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin10Lite32.ForeColor = Color.White;
            btnWin10Lite32.Location = new Point(289, 337);
            btnWin10Lite32.Margin = new Padding(3, 2, 3, 2);
            btnWin10Lite32.Name = "btnWin10Lite32";
            btnWin10Lite32.Size = new Size(136, 53);
            btnWin10Lite32.TabIndex = 46;
            btnWin10Lite32.Text = "32bit";
            btnWin10Lite32.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin10Lite32.UseVisualStyleBackColor = true;
            btnWin10Lite32.MouseUp += btnWin10Lite32_MouseUp;
            // 
            // lblWin10Lite
            // 
            lblWin10Lite.AutoSize = true;
            lblWin10Lite.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWin10Lite.ForeColor = Color.White;
            lblWin10Lite.Location = new Point(283, 240);
            lblWin10Lite.Name = "lblWin10Lite";
            lblWin10Lite.Size = new Size(285, 39);
            lblWin10Lite.TabIndex = 45;
            lblWin10Lite.Text = "Windows 10 Lite";
            // 
            // lblInfoWin10AIO
            // 
            lblInfoWin10AIO.AutoSize = true;
            lblInfoWin10AIO.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfoWin10AIO.ForeColor = Color.Coral;
            lblInfoWin10AIO.Location = new Point(477, 104);
            lblInfoWin10AIO.Name = "lblInfoWin10AIO";
            lblInfoWin10AIO.Size = new Size(392, 29);
            lblInfoWin10AIO.TabIndex = 44;
            lblInfoWin10AIO.Text = "Edizioni incluse: Consumer e LTSC";
            lblInfoWin10AIO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnWin10AIO64
            // 
            btnWin10AIO64.Cursor = Cursors.Hand;
            btnWin10AIO64.FlatAppearance.BorderSize = 0;
            btnWin10AIO64.FlatStyle = FlatStyle.Flat;
            btnWin10AIO64.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin10AIO64.ForeColor = Color.White;
            btnWin10AIO64.Location = new Point(697, 135);
            btnWin10AIO64.Margin = new Padding(3, 2, 3, 2);
            btnWin10AIO64.Name = "btnWin10AIO64";
            btnWin10AIO64.Size = new Size(136, 53);
            btnWin10AIO64.TabIndex = 43;
            btnWin10AIO64.Text = "64bit";
            btnWin10AIO64.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin10AIO64.UseVisualStyleBackColor = true;
            btnWin10AIO64.MouseUp += btnWin10AIO64_MouseUp;
            // 
            // btnWin10AIO32
            // 
            btnWin10AIO32.Cursor = Cursors.Hand;
            btnWin10AIO32.FlatAppearance.BorderSize = 0;
            btnWin10AIO32.FlatStyle = FlatStyle.Flat;
            btnWin10AIO32.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin10AIO32.ForeColor = Color.White;
            btnWin10AIO32.Location = new Point(543, 135);
            btnWin10AIO32.Margin = new Padding(3, 2, 3, 2);
            btnWin10AIO32.Name = "btnWin10AIO32";
            btnWin10AIO32.Size = new Size(136, 53);
            btnWin10AIO32.TabIndex = 42;
            btnWin10AIO32.Text = "32bit";
            btnWin10AIO32.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin10AIO32.UseVisualStyleBackColor = true;
            btnWin10AIO32.MouseUp += btnWin10AIO32_MouseUp;
            // 
            // lblWin10AIO
            // 
            lblWin10AIO.AutoSize = true;
            lblWin10AIO.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWin10AIO.ForeColor = Color.White;
            lblWin10AIO.Location = new Point(245, 66);
            lblWin10AIO.Name = "lblWin10AIO";
            lblWin10AIO.Size = new Size(389, 39);
            lblWin10AIO.TabIndex = 41;
            lblWin10AIO.Text = "Windows 10 Stock AiO";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.pngWin10;
            pictureBox1.Location = new Point(825, 8);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 66);
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Location = new Point(10, 8);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(48, 41);
            btnBack.TabIndex = 39;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Coral;
            label1.Location = new Point(31, 104);
            label1.Name = "label1";
            label1.Size = new Size(382, 29);
            label1.TabIndex = 51;
            label1.Text = "Edizioni incluse: Pro ed Enterprise";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnWin10ARM64
            // 
            btnWin10ARM64.Cursor = Cursors.Hand;
            btnWin10ARM64.FlatAppearance.BorderSize = 0;
            btnWin10ARM64.FlatStyle = FlatStyle.Flat;
            btnWin10ARM64.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin10ARM64.ForeColor = Color.White;
            btnWin10ARM64.Location = new Point(166, 135);
            btnWin10ARM64.Margin = new Padding(3, 2, 3, 2);
            btnWin10ARM64.Name = "btnWin10ARM64";
            btnWin10ARM64.Size = new Size(162, 53);
            btnWin10ARM64.TabIndex = 52;
            btnWin10ARM64.Text = "ARM64";
            btnWin10ARM64.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWin10ARM64.UseVisualStyleBackColor = true;
            btnWin10ARM64.MouseUp += btnWin10ARM64_MouseUp;
            // 
            // FormWin10
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
            Controls.Add(btnWin10ARM64);
            Controls.Add(label1);
            Controls.Add(lblHashInfo);
            Controls.Add(btnInfoWin10Lite);
            Controls.Add(lblInfoWin10Lite);
            Controls.Add(btnWin10Lite64);
            Controls.Add(btnWin10Lite32);
            Controls.Add(lblWin10Lite);
            Controls.Add(lblInfoWin10AIO);
            Controls.Add(btnWin10AIO64);
            Controls.Add(btnWin10AIO32);
            Controls.Add(lblWin10AIO);
            Controls.Add(pictureBox1);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormWin10";
            Text = "FormWin10";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void FormWin10_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lblHashInfo;
        private Label btnInfoWin10Lite;
        private Label lblInfoWin10Lite;
        private Button btnWin10Lite64;
        private Button btnWin10Lite32;
        private Label lblWin10Lite;
        private Label lblInfoWin10AIO;
        private Button btnWin10AIO64;
        private Button btnWin10AIO32;
        private Label lblWin10AIO;
        private PictureBox pictureBox1;
        private Button btnBack;
        private Label label1;
        private Button btnWin10ARM64;
    }
}
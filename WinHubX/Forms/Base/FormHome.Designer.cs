namespace WinHubX
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            imgHomeLogo = new PictureBox();
            lblInfoWinAIO64 = new Label();
            nickSparrow = new PictureBox();
            btnChangelog = new Button();
            btnKofi = new Button();
            tgNico = new Button();
            tgGreg = new Button();
            ((System.ComponentModel.ISupportInitialize)imgHomeLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nickSparrow).BeginInit();
            SuspendLayout();
            // 
            // imgHomeLogo
            // 
            imgHomeLogo.Image = Properties.Resources.homeLogo;
            imgHomeLogo.Location = new Point(680, 0);
            imgHomeLogo.Name = "imgHomeLogo";
            imgHomeLogo.Size = new Size(350, 245);
            imgHomeLogo.TabIndex = 0;
            imgHomeLogo.TabStop = false;
            // 
            // lblInfoWinAIO64
            // 
            lblInfoWinAIO64.AutoSize = true;
            lblInfoWinAIO64.Font = new Font("Product Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoWinAIO64.ForeColor = Color.White;
            lblInfoWinAIO64.Location = new Point(12, 85);
            lblInfoWinAIO64.MaximumSize = new Size(680, 0);
            lblInfoWinAIO64.Name = "lblInfoWinAIO64";
            lblInfoWinAIO64.Size = new Size(677, 324);
            lblInfoWinAIO64.TabIndex = 92;
            lblInfoWinAIO64.Text = resources.GetString("lblInfoWinAIO64.Text");
            lblInfoWinAIO64.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nickSparrow
            // 
            nickSparrow.Image = Properties.Resources.nicksparrow;
            nickSparrow.Location = new Point(680, 321);
            nickSparrow.Name = "nickSparrow";
            nickSparrow.Size = new Size(350, 146);
            nickSparrow.TabIndex = 93;
            nickSparrow.TabStop = false;
            // 
            // btnChangelog
            // 
            btnChangelog.Cursor = Cursors.Hand;
            btnChangelog.FlatAppearance.BorderSize = 0;
            btnChangelog.FlatStyle = FlatStyle.Flat;
            btnChangelog.Font = new Font("Product Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangelog.ForeColor = Color.Coral;
            btnChangelog.Location = new Point(698, 251);
            btnChangelog.Name = "btnChangelog";
            btnChangelog.Size = new Size(320, 64);
            btnChangelog.TabIndex = 94;
            btnChangelog.Text = "v1.0.0.0 - Changelog";
            btnChangelog.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnChangelog.UseVisualStyleBackColor = true;
            btnChangelog.Click += btnChangelog_Click;
            // 
            // btnKofi
            // 
            btnKofi.Cursor = Cursors.Hand;
            btnKofi.FlatAppearance.BorderSize = 0;
            btnKofi.FlatStyle = FlatStyle.Flat;
            btnKofi.Font = new Font("Product Sans", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnKofi.ForeColor = Color.Coral;
            btnKofi.Image = Properties.Resources.pngCoffee;
            btnKofi.Location = new Point(698, 473);
            btnKofi.Name = "btnKofi";
            btnKofi.Size = new Size(320, 85);
            btnKofi.TabIndex = 95;
            btnKofi.Text = "se vuoi sostenere il\r\nprogetto, clicca qui!";
            btnKofi.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnKofi.UseVisualStyleBackColor = true;
            btnKofi.Click += btnKofi_Click;
            // 
            // tgNico
            // 
            tgNico.Cursor = Cursors.Hand;
            tgNico.FlatStyle = FlatStyle.Flat;
            tgNico.Image = Properties.Resources.pngTelegram;
            tgNico.Location = new Point(797, 427);
            tgNico.Name = "tgNico";
            tgNico.Size = new Size(26, 26);
            tgNico.TabIndex = 96;
            tgNico.UseVisualStyleBackColor = true;
            tgNico.Click += tgNico_Click;
            // 
            // tgGreg
            // 
            tgGreg.Cursor = Cursors.Hand;
            tgGreg.FlatStyle = FlatStyle.Flat;
            tgGreg.Image = Properties.Resources.pngTelegram;
            tgGreg.Location = new Point(829, 427);
            tgGreg.Name = "tgGreg";
            tgGreg.Size = new Size(26, 26);
            tgGreg.TabIndex = 97;
            tgGreg.UseVisualStyleBackColor = true;
            tgGreg.Click += tgGreg_Click;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1030, 570);
            Controls.Add(tgGreg);
            Controls.Add(tgNico);
            Controls.Add(btnKofi);
            Controls.Add(btnChangelog);
            Controls.Add(nickSparrow);
            Controls.Add(lblInfoWinAIO64);
            Controls.Add(imgHomeLogo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormHome";
            Text = "FormHome";
            ((System.ComponentModel.ISupportInitialize)imgHomeLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nickSparrow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imgHomeLogo;
        private Label lblInfoWinAIO64;
        private PictureBox nickSparrow;
        private Button btnChangelog;
        private Button btnKofi;
        private Button tgNico;
        private Button tgGreg;
    }
}
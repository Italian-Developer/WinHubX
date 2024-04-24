namespace WinHubX.Forms.Settaggi
{
    partial class FormDefender
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
            DisabilitaDefender = new CheckedListBox();
            btnAvviaSelezionatiDef = new Button();
            btnProtezioneMinima = new Button();
            btnRipristinaDefender = new Button();
            AbilitaDefender = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
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
            btnBack.TabIndex = 7;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // DisabilitaDefender
            // 
            DisabilitaDefender.BackColor = Color.FromArgb(37, 38, 39);
            DisabilitaDefender.BorderStyle = BorderStyle.None;
            DisabilitaDefender.Font = new Font("Segoe UI", 10.2F);
            DisabilitaDefender.ForeColor = Color.White;
            DisabilitaDefender.FormattingEnabled = true;
            DisabilitaDefender.Items.AddRange(new object[] { "Disabilita Controllo Accesso Cartella", "Disabilita Isolamento Core", "Disabilita Applicazione Defender Guard", "Disabilita Protezione Account Warning", "Disabilita Blocco Download Files", "Disabilita Windows Script Host", "Disabilita .NET Strong Cryptography", "Disabilita Meltdown CVE-2017-5754", "Livello Minimo UAC", "Disabilita Implicit Administrative Sheres", "Disabilita Windows Firewall", "Disabilita Windows Defender CLoud", "Disabilita Windows Defender SysTray", "Disabilita Windows Defender Services" });
            DisabilitaDefender.Location = new Point(158, 38);
            DisabilitaDefender.Name = "DisabilitaDefender";
            DisabilitaDefender.Size = new Size(303, 294);
            DisabilitaDefender.TabIndex = 8;
            // 
            // btnAvviaSelezionatiDef
            // 
            btnAvviaSelezionatiDef.Cursor = Cursors.Hand;
            btnAvviaSelezionatiDef.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionatiDef.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionatiDef.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnAvviaSelezionatiDef.ForeColor = Color.White;
            btnAvviaSelezionatiDef.Location = new Point(344, 371);
            btnAvviaSelezionatiDef.Margin = new Padding(3, 2, 3, 2);
            btnAvviaSelezionatiDef.Name = "btnAvviaSelezionatiDef";
            btnAvviaSelezionatiDef.Size = new Size(208, 56);
            btnAvviaSelezionatiDef.TabIndex = 23;
            btnAvviaSelezionatiDef.Text = "Avvia Selezionati";
            btnAvviaSelezionatiDef.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionatiDef.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiDef.Click += btnAvviaSelezionatiDef_Click;
            // 
            // btnProtezioneMinima
            // 
            btnProtezioneMinima.Cursor = Cursors.Hand;
            btnProtezioneMinima.FlatAppearance.BorderSize = 0;
            btnProtezioneMinima.FlatStyle = FlatStyle.Flat;
            btnProtezioneMinima.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnProtezioneMinima.ForeColor = Color.White;
            btnProtezioneMinima.Location = new Point(10, 371);
            btnProtezioneMinima.Margin = new Padding(3, 2, 3, 2);
            btnProtezioneMinima.Name = "btnProtezioneMinima";
            btnProtezioneMinima.Size = new Size(220, 56);
            btnProtezioneMinima.TabIndex = 24;
            btnProtezioneMinima.Text = "Protezione Minima";
            btnProtezioneMinima.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProtezioneMinima.UseVisualStyleBackColor = true;
            btnProtezioneMinima.Click += btnProtezioneMinima_Click;
            // 
            // btnRipristinaDefender
            // 
            btnRipristinaDefender.Cursor = Cursors.Hand;
            btnRipristinaDefender.FlatAppearance.BorderSize = 0;
            btnRipristinaDefender.FlatStyle = FlatStyle.Flat;
            btnRipristinaDefender.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnRipristinaDefender.ForeColor = Color.White;
            btnRipristinaDefender.Location = new Point(659, 371);
            btnRipristinaDefender.Margin = new Padding(3, 2, 3, 2);
            btnRipristinaDefender.Name = "btnRipristinaDefender";
            btnRipristinaDefender.Size = new Size(230, 56);
            btnRipristinaDefender.TabIndex = 26;
            btnRipristinaDefender.Text = "Ripristina Defender";
            btnRipristinaDefender.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRipristinaDefender.UseVisualStyleBackColor = true;
            btnRipristinaDefender.Click += btnRipristinaDefender_Click;
            // 
            // AbilitaDefender
            // 
            AbilitaDefender.BackColor = Color.FromArgb(37, 38, 39);
            AbilitaDefender.BorderStyle = BorderStyle.None;
            AbilitaDefender.Font = new Font("Segoe UI", 10.2F);
            AbilitaDefender.ForeColor = Color.White;
            AbilitaDefender.FormattingEnabled = true;
            AbilitaDefender.Items.AddRange(new object[] { "Abilita Controllo Accesso Cartella", "Abilita Isolamento Core", "Abilita Applicazione Defender Guard", "Abilita Protezione Account Warning", "Abilita Blocco Download Files", "Abilita Windows Script Host", "Abilita .NET Strong Cryptography", "Abilita Meltdown CVE-2017-5754", "Livello Massimo UAC", "Abilita Implicit Administrative Sheres", "Abilita Windows Firewall", "Abilita Windows Defender CLoud", "Abilita Windows Defender SysTray", "Abilita Windows Defender Services" });
            AbilitaDefender.Location = new Point(502, 42);
            AbilitaDefender.Name = "AbilitaDefender";
            AbilitaDefender.Size = new Size(303, 294);
            AbilitaDefender.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(158, 6);
            label1.Name = "label1";
            label1.Size = new Size(263, 31);
            label1.TabIndex = 28;
            label1.Text = "Disabilita Defender";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(502, 6);
            label2.Name = "label2";
            label2.Size = new Size(223, 31);
            label2.TabIndex = 29;
            label2.Text = "Abilita Defender";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Coral;
            label4.Location = new Point(10, 330);
            label4.Name = "label4";
            label4.Size = new Size(138, 39);
            label4.TabIndex = 55;
            label4.Text = "Attenzione!\r\nsarai maggiormente esposto\r\nad eventuali virus";
            label4.TextAlign = ContentAlignment.BottomCenter;
            // 
            // FormDefender
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 428);
            Controls.Add(btnProtezioneMinima);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AbilitaDefender);
            Controls.Add(btnRipristinaDefender);
            Controls.Add(btnAvviaSelezionatiDef);
            Controls.Add(DisabilitaDefender);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormDefender";
            Text = "FormDefender";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private CheckedListBox DisabilitaDefender;
        private Button btnAvviaSelezionatiDef;
        private Button btnProtezioneMinima;
        private Button btnRipristinaDefender;
        private CheckedListBox AbilitaDefender;
        private Label label1;
        private Label label2;
        private Label label4;
    }
}
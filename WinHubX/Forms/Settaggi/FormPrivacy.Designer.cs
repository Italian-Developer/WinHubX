namespace WinHubX.Forms.Settaggi
{
    partial class FormPrivacy
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
            DisabilitaPrivacy = new CheckedListBox();
            btnAvviaSelezionati = new Button();
            lblWin7Lite = new Label();
            label1 = new Label();
            AbilitaPrivacy = new CheckedListBox();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Location = new Point(14, 15);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(55, 55);
            btnBack.TabIndex = 6;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // DisabilitaPrivacy
            // 
            DisabilitaPrivacy.BackColor = Color.FromArgb(37, 38, 39);
            DisabilitaPrivacy.BorderStyle = BorderStyle.None;
            DisabilitaPrivacy.ForeColor = Color.White;
            DisabilitaPrivacy.FormattingEnabled = true;
            DisabilitaPrivacy.Items.AddRange(new object[] { "Disabilita Opzioni Lingua", "Disabilita Suggerimenti App", "Disabilita Telemetria", "Disabilita Tracking", "Disabilita Segnalazione Errori", "Disabilita Tracking Diagnostica", "Disabilita WAP Push Service", "Disbailita Home Group", "Disabilita Assistenza Remota", "Disabilita Storage Check", "Disabilita Superfetch", "Disabilita Ibernazione", "Disabilita Ottimizzazione FullScreen", "Disbailita Schedul Defrag", "Disabilita Xbox Features", "Disabilita Avvio Rapido", "Normal Bandwidth", "Disabilita Auto Manteinance", "Disabilita Spazio Riservato", "Disabilita Tweaks Game DVR", "Disabilita Storia Attivita" });
            DisabilitaPrivacy.Location = new Point(140, 74);
            DisabilitaPrivacy.Margin = new Padding(3, 4, 3, 4);
            DisabilitaPrivacy.Name = "DisabilitaPrivacy";
            DisabilitaPrivacy.Size = new Size(296, 484);
            DisabilitaPrivacy.TabIndex = 7;
            DisabilitaPrivacy.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // btnAvviaSelezionati
            // 
            btnAvviaSelezionati.Cursor = Cursors.Hand;
            btnAvviaSelezionati.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionati.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionati.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionati.ForeColor = Color.White;
            btnAvviaSelezionati.Location = new Point(792, 15);
            btnAvviaSelezionati.Name = "btnAvviaSelezionati";
            btnAvviaSelezionati.Size = new Size(207, 90);
            btnAvviaSelezionati.TabIndex = 22;
            btnAvviaSelezionati.Text = "Avvia Selezionati";
            btnAvviaSelezionati.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionati.UseVisualStyleBackColor = true;
            btnAvviaSelezionati.Click += btnAvviaSelezionati_Click;
            // 
            // lblWin7Lite
            // 
            lblWin7Lite.AutoSize = true;
            lblWin7Lite.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWin7Lite.ForeColor = Color.White;
            lblWin7Lite.Location = new Point(140, 31);
            lblWin7Lite.Name = "lblWin7Lite";
            lblWin7Lite.Size = new Size(296, 39);
            lblWin7Lite.TabIndex = 23;
            lblWin7Lite.Text = "Disabilita Privacy";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(481, 31);
            label1.Name = "label1";
            label1.Size = new Size(247, 39);
            label1.TabIndex = 24;
            label1.Text = "Abilita Privacy";
            // 
            // AbilitaPrivacy
            // 
            AbilitaPrivacy.BackColor = Color.FromArgb(37, 38, 39);
            AbilitaPrivacy.BorderStyle = BorderStyle.None;
            AbilitaPrivacy.ForeColor = Color.White;
            AbilitaPrivacy.FormattingEnabled = true;
            AbilitaPrivacy.Items.AddRange(new object[] { "Abilita Opzioni Lingua", "Abilita Suggerimenti App", "Abilita Telemetria", "Abilita Tracking", "Abilita Segnalazione Errori", "Abilita Tracking Diagnostica", "Abilita WAP Push Service", "Abilita Home Group", "Abilita Assistenza Remota", "Abilita Storage Check", "Abilita Superfetch", "Abilita Ibernazione", "Abilita Ottimizzazione FullScreen", "Abilita Schedul Defrag", "Abilita Xbox Features", "Abilita Avvio Rapido", "All Bandwidth", "Abilita Auto Manteinance", "Abilita Spazio Riservato", "Abilita Tweaks Game DVR", "Abilita Storia Attivita" });
            AbilitaPrivacy.Location = new Point(481, 74);
            AbilitaPrivacy.Margin = new Padding(3, 4, 3, 4);
            AbilitaPrivacy.Name = "AbilitaPrivacy";
            AbilitaPrivacy.Size = new Size(305, 484);
            AbilitaPrivacy.TabIndex = 25;
            // 
            // FormPrivacy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1030, 571);
            Controls.Add(AbilitaPrivacy);
            Controls.Add(label1);
            Controls.Add(lblWin7Lite);
            Controls.Add(btnAvviaSelezionati);
            Controls.Add(DisabilitaPrivacy);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPrivacy";
            Text = "FormPrivacy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private CheckedListBox DisabilitaPrivacy;
        private Button btnAvviaSelezionati;
        private Label lblWin7Lite;
        private Label label1;
        private CheckedListBox AbilitaPrivacy;
    }
}
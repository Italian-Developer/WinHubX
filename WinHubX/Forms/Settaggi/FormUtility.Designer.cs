namespace WinHubX.Forms.Settaggi
{
    partial class FormUtility
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
            DisabilitaUtility = new CheckedListBox();
            AbilitaUtility = new CheckedListBox();
            btnAvviaSelezionatiUti = new Button();
            lblWin7Lite = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(55, 55);
            btnBack.TabIndex = 7;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // DisabilitaUtility
            // 
            DisabilitaUtility.BackColor = Color.FromArgb(37, 38, 39);
            DisabilitaUtility.BorderStyle = BorderStyle.None;
            DisabilitaUtility.ForeColor = Color.White;
            DisabilitaUtility.FormattingEnabled = true;
            DisabilitaUtility.Items.AddRange(new object[] { "Disabilita Background App", "Disabilita Feedback", "Disabilita Advertising ID", "Disabilita Filtro Smart Screen", "Disabilita Wifi Sense", "Disabilita Desktop Remoto", "Disabilita attivazione del Numlock in avvio", "Disabilita News e Interessi", "Disabilita Index File", "Disabilita Edge PDF", "Disabilita Mappe", "Disabilita UWP apps", "Disabilita Esperienze Personalizzate Microsoft" });
            DisabilitaUtility.Location = new Point(106, 180);
            DisabilitaUtility.Margin = new Padding(3, 4, 3, 4);
            DisabilitaUtility.Name = "DisabilitaUtility";
            DisabilitaUtility.Size = new Size(332, 286);
            DisabilitaUtility.TabIndex = 8;
            // 
            // AbilitaUtility
            // 
            AbilitaUtility.BackColor = Color.FromArgb(37, 38, 39);
            AbilitaUtility.BorderStyle = BorderStyle.None;
            AbilitaUtility.ForeColor = Color.White;
            AbilitaUtility.FormattingEnabled = true;
            AbilitaUtility.Items.AddRange(new object[] { "Abilita Background App", "Abilita Feedback", "Abilita Advertising ID", "Abilita Filtro Smart Screen", "Abilita Wifi Sense", "Abilita Desktop Remoto", "Abilita attivazione del Numlock in avvio", "Abilita News e Interessi", "Abilita Risparmio Energetico Personalizzato", "Abilita Mappe", "Abilita UWP apps", "Abilita Esperienze Personalizzate Microsoft", "Migliora uso SSD" });
            AbilitaUtility.Location = new Point(479, 180);
            AbilitaUtility.Margin = new Padding(3, 4, 3, 4);
            AbilitaUtility.Name = "AbilitaUtility";
            AbilitaUtility.Size = new Size(331, 286);
            AbilitaUtility.TabIndex = 9;
            // 
            // btnAvviaSelezionatiUti
            // 
            btnAvviaSelezionatiUti.Cursor = Cursors.Hand;
            btnAvviaSelezionatiUti.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionatiUti.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionatiUti.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionatiUti.ForeColor = Color.White;
            btnAvviaSelezionatiUti.Location = new Point(811, 12);
            btnAvviaSelezionatiUti.Name = "btnAvviaSelezionatiUti";
            btnAvviaSelezionatiUti.Size = new Size(207, 90);
            btnAvviaSelezionatiUti.TabIndex = 23;
            btnAvviaSelezionatiUti.Text = "Avvia Selezionati";
            btnAvviaSelezionatiUti.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionatiUti.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiUti.Click += btnAvviaSelezionatiUti_Click;
            // 
            // lblWin7Lite
            // 
            lblWin7Lite.AutoSize = true;
            lblWin7Lite.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWin7Lite.ForeColor = Color.White;
            lblWin7Lite.Location = new Point(106, 137);
            lblWin7Lite.Name = "lblWin7Lite";
            lblWin7Lite.Size = new Size(268, 39);
            lblWin7Lite.TabIndex = 24;
            lblWin7Lite.Text = "Disabilita Utility";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(479, 137);
            label1.Name = "label1";
            label1.Size = new Size(219, 39);
            label1.TabIndex = 25;
            label1.Text = "Abilita Utility";
            // 
            // FormUtility
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1030, 571);
            Controls.Add(label1);
            Controls.Add(lblWin7Lite);
            Controls.Add(btnAvviaSelezionatiUti);
            Controls.Add(AbilitaUtility);
            Controls.Add(DisabilitaUtility);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUtility";
            Text = "FormUtility";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private CheckedListBox DisabilitaUtility;
        private CheckedListBox AbilitaUtility;
        private Button btnAvviaSelezionatiUti;
        private Label lblWin7Lite;
        private Label label1;
    }
}
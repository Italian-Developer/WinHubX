namespace WinHubX.Forms.Settaggi
{
    partial class FormUpdate
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
            DisabilitaUpdate = new CheckedListBox();
            btnAvviaSelezionatiUpda = new Button();
            AbilitaUpdate = new CheckedListBox();
            label2 = new Label();
            label1 = new Label();
            btnUpdateEssential = new Button();
            btnResetUpdate = new Button();
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
            btnBack.TabIndex = 8;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // DisabilitaUpdate
            // 
            DisabilitaUpdate.BackColor = Color.FromArgb(37, 38, 39);
            DisabilitaUpdate.BorderStyle = BorderStyle.None;
            DisabilitaUpdate.ForeColor = Color.White;
            DisabilitaUpdate.FormattingEnabled = true;
            DisabilitaUpdate.Items.AddRange(new object[] { "Disabilita Download Automatico Windows Update", "Disabilita Update Prodotti Microsoft", "Disabilita Download Driver Windows Update", "Disabilita Riavvio Automatico Windows Update", "Disabilita Notifiche Update" });
            DisabilitaUpdate.Location = new Point(37, 226);
            DisabilitaUpdate.Margin = new Padding(3, 4, 3, 4);
            DisabilitaUpdate.Name = "DisabilitaUpdate";
            DisabilitaUpdate.Size = new Size(387, 110);
            DisabilitaUpdate.TabIndex = 9;
            // 
            // btnAvviaSelezionatiUpda
            // 
            btnAvviaSelezionatiUpda.Cursor = Cursors.Hand;
            btnAvviaSelezionatiUpda.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionatiUpda.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionatiUpda.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionatiUpda.ForeColor = Color.White;
            btnAvviaSelezionatiUpda.Location = new Point(811, 12);
            btnAvviaSelezionatiUpda.Name = "btnAvviaSelezionatiUpda";
            btnAvviaSelezionatiUpda.Size = new Size(207, 90);
            btnAvviaSelezionatiUpda.TabIndex = 24;
            btnAvviaSelezionatiUpda.Text = "Avvia Selezionati";
            btnAvviaSelezionatiUpda.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionatiUpda.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiUpda.Click += btnAvviaSelezionatiUpda_Click;
            // 
            // AbilitaUpdate
            // 
            AbilitaUpdate.BackColor = Color.FromArgb(37, 38, 39);
            AbilitaUpdate.BorderStyle = BorderStyle.None;
            AbilitaUpdate.ForeColor = Color.White;
            AbilitaUpdate.FormattingEnabled = true;
            AbilitaUpdate.Items.AddRange(new object[] { "Abilita Download Automatico Windows Update", "Abilita Update Prodotti Microsoft", "Abilita Download Driver Windows Update", "Abilita Riavvio Automatico Windows Update", "Abilita Notifiche Update" });
            AbilitaUpdate.Location = new Point(447, 226);
            AbilitaUpdate.Margin = new Padding(3, 4, 3, 4);
            AbilitaUpdate.Name = "AbilitaUpdate";
            AbilitaUpdate.Size = new Size(387, 110);
            AbilitaUpdate.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(37, 183);
            label2.Name = "label2";
            label2.Size = new Size(293, 39);
            label2.TabIndex = 30;
            label2.Text = "Disabilita Update";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(447, 183);
            label1.Name = "label1";
            label1.Size = new Size(244, 39);
            label1.TabIndex = 31;
            label1.Text = "Abilita Update";
            // 
            // btnUpdateEssential
            // 
            btnUpdateEssential.Cursor = Cursors.Hand;
            btnUpdateEssential.FlatAppearance.BorderSize = 0;
            btnUpdateEssential.FlatStyle = FlatStyle.Flat;
            btnUpdateEssential.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateEssential.ForeColor = Color.White;
            btnUpdateEssential.Location = new Point(811, 196);
            btnUpdateEssential.Name = "btnUpdateEssential";
            btnUpdateEssential.Size = new Size(207, 90);
            btnUpdateEssential.TabIndex = 32;
            btnUpdateEssential.Text = "Update Essenziale";
            btnUpdateEssential.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdateEssential.UseVisualStyleBackColor = true;
            btnUpdateEssential.Click += btnUpdateEssential_Click;
            // 
            // btnResetUpdate
            // 
            btnResetUpdate.Cursor = Cursors.Hand;
            btnResetUpdate.FlatAppearance.BorderSize = 0;
            btnResetUpdate.FlatStyle = FlatStyle.Flat;
            btnResetUpdate.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResetUpdate.ForeColor = Color.White;
            btnResetUpdate.Location = new Point(811, 407);
            btnResetUpdate.Name = "btnResetUpdate";
            btnResetUpdate.Size = new Size(207, 138);
            btnResetUpdate.TabIndex = 33;
            btnResetUpdate.Text = "Ripristina Windows Update";
            btnResetUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnResetUpdate.UseVisualStyleBackColor = true;
            btnResetUpdate.Click += btnResetUpdate_Click;
            // 
            // FormUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1030, 571);
            Controls.Add(btnResetUpdate);
            Controls.Add(btnUpdateEssential);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(AbilitaUpdate);
            Controls.Add(btnAvviaSelezionatiUpda);
            Controls.Add(DisabilitaUpdate);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUpdate";
            Text = "FormUpdate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private CheckedListBox DisabilitaUpdate;
        private Button btnAvviaSelezionatiUpda;
        private CheckedListBox AbilitaUpdate;
        private Label label2;
        private Label label1;
        private Button btnUpdateEssential;
        private Button btnResetUpdate;
    }
}
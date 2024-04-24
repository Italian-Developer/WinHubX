namespace WinHubX.Forms.ReinstallaAPP
{
    partial class FormReinstallaAPP
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
            btnAvviaSelezionatiApp = new Button();
            App1 = new CheckedListBox();
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
            btnBack.TabIndex = 8;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnAvviaSelezionatiApp
            // 
            btnAvviaSelezionatiApp.Cursor = Cursors.Hand;
            btnAvviaSelezionatiApp.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionatiApp.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionatiApp.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionatiApp.ForeColor = Color.White;
            btnAvviaSelezionatiApp.Location = new Point(737, 9);
            btnAvviaSelezionatiApp.Margin = new Padding(3, 2, 3, 2);
            btnAvviaSelezionatiApp.Name = "btnAvviaSelezionatiApp";
            btnAvviaSelezionatiApp.Size = new Size(154, 61);
            btnAvviaSelezionatiApp.TabIndex = 26;
            btnAvviaSelezionatiApp.Text = "Avvia Selezionati";
            btnAvviaSelezionatiApp.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionatiApp.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiApp.Click += btnAvviaSelezionatiApp_Click;
            // 
            // App1
            // 
            App1.BackColor = Color.FromArgb(37, 38, 39);
            App1.BorderStyle = BorderStyle.None;
            App1.ForeColor = Color.White;
            App1.FormattingEnabled = true;
            App1.Items.AddRange(new object[] { "Microsoft Edge", "Microsoft Store", "Windows Defender" });
            App1.Location = new Point(98, 20);
            App1.Name = "App1";
            App1.Size = new Size(163, 54);
            App1.TabIndex = 25;
            // 
            // FormReinstallaAPP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 428);
            Controls.Add(btnAvviaSelezionatiApp);
            Controls.Add(App1);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormReinstallaAPP";
            Text = "FormReinstallaAPP";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBack;
        private Button btnAvviaSelezionatiApp;
        private CheckedListBox App1;
    }
}
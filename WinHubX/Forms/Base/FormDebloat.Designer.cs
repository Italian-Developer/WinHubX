﻿namespace WinHubX.Forms.Base
{
    partial class FormDebloat
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
            Bloat1 = new CheckedListBox();
            Bloat2 = new CheckedListBox();
            Bloat3 = new CheckedListBox();
            btnAvviaSelezionatiDebloat = new Button();
            btnReinstallaAPP = new Button();
            btnDebloatAuto = new Button();
            SuspendLayout();
            // 
            // Bloat1
            // 
            Bloat1.BackColor = Color.FromArgb(37, 38, 39);
            Bloat1.BorderStyle = BorderStyle.None;
            Bloat1.ForeColor = Color.White;
            Bloat1.FormattingEnabled = true;
            Bloat1.Items.AddRange(new object[] { "Calcolatrice", "Foto", "Canonical", "Xbox TCUI", "Xbox APP", "Xbox Overlay", "Xbox Speech", "Xbox Identity", "Sticky Notes", "MS Paint", "Windows Camera", "HiFi Extension", "Cattura Schermo", "Estensione VP9", "Estensione Web", "Estensione WebpImage", "WindSynthBerry", "MidiBerry", "Slack", "Mixed Reality", "PPI Projection", "Bing News", "Get Help", "Per iniziare", "Messaggi" });
            Bloat1.Location = new Point(32, 7);
            Bloat1.Margin = new Padding(3, 4, 3, 4);
            Bloat1.Name = "Bloat1";
            Bloat1.Size = new Size(186, 550);
            Bloat1.TabIndex = 10;
            // 
            // Bloat2
            // 
            Bloat2.BackColor = Color.FromArgb(37, 38, 39);
            Bloat2.BorderStyle = BorderStyle.None;
            Bloat2.ForeColor = Color.White;
            Bloat2.FormattingEnabled = true;
            Bloat2.Items.AddRange(new object[] { "Microsoft 3D Viewer", "Microsoft Office Hub", "Solitario", "Network Speed Test", "Microsoft News", "Office Lens", "One Note", "Office Sway", "One Connect", "Microsoft People", "Paint 3D", "Desktop Remoto", "App Skype", "Office To Do", "Whiteboard", "Windows Alarm", "Comunicazione", "Feedback Hub", "Windows Maps", "Registratore Suoni", "Zune Music", "Zune Video", "Eclipse", "Pack Lingua", "Adobe Express" });
            Bloat2.Location = new Point(303, 7);
            Bloat2.Margin = new Padding(3, 4, 3, 4);
            Bloat2.Name = "Bloat2";
            Bloat2.Size = new Size(194, 550);
            Bloat2.TabIndex = 11;
            // 
            // Bloat3
            // 
            Bloat3.BackColor = Color.FromArgb(37, 38, 39);
            Bloat3.BorderStyle = BorderStyle.None;
            Bloat3.ForeColor = Color.White;
            Bloat3.FormattingEnabled = true;
            Bloat3.Items.AddRange(new object[] { "Duolingo", "PandoraMedia", "Candy Crush", "BubbleWitch", "Wunderlist", "Flipboard", "Twitter", "Facebook", "Dolby", "Advertising XAML", "Portafoglio", "Desktop Installer", "Collegamento A Telefono", "Edge", "Microsoft Store", "Windows Defender" });
            Bloat3.Location = new Point(558, 7);
            Bloat3.Margin = new Padding(3, 4, 3, 4);
            Bloat3.Name = "Bloat3";
            Bloat3.Size = new Size(199, 550);
            Bloat3.TabIndex = 12;
            // 
            // btnAvviaSelezionatiDebloat
            // 
            btnAvviaSelezionatiDebloat.Cursor = Cursors.Hand;
            btnAvviaSelezionatiDebloat.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionatiDebloat.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionatiDebloat.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionatiDebloat.ForeColor = Color.White;
            btnAvviaSelezionatiDebloat.Location = new Point(842, 7);
            btnAvviaSelezionatiDebloat.Name = "btnAvviaSelezionatiDebloat";
            btnAvviaSelezionatiDebloat.Size = new Size(176, 81);
            btnAvviaSelezionatiDebloat.TabIndex = 24;
            btnAvviaSelezionatiDebloat.Text = "Avvia Selezionati";
            btnAvviaSelezionatiDebloat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionatiDebloat.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiDebloat.Click += btnAvviaSelezionatiDebloat_Click;
            // 
            // btnReinstallaAPP
            // 
            btnReinstallaAPP.Cursor = Cursors.Hand;
            btnReinstallaAPP.FlatAppearance.BorderSize = 0;
            btnReinstallaAPP.FlatStyle = FlatStyle.Flat;
            btnReinstallaAPP.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReinstallaAPP.ForeColor = Color.White;
            btnReinstallaAPP.Location = new Point(842, 477);
            btnReinstallaAPP.Name = "btnReinstallaAPP";
            btnReinstallaAPP.Size = new Size(176, 81);
            btnReinstallaAPP.TabIndex = 25;
            btnReinstallaAPP.Text = "Reinstalla App";
            btnReinstallaAPP.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReinstallaAPP.UseVisualStyleBackColor = true;
            // 
            // btnDebloatAuto
            // 
            btnDebloatAuto.Cursor = Cursors.Hand;
            btnDebloatAuto.FlatAppearance.BorderSize = 0;
            btnDebloatAuto.FlatStyle = FlatStyle.Flat;
            btnDebloatAuto.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDebloatAuto.ForeColor = Color.White;
            btnDebloatAuto.Location = new Point(842, 215);
            btnDebloatAuto.Name = "btnDebloatAuto";
            btnDebloatAuto.Size = new Size(176, 81);
            btnDebloatAuto.TabIndex = 26;
            btnDebloatAuto.Text = "Debloat Automatico";
            btnDebloatAuto.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDebloatAuto.UseVisualStyleBackColor = true;
            btnDebloatAuto.Click += btnDebloatAuto_Click;
            // 
            // FormDebloat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1030, 570);
            Controls.Add(btnDebloatAuto);
            Controls.Add(btnReinstallaAPP);
            Controls.Add(btnAvviaSelezionatiDebloat);
            Controls.Add(Bloat3);
            Controls.Add(Bloat2);
            Controls.Add(Bloat1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDebloat";
            Text = "FormDebloat";
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox Bloat1;
        private CheckedListBox Bloat2;
        private CheckedListBox Bloat3;
        private Button btnAvviaSelezionatiDebloat;
        private Button btnReinstallaAPP;
        private Button btnDebloatAuto;
    }
}
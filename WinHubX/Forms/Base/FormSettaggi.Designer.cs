namespace WinHubX.Forms.Base
{
    partial class FormSettaggi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettaggi));
            btnPrivacy = new Button();
            btnUtility = new Button();
            btnDefender = new Button();
            btnUpdate = new Button();
            lblInfoPrivacy = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnPersonalizzazione = new Button();
            label4 = new Label();
            label5 = new Label();
            btnRipristinaSO = new Button();
            label6 = new Label();
            btnAttivaWSA = new Button();
            btnAttivaWSL = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // btnPrivacy
            // 
            btnPrivacy.Cursor = Cursors.Hand;
            btnPrivacy.FlatAppearance.BorderSize = 0;
            btnPrivacy.FlatStyle = FlatStyle.Flat;
            btnPrivacy.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrivacy.ForeColor = Color.White;
            btnPrivacy.Image = (Image)resources.GetObject("btnPrivacy.Image");
            btnPrivacy.Location = new Point(66, 12);
            btnPrivacy.Name = "btnPrivacy";
            btnPrivacy.Size = new Size(347, 63);
            btnPrivacy.TabIndex = 6;
            btnPrivacy.Text = "Privacy";
            btnPrivacy.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrivacy.UseVisualStyleBackColor = true;
            btnPrivacy.Click += btnPrivacy_Click;
            // 
            // btnUtility
            // 
            btnUtility.Cursor = Cursors.Hand;
            btnUtility.FlatAppearance.BorderSize = 0;
            btnUtility.FlatStyle = FlatStyle.Flat;
            btnUtility.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUtility.ForeColor = Color.White;
            btnUtility.Image = (Image)resources.GetObject("btnUtility.Image");
            btnUtility.Location = new Point(607, 12);
            btnUtility.Name = "btnUtility";
            btnUtility.Size = new Size(347, 63);
            btnUtility.TabIndex = 7;
            btnUtility.Text = "Utility";
            btnUtility.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUtility.UseVisualStyleBackColor = true;
            btnUtility.Click += btnUtility_Click;
            // 
            // btnDefender
            // 
            btnDefender.Cursor = Cursors.Hand;
            btnDefender.FlatAppearance.BorderSize = 0;
            btnDefender.FlatStyle = FlatStyle.Flat;
            btnDefender.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDefender.ForeColor = Color.White;
            btnDefender.Image = (Image)resources.GetObject("btnDefender.Image");
            btnDefender.ImageAlign = ContentAlignment.MiddleRight;
            btnDefender.Location = new Point(66, 169);
            btnDefender.Name = "btnDefender";
            btnDefender.Size = new Size(347, 63);
            btnDefender.TabIndex = 8;
            btnDefender.Text = "Defender";
            btnDefender.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDefender.UseVisualStyleBackColor = true;
            btnDefender.Click += btnDefender_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Image = (Image)resources.GetObject("btnUpdate.Image");
            btnUpdate.Location = new Point(622, 169);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(347, 63);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // lblInfoPrivacy
            // 
            lblInfoPrivacy.AutoSize = true;
            lblInfoPrivacy.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfoPrivacy.ForeColor = Color.Coral;
            lblInfoPrivacy.Location = new Point(22, 83);
            lblInfoPrivacy.Name = "lblInfoPrivacy";
            lblInfoPrivacy.Size = new Size(454, 58);
            lblInfoPrivacy.TabIndex = 49;
            lblInfoPrivacy.Text = "Impostazioni Privacy\r\nModifica la tua privacy come meglio credi";
            lblInfoPrivacy.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Coral;
            label1.Location = new Point(528, 83);
            label1.Name = "label1";
            label1.Size = new Size(480, 58);
            label1.TabIndex = 50;
            label1.Text = "Impostazioni Utility\r\nImpostazioni per gestire al meglio Windows\r\n";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Coral;
            label2.Location = new Point(15, 235);
            label2.Name = "label2";
            label2.Size = new Size(461, 58);
            label2.TabIndex = 51;
            label2.Text = "Impostazioni Defender\r\nAbilita/Disabilita la protezione di Windows\r\n";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Coral;
            label3.Location = new Point(562, 235);
            label3.Name = "label3";
            label3.Size = new Size(428, 58);
            label3.TabIndex = 52;
            label3.Text = "Impostazioni Update\r\nAbilita/Disabilita gli update di Windows";
            label3.TextAlign = ContentAlignment.BottomCenter;
            // 
            // btnPersonalizzazione
            // 
            btnPersonalizzazione.Cursor = Cursors.Hand;
            btnPersonalizzazione.FlatAppearance.BorderSize = 0;
            btnPersonalizzazione.FlatStyle = FlatStyle.Flat;
            btnPersonalizzazione.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPersonalizzazione.ForeColor = Color.White;
            btnPersonalizzazione.Image = (Image)resources.GetObject("btnPersonalizzazione.Image");
            btnPersonalizzazione.ImageAlign = ContentAlignment.MiddleRight;
            btnPersonalizzazione.Location = new Point(528, 330);
            btnPersonalizzazione.Name = "btnPersonalizzazione";
            btnPersonalizzazione.Size = new Size(485, 67);
            btnPersonalizzazione.TabIndex = 53;
            btnPersonalizzazione.Text = "Personalizzazione";
            btnPersonalizzazione.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPersonalizzazione.UseVisualStyleBackColor = true;
            btnPersonalizzazione.Click += btnPersonalizzazione_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Coral;
            label4.Location = new Point(512, 400);
            label4.Name = "label4";
            label4.Size = new Size(510, 29);
            label4.TabIndex = 54;
            label4.Text = "Personalizza il tuo Windows in base al tuo stile";
            label4.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Coral;
            label5.Location = new Point(95, 405);
            label5.Name = "label5";
            label5.Size = new Size(332, 29);
            label5.TabIndex = 56;
            label5.Text = "Tenta di riparare il S.O. in uso";
            label5.TextAlign = ContentAlignment.BottomCenter;
            // 
            // btnRipristinaSO
            // 
            btnRipristinaSO.Cursor = Cursors.Hand;
            btnRipristinaSO.FlatAppearance.BorderSize = 0;
            btnRipristinaSO.FlatStyle = FlatStyle.Flat;
            btnRipristinaSO.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRipristinaSO.ForeColor = Color.White;
            btnRipristinaSO.Image = (Image)resources.GetObject("btnRipristinaSO.Image");
            btnRipristinaSO.ImageAlign = ContentAlignment.MiddleRight;
            btnRipristinaSO.Location = new Point(15, 324);
            btnRipristinaSO.Name = "btnRipristinaSO";
            btnRipristinaSO.Size = new Size(485, 78);
            btnRipristinaSO.TabIndex = 55;
            btnRipristinaSO.Text = "Ripristina Sistema";
            btnRipristinaSO.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRipristinaSO.UseVisualStyleBackColor = true;
            btnRipristinaSO.Click += btnRipristinaSO_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Coral;
            label6.Location = new Point(22, 528);
            label6.Name = "label6";
            label6.Size = new Size(442, 29);
            label6.TabIndex = 58;
            label6.Text = "Installa il sottosistema Windows Andorid";
            label6.TextAlign = ContentAlignment.BottomCenter;
            // 
            // btnAttivaWSA
            // 
            btnAttivaWSA.Cursor = Cursors.Hand;
            btnAttivaWSA.FlatAppearance.BorderSize = 0;
            btnAttivaWSA.FlatStyle = FlatStyle.Flat;
            btnAttivaWSA.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAttivaWSA.ForeColor = Color.White;
            btnAttivaWSA.Image = (Image)resources.GetObject("btnAttivaWSA.Image");
            btnAttivaWSA.ImageAlign = ContentAlignment.MiddleRight;
            btnAttivaWSA.Location = new Point(-9, 466);
            btnAttivaWSA.Name = "btnAttivaWSA";
            btnAttivaWSA.Size = new Size(485, 59);
            btnAttivaWSA.TabIndex = 57;
            btnAttivaWSA.Text = "Attiva WSA";
            btnAttivaWSA.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAttivaWSA.UseVisualStyleBackColor = true;
            // 
            // btnAttivaWSL
            // 
            btnAttivaWSL.Cursor = Cursors.Hand;
            btnAttivaWSL.FlatAppearance.BorderSize = 0;
            btnAttivaWSL.FlatStyle = FlatStyle.Flat;
            btnAttivaWSL.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAttivaWSL.ForeColor = Color.White;
            btnAttivaWSL.Image = (Image)resources.GetObject("btnAttivaWSL.Image");
            btnAttivaWSL.ImageAlign = ContentAlignment.MiddleRight;
            btnAttivaWSL.Location = new Point(528, 466);
            btnAttivaWSL.Name = "btnAttivaWSL";
            btnAttivaWSL.Size = new Size(485, 59);
            btnAttivaWSL.TabIndex = 59;
            btnAttivaWSL.Text = "Attiva WSL";
            btnAttivaWSL.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAttivaWSL.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Coral;
            label7.Location = new Point(562, 528);
            label7.Name = "label7";
            label7.Size = new Size(414, 29);
            label7.TabIndex = 60;
            label7.Text = "Installa il sottosistema Windows Linux";
            label7.TextAlign = ContentAlignment.BottomCenter;
            // 
            // FormSettaggi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1030, 571);
            Controls.Add(label7);
            Controls.Add(btnAttivaWSL);
            Controls.Add(label6);
            Controls.Add(btnAttivaWSA);
            Controls.Add(label5);
            Controls.Add(btnRipristinaSO);
            Controls.Add(label4);
            Controls.Add(btnPersonalizzazione);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblInfoPrivacy);
            Controls.Add(btnUpdate);
            Controls.Add(btnDefender);
            Controls.Add(btnUtility);
            Controls.Add(btnPrivacy);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSettaggi";
            Text = "FormSettaggi";
            Load += FormSettaggi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrivacy;
        private Button btnUtility;
        private Button btnDefender;
        private Button btnUpdate;
        private Label lblInfoPrivacy;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnPersonalizzazione;
        private Label label4;
        private Label label5;
        private Button btnRipristinaSO;
        private Label label6;
        private Button btnAttivaWSA;
        private Button btnAttivaWSL;
        private Label label7;
    }
}
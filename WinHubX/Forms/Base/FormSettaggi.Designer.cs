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
            btnPrivacy = new Button();
            btnUtility = new Button();
            btnDefender = new Button();
            btnUpdate = new Button();
            lblInfoPrivacy = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnPrivacy
            // 
            btnPrivacy.Cursor = Cursors.Hand;
            btnPrivacy.FlatAppearance.BorderSize = 0;
            btnPrivacy.FlatStyle = FlatStyle.Flat;
            btnPrivacy.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrivacy.ForeColor = Color.White;
            btnPrivacy.Image = Properties.Resources.pngWin7;
            btnPrivacy.Location = new Point(68, 76);
            btnPrivacy.Name = "btnPrivacy";
            btnPrivacy.Size = new Size(347, 91);
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
            btnUtility.Image = Properties.Resources.pngWin7;
            btnUtility.Location = new Point(605, 76);
            btnUtility.Name = "btnUtility";
            btnUtility.Size = new Size(347, 91);
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
            btnDefender.Image = Properties.Resources.pngWin7;
            btnDefender.Location = new Point(68, 390);
            btnDefender.Name = "btnDefender";
            btnDefender.Size = new Size(347, 91);
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
            btnUpdate.Image = Properties.Resources.pngWin7;
            btnUpdate.Location = new Point(605, 390);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(347, 91);
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
            lblInfoPrivacy.Location = new Point(8, 170);
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
            label1.Location = new Point(510, 170);
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
            label2.Location = new Point(8, 484);
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
            label3.Location = new Point(562, 484);
            label3.Name = "label3";
            label3.Size = new Size(428, 58);
            label3.TabIndex = 52;
            label3.Text = "Impostazioni Update\r\nAbilita/Disabilita gli update di Windows";
            label3.TextAlign = ContentAlignment.BottomCenter;
            // 
            // FormSettaggi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1030, 571);
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
    }
}
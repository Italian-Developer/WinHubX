namespace WinHubX.Dialog
{
    partial class PacManDialog
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
            label1 = new Label();
            btnInstallaPacMan = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Coral;
            label1.Location = new Point(30, 9);
            label1.Name = "label1";
            label1.Size = new Size(328, 20);
            label1.TabIndex = 51;
            label1.Text = "Scaricare PacMan per avviare gli apk esterni?";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // btnInstallaPacMan
            // 
            btnInstallaPacMan.Cursor = Cursors.Hand;
            btnInstallaPacMan.FlatAppearance.BorderSize = 0;
            btnInstallaPacMan.FlatStyle = FlatStyle.Flat;
            btnInstallaPacMan.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInstallaPacMan.ForeColor = Color.White;
            btnInstallaPacMan.Location = new Point(54, 59);
            btnInstallaPacMan.Margin = new Padding(3, 2, 3, 2);
            btnInstallaPacMan.Name = "btnInstallaPacMan";
            btnInstallaPacMan.Size = new Size(283, 73);
            btnInstallaPacMan.TabIndex = 77;
            btnInstallaPacMan.Text = "Installa PacMan";
            btnInstallaPacMan.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInstallaPacMan.UseVisualStyleBackColor = true;
            btnInstallaPacMan.Click += btnInstallaPacMan_Click;
            // 
            // PacManDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(422, 216);
            Controls.Add(btnInstallaPacMan);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PacManDialog";
            Text = "PacMan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnInstallaPacMan;
        private Button btnClose;
    }
}
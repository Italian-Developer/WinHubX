using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinHubX.Dialog
{
    partial class PacManDialog
    {
        private IContainer components = null;
        private Label lblPrompt;
        private Button btnInstallPacMan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            lblPrompt = CreatePromptLabel();
            btnInstallPacMan = CreateInstallButton();

            SuspendLayout();

            // 
            // PacManDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(422, 216);
            Controls.Add(btnInstallPacMan);
            Controls.Add(lblPrompt);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PacManDialog";
            Text = "PacMan";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label CreatePromptLabel()
        {
            return new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0),
                ForeColor = Color.Coral,
                Location = new Point(30, 9),
                Name = "lblPrompt",
                Size = new Size(328, 20),
                Text = "Scaricare PacMan per avviare gli apk esterni?",
                TextAlign = ContentAlignment.BottomCenter
            };
        }

        private Button CreateInstallButton()
        {
            var button = new Button
            {
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 },
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.White,
                Location = new Point(54, 59),
                Margin = new Padding(3, 2, 3, 2),
                Name = "btnInstallPacMan",
                Size = new Size(283, 73),
                Text = "Installa PacMan",
                TextImageRelation = TextImageRelation.ImageBeforeText,
                UseVisualStyleBackColor = true
            };
            button.Click += BtnInstallPacMan_Click;
            return button;
        }
    }
}

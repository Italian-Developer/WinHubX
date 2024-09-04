using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinHubX.Forms.Base
{
    partial class ProgressForm
    {
        private System.ComponentModel.IContainer components = null;
        private ProgressBar progressBar;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            progressBar = new ProgressBar();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 40);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(260, 23);
            progressBar.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(151, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Operazione in corso...";
            // 
            // ProgressForm
            // 
            ClientSize = new Size(284, 75);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ProgressForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "In corso...";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

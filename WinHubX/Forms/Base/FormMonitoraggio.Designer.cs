namespace WinHubX.Forms.Base
{
    partial class FormMonitoraggio
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
            lblInfoWin12 = new Label();
            testoram = new Label();
            testoCPU = new Label();
            btnOttRam = new Button();
            btnOttCPU = new Button();
            BarRAM = new Bottoni.CircularProgressBar();
            BarCPU = new Bottoni.CircularProgressBar();
            bottoniSwap = new Bottoni.BottoniSwap();
            SuspendLayout();
            // 
            // lblInfoWin12
            // 
            lblInfoWin12.AutoSize = true;
            lblInfoWin12.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfoWin12.ForeColor = Color.Coral;
            lblInfoWin12.Location = new Point(12, 9);
            lblInfoWin12.Name = "lblInfoWin12";
            lblInfoWin12.Size = new Size(196, 24);
            lblInfoWin12.TabIndex = 81;
            lblInfoWin12.Text = "Attivare monitoraggio?";
            lblInfoWin12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // testoram
            // 
            testoram.AutoSize = true;
            testoram.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic);
            testoram.ForeColor = Color.Coral;
            testoram.Location = new Point(207, 243);
            testoram.Name = "testoram";
            testoram.Size = new Size(48, 20);
            testoram.TabIndex = 84;
            testoram.Text = "RAM";
            testoram.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // testoCPU
            // 
            testoCPU.AutoSize = true;
            testoCPU.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic);
            testoCPU.ForeColor = Color.Coral;
            testoCPU.Location = new Point(659, 243);
            testoCPU.Name = "testoCPU";
            testoCPU.Size = new Size(45, 20);
            testoCPU.TabIndex = 85;
            testoCPU.Text = "CPU";
            testoCPU.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnOttRam
            // 
            btnOttRam.Cursor = Cursors.Hand;
            btnOttRam.FlatAppearance.BorderSize = 0;
            btnOttRam.FlatStyle = FlatStyle.Flat;
            btnOttRam.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOttRam.ForeColor = Color.White;
            btnOttRam.Location = new Point(127, 305);
            btnOttRam.Margin = new Padding(3, 2, 3, 2);
            btnOttRam.Name = "btnOttRam";
            btnOttRam.Size = new Size(219, 37);
            btnOttRam.TabIndex = 86;
            btnOttRam.Text = "Ottimizza RAM";
            btnOttRam.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOttRam.UseVisualStyleBackColor = true;
            btnOttRam.Click += btnOttRam_Click;
            // 
            // btnOttCPU
            // 
            btnOttCPU.Cursor = Cursors.Hand;
            btnOttCPU.FlatAppearance.BorderSize = 0;
            btnOttCPU.FlatStyle = FlatStyle.Flat;
            btnOttCPU.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOttCPU.ForeColor = Color.White;
            btnOttCPU.Location = new Point(571, 305);
            btnOttCPU.Margin = new Padding(3, 2, 3, 2);
            btnOttCPU.Name = "btnOttCPU";
            btnOttCPU.Size = new Size(210, 37);
            btnOttCPU.TabIndex = 87;
            btnOttCPU.Text = "Ottimizza CPU";
            btnOttCPU.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOttCPU.UseVisualStyleBackColor = true;
            btnOttCPU.Click += btnOttCPU_Click;
            // 
            // BarRAM
            // 
            BarRAM.Location = new Point(155, 103);
            BarRAM.Maximum = 100;
            BarRAM.Minimum = 0;
            BarRAM.Name = "BarRAM";
            BarRAM.Size = new Size(158, 128);
            BarRAM.TabIndex = 88;
            BarRAM.Text = "BarRam";
            BarRAM.Value = 0;
            // 
            // BarCPU
            // 
            BarCPU.Location = new Point(601, 103);
            BarCPU.Maximum = 100;
            BarCPU.Minimum = 0;
            BarCPU.Name = "BarCPU";
            BarCPU.Size = new Size(158, 128);
            BarCPU.TabIndex = 89;
            BarCPU.Text = "BarRam";
            BarCPU.Value = 0;
            BarCPU.Click += BarCPU_Click;
            // 
            // bottoniSwap
            // 
            bottoniSwap.AutoSize = true;
            bottoniSwap.Location = new Point(236, 9);
            bottoniSwap.MinimumSize = new Size(50, 25);
            bottoniSwap.Name = "bottoniSwap";
            bottoniSwap.OffBackColor = Color.Gray;
            bottoniSwap.OffToggleColor = Color.Gainsboro;
            bottoniSwap.OnBackColor = Color.Lime;
            bottoniSwap.OnToggleColor = Color.WhiteSmoke;
            bottoniSwap.Size = new Size(50, 25);
            bottoniSwap.TabIndex = 90;
            bottoniSwap.UseVisualStyleBackColor = true;
            bottoniSwap.CheckedChanged += bottoniSwap_CheckedChanged_1;
            // 
            // FormMonitoraggio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
            Controls.Add(bottoniSwap);
            Controls.Add(BarCPU);
            Controls.Add(BarRAM);
            Controls.Add(btnOttCPU);
            Controls.Add(btnOttRam);
            Controls.Add(testoCPU);
            Controls.Add(testoram);
            Controls.Add(lblInfoWin12);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMonitoraggio";
            Text = "\\\\";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Bottoni.BottoniSwap bottoniSwap;
        private Label lblInfoWin12;
        private Bottoni.CircularProgressBar BarRAM;
        private Bottoni.CircularProgressBar BarCPU;
        private Label testoram;
        private Label testoCPU;
        private Button btnOttRam;
        private Button btnOttCPU;
    }
}
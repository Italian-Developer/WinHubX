namespace WinHubX
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            btnTools = new Button();
            btnMonitoraggio = new Button();
            btnCreaISO = new Button();
            btnDebloat = new Button();
            btnSettaggi = new Button();
            btnOffice = new Button();
            btnWin = new Button();
            btnHome = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            pnlNav = new Panel();
            PnlFormLoader = new Panel();
            btnClose = new Button();
            btnMnmz = new Button();
            pictureBox2 = new PictureBox();
            lblPanelTitle = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 60, 59);
            panel1.Controls.Add(btnTools);
            panel1.Controls.Add(btnMonitoraggio);
            panel1.Controls.Add(btnCreaISO);
            panel1.Controls.Add(btnDebloat);
            panel1.Controls.Add(btnSettaggi);
            panel1.Controls.Add(btnOffice);
            panel1.Controls.Add(btnWin);
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(219, 570);
            panel1.TabIndex = 0;
            // 
            // btnTools
            // 
            btnTools.Dock = DockStyle.Top;
            btnTools.FlatAppearance.BorderSize = 0;
            btnTools.FlatStyle = FlatStyle.Flat;
            btnTools.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            btnTools.ForeColor = SystemColors.Window;
            btnTools.Image = (Image)resources.GetObject("btnTools.Image");
            btnTools.ImageAlign = ContentAlignment.MiddleRight;
            btnTools.Location = new Point(0, 504);
            btnTools.Margin = new Padding(3, 2, 3, 2);
            btnTools.Name = "btnTools";
            btnTools.Padding = new Padding(4, 0, 9, 0);
            btnTools.Size = new Size(219, 56);
            btnTools.TabIndex = 7;
            btnTools.Text = "Tools";
            btnTools.TextAlign = ContentAlignment.MiddleLeft;
            btnTools.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnTools.UseVisualStyleBackColor = true;
            btnTools.Click += btnTools_Click;
            // 
            // btnMonitoraggio
            // 
            btnMonitoraggio.Dock = DockStyle.Top;
            btnMonitoraggio.FlatAppearance.BorderSize = 0;
            btnMonitoraggio.FlatStyle = FlatStyle.Flat;
            btnMonitoraggio.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMonitoraggio.ForeColor = SystemColors.Window;
            btnMonitoraggio.Image = (Image)resources.GetObject("btnMonitoraggio.Image");
            btnMonitoraggio.ImageAlign = ContentAlignment.MiddleRight;
            btnMonitoraggio.Location = new Point(0, 448);
            btnMonitoraggio.Margin = new Padding(3, 2, 3, 2);
            btnMonitoraggio.Name = "btnMonitoraggio";
            btnMonitoraggio.Padding = new Padding(4, 0, 9, 0);
            btnMonitoraggio.Size = new Size(219, 56);
            btnMonitoraggio.TabIndex = 6;
            btnMonitoraggio.Text = "Monitoraggio";
            btnMonitoraggio.TextAlign = ContentAlignment.MiddleLeft;
            btnMonitoraggio.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnMonitoraggio.UseVisualStyleBackColor = true;
            btnMonitoraggio.Click += btnMonitoraggio_Click;
            // 
            // btnCreaISO
            // 
            btnCreaISO.Dock = DockStyle.Top;
            btnCreaISO.FlatAppearance.BorderSize = 0;
            btnCreaISO.FlatStyle = FlatStyle.Flat;
            btnCreaISO.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            btnCreaISO.ForeColor = SystemColors.Window;
            btnCreaISO.Image = (Image)resources.GetObject("btnCreaISO.Image");
            btnCreaISO.ImageAlign = ContentAlignment.MiddleRight;
            btnCreaISO.Location = new Point(0, 392);
            btnCreaISO.Margin = new Padding(3, 2, 3, 2);
            btnCreaISO.Name = "btnCreaISO";
            btnCreaISO.Padding = new Padding(4, 0, 9, 0);
            btnCreaISO.Size = new Size(219, 56);
            btnCreaISO.TabIndex = 4;
            btnCreaISO.Text = "Crea ISO";
            btnCreaISO.TextAlign = ContentAlignment.MiddleLeft;
            btnCreaISO.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCreaISO.UseVisualStyleBackColor = true;
            btnCreaISO.Click += btnCreaISO_Click;
            // 
            // btnDebloat
            // 
            btnDebloat.Dock = DockStyle.Top;
            btnDebloat.FlatAppearance.BorderSize = 0;
            btnDebloat.FlatStyle = FlatStyle.Flat;
            btnDebloat.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            btnDebloat.ForeColor = SystemColors.Window;
            btnDebloat.Image = (Image)resources.GetObject("btnDebloat.Image");
            btnDebloat.ImageAlign = ContentAlignment.MiddleRight;
            btnDebloat.Location = new Point(0, 336);
            btnDebloat.Margin = new Padding(3, 2, 3, 2);
            btnDebloat.Name = "btnDebloat";
            btnDebloat.Padding = new Padding(4, 0, 9, 0);
            btnDebloat.Size = new Size(219, 56);
            btnDebloat.TabIndex = 3;
            btnDebloat.Text = "Debloat";
            btnDebloat.TextAlign = ContentAlignment.MiddleLeft;
            btnDebloat.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDebloat.UseVisualStyleBackColor = true;
            btnDebloat.Click += btnDebloat_Click;
            // 
            // btnSettaggi
            // 
            btnSettaggi.Dock = DockStyle.Top;
            btnSettaggi.FlatAppearance.BorderSize = 0;
            btnSettaggi.FlatStyle = FlatStyle.Flat;
            btnSettaggi.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            btnSettaggi.ForeColor = SystemColors.Window;
            btnSettaggi.Image = (Image)resources.GetObject("btnSettaggi.Image");
            btnSettaggi.ImageAlign = ContentAlignment.MiddleRight;
            btnSettaggi.Location = new Point(0, 280);
            btnSettaggi.Margin = new Padding(3, 2, 3, 2);
            btnSettaggi.Name = "btnSettaggi";
            btnSettaggi.Padding = new Padding(4, 0, 9, 0);
            btnSettaggi.Size = new Size(219, 56);
            btnSettaggi.TabIndex = 2;
            btnSettaggi.Text = "Settaggi";
            btnSettaggi.TextAlign = ContentAlignment.MiddleLeft;
            btnSettaggi.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSettaggi.UseVisualStyleBackColor = true;
            btnSettaggi.Click += btnSettaggi_Click;
            // 
            // btnOffice
            // 
            btnOffice.Dock = DockStyle.Top;
            btnOffice.FlatAppearance.BorderSize = 0;
            btnOffice.FlatStyle = FlatStyle.Flat;
            btnOffice.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            btnOffice.ForeColor = SystemColors.Window;
            btnOffice.Image = (Image)resources.GetObject("btnOffice.Image");
            btnOffice.ImageAlign = ContentAlignment.MiddleRight;
            btnOffice.Location = new Point(0, 224);
            btnOffice.Margin = new Padding(3, 2, 3, 2);
            btnOffice.Name = "btnOffice";
            btnOffice.Padding = new Padding(4, 0, 9, 0);
            btnOffice.Size = new Size(219, 56);
            btnOffice.TabIndex = 1;
            btnOffice.Text = "Office";
            btnOffice.TextAlign = ContentAlignment.MiddleLeft;
            btnOffice.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnOffice.UseVisualStyleBackColor = true;
            btnOffice.Click += btnOffice_Click;
            btnOffice.Leave += btnOffice_Leave;
            // 
            // btnWin
            // 
            btnWin.Dock = DockStyle.Top;
            btnWin.FlatAppearance.BorderSize = 0;
            btnWin.FlatStyle = FlatStyle.Flat;
            btnWin.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            btnWin.ForeColor = SystemColors.Window;
            btnWin.Image = (Image)resources.GetObject("btnWin.Image");
            btnWin.ImageAlign = ContentAlignment.MiddleRight;
            btnWin.Location = new Point(0, 168);
            btnWin.Margin = new Padding(3, 2, 3, 2);
            btnWin.Name = "btnWin";
            btnWin.Padding = new Padding(4, 0, 9, 0);
            btnWin.Size = new Size(219, 56);
            btnWin.TabIndex = 1;
            btnWin.Text = "Windows";
            btnWin.TextAlign = ContentAlignment.MiddleLeft;
            btnWin.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnWin.UseVisualStyleBackColor = true;
            btnWin.Click += btnWin_Click;
            btnWin.Leave += btnWin_Leave;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            btnHome.ForeColor = SystemColors.Window;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageAlign = ContentAlignment.MiddleRight;
            btnHome.Location = new Point(0, 112);
            btnHome.Margin = new Padding(3, 2, 3, 2);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(4, 0, 9, 0);
            btnHome.Size = new Size(219, 56);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            btnHome.Leave += btnHome_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(219, 112);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.pngLogoWHX;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(219, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.FromArgb(0, 126, 249);
            pnlNav.Location = new Point(0, 122);
            pnlNav.Margin = new Padding(3, 2, 3, 2);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(3, 38);
            pnlNav.TabIndex = 1;
            // 
            // PnlFormLoader
            // 
            PnlFormLoader.Dock = DockStyle.Bottom;
            PnlFormLoader.Location = new Point(219, 142);
            PnlFormLoader.Margin = new Padding(3, 2, 3, 2);
            PnlFormLoader.Name = "PnlFormLoader";
            PnlFormLoader.Size = new Size(901, 428);
            PnlFormLoader.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.pngClose;
            btnClose.Location = new Point(1072, 0);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(48, 41);
            btnClose.TabIndex = 3;
            btnClose.UseMnemonic = false;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnMnmz
            // 
            btnMnmz.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMnmz.Cursor = Cursors.Hand;
            btnMnmz.FlatAppearance.BorderSize = 0;
            btnMnmz.FlatStyle = FlatStyle.Flat;
            btnMnmz.Image = Properties.Resources.pngMinimize;
            btnMnmz.Location = new Point(1032, 5);
            btnMnmz.Margin = new Padding(3, 2, 3, 2);
            btnMnmz.Name = "btnMnmz";
            btnMnmz.Size = new Size(35, 30);
            btnMnmz.TabIndex = 3;
            btnMnmz.UseMnemonic = false;
            btnMnmz.UseVisualStyleBackColor = true;
            btnMnmz.Click += btnMnmz_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.pngXtndLogo_WinHubX;
            pictureBox2.Location = new Point(219, 0);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(263, 70);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // lblPanelTitle
            // 
            lblPanelTitle.AutoSize = true;
            lblPanelTitle.Font = new Font("Microsoft Sans Serif", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPanelTitle.ForeColor = Color.White;
            lblPanelTitle.Location = new Point(221, 67);
            lblPanelTitle.Name = "lblPanelTitle";
            lblPanelTitle.Size = new Size(125, 44);
            lblPanelTitle.TabIndex = 5;
            lblPanelTitle.Text = "Home";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1120, 570);
            Controls.Add(lblPanelTitle);
            Controls.Add(pictureBox2);
            Controls.Add(btnMnmz);
            Controls.Add(btnClose);
            Controls.Add(PnlFormLoader);
            Controls.Add(pnlNav);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnHome;
        private PictureBox pictureBox1;
        private Button btnOffice;
        private Button btnWin;
        private Panel pnlNav;
        public Panel PnlFormLoader;
        private Button btnClose;
        private Button btnMnmz;
        private PictureBox pictureBox2;
        public Label lblPanelTitle;
        private Button btnSettaggi;
        private Button btnDebloat;
        private Button btnCreaISO;
        private Button btnTools;
        private Button btnMonitoraggio;
    }
}

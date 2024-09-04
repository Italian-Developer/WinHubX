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
            btnupdate = new Button();
            btnTools = new Button();
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
            panel1.Controls.Add(btnupdate);
            panel1.Controls.Add(btnTools);
            panel1.Controls.Add(btnCreaISO);
            panel1.Controls.Add(btnDebloat);
            panel1.Controls.Add(btnSettaggi);
            panel1.Controls.Add(btnOffice);
            panel1.Controls.Add(btnWin);
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(panel2);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // btnupdate
            // 
            resources.ApplyResources(btnupdate, "btnupdate");
            btnupdate.FlatAppearance.BorderSize = 0;
            btnupdate.ForeColor = SystemColors.Window;
            btnupdate.Name = "btnupdate";
            btnupdate.UseVisualStyleBackColor = true;
            btnupdate.Click += btnupdate_Click;
            // 
            // btnTools
            // 
            resources.ApplyResources(btnTools, "btnTools");
            btnTools.FlatAppearance.BorderSize = 0;
            btnTools.ForeColor = SystemColors.Window;
            btnTools.Name = "btnTools";
            btnTools.UseVisualStyleBackColor = true;
            btnTools.Click += btnTools_Click;
            // 
            // btnCreaISO
            // 
            resources.ApplyResources(btnCreaISO, "btnCreaISO");
            btnCreaISO.FlatAppearance.BorderSize = 0;
            btnCreaISO.ForeColor = SystemColors.Window;
            btnCreaISO.Name = "btnCreaISO";
            btnCreaISO.UseVisualStyleBackColor = true;
            btnCreaISO.Click += btnCreaISO_Click;
            // 
            // btnDebloat
            // 
            resources.ApplyResources(btnDebloat, "btnDebloat");
            btnDebloat.FlatAppearance.BorderSize = 0;
            btnDebloat.ForeColor = SystemColors.Window;
            btnDebloat.Name = "btnDebloat";
            btnDebloat.UseVisualStyleBackColor = true;
            btnDebloat.Click += btnDebloat_Click;
            // 
            // btnSettaggi
            // 
            resources.ApplyResources(btnSettaggi, "btnSettaggi");
            btnSettaggi.FlatAppearance.BorderSize = 0;
            btnSettaggi.ForeColor = SystemColors.Window;
            btnSettaggi.Name = "btnSettaggi";
            btnSettaggi.UseVisualStyleBackColor = true;
            btnSettaggi.Click += btnSettaggi_Click;
            // 
            // btnOffice
            // 
            resources.ApplyResources(btnOffice, "btnOffice");
            btnOffice.FlatAppearance.BorderSize = 0;
            btnOffice.ForeColor = SystemColors.Window;
            btnOffice.Name = "btnOffice";
            btnOffice.UseVisualStyleBackColor = true;
            btnOffice.Click += btnOffice_Click;
            btnOffice.Leave += btnOffice_Leave;
            // 
            // btnWin
            // 
            resources.ApplyResources(btnWin, "btnWin");
            btnWin.FlatAppearance.BorderSize = 0;
            btnWin.ForeColor = SystemColors.Window;
            btnWin.Name = "btnWin";
            btnWin.UseVisualStyleBackColor = true;
            btnWin.Click += btnWin_Click;
            // 
            // btnHome
            // 
            resources.ApplyResources(btnHome, "btnHome");
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.ForeColor = SystemColors.Window;
            btnHome.Name = "btnHome";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = Properties.Resources.pngLogoWHX;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.FromArgb(0, 126, 249);
            resources.ApplyResources(pnlNav, "pnlNav");
            pnlNav.Name = "pnlNav";
            // 
            // PnlFormLoader
            // 
            resources.ApplyResources(PnlFormLoader, "PnlFormLoader");
            PnlFormLoader.Name = "PnlFormLoader";
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.Image = Properties.Resources.pngClose;
            btnClose.Name = "btnClose";
            btnClose.UseMnemonic = false;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnMnmz
            // 
            resources.ApplyResources(btnMnmz, "btnMnmz");
            btnMnmz.Cursor = Cursors.Hand;
            btnMnmz.FlatAppearance.BorderSize = 0;
            btnMnmz.Image = Properties.Resources.pngMinimize;
            btnMnmz.Name = "btnMnmz";
            btnMnmz.UseMnemonic = false;
            btnMnmz.UseVisualStyleBackColor = true;
            btnMnmz.Click += btnMnmz_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.pngXtndLogo_WinHubX;
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // lblPanelTitle
            // 
            resources.ApplyResources(lblPanelTitle, "lblPanelTitle");
            lblPanelTitle.ForeColor = Color.White;
            lblPanelTitle.Name = "lblPanelTitle";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(lblPanelTitle);
            Controls.Add(pictureBox2);
            Controls.Add(btnMnmz);
            Controls.Add(btnClose);
            Controls.Add(PnlFormLoader);
            Controls.Add(pnlNav);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
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
        private Button btnupdate;
    }
}

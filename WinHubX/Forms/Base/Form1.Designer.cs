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
            panel1.Controls.Add(btnOffice);
            panel1.Controls.Add(btnWin);
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 720);
            panel1.TabIndex = 0;
            // 
            // btnTools
            // 
            btnTools.Dock = DockStyle.Top;
            btnTools.FlatAppearance.BorderSize = 0;
            btnTools.FlatStyle = FlatStyle.Flat;
            btnTools.Font = new Font("Product Sans", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTools.ForeColor = SystemColors.Window;
            btnTools.Image = Properties.Resources.pngTools;
            btnTools.ImageAlign = ContentAlignment.MiddleRight;
            btnTools.Location = new Point(0, 375);
            btnTools.Name = "btnTools";
            btnTools.Padding = new Padding(5, 0, 10, 0);
            btnTools.Size = new Size(250, 75);
            btnTools.TabIndex = 1;
            btnTools.Text = "Tools";
            btnTools.TextAlign = ContentAlignment.MiddleLeft;
            btnTools.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnTools.UseVisualStyleBackColor = true;
            btnTools.Click += btnTools_Click;
            btnTools.Leave += btnTools_Leave;
            // 
            // btnOffice
            // 
            btnOffice.Dock = DockStyle.Top;
            btnOffice.FlatAppearance.BorderSize = 0;
            btnOffice.FlatStyle = FlatStyle.Flat;
            btnOffice.Font = new Font("Product Sans", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOffice.ForeColor = SystemColors.Window;
            btnOffice.Image = Properties.Resources.pngOffice;
            btnOffice.ImageAlign = ContentAlignment.MiddleRight;
            btnOffice.Location = new Point(0, 300);
            btnOffice.Name = "btnOffice";
            btnOffice.Padding = new Padding(5, 0, 10, 0);
            btnOffice.Size = new Size(250, 75);
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
            btnWin.Font = new Font("Product Sans", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWin.ForeColor = SystemColors.Window;
            btnWin.Image = Properties.Resources.pngWin;
            btnWin.ImageAlign = ContentAlignment.MiddleRight;
            btnWin.Location = new Point(0, 225);
            btnWin.Name = "btnWin";
            btnWin.Padding = new Padding(5, 0, 10, 0);
            btnWin.Size = new Size(250, 75);
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
            btnHome.Font = new Font("Product Sans", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = SystemColors.Window;
            btnHome.Image = Properties.Resources.pngHome;
            btnHome.ImageAlign = ContentAlignment.MiddleRight;
            btnHome.Location = new Point(0, 150);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(5, 0, 10, 0);
            btnHome.Size = new Size(250, 75);
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
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 150);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.pngLogoWHX;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.FromArgb(0, 126, 249);
            pnlNav.Location = new Point(0, 162);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(3, 50);
            pnlNav.TabIndex = 1;
            // 
            // PnlFormLoader
            // 
            PnlFormLoader.Dock = DockStyle.Bottom;
            PnlFormLoader.Location = new Point(250, 150);
            PnlFormLoader.Name = "PnlFormLoader";
            PnlFormLoader.Size = new Size(1030, 570);
            PnlFormLoader.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.pngClose;
            btnClose.Location = new Point(1225, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(55, 55);
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
            btnMnmz.Location = new Point(1179, 7);
            btnMnmz.Name = "btnMnmz";
            btnMnmz.Size = new Size(40, 40);
            btnMnmz.TabIndex = 3;
            btnMnmz.UseMnemonic = false;
            btnMnmz.UseVisualStyleBackColor = true;
            btnMnmz.Click += btnMnmz_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.pngXtndLogo_WinHubX;
            pictureBox2.Location = new Point(250, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(301, 93);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // lblPanelTitle
            // 
            lblPanelTitle.AutoSize = true;
            lblPanelTitle.Font = new Font("Product Sans Black", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPanelTitle.ForeColor = Color.White;
            lblPanelTitle.Location = new Point(250, 90);
            lblPanelTitle.Name = "lblPanelTitle";
            lblPanelTitle.Size = new Size(155, 59);
            lblPanelTitle.TabIndex = 5;
            lblPanelTitle.Text = "Home";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(1280, 720);
            Controls.Add(lblPanelTitle);
            Controls.Add(pictureBox2);
            Controls.Add(btnMnmz);
            Controls.Add(btnClose);
            Controls.Add(PnlFormLoader);
            Controls.Add(pnlNav);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Button btnTools;
        private Button btnOffice;
        private Button btnWin;
        private Panel pnlNav;
        public Panel PnlFormLoader;
        private Button btnClose;
        private Button btnMnmz;
        private PictureBox pictureBox2;
        public Label lblPanelTitle;
    }
}

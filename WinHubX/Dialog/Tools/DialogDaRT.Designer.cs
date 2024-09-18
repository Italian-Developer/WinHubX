using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinHubX.Dialog.Tools
{
    partial class DialogDaRT : Form
    {
        private IContainer components = null;
        private Button btnDownload;
        private Button btnClose;
        private Label lblInfoTool;
        private PictureBox imgTool;

        public DialogDaRT()
        {
            InitializeComponent();
        }

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
            var resources = new ComponentResourceManager(typeof(DialogDaRT));

            // Initialize components
            btnDownload = CreateButton(
                "Download ~700MB",
                new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold),
                new Point(166, 313),
                new Size(368, 52),
                // Use a placeholder for the image
                null,
                btnDownload_Click
            );

            btnClose = CreateButton(
                null,
                null,
                new Point(641, 9),
                new Size(48, 41),
                // Use a placeholder for the image
                null,
                btnClose_Click,
                false
            );

            lblInfoTool = CreateLabel(
                resources.GetString("lblInfoTool.Text"),
                new Font("Microsoft Sans Serif", 15F),
                new Point(53, 125),
                new Size(595, 186),
                Color.Coral
            );

            imgTool = CreatePictureBox(
                // Use a placeholder for the image
                null,
                new Point(148, 11),
                new Size(401, 112)
            );

            // DialogDaRT Form properties
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(700, 375);
            Controls.AddRange(new Control[] { btnDownload, btnClose, lblInfoTool, imgTool });
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "DialogDaRT";
            Text = "DialogDaRT";
            ResumeLayout(false);
        }

        private Button CreateButton(string text, Font font, Point location, Size size, Image image, EventHandler clickEvent, bool textVisible = true)
        {
            var button = new Button
            {
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 },
                FlatStyle = FlatStyle.Flat,
                Font = font,
                ForeColor = Color.White,
                Location = location,
                Name = $"{text?.Replace(" ", "") ?? "Unnamed"}Button",
                Size = size,
                Text = text,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                UseVisualStyleBackColor = true,
                Image = image,
                Visible = textVisible
            };

            button.Click += clickEvent;
            return button;
        }

        private Label CreateLabel(string text, Font font, Point location, Size size, Color? foreColor = null)
        {
            return new Label
            {
                AutoSize = true,
                Font = font,
                ForeColor = foreColor ?? Color.White,
                Location = location,
                Name = $"{text.Replace(" ", "")}Label",
                Size = size,
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private PictureBox CreatePictureBox(Image image, Point location, Size size)
        {
            return new PictureBox
            {
                Image = image,
                Location = location,
                Name = "imgTool",
                Size = size,
                TabStop = false
            };
        }
    }
}

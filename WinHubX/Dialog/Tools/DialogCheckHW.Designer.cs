namespace WinHubX.Dialog.Tools
{
    partial class DialogCheckHW
    {
        private System.ComponentModel.IContainer components = null;

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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogCheckHW));

            // Initialize components
            label1 = CreateLabel("Check Hardware Tool", new Font("Product Sans Black", 25.8F, FontStyle.Bold), new Point(174, 70), new Size(451, 55));
            btnDownload = CreateButton("Check Hardware", new Font("Product Sans Black", 25.8F, FontStyle.Bold), new Point(215, 417), new Size(370, 70), Properties.Resources.pngDownload, btnDownload_Click);
            btnClose = CreateButton(null, null, new Point(733, 12), new Size(55, 55), Properties.Resources.pngClose, btnClose_Click, false);
            lblInfoTool = CreateLabel(resources.GetString("lblInfoTool.Text"), new Font("Product Sans", 15F), new Point(77, 138), new Size(645, 224), Color.Coral);

            // DialogCheckHW Form properties
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(800, 500);
            Controls.AddRange(new Control[] { label1, btnDownload, btnClose, lblInfoTool });
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DialogCheckHW";
            Text = "DialogCheckHW";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label CreateLabel(string text, Font font, Point location, Size size, Color? foreColor = null)
        {
            return new Label
            {
                AutoSize = true,
                Font = font,
                ForeColor = foreColor ?? Color.White,
                Location = location,
                Name = $"{text.Replace(" ", "")}Label", // Generate a name based on text
                Size = size,
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private Button CreateButton(string text, Font font, Point location, Size size, Image image, EventHandler clickEvent, bool textVisible = true)
        {
            return new Button
            {
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 },
                FlatStyle = FlatStyle.Flat,
                Font = font,
                ForeColor = Color.White,
                Location = location,
                Name = $"{text.Replace(" ", "")}Button", // Generate a name based on text
                Size = size,
                Text = text,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                UseVisualStyleBackColor = true,
                Image = image,
                Visible = textVisible
            }.WithClickEvent(clickEvent);
        }
    }

    public static class ControlExtensions
    {
        public static T WithClickEvent<T>(this T control, EventHandler clickEvent) where T : Control
        {
            control.Click += clickEvent;
            return control;
        }
    }
}

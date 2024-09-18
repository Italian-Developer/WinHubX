using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinHubX.Forms.Bottoni
{
    [DefaultProperty("Checked")]
    public class BottoniSwap : CheckBox
    {
        // Fields for colors and style
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        // Fields for size properties
        private int toggleSize = 20; // Default size of the toggle
        private int borderSize = 2; // Default size of the border when the solid style is false

        // Constructor
        public BottoniSwap()
        {
            // Set a minimum size to accommodate the toggle and border
            this.MinimumSize = new Size(45, toggleSize + borderSize * 2);
        }

        // Properties for colors and style
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "MediumSlateBlue")]
        public Color OnBackColor
        {
            get => onBackColor;
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "WhiteSmoke")]
        public Color OnToggleColor
        {
            get => onToggleColor;
            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Gray")]
        public Color OffBackColor
        {
            get => offBackColor;
            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Gainsboro")]
        public Color OffToggleColor
        {
            get => offToggleColor;
            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get => base.Text;
            set { }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get => solidStyle;
            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }

        // Properties for size
        [Category("Appearance")]
        [DefaultValue(20)]
        public int ToggleSize
        {
            get => toggleSize;
            set
            {
                toggleSize = value;
                this.MinimumSize = new Size(45, toggleSize + borderSize * 2);
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(2)]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.MinimumSize = new Size(45, toggleSize + borderSize * 2);
                this.Invalidate();
            }
        }

        // Methods

        // Get the path for drawing the control
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        // Draw the control
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            // Adjust the toggle position based on the property
            int togglePosition = this.Checked ? this.Width - this.Height + 1 : 2;

            // Draw the control surface
            using (GraphicsPath path = GetFigurePath())
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(this.Checked ? onBackColor : offBackColor), path);
                else
                    pevent.Graphics.DrawPath(new Pen(this.Checked ? onBackColor : offBackColor, borderSize), path);
            }

            // Draw the toggle
            pevent.Graphics.FillEllipse(new SolidBrush(this.Checked ? onToggleColor : offToggleColor),
                new Rectangle(togglePosition, (this.Height - toggleSize) / 2, toggleSize, toggleSize));
        }
    }
}

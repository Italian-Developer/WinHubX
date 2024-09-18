using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinHubX.Forms.Bottoni
{
    public class BottoniSwap : CheckBox
    {
        // Fields for colors and style
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        // New fields for size properties
        private int toggleSize = 20; // Default size of the toggle.
        private int borderSize = 2; // Default size of the border when the solid style is false.

        // Constructor
        public BottoniSwap()
        {
            // Set a minimum size to accommodate the toggle and border
            MinimumSize = new Size(45, toggleSize + borderSize * 2);
        }

        // Properties for colors and style
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "MediumSlateBlue")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OnBackColor
        {
            get => onBackColor;
            set
            {
                if (onBackColor != value)
                {
                    onBackColor = value;
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "WhiteSmoke")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OnToggleColor
        {
            get => onToggleColor;
            set
            {
                if (onToggleColor != value)
                {
                    onToggleColor = value;
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Gray")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OffBackColor
        {
            get => offBackColor;
            set
            {
                if (offBackColor != value)
                {
                    offBackColor = value;
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Gainsboro")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OffToggleColor
        {
            get => offToggleColor;
            set
            {
                if (offToggleColor != value)
                {
                    offToggleColor = value;
                    Invalidate();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get => base.Text ?? string.Empty; // Ensure no null value is returned
            set { }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool SolidStyle
        {
            get => solidStyle;
            set
            {
                if (solidStyle != value)
                {
                    solidStyle = value;
                    Invalidate();
                }
            }
        }

        // New properties for size
        [Category("Appearance")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ToggleSize
        {
            get => toggleSize;
            set
            {
                if (toggleSize != value)
                {
                    toggleSize = value;
                    MinimumSize = new Size(45, toggleSize + borderSize * 2);
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                if (borderSize != value)
                {
                    borderSize = value;
                    MinimumSize = new Size(45, toggleSize + borderSize * 2);
                    Invalidate();
                }
            }
        }

        // Methods

        // Get the path for drawing the control
        private GraphicsPath GetFigurePath()
        {
            int arcSize = Height - 1;
            var leftArc = new Rectangle(0, 0, arcSize, arcSize);
            var rightArc = new Rectangle(Width - arcSize - 2, 0, arcSize, arcSize);

            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        // Draw the control
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? Color.Transparent); // Handle potential null Parent

            // Adjusting the toggle size based on the property
            int togglePosition = Checked ? Width - Height + 1 : 2;

            // Draw the control surface
            using var path = GetFigurePath();
            if (solidStyle)
                e.Graphics.FillPath(new SolidBrush(Checked ? onBackColor : offBackColor), path);
            else
                e.Graphics.DrawPath(new Pen(Checked ? onBackColor : offBackColor, borderSize), path);

            // Draw the toggle
            e.Graphics.FillEllipse(new SolidBrush(Checked ? onToggleColor : offToggleColor),
                new Rectangle(togglePosition, (Height - toggleSize) / 2, toggleSize, toggleSize));
        }
    }
}

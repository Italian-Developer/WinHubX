using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinHubX.Forms.Bottoni
{
    internal class CircularProgressBar : Control
    {
        private int _minimum = 0;
        private int _maximum = 100;
        private int _value = 30;  // Impostato a 30 per il test iniziale

        [Category("Appearance")]
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                if (value >= _maximum)
                    throw new ArgumentException("Minimum must be less than Maximum");
                _minimum = value;
                if (_value < _minimum)
                    _value = _minimum;
                Refresh();
            }
        }

        [Category("Appearance")]
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                if (value <= _minimum)
                    throw new ArgumentException("Maximum must be greater than Minimum");
                _maximum = value;
                if (_value > _maximum)
                    _value = _maximum;
                Refresh();
            }
        }

        [Category("Appearance")]
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < _minimum || value > _maximum)
                    throw new ArgumentException("Value must be between Minimum and Maximum");
                _value = value;
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            float progressAngle = 360.0f * (_value - _minimum) / (_maximum - _minimum);

            // Dimensioni per la progress bar e per il fondo
            int margin = 10;
            int circleSize = Math.Min(this.Width, this.Height) - margin * 2;
            Rectangle rectBackground = new Rectangle((this.Width - circleSize) / 2, (this.Height - circleSize) / 2, circleSize, circleSize);

            // Background Circle
            using (SolidBrush brushBackground = new SolidBrush(Color.FromArgb(240, 240, 240))) // Colore del fondo
            {
                g.FillEllipse(brushBackground, rectBackground);
            }

            // Progress Circle
            using (Pen penProgress = new Pen(Color.FromArgb(0, 120, 215), 12)) // Colore del progresso e spessore
            {
                g.DrawArc(penProgress, rectBackground, -90, progressAngle);
            }

            // Text Center
            string text = $"{Value}%";
            using (Font font = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Bold))
            using (Brush brushText = new SolidBrush(Color.FromArgb(0, 120, 215)))
            {
                SizeF textSize = g.MeasureString(text, font);
                PointF textLocation = new PointF(this.Width / 2 - textSize.Width / 2,
                                                 this.Height / 2 - textSize.Height / 2);
                g.DrawString(text, font, brushText, textLocation);
            }
        }

        public CircularProgressBar()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            this.Size = new Size(150, 150);  // Default size, can be changed in the designer or programmatically
        }
    }
}

using testWinForms;

namespace View
{
    public class CircleParametersBox : FigureParametersBox
    {
        public NumericBox radiusTextBox { get; private set; }

        public CircleParametersBox()
        {
            radiusTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 0),
            };

            this.Controls.Add(radiusTextBox);
        }
    }
}

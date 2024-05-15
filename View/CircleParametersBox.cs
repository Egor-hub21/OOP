using testWinForms;

namespace View
{
    public class CircleParametersBox : FigureParametersBox
    {
        public NumericBox radiusTextBox { get; set; }
        public Label radiusLabel { get; set; }

        public CircleParametersBox()
        {
            radiusLabel = new Label()
            {
                Text = "Radius :",
                Dock = DockStyle.Bottom,
            };

            radiusTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
            };

            Size = new Size(200, 75);
            Text = "CircleParameters";

            Controls.Add(radiusLabel);
            Controls.Add(radiusTextBox);
        }
    }
}

using testWinForms;

namespace View
{
    public class RectangleParametersBox : FigureParametersBox
    {
        public NumericBox lengthTextBox { get; private set; }
        public NumericBox widthSideTextBox { get; private set; }

        public Label lenghtLabel { get; set; }
        public Label widthLabel { get; set; }

        public RectangleParametersBox()
        {
            lenghtLabel = new Label()
            {
                Text = "Lenght :",
                Dock = DockStyle.Bottom,
            };

            widthLabel = new Label()
            {
                Text = "Width :",
                Dock = DockStyle.Bottom,
            };

            lengthTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
            };
            

            widthSideTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
            };

            Size = new Size(200, 120);
            Text = "CircleParameters";

            Controls.Add(lenghtLabel);
            Controls.Add(lengthTextBox);
            Controls.Add(widthLabel);
            Controls.Add(widthSideTextBox);
        }
    }
}

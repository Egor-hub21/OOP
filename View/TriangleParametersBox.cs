using testWinForms;

namespace View
{
    public class TriangleParametersBox : FigureParametersBox
    {
        public NumericBox angleTextBox { get; private set; }
        public NumericBox firstSideTextBox { get; private set; }
        public NumericBox secondSideTextBox { get; private set; }

        public Label angelLabel { get; set; }
        public Label firstSideLabel { get; set; }
        public Label secondSideLabel { get; set; }


        public TriangleParametersBox()
        {
            angelLabel = new Label()
            {
                Text = "Angel :",
                Dock = DockStyle.Bottom,
            };

            firstSideLabel = new Label()
            {
                Text = "FirstSide :",
                Dock = DockStyle.Bottom,
            };

            secondSideLabel = new Label()
            {
                Text = "SecondSide :",
                Dock = DockStyle.Bottom,
            };

            angleTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 0),
            };

            firstSideTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 50),
            };

            secondSideTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 100),
            };

            Size = new Size(200, 165);
            Text = "TriangleParameters";

            Controls.Add(angelLabel);
            Controls.Add(firstSideTextBox);
            Controls.Add(firstSideLabel);
            Controls.Add(angleTextBox);
            Controls.Add(secondSideLabel);
            Controls.Add(secondSideTextBox);
        }
    }
}

using testWinForms;

namespace View
{
    public class TriangleParametersBox : FigureParametersBox
    {
        public NumericBox angelTextBox { get; private set; }
        public NumericBox firstSideTextBox { get; private set; }
        public NumericBox secondSideTextBox { get; private set; }


        public TriangleParametersBox()
        {
            angelTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 0),
            };
            this.Controls.Add(angelTextBox);

            firstSideTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 50),
            };
            this.Controls.Add(firstSideTextBox);

            secondSideTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 100),
            };
            this.Controls.Add(secondSideTextBox);
        }
    }
}

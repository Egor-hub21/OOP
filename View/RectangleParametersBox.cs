using testWinForms;

namespace View
{
    public class RectangleParametersBox : FigureParametersBox
    {
        public NumericBox lenghtTextBox { get; private set; }
        public NumericBox widthSideTextBox { get; private set; }


        public RectangleParametersBox()
        {
            lenghtTextBox = new NumericBox()
            {
                Location = new Point(0, 0),
            };
            this.Controls.Add(lenghtTextBox);

            widthSideTextBox = new NumericBox()
            {
                Location = new Point(0, 50),
            };
            this.Controls.Add(widthSideTextBox);
        }
    }
}

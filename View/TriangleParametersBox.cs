namespace View
{
    /// <summary>
    /// FigureParametersBox для ввода данных о треугольникке.
    /// </summary>
    public class TriangleParametersBox : FigureParametersBox
    {
        /// <summary>
        /// Текстовое поле для ввода угла.
        /// </summary>
        public NumericBox AngleTextBox { get; private set; }

        /// <summary>
        /// Текстовое поле для ввода первой стороны.
        /// </summary>
        public NumericBox FirstSideTextBox { get; private set; }

        /// <summary>
        /// Текстовое поле для ввода второй стороны.
        /// </summary>
        public NumericBox SecondSideTextBox { get; private set; }

        /// <summary>
        /// Название поля для ввода угла.
        /// </summary>
        public Label AngelLabel { get; set; }

        /// <summary>
        /// Название поля для ввода первой стороны.
        /// </summary>
        public Label FirstSideLabel { get; set; }

        /// <summary>
        /// Название поля для ввода второй стороны.
        /// </summary>
        public Label SecondSideLabel { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TriangleParametersBox"/> class.
        /// </summary>
        public TriangleParametersBox()
        {
            AngelLabel = new Label()
            {
                Text = "Angel :",
                Dock = DockStyle.Bottom,
            };

            FirstSideLabel = new Label()
            {
                Text = "FirstSide :",
                Dock = DockStyle.Bottom,
            };

            SecondSideLabel = new Label()
            {
                Text = "SecondSide :",
                Dock = DockStyle.Bottom,
            };

            AngleTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 0),
            };

            FirstSideTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 50),
            };

            SecondSideTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 100),
            };

            Size = new Size(200, 165);
            Text = "TriangleParameters";

            Controls.Add(FirstSideLabel);
            Controls.Add(FirstSideTextBox);
            Controls.Add(SecondSideLabel);
            Controls.Add(SecondSideTextBox);
            Controls.Add(AngelLabel);
            Controls.Add(AngleTextBox);
        }
    }
}

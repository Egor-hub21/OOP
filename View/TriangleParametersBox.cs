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
                Text = "Угол :",
                Left = leftElement,
                Top = topElement,
                Width = widthElement,
            };

            FirstSideLabel = new Label()
            {
                Text = "Сторона 1:",
                Left = leftElement,
                //TODO: to const
                Top = topElement + 40,
                Width = widthElement,
            };

            SecondSideLabel = new Label()
            {
                Text = "Сторона 2:",
                Left = leftElement,
                //TODO: to const
                Top = topElement + 40 * 2,
                Width = widthElement,
            };

            AngleTextBox = new NumericBox()
            {
                //TODO: to const
                Left = leftElement + 80,
                Top = topElement,
                Width = widthElement,
            };

            FirstSideTextBox = new NumericBox()
            {
                //TODO: to const
                Left = leftElement + 80,
                Top = topElement + 40,
                Width = widthElement,
            };

            SecondSideTextBox = new NumericBox()
            {
                //TODO: to const
                Left = leftElement + 80,
                Top = topElement + 40 * 2,
                Width = widthElement,
            };

            Size = new Size(width, height);
            Text = "Параметры треугольника";

            Controls.Add(FirstSideLabel);
            Controls.Add(FirstSideTextBox);
            Controls.Add(SecondSideLabel);
            Controls.Add(SecondSideTextBox);
            Controls.Add(AngelLabel);
            Controls.Add(AngleTextBox);
        }
    }
}

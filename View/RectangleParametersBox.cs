namespace View
{
    /// <summary>
    /// FigureParametersBox для ввода данных о прямоугольнике.
    /// </summary>
    public class RectangleParametersBox : FigureParametersBox
    {
        /// <summary>
        /// Текстовое поле для ввода длинны.
        /// </summary>
        public NumericBox LengthTextBox { get; private set; }

        /// <summary>
        /// Текстовое поле для ввода ширины.
        /// </summary>
        public NumericBox WidthSideTextBox { get; private set; }

        /// <summary>
        /// Название поля для ввода длинны.
        /// </summary>
        public Label LenghtLabel { get; set; }

        /// <summary>
        /// Название поля для ввода ширины.
        /// </summary>
        public Label WidthLabel { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RectangleParametersBox"/> class.
        /// </summary>
        public RectangleParametersBox()
        {
            LenghtLabel = new Label()
            {
                Text = "Длина :",
                Left = leftElement,
                Top = topElement,
                Width = widthElement,
            };

            WidthLabel = new Label()
            {
                Text = "Ширина :",
                Left = leftElement,
                Top = topElement + 40,
                Width = widthElement,
            };

            LengthTextBox = new NumericBox()
            {
                Left = leftElement + 80,
                Top = topElement,
                Width = widthElement,
            };

            WidthSideTextBox = new NumericBox()
            {
                Left = leftElement + 80,
                Top = topElement + 40,
                Width = widthElement,
            };

            //TODO: duplication +
            Size = new Size(width, height);
            Text = "Параметры окружности";

            Controls.Add(LenghtLabel);
            Controls.Add(LengthTextBox);
            Controls.Add(WidthLabel);
            Controls.Add(WidthSideTextBox);
        }
    }
}

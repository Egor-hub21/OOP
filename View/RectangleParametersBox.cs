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
                Left = LleftElement,
                Top = TopElement,
                Width = WidthElement,
            };

            WidthLabel = new Label()
            {
                Text = "Ширина :",
                Left = LleftElement,
                Top = TopElement + ShiftTop,
                Width = WidthElement,
            };

            LengthTextBox = new NumericBox()
            {
                Left = LleftElement + ShiftLleft,
                Top = TopElement,
                Width = WidthElement,
            };

            WidthSideTextBox = new NumericBox()
            {
                Left = LleftElement + ShiftLleft,
                Top = TopElement + ShiftTop,
                Width = WidthElement,
            };

            //TODO: duplication +
            Size = new Size(WidthBox, HeightBox);
            Text = "Параметры окружности";

            Controls.Add(LenghtLabel);
            Controls.Add(LengthTextBox);
            Controls.Add(WidthLabel);
            Controls.Add(WidthSideTextBox);
        }
    }
}

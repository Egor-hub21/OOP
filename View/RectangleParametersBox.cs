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
                Text = "Lenght :",
                Dock = DockStyle.Bottom,
            };

            WidthLabel = new Label()
            {
                Text = "Width :",
                Dock = DockStyle.Bottom,
            };

            LengthTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
            };

            WidthSideTextBox = new NumericBox()
            {
                Dock = DockStyle.Bottom,
            };

            Size = new Size(200, 120);
            Text = "CircleParameters";

            Controls.Add(LenghtLabel);
            Controls.Add(LengthTextBox);
            Controls.Add(WidthLabel);
            Controls.Add(WidthSideTextBox);
        }
    }
}

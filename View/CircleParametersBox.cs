namespace View
{
    /// <summary>
    /// FigureParametersBox для ввода данных о круге.
    /// </summary>
    public class CircleParametersBox : FigureParametersBox
    {
        /// <summary>
        /// Текстовое поле для ввода радиуса.
        /// </summary>
        public NumericBox RadiusTextBox { get; set; }

        /// <summary>
        /// Название поля для ввода радиуса.
        /// </summary>
        public Label RadiusLabel { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CircleParametersBox"/> class.
        /// </summary>
        public CircleParametersBox()
        {
            RadiusLabel = new Label()
            {
                Text = "Радиус :",
                Left = leftElement,
                Top = topElement,
                Width = widthElement,
            };

            RadiusTextBox = new NumericBox()
            {
                Left = leftElement + 80,
                Top = topElement,
                Width = widthElement,
            };

            Size = new Size(width, height);
            Text = "Параметры окружности";

            Controls.Add(RadiusLabel);
            Controls.Add(RadiusTextBox);
        }
    }
}

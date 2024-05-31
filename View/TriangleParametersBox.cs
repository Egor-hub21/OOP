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
                Left = LeftElement,
                Top = TopElement,
                Width = WidthElement,
            };

            FirstSideLabel = new Label()
            {
                Text = "Сторона 1:",
                Left = LeftElement,
                Top = TopElement + ShiftTop,
                Width = WidthElement,
            };

            SecondSideLabel = new Label()
            {
                Text = "Сторона 2:",
                Left = LeftElement,
                Top = TopElement + ShiftTop * 2,
                Width = WidthElement,
            };

            AngleTextBox = new NumericBox()
            {
                Left = LeftElement + ShiftLeft,
                Top = TopElement,
                Width = WidthElement,
            };

            FirstSideTextBox = new NumericBox()
            {
                Left = LeftElement + ShiftLeft,
                Top = TopElement + ShiftTop,
                Width = WidthElement,
            };

            SecondSideTextBox = new NumericBox()
            {
                Left = LeftElement + ShiftLeft,
                Top = TopElement + ShiftTop * 2,
                Width = WidthElement,
            };

            Size = new Size(WidthBox, HeightBox);
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

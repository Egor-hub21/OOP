namespace View
{
    /// <summary>
    /// GroupBox для ввода данных о геометрической фигуре.
    /// </summary>
    public class FigureParametersBox : GroupBox
    {
        //TODO: RSDN
        /// <summary>
        /// Шириена box.
        /// </summary>
        protected readonly int width = 200;

        /// <summary>
        /// Высота box.
        /// </summary>
        protected readonly int height = 140;

        /// <summary>
        /// Ширина элемента.
        /// </summary>
        protected readonly int widthElement = 80;

        /// <summary>
        /// Расстояние в пикселях между левым краем элемента управления
        /// и левым краем клиентской области его контейнера.
        /// </summary>
        protected readonly int leftElement = 10;

        /// <summary>
        /// Расстояние в пикселях между верхним краем элемента управления
        /// и верхним краем клиентской области его контейнера.
        /// </summary>
        protected readonly int topElement = 20;


        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FigureParametersBox"/> class.
        /// </summary>
        public FigureParametersBox()
        { }
    }
}

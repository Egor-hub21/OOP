namespace GeometricFigures
{
    /// <summary>
    /// Описывает характеристики прямоугольника.
    /// </summary>
    public class Rectangle : GeometricFigureBase
    {
        /// <summary>
        /// Длинна.
        /// </summary>
        private double _length;

        /// <summary>
        /// Высота.
        /// </summary>
        private double _width;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="length">Длинна.</param>
        /// <param name="width">Ширина.</param>
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        public Rectangle() : this(1, 1)
        { }

        /// <summary>
        /// Get Set <see cref="_length"/>..
        /// </summary>
        public double Length
        {
            get => _length;

            set
            {
                CheckNumberPositivity(value);

                _length = value;
            }
        }

        /// <summary>
        /// Get Set <see cref="_width"/>..
        /// </summary>
        public double Width
        {
            get => _width;
            set
            {
                CheckNumberPositivity(value);

                _width = value;
            }
        }

        /// <inheritdoc/>
        public override string TypeFigure
        {
            get => TypeFigures.Rectangle.ToString();
        }

        /// <inheritdoc/>
        public override double Area { get => Width * Length; }

        /// <inheritdoc/>
        public override double Perimeter { get => (Width * 2) + (2 * Length); }

        /// <inheritdoc/>
        public override string Info { get => $"Длина: {Length}, Ширина: {Width}"; }
    }
}

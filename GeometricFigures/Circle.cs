namespace GeometricFigures
{
    /// <summary>
    /// Описывает характеристики круга.
    /// </summary>
    public class Circle : GeometricFigureBase
    {
        /// <summary>
        /// радиус окружности.
        /// </summary>
        private double _radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Радиус.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        public Circle() : this(1)
        { }

        /// <summary>
        /// Get Set <see cref="_radius"/>.
        /// </summary>
        public double Radius
        {
            get => _radius;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _radius = value;
            }
        }

        /// <inheritdoc/>
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        /// <inheritdoc/>
        public override string GetInfo()
        {
            return $"Радиус: {Radius}";
        }

        /// <inheritdoc/>
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}

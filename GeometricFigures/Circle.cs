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
                CheckNumberPositivity(value);

                _radius = value;
            }
        }

        /// <inheritdoc/>
        public override string TypeFigure
        {
            get => TypeFigures.Circle.ToString();
        }

        /// <inheritdoc/>
        public override double Area { get => Math.PI * Math.Pow(Radius, 2); }

        /// <inheritdoc/>
        public override double Perimeter { get => 2 * Math.PI * Radius; }

        /// <inheritdoc/>
        public override string Info { get => $"Радиус: {Radius}"; }
    }
}

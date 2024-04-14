namespace GeometricFigures
{
    /// <summary>
    /// Описывает характеристики треугольника.
    /// </summary>
    public class Triangle : GeometricFigureBase
    {
        /// <summary>
        /// Первая сторона.
        /// </summary>
        private double _firstSide;

        /// <summary>
        /// Вторая сторона.
        /// </summary>
        private double _secondSide;

        /// <summary>
        /// Угол между прямыми.
        /// </summary>
        private Angle _angle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="firstSide">Первая сторона.</param>
        /// <param name="secondSide">Вторая сторона.</param>
        /// <param name="angle">Угол между прямыми.</param>
        public Triangle(double firstSide, double secondSide, Angle angle)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            Angle = angle;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        public Triangle() : this(1, 1, new Angle(60))
        { }

        /// <summary>
        /// Get Set <see cref="_firstSide"/>.
        /// </summary>
        public double FirstSide
        {
            get => _firstSide;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _firstSide = value;
            }
        }

        /// <summary>
        /// Get Set <see cref="_secondSide"/>.
        /// </summary>
        public double SecondSide
        {
            get => _secondSide;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _secondSide = value;
            }
        }

        /// <summary>
        /// Get Set <see cref="_thirdSide"/>.
        /// </summary>
        public Angle Angle
        {
            get => _angle;

            set
            {
                if (value.Degrees <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _angle = value;
            }
        }

        /// <inheritdoc/>
        public override double GetArea()
        {
            return 0.5 * FirstSide * SecondSide * Math.Sin(Angle.Radians);
        }

        /// <inheritdoc/>
        public override string GetInfo()
        {
            return $"Стороны треугольника :{FirstSide};"
                + $" {SecondSide};"
                + $" {Angle.Degrees};";
        }

        /// <inheritdoc/>
        public override double GetPerimeter()
        {
            return FirstSide + SecondSide + GetThirdSide();
        }

        /// <summary>
        /// Возвращает значение третьей стороны.
        /// </summary>
        /// <returns>Третья сторона.</returns>
        public double GetThirdSide()
        {
            return Math.Pow(FirstSide, 2) + Math.Pow(SecondSide, 2)
                - (2 * FirstSide * SecondSide * Math.Sin(Angle.Radians));
        }
    }
}
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
                CheckNumberPositivity(value);

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
                CheckNumberPositivity(value);

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
                CheckNumberPositivity(value.Degrees);
                if (value.Degrees >= 180)
                {
                    throw new ArgumentOutOfRangeException(
                        "Угол треугольника должен быть меньше 180!");
                }

                _angle = value;
            }
        }

        /// <inheritdoc/>
        public override string TypeFigure { get => GetType().Name; }

        /// <inheritdoc/>
        public override double Area { get => GetArea(); }

        /// <inheritdoc/>
        public override double Perimeter { get => GetPerimeter(); }

        /// <inheritdoc/>
        public override string Info { get => GetInfo(); }

        /// <inheritdoc/>
        public override double GetArea()
        {
            return 0.5 * FirstSide * SecondSide * Math.Sin(Angle.Radians);
        }

        /// <inheritdoc/>
        public override string GetInfo()
        {
            return $"Первая сторона: {FirstSide}; "
                + $"Вторая сторона: {SecondSide}; "
                + $"Угол м/у ними: {Angle.Degrees};";
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

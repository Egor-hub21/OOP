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
        public Triangle(double firstSide, double secondSide, double angle)
        {
            if (angle <= 0 || angle >= 180)
            {
                throw new ArgumentOutOfRangeException("Введенный угол" +
                    " должен находиться в диапазоне от 0 до 180!");
            }

            FirstSide = firstSide;
            SecondSide = secondSide;
            Angle = new Angle(angle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        public Triangle() : this(1, 1, 60)
        { }

        /// <summary>
        /// Gets or sets get Set <see cref="_firstSide"/>.
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
        /// Gets or sets get Set <see cref="_secondSide"/>.
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
        /// Gets or sets get Set <see cref="_thirdSide"/>.
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
        public override string TypeFigure
        {
            get => "Треугольник";
        }

        /// <inheritdoc/>
        public override double Area
        {
            get => 0.5 * FirstSide
                * SecondSide
                * Math.Sin(Angle.Radians);
        }

        /// <inheritdoc/>
        public override double Perimeter
        {
            get => FirstSide + SecondSide + GetThirdSide();
        }

        /// <inheritdoc/>
        public override string Info
        {
            get => $"Первая сторона: {FirstSide};\n"
                + $"Вторая сторона: {SecondSide};\n"
                + $"Угол м/у ними: {Angle.Degrees};";
        }

        /// <summary>
        /// Возвращает значение третьей стороны.
        /// </summary>
        /// <returns>Третья сторона.</returns>
        public double GetThirdSide()
        {
            return Math.Pow((Math.Pow(FirstSide, 2) + Math.Pow(SecondSide, 2)
                - (2 * FirstSide * SecondSide * Math.Cos(Angle.Radians))), 0.5);
        }
    }
}

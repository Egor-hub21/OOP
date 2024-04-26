namespace GeometricFigures
{
    /// <summary>
    /// Структура описывает угол между двумя прямыми.
    /// </summary>
    public struct Angle
    {
        /// <summary>
        /// Градусы.
        /// </summary>
        private double _degrees;

        /// <summary>
        /// Initializes a new instance of the <see cref="Angle"/> struct.
        /// </summary>
        /// <param name="degrees">Градусы.</param>
        public Angle(double degrees)
        {
            Degrees = degrees;
        }

        /// <summary>
        /// GetSet угол в градусах.
        /// </summary>
        public double Degrees
        {
            get => _degrees;

            set
            {
                int rotation = 360;
                if (value > rotation)
                {
                    int countRotations = Convert.ToInt32(value / rotation);
                    value -= rotation * countRotations;
                }

                _degrees = value;
            }
        }

        /// <summary>
        /// GetSet угол в радианах.
        /// </summary>
        public double Radians
        {
            get => Degrees * Math.PI / 180;

            set => Degrees = value * 180 / Math.PI;
        }
    }
}

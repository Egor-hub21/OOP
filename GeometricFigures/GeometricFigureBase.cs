
namespace GeometricFigures
{
    /// <summary>
    /// Описывает общую природу всех геометрических фигур.
    /// </summary>
    public abstract class GeometricFigureBase
    {
        /// <summary>
        /// Тип фигуры.
        /// </summary>
        public abstract string TypeFigure { get; }

        /// <summary>
        /// Площадь фигуры.
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// Периметр фигуры.
        /// </summary>
        public abstract double Perimeter { get; }

        /// <summary>
        /// Информацию о фигуре в форме строки.
        /// </summary>
        public abstract string Info { get; }

        /// <summary>
        /// Возвращает площадь фигуры.
        /// </summary>
        /// <returns>Площадь.</returns>
        public abstract double GetArea();

        /// <summary>
        /// Возвращает периметр фигуры.
        /// </summary>
        /// <returns>Периметр.</returns>
        public abstract double GetPerimeter();

        /// <summary>
        /// Возвращает информацию о фигуре в форме строки.
        /// </summary>
        /// <returns>Информация.</returns>
        public abstract string GetInfo();

        /// <summary>
        /// Выбрасывает исключение если число меньше или равно нулю.
        /// </summary>
        /// <param name="number">Число.</param>
        /// <exception cref="ArgumentOutOfRangeException">Исключение.</exception>
        protected static void CheckNumberPositivity(double number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Число должно быть больше нуля.");
            }
        }
    }
}


namespace GeometricFigures
{
    /// <summary>
    /// Описывает общую природу всех геометрических фигур.
    /// </summary>
    public abstract class GeometricFigureBase
    {
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

    }
}

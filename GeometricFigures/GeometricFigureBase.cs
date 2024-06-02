using System.ComponentModel;
using System.Xml.Serialization;

namespace GeometricFigures
{
    /// <summary>
    /// Описывает общую природу всех геометрических фигур.
    /// </summary>
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    public abstract class GeometricFigureBase
    {
        /// <summary>
        /// Тип фигуры.
        /// </summary>
        [DisplayName("Тип фигуры")]
        public abstract string TypeFigure { get; }

        /// <summary>
        /// Площадь фигуры.
        /// </summary>
        [DisplayName("Площадь")]
        public abstract double Area { get; }

        /// <summary>
        /// Периметр фигуры.
        /// </summary>
        [DisplayName("Периметр")]
        public abstract double Perimeter { get; }

        /// <summary>
        /// Информацию о фигуре в форме строки.
        /// </summary>
        [DisplayName("Информация")]
        public abstract string Info { get; }

        /// <summary>
        /// Выбрасывает исключение если число меньше или равно нулю.
        /// </summary>
        /// <param name="number">Число.</param>
        /// <exception cref="ArgumentOutOfRangeException">Исключение.</exception>
        protected static void CheckNumberPositivity(double number)
        {
            if (number is double.NaN)
            {
                throw new ArgumentOutOfRangeException(
                    "Введено NaN.");
            }

            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Число должно быть больше нуля.");
            }
        }
    }
}

using GeometricFigures;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// Представляет данные для события, возникающего при
    /// добавлении нескольких новых геометрических фигур.
    /// </summary>
    internal class FiguresAddedEventArgs : EventArgs
    {
        /// <summary>
        /// Получает список добавленных геометрических фигур.
        /// </summary>
        public BindingList<GeometricFigureBase> GeometricFigure { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса 
        /// <see cref="FiguresAddedEventArgs"/>.
        /// </summary>
        /// <param name="geometricFigure">Список 
        /// добавленных геометрических фигур.</param>
        /// <exception cref="ArgumentNullException">Если 
        /// <paramref name="geometricFigure"/> равен <c>null</c>.</exception>
        public FiguresAddedEventArgs(
            BindingList<GeometricFigureBase> geometricFigure)
        {
            if (geometricFigure == null)
            {
                throw new ArgumentNullException();
            }

            GeometricFigure = geometricFigure;
        }
    }
}

using GeometricFigures;

namespace View
{
    //TODO: XML +
    /// <summary>
    /// Представляет данные для события, возникающего
    /// при добавлении новой геометрической фигуры.
    /// </summary>
    internal class FigureAddedEventArgs : EventArgs 
    {
        //TODO: XML +
        /// <summary>
        /// Получает добавленную геометрическую фигуру.
        /// </summary>
        public GeometricFigureBase GeometricFigure { get; }

        //TODO: XML +
        /// <summary>
        /// Инициализирует новый экземпляр
        /// класса <see cref="FigureAddedEventArgs"/>.
        /// </summary>
        /// <param name="geometricFigure">Добавленная 
        /// геометрическая фигура.</param>
        /// <exception cref="ArgumentNullException">Если 
        /// <paramref name="geometricFigure"/> равен <c>null</c>.</exception>
        public FigureAddedEventArgs(GeometricFigureBase geometricFigure)
        {
            if (geometricFigure == null)
            { 
                throw new ArgumentNullException(); 
            }

            GeometricFigure = geometricFigure;
        }
    }
}

using GeometricFigures;

namespace View
{
    internal class FigureAddedEventArgs : EventArgs 
    {
        public GeometricFigureBase GeometricFigure { get; }

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

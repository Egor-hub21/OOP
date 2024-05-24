using GeometricFigures;

namespace View
{
    //TODO: XML
    internal class FigureAddedEventArgs : EventArgs 
    {
        //TODO: XML
        public GeometricFigureBase GeometricFigure { get; }

        //TODO: XML
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

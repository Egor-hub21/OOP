using GeometricFigures;
using System.ComponentModel;

namespace View
{
    //TODO: XML
    internal class FiguresAddedEventArgs : EventArgs
    {
        //TODO: XML
        public BindingList<GeometricFigureBase> GeometricFigure { get; }

        //TODO: XML
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

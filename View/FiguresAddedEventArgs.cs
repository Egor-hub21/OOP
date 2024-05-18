using GeometricFigures;
using System.ComponentModel;

namespace View
{
    internal class FiguresAddedEventArgs : EventArgs
    {
        public BindingList<GeometricFigureBase> GeometricFigure { get; }

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

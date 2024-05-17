using GeometricFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

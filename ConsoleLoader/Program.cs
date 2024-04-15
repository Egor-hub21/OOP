using GeometricFigures;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс Program.
    /// </summary>
    internal class Program
    {

        /// <summary>
        /// Метод Main.
        /// </summary>
        public static void Main()
        {
            GeometricFigureBase newCircel = ConsoleFigures.ConsoleReadTriangle();
            Console.WriteLine(newCircel.GetArea());

        }
    }
}

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
            double t = Convert.ToDouble(Console.ReadLine());
            GeometricFigureBase newCircel = ConsoleFigures.ConsoleReadTriangle();
            Console.WriteLine(newCircel.GetArea());

        }
    }
}

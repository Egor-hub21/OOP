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
            while (true)
            {
                Console.WriteLine("Чтобы выйти из программы, нажмите \"x\", "
                    + "для начала работы - любую другую клавишу :");

                ConsoleKeyInfo userInput = Console.ReadKey();
                Console.WriteLine();

                switch (userInput.KeyChar)
                {
                    case 'x':
                    {
                        return;
                    }

                    default:
                    {
                        break;
                    }
                }

                GeometricFigureBase newFigure = ConsoleFigures.ReadFigure();
                Console.WriteLine(Math.Round(newFigure.GetArea(), 2));
            }

        }
    }
}

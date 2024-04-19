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
                GeometricFigureBase newFigur = ConsoleFigures.ReadFigure();
                Console.WriteLine(newFigur.GetArea());

                Console.WriteLine("Введите символ 'y',продолжить выполнение программы :");
                ConsoleKeyInfo userInput = Console.ReadKey();
                Console.WriteLine();

                switch (userInput.KeyChar)
                {
                    case 'y':
                        Console.WriteLine("Продолжение выполнения программы.");
                        break;
                    default:
                        return;
                }
            }

        }
    }
}

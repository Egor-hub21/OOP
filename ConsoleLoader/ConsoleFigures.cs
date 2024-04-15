using GeometricFigures;

namespace ConsoleLoader
{
    /// <summary>
    /// Ввод данных о фигурах с консоли.
    /// </summary>
    public static class ConsoleFigures
    {
        /// <summary>
        /// Ввод данных о круге с консоли.
        /// </summary>
        /// <returns>Круг.</returns>
        public static Circle ConsoleReadCircle()
        {
            Circle circle = new Circle();

            var actions = new List<Action>()
            {
                () =>
                {
                    Console.WriteLine("Введите радиус");
                    circle.Radius = Convert.ToDouble(Console.ReadLine());
                },
            };

            return ConsoleReadFigure(circle, actions);
        }

        /// <summary>
        /// Ввод данных о прямоугольнике с консоли.
        /// </summary>
        /// <returns>прямоугольник.</returns>
        public static Rectangle ConsoleReadRectangle()
        {
            Rectangle rectangle = new Rectangle();

            var actions = new List<Action>()
            {
                () =>
                    {
                        Console.WriteLine("Введите длину");
                        rectangle.Length = Convert.ToDouble(Console.ReadLine());
                    },
                () =>
                {
                    Console.WriteLine("Введите ширину");
                    rectangle.Width = Convert.ToDouble(Console.ReadLine());
                },
            };

            return ConsoleReadFigure(rectangle, actions);
        }

        /// <summary>
        /// Ввод данных о треугольнике с консоли.
        /// </summary>
        /// <returns>треугольник.</returns>
        public static Triangle ConsoleReadTriangle()
        {
            Triangle triangle = new Triangle();

            var actions = new List<Action>()
            {
                () =>
                {
                    Console.WriteLine("Введите первую сторону");
                    triangle.FirstSide = Convert.ToDouble(Console.ReadLine());
                },
                () =>
                {
                    Console.WriteLine("Введите вторую сторону");
                    triangle.SecondSide = Convert.ToDouble(Console.ReadLine());
                },
                () =>
                {
                    Console.WriteLine("Угол");
                    triangle.Angle = new Angle(Convert.ToDouble(Console.ReadLine()));
                },
            };

            return ConsoleReadFigure(triangle, actions);
        }

        /// <summary>
        /// Создание геометрической фигуры.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="figure"> Геометрическая фигура.</param>
        /// <param name="assignActions">Действия для создания фигуры.</param>
        /// <returns>Геометрическая фигура.</returns>
        private static T ConsoleReadFigure<T>(T figure, List<Action> assignActions)
        {
            Dictionary<Type, Action<string>> catchDictionary = new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
            };

            foreach (var assignAction in assignActions)
            {
                ActionHandler(assignAction, catchDictionary);
            }

            return figure;
        }

        /// <summary>
        /// Зацикливает выполнение программы до ее корректного завершения.
        /// </summary>
        /// <param name="tryAction">Действия.</param>
        /// <param name="catchActionDictionary">Словарь в котором хранятся
        /// действия в случае возникновения исключений.</param>
        private static void ActionHandler(Action tryAction,
            Dictionary<Type, Action<string>> catchActionDictionary)
        {
            while (true)
            {
                try
                {
                    tryAction.Invoke();
                    return;
                }
                catch (Exception ex)
                {
                    catchActionDictionary[ex.GetType()].Invoke(ex.Message);
                }

                Console.WriteLine("\n!Ошибка ввода!\nПопробуйте снова:");
            }
        }

    }
}

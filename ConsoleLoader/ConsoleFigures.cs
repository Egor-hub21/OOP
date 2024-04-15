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

            var catchDictionary = new Dictionary<Type, Action<string>>()
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

            var actions = new List<Action>()
            {
                () =>
                {
                    Console.WriteLine("Введите радиус");
                    circle.Radius = Convert.ToDouble(Console.ReadLine());
                },
            };

            foreach (Action action in actions)
            {
                ActionHandler(action, catchDictionary);
            }

            return circle;
        }

        /// <summary>
        /// Ввод данных о прямоугольнике с консоли.
        /// </summary>
        /// <returns>прямоугольник.</returns>
        public static Rectangle ConsoleReadRectangle()
        {
            Rectangle rectangle = new Rectangle();

            var catchDictionary = new Dictionary<Type, Action<string>>()
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

            foreach (Action action in actions)
            {
                ActionHandler(action, catchDictionary);
            }

            return rectangle;
        }

        /// <summary>
        /// Ввод данных о треугольнике с консоли.
        /// </summary>
        /// <returns>треугольник.</returns>
        public static Triangle ConsoleReadTriangle()
        {
            Triangle triangle = new Triangle();

            var catchDictionary = new Dictionary<Type, Action<string>>()
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

            foreach (Action action in actions)
            {
                ActionHandler(action, catchDictionary);
            }

            return triangle;
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

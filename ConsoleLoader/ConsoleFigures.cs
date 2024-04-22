using GeometricFigures;

namespace ConsoleLoader
{
    /// <summary>
    /// Ввод данных о фигурах с консоли.
    /// </summary>
    public static class ConsoleFigures
    {
        /// <summary>
        /// Создание фигуры.
        /// </summary>
        /// <returns>Фигура.</returns>
        /// <exception cref="ArgumentOutOfRangeException">.</exception>
        public static GeometricFigureBase ReadFigure()
        {
            GeometricFigureBase figureBase = new Circle();

            var actions = new List<Action>()
            {
                () =>
                {
                    Console.WriteLine("Номера фигур:\n" +
                        "\t1 - Круг;\n" +
                        "\t2 - Прямоугольник;\n" +
                        "\t3 - Треугольник.\n" +
                        "Введите номер фигуры:");
                },

                () =>
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    Console.WriteLine();

                    switch (keyInfo.KeyChar)
                    {
                        case '1':
                            figureBase = ReadCircle();
                            break;
                        case '2':
                            figureBase = ReadRectangle();
                            break;
                        case '3':
                            figureBase = ReadTriangle();
                            break;
                        default:
                            //TODO: RSDN
                             throw new ArgumentOutOfRangeException("\nВы нажали недопустимую клавишу");
                    }
                },
            };

            ActionHandler(actions);

            return figureBase;
        }

        /// <summary>
        /// Ввод данных о круге с консоли.
        /// </summary>
        /// <returns>Круг.</returns>
        public static Circle ReadCircle()
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

            ActionHandler(actions);

            return circle;
        }

        /// <summary>
        /// Ввод данных о прямоугольнике с консоли.
        /// </summary>
        /// <returns>прямоугольник.</returns>
        public static Rectangle ReadRectangle()
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

            ActionHandler(actions);

            return rectangle;
        }

        /// <summary>
        /// Ввод данных о треугольнике с консоли.
        /// </summary>
        /// <returns>треугольник.</returns>
        public static Triangle ReadTriangle()
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

            ActionHandler(actions);

            return triangle;
        }

        /// <summary>
        /// Зацикливает выполнение программы до ее корректного завершения.
        /// </summary>
        /// <param name="assignActions">Действия для создания фигуры.</param>
        /// действия в случае возникновения исключений.</param>
        private static void ActionHandler(List<Action> assignActions)
        {
            //TODO: RSDN
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
                while (true)
                {
                    try
                    {
                        assignAction.Invoke();
                        break;
                    }
                    catch (Exception ex)
                    {
                        catchDictionary[ex.GetType()].Invoke(ex.Message);
                    }

                    Console.WriteLine("\n!Ошибка ввода!\nПопробуйте снова:\n");
                }
            }
        }

    }
}

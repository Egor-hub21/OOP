using People;

namespace ConsolePeople
{
    /// <summary>
    /// Класс реализующий взаимодействие <see cref="PersonBase"/>
    /// с пользователем.
    /// </summary>
    public class ConsolePerson
    {
        /// <summary>
        /// Чтения <see cref="PersonBase"/> с клавиатуры.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="PersonBase"/>.</returns>
        public static PersonBase ConsoleReadPerson()
        {
            PersonBase сonsolePerson = new PersonBase();

            var catchDictioary = new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        Console.WriteLine($"Возникло исключение {message}");
                    }
                }
            };

            var tmpCollection = new List<Tuple<Action, Dictionary<Type,
                                                          Action<string>>>>
            {
                new Tuple<Action, Dictionary<Type,Action<string>>>(
                        () =>
                        {
                            Console.WriteLine("Введите имя: ");
                            сonsolePerson.FirstName = Console.ReadLine();
                        },
                        catchDictioary
                    ),
                new Tuple<Action, Dictionary<Type,Action<string>>>(
                        () =>
                        {
                            Console.WriteLine("Введите фамилию: ");
                            сonsolePerson.LastName = Console.ReadLine();
                        },
                        catchDictioary
                    ),
                new Tuple<Action, Dictionary<Type,Action<string>>>(
                        () =>
                        {
                            Console.WriteLine($"Введите Возраст человека: ");
                            сonsolePerson.Age =
                                        Convert.ToInt32(Console.ReadLine());
                        },
                        catchDictioary
                        ),
                new Tuple<Action, Dictionary<Type,Action<string>>>(
                        () =>
                        {
                            Console.WriteLine("Введите пол М/Ж (M/F): ");
                            var enteredGender = Console.ReadLine().ToLower();
                            switch (enteredGender)
                            {
                                case "m":
                                case "м":
                                    {
                                        сonsolePerson.Gender = Gender.Male;
                                        break;
                                    }

                                case "f":
                                case "ж":
                                    {
                                        сonsolePerson.Gender = Gender.Female;
                                        break;
                                    }

                                default:
                                    {
                                        throw new ArgumentException
                                            ("Некорректный ввод. При вводе "
                                            + "разрешено использовать "
                                            + "следующие символы: М,Ж,M,F.");
                                    }
                            }
                        },
                        new Dictionary<Type, Action<string>>()
                        {
                            {
                                typeof(ArgumentException),
                                (string message) =>
                                {
                                    Console.WriteLine($"Введён не корректный"
                                                      + $" пол, ошибка:"
                                                      + $" {message}");
                                }
                            }
                        }
                    )
            };

            foreach (var action in tmpCollection)
            {
                ActionHandler(action.Item1, action.Item2);
            }

            return сonsolePerson;
        }

        /// <summary>
        /// Вспомогательный метод зацикливания действий пользователя.
        /// </summary>
        /// <param name="tryAction">Действие.</param>
        /// <param name="catchActionDictionary">Словарь Key:Тип исключения,
        /// Value: действие.</param>
        private static void ActionHandler(Action tryAction, Dictionary<Type,
                                      Action<string>> catchActionDictionary)
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

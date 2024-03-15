using People;

namespace ConsolePeople
{
    /// <summary>
    /// Класс статических методов
    /// для создания случайных людей.
    /// </summary>
    public class RandomPerson
    {
        #region RandomPerson

        /// <summary>
        /// Создает экземпляяр класса <see cref="Person"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Person"/>.</returns>
        public static Person GetRandomPerson()
        {
            Person randomPerson = new Person();
            RandomDataPerson(randomPerson);
            RandomDataPerson(randomPerson);

            return randomPerson;
        }

        /// <summary>
        /// Создает экземпляяр класса <see cref="Person"/>
        /// со случайным набором полей.
        /// </summary>
        /// <param name="gender">Пол.</param>
        /// <returns>Экземпляр класса <see cref="Person"/>.</returns>
        public static Person GetRandomPerson(Gender gender)
        {
            Person randomPerson = new Person();
            randomPerson.Gender = gender;
            RandomDataPerson(randomPerson);

            return randomPerson;
        }

        /// <summary>
        /// Присваивает объекту случайные
        /// данные в зависимости от пола.
        /// </summary>
        /// <param name="randomPerson">Экземпляр класса.</param>
        protected static void RandomDataPerson(Person randomPerson)
        {
            RandomAge(randomPerson);
            RandomNames(randomPerson);
        }

        /// <summary>
        /// Создание рандомного возраста.
        /// </summary>
        /// <param name="randomPerson">Экземпляр класса.</param>
        protected static void RandomAge(Person randomPerson)
        {
            Random random = new Random();
            randomPerson.Age = random.Next(randomPerson.AgeMin,
                                            randomPerson.AgeMax);
        }

        /// <summary>
        /// Создание рандомного пола.
        /// </summary>
        /// <param name="randomPerson">Экземпляр класса.</param>
        protected static void RandomGender(Person randomPerson)
        {
            Random random = new Random();
            randomPerson.Gender = (Gender)random.Next(
                                   Enum.GetNames(typeof(Gender)).Length);
        }

        /// <summary>
        /// Создание рандомных имен.
        /// </summary>
        /// <param name="randomPerson">Экземпляр класса.</param>
        protected static void RandomNames(Person randomPerson)
        {
            // Создание пулла фамилий и имен
            string[] manFirstNames = { "Александр", "Михаил", "Дмитрий",
                                       "Иван", "Олег", "Николай", "Ален" };
            string[] femFirstNames = { "Александра", "Анна", "Мария", "Ивана",
                                       "Ольга", "Елена", "Екатерина" };
            string[] unisexLastNames = { "Ямцун", "Ромм", "Резник", "Кулиш",
                                         "Томпсон", "Думер", "Бумер",
                                         "Герман", "Штраус" };
            string[] manLastNames = { "Блохин", "Андреев", "Дорохов",
                                      "Ермилов", "Ефимов", "Золотарев",
                                      "Казаков" };

            Random random = new Random();
            int numLastNames = random.Next(2);

            randomPerson.FirstName = randomPerson.Gender == Gender.Female
                ? RandomString(femFirstNames)
                : RandomString(manFirstNames);

            randomPerson.LastName = numLastNames == 0
                ? RandomString(unisexLastNames)
                : randomPerson.Gender == Gender.Female
                ? RandomString(manLastNames) + "а"
                : RandomString(manLastNames);
        }

        #endregion

        #region RandomChild

        /// <summary>
        /// Создает экземпляяр класса <see cref="Child"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Child"/>.</returns>
        public static Child GetRandomChild()
        {
            Child randomChild = new Child();
            RandomDataChild(randomChild);

            return randomChild;
        }

        /// <summary>
        /// Генерирует случайный набор даных для объекта <see cref="Child"/>.
        /// </summary>
        /// <param name="randomChild">Экземпляр класса.</param>
        protected static void RandomDataChild(Child randomChild)
        {
            RandomDataPerson(randomChild);
            Learning(randomChild);
        }

        /// <summary>
        /// Генерирует случайное место обучения.
        /// </summary>
        /// <param name="randomChild">Экземпляр класса.</param>
        protected static void Learning(Child randomChild)
        {
            var teaching = new Dictionary<string, string[]>()
            {
                {
                    "baby",
                    new string[]
                    {
                        "Домашнее обучение"
                    }
                },
                {
                    "preschool",
                    new string[]
                    {
                        "Домашнее обучение",
                        "Детский сад ",
                        "Детский сад Солнышко"
                    }
                },
                {
                    "school",
                    new string[]
                    {
                        "Домашнее обучение",
                        "СОШ №10",
                        "СОШ №2"
                    }
                },
            };

            if (randomChild.Age < 2)
            {
                RandomLearning(teaching, "baby", randomChild);
            }
            else if (randomChild.Age < 7)
            {
                RandomLearning(teaching, "preschool", randomChild);
            }
            else
            {
                RandomLearning(teaching, "school", randomChild);
            }
        }

        /// <summary>
        /// Генерирует случайное место учебы.
        /// </summary>
        /// <param name="teaching">Словарь с учебными заведениями.</param>
        /// <param name="key">Ключ словаря (стадия образоваия).</param>
        private static void RandomLearning(Dictionary<string, string[]> teaching,
                                               string key, Child randomChild)
        {
            randomChild.PlacOfStudy = RandomString(teaching[key]);
        }

        #endregion

        #region  RandomAdult

        /// <summary>
        /// Создает экземпляяр класса <see cref="Adult"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Adult"/>.</returns>
        public static Adult GetRandomAdult()
        {
            Adult randomAdult = new Adult();
            RandomGender(randomAdult);
            RandomDataAdult(randomAdult);
            return randomAdult;
        }

        /// <summary>
        /// Создает экземпляяр класса <see cref="Adult"/>
        /// со случайным набором полей.
        /// </summary>
        /// <param name="gender">Пол.</param>
        /// <returns>Экземпляр класса <see cref="Adult"/>.</returns>
        public static Adult GetRandomAdult(Gender gender)
        {
            Adult randomAdult = new Adult
            {
                Gender = gender
            };
            RandomDataAdult(randomAdult);
            return randomAdult;
        }

        /// <summary>
        /// Генерирует случайный набор даных для объекта <see cref="Adult"/>.
        /// </summary>
        /// <param name="randomAdult">Экземпляр класса.</param>
        protected static void RandomDataAdult(Adult randomAdult)
        {
            RandomDataPerson(randomAdult);
            RandomWork(randomAdult);
            randomAdult.PassportSeries = RandomPassportData(4);
            randomAdult.PassportNumber = RandomPassportData(6);
        }

        /// <summary>
        /// Генерирует случайное место работы.
        /// </summary>
        /// <param name="randomAdult">Экземпляр класса.</param>
        protected static void RandomWork(Adult randomAdult)
        {
            string?[] works =
            {
                "СО ЕЭС",
                "Россети",
                "Росатом",
                "ФСК",
                null
            };

            randomAdult.PlaceOfWork = RandomString(works);
        }
        #endregion

        /// <summary>
        /// Производит выбор случайной строки из массива строк.
        /// </summary>
        /// <param name="strings">Массива строк.</param>
        /// <returns>Строка.</returns>
        protected static string RandomString(string?[] strings)
        {
            Random random = new Random();
            return strings[random.Next(strings.Length)];
        }

        /// <summary>
        /// Генерирует случайное число из указанного диапазона.
        /// </summary>
        /// <param name="size">Количество символов.</param>
        /// <returns>Число.</returns>
        public static int RandomPassportData(int size)
        {
            Random random = new Random();

            int maxValue = (int)Math.Pow(10, size);
            while (true)
            {
                return random.Next(maxValue / 10, maxValue);
            }
        }
    }
}

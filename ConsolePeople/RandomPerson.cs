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
        /// Присваивает объекту случайные
        /// данные в зависимости от пола.
        /// </summary>
        /// <param name="randomPerson">Экземпляр класса.</param>
        private static void AssignDataPerson(PersonBase randomPerson)
        {
            AssignAge(randomPerson);
            AssignNames(randomPerson);
        }

        /// <summary>
        /// Создание случайного возраста.
        /// </summary>
        /// <param name="randomPerson">Экземпляр класса.</param>
        private static void AssignAge(PersonBase randomPerson)
        {
            Random random = new Random();
            randomPerson.Age = random.Next(randomPerson.AgeMin,
                                            randomPerson.AgeMax);
        }

        /// <summary>
        /// Создание случайного пола.
        /// </summary>
        /// <param name="randomPerson">Экземпляр класса.</param>
        private static void AssignGender(PersonBase randomPerson)
        {
            Random random = new Random();
            randomPerson.Gender = (Gender)random.Next(
                                   Enum.GetNames(typeof(Gender)).Length);
        }

        /// <summary>
        /// Создание случайного имен.
        /// </summary>
        /// <param name="randomPerson">Экземпляр класса.</param>
        protected static void AssignNames(PersonBase randomPerson)
        {
            // Создание пула фамилий и имен
            string[] manFirstNames = [ "Александр", "Михаил", "Дмитрий",
                                       "Иван", "Олег", "Николай", "Ален" ];
            string[] femFirstNames = [ "Александра", "Анна", "Мария", "Ивана",
                                       "Ольга", "Елена", "Екатерина" ];
            string[] unisexLastNames = [ "Ямцун", "Ромм", "Резник", "Кулиш",
                                         "Томпсон", "Думер", "Бумер",
                                         "Герман", "Штраус" ];
            string[] manLastNames = [ "Блохин", "Андреев", "Дорохов",
                                      "Ермилов", "Ефимов", "Золотарев",
                                      "Казаков" ];

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

        #region  RandomAdult

        /// <summary>
        /// Создает экземпляр класса <see cref="Adult"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Adult"/>.</returns>
        public static Adult GetAdult()
        {
            Adult randomAdult = new Adult();

            AssignGender(randomAdult);
            AssignDataAdult(randomAdult);
            AssignSpouse(randomAdult);

            return randomAdult;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Adult"/>
        /// со случайным набором полей.
        /// </summary>
        /// <param name="gender">Пол.</param>
        /// <returns>Экземпляр класса <see cref="Adult"/>.</returns>
        public static Adult GetAdult(Gender gender)
        {
            Adult randomAdult = new Adult()
            {
                Gender = gender
            };

            AssignDataAdult(randomAdult);

            return randomAdult;
        }

        /// <summary>
        /// Генерирует случайный набор данных для объекта <see cref="Adult"/>.
        /// </summary>
        /// <param name="randomAdult">Экземпляр класса.</param>
        private static void AssignDataAdult(Adult randomAdult)
        {
            AssignDataPerson(randomAdult);
            AssignWork(randomAdult);
            randomAdult.PassportSeries = AssignData(4);
            randomAdult.PassportNumber = AssignData(6);

        }

        /// <summary>
        /// Генерирует случайное место работы.
        /// </summary>
        /// <param name="randomAdult">Экземпляр класса.</param>
        private static void AssignWork(Adult randomAdult)
        {
            string[] works =
            [
                "СО ЕЭС",
                "Россети",
                "Росатом",
                "ФСК",
                ""
            ];

            randomAdult.PlaceOfWork = RandomString(works);
        }

        /// <summary>
        /// Генерирует случайное число из указанного диапазона.
        /// </summary>
        /// <param name="size">Количество символов.</param>
        /// <returns>Число.</returns>
        private static int AssignData(int size)
        {
            Random random = new Random();

            int maxValue = (int)Math.Pow(10, size);

            //TODO: +
            return random.Next(maxValue / 10, maxValue);

        }

        /// <summary>
        /// Назначает супруга для указанного взрослого на
        /// основе случайно сгенерированных критериев.
        /// </summary>
        /// <param name="randomAdult">Взрослый, для которого
        /// назначается супруг(а).</param>
        private static void AssignSpouse(Adult randomAdult)
        {
            Random random = new Random();
            int numLastNames = random.Next(2);
            switch (numLastNames)
            {
                case 0:
                    {
                        Gender gender = randomAdult.Gender;
                        switch (gender)
                        {
                            case Gender.Male:
                                {
                                    Adult randomSpouse = GetAdult(Gender.Female);

                                    randomAdult.LastName =
                                        RemoveLastA(randomSpouse.LastName);

                                    randomAdult.Spouse = randomSpouse;
                                }

                                break;
                            case Gender.Female:
                                {
                                    Adult randomSpouse = GetAdult(Gender.Male);

                                    randomSpouse.LastName =
                                        RemoveLastA(randomAdult.LastName);

                                    randomAdult.Spouse = randomSpouse;
                                }

                                break;
                            default:
                                break;

                        }
                    }

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region RandomChild

        /// <summary>
        /// Создает экземпляр класса <see cref="Child"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Child"/>.</returns>
        public static Child GetChild()
        {
            Child randomChild = new Child();

            AssignDataChild(randomChild);

            return randomChild;
        }

        /// <summary>
        /// Генерирует случайный набор данных для объекта <see cref="Child"/>.
        /// </summary>
        /// <param name="randomChild">Экземпляр класса.</param>
        private static void AssignDataChild(Child randomChild)
        {
            AssignDataPerson(randomChild);
            AssignPlaceOfStudy(randomChild);
            AssignParents(randomChild);
        }

        /// <summary>
        /// Генерирует случайное место обучения.
        /// </summary>
        /// <param name="randomChild">Экземпляр класса.</param>
        private static void AssignPlaceOfStudy(Child randomChild)
        {
            var teaching = new Dictionary<string, string[]>()
            {
                {
                    "baby",
                    new string[]
                    {
                        ""
                    }
                },
                {
                    "preschool",
                    new string[]
                    {
                        "",
                        "Детский сад ",
                        "Детский сад Солнышко"
                    }
                },
                {
                    "school",
                    new string[]
                    {
                        "",
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
        /// Под метод для выбора из словаря случайного места учебы и
        /// назначения его ребенку место учебы.
        /// </summary>
        /// <param name="teaching">Словарь с учебными заведениями.</param>
        /// <param name="key">Ключ словаря (стадия образования).</param>
        private static void RandomLearning(Dictionary<string, string[]> teaching,
                                               string key, Child randomChild)
        {
            randomChild.PlaceOfStudy = RandomString(teaching[key]);
        }

        /// <summary>
        /// Метод для назначения родителей для ребенка.
        /// </summary>
        /// <param name="child">Ребенок.</param>
        private static void AssignParents(Child child)
        {
            Random random = new Random();
            int numLastNames = random.Next(3);
            switch (numLastNames)
            {
                case 0:
                    {
                        Adult mother = GetAdult(Gender.Female);

                        Adult father = GetAdult(Gender.Male);

                        child.LastName = RemoveLastA(mother.LastName);
                        father.LastName = RemoveLastA(mother.LastName);

                        child.Father = father;
                        child.Mother = mother;

                        child.Father.Spouse = child.Mother;
                    }

                    break;
                case 1:
                    {
                        Adult parent = GetAdult();

                        if (parent.Gender != child.Gender)
                        {
                            if (parent.Gender == Gender.Female)
                            {
                                child.LastName = RemoveLastA(parent.LastName);
                            }
                            else
                            {
                                parent.LastName = RemoveLastA(child.LastName);
                            }
                        }
                        else
                        {
                            child.LastName = parent.LastName;

                            if (parent.Gender == Gender.Female)
                            {
                                child.Mother = parent;
                            }
                            else
                            {
                                child.Father = parent;
                            }
                        }
                    }

                    break;
                default:
                    break;
            }

        }
        #endregion

        /// <summary>
        /// Добавляет в список случайных людей.
        /// </summary>
        /// <param name="count">Количество людей.</param>
        /// <param name="peopleList">Список людей.</param>
        public static void AddRandomPeople(int count, PersonList peopleList)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                var typeOfPerson = random.Next(2);
                switch (typeOfPerson)
                {
                    case 0:
                        peopleList.AddPerson(GetAdult());
                        break;
                    case 1:
                        peopleList.AddPerson(GetChild());
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Производит выбор случайной строки из массива строк.
        /// </summary>
        /// <param name="strings">Массива строк.</param>
        /// <returns>Строка.</returns>
        private static string RandomString(string[] strings)
        {
            Random random = new Random();
            return strings[random.Next(strings.Length)];
        }

        /// <summary>
        /// Метод для удаления символа "а" в конце строки,
        /// если он присутствует.
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns>Исправленная строка.</returns>
        private static string RemoveLastA(string input)
        {
            if (!string.IsNullOrEmpty(input) && input.EndsWith("а"))
            {
                return input.Substring(0, input.Length - 1);
            }

            return input;
        }
    }
}

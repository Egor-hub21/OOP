using System.Text.RegularExpressions;

namespace FirstLab
{
    /// <summary>
    /// Класс Person, содержащий: имя, фамилию, возраст, пол.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Возраст.
        /// </summary>
        private int _age;

        /// <summary>
        /// Имя.
        /// </summary>
        private string _firstName;

        /// <summary>
        /// Гендер.
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        private const int _ageMin = 0;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        private const int _ageMax = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// Конструктор класса <see cref="Person"/>.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        public Person(string firstName, string lastName, int age, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Gets or sets the <see cref="Person._age"/> \ Получает или задает  возраст.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value <= _ageMin)
                {
                    throw new Exception($"Введенный возраст ниже допустимого {_ageMin}");
                }
                else if (value >= _ageMax)
                {
                    throw new Exception($"Введенный возраст выше допустимого {_ageMax}");
                }
                else
                {
                    _age = value;
                }

            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Person._firstName"/> \ Получает или задает имя.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }

            set
            {
                if (!SymbolControl(value))
                {
                    throw new Exception($"При вводе имени использовались недопустимые символы");
                }
                else
                {
                    _firstName = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Person._gender"/> \ Получает или задает  пол.
        /// </summary>
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Person._lastName"/> \ Получает или задает  фамилию.
        /// </summary>
        public string LastName
        {
            get { return _lastName; }

            set
            {
                if (!SymbolControl(value))
                {
                    throw new Exception($"При вводе фамилии использовались недопустимые символы");
                }
                else
                {
                    _lastName = value;
                }
            }
        }

        /// <summary>
        /// Чтения <see cref="Person"/> с клавиатуры.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Person"/>.</returns>
        public static Person ConsoleReadPerson()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());
            string gender = Console.ReadLine();
            Gender genderEnum;
            if (gender == "Male")
            {
                genderEnum = Gender.Male;
            }
            else if (gender == "Female")
            {
                genderEnum = Gender.Female;
            }
            else
            {
                throw new Exception("Ошибка ввода!");
            }

            return new Person(firstName, lastName, age, genderEnum);
        }

        /// <summary>
        /// Возвращает строку с информацией о <see cref="Person"/>.
        /// </summary>
        /// <returns>Информация о <see cref="Person"/> в вмиде строки.</returns>
        public string GetPersonInfo()
        {
            return ($"Имя: {FirstName}\tФамилия: {LastName}\t" +
                    $"Возраст: {Age}\tПол: {Gender}\n");
        }

        /// <summary>
        /// Создает экземпляяр класса <see cref="Person"/> со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Person"/>.</returns>
        public static Person GetRandomPerson()
        {
            // Создание пулла фамилий и имен
            string[] manFirstNames = { "Александр", "Михаил", "Дмитрий", "Иван", "Олег", "Николай", "Ален" };
            string[] femFirstNames = { "Александра", "Анна", "Мария", "Ивана", "Ольга", "Елена", "Екатерина" };
            string[] unisexLastNames = { "Ямцун", "Ромм", "Резник", "Кулиш", "Томпсон", "Думер", "Бумер", "Герман", "Штраус" };
            string[] manLastNames = { "Блохин", "Андреев", "Дорохов", "Ермилов", "Ефимов", "Золотарев", "Казаков" };

            Random random = new Random();

            int randomAge = random.Next(_ageMin, _ageMax);
            Gender randomGender = (Gender)random.Next(Enum.GetNames(typeof(Gender)).Length);

            int numLastNames = random.Next(2);

            string randomFirstName;
            string randomLastName;

            if (randomGender == Gender.Female)
            {
                randomFirstName = femFirstNames[random.Next(femFirstNames.Length)];

                if (numLastNames == 0)
                {
                    randomLastName = unisexLastNames[random.Next(unisexLastNames.Length)];
                }
                else
                {
                    randomLastName = manLastNames[random.Next(manLastNames.Length)] + "a";
                }
            }

            else
            {
                randomFirstName = manFirstNames[random.Next(manFirstNames.Length)];
                if (numLastNames == 0)
                {
                    randomLastName = unisexLastNames[random.Next(unisexLastNames.Length)];
                }
                else
                {
                    randomLastName = manLastNames[random.Next(manLastNames.Length)];
                }
            }

            return new Person(randomFirstName, randomLastName, randomAge, randomGender);
        }

        /// <summary>
        /// Проверка: слово должно содержать только
        /// русские или английские символы.
        /// </summary>
        /// <param name="word">Проверяемое слово.</param>
        /// <returns>trye условие выполняется;
        /// false условие не выполняется.</returns>
        public static bool SymbolControl(string word)
        {
            Regex regex = new Regex("^[a-zA-Zа-яА-Я]+$");
            return regex.IsMatch(word);
        }
    }
}

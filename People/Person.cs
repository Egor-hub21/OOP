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
        public const int AgeMin = 0;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        public const int AgeMax = 100;

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
                if (value < AgeMin)
                {
                    throw new Exception($"Введенный возраст ниже допустимого {AgeMin}");
                }
                else if (value >= AgeMax)
                {
                    throw new Exception($"Введенный возраст выше допустимого {AgeMax}");
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
                else if (!AlphabeticalControl(_lastName, value))
                {
                    throw new Exception($"Фамилия и имя введены с использованием разных алфавитов");
                }
                else
                {
                    _firstName = CorrectionRegister(value);
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
                else if (!AlphabeticalControl(value, _firstName))
                {
                    throw new Exception($"Фамилия и имя введены с использованием разных алфавитов");
                }
                else
                {
                    _lastName = CorrectionRegister(value);
                }
            }
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
        /// Проверка: слово должно содержать только
        /// русские или только английские символы.
        /// </summary>
        /// <param name="word">Проверяемое слово.</param>
        /// <returns>trye условие выполняется;
        /// false условие не выполняется.</returns>
        public static bool SymbolControl(string word)
        {
            {
                Regex regex1 = new Regex("^(([a-zA-Z]+)|([а-яА-Я]+))$");
                Regex regex2 = new Regex("^(([a-zA-Z]+-[a-zA-Z]+)|([а-яА-Я]+-[а-яА-Я]+))$");

                bool letter = false;

                if (regex1.IsMatch(word))
                {
                    letter = true;
                }
                else if (regex2.IsMatch(word))
                {
                    letter = true;
                }
                return letter;
            }
        }

        /// <summary>
        /// Сравнивает фамилию и имя если алфавит совпадает то возвращает true.
        /// </summary>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="firstName">Имя.</param>
        /// <returns>Булевое значение.</returns>
        public static bool AlphabeticalControl(string lastName, string firstName)
        {
            Regex regex = new Regex("^(([a-zA-Z]+)|([а-яА-Я]+))$");

            string newWord = lastName + firstName;
            newWord = string.Concat(newWord.Split("-"));

            return regex.IsMatch(newWord);
        }

        /// <summary>
        /// Первая буква большой регистр, последующие малый.
        /// </summary>
        /// <param name="word">Слово.</param>
        /// <returns>Слово.</returns>
        public static string CorrectionRegister(string word)
        {

            Regex regex1 = new Regex("^(([a-zA-Z]+)|([а-яА-Я]+))$");
            Regex regex2 = new Regex("^(([a-zA-Z]+-[a-zA-Z]+)|([а-яА-Я]+-[а-яА-Я]+))$");

            string newWord = "Ошибка";

            if (regex1.IsMatch(word))
            {
                newWord = word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
            }
            else if (regex2.IsMatch(word))
            {
                string[] words = word.Split('-');
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
                }
                newWord = words[0] + "-" + words[1];
            }
            return newWord;
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

            int randomAge = random.Next(AgeMin, AgeMax);
            Gender randomGender = (Gender)random.Next(Enum.GetNames(typeof(Gender)).Length);

            int numLastNames = random.Next(2);

            string randomFirstName;
            string randomLastName;

            if (randomGender == Gender.Female)
            {
                randomFirstName = femFirstNames[random.Next(femFirstNames.Length)];

                randomLastName = numLastNames == 0
                    ? unisexLastNames[random.Next(unisexLastNames.Length)]
                    : manLastNames[random.Next(manLastNames.Length)] + "а";
            }

            else
            {
                randomFirstName = manFirstNames[random.Next(manFirstNames.Length)];

                randomLastName = numLastNames == 0
                    ? unisexLastNames[random.Next(unisexLastNames.Length)]
                    : manLastNames[random.Next(manLastNames.Length)];
            }

            return new Person(randomFirstName, randomLastName, randomAge, randomGender);
        }
    }
}

using System.Text.RegularExpressions;

namespace People
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
        /// Фамилия.
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Минимальный и Максимальный возраст.
        /// </summary>
        protected const int _ageMin = 0;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        protected const int _ageMax = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person() : this("Неизвестно", "Неизвестно", 18, Gender.Male)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// Конструктор класса <see cref="Person"/>.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        public Person(string firstName, string lastName, int age,
                      Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Gets or sets the <see cref="Person._age"/>.
        /// Получает или задает  возраст.
        /// </summary>
        public virtual int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value < _ageMin || value >= _ageMax)
                {
                    throw new ArgumentOutOfRangeException
                        ($"Введенный возраст выходит из " +
                        $"допустимого прела: {_ageMin} <= age < {_ageMax}");
                }
                else
                {
                    _age = value;
                }

            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Person._firstName"/>.
        /// Получает или задает имя.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }

            set
            {
                if (!CheckWordSameLanguage(value))
                {
                    throw new FormatException
                                       ($"При вводе имени " +
                                        $"использовались " +
                                        $"недопустимые символы");
                }
                _firstName = CorrectionRegister(value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Person._gender"/>.
        /// Получает или задает  пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Person._lastName"/>.
        /// Получает или задает  фамилию.
        /// </summary>
        public string LastName
        {
            get { return _lastName; }

            set
            {
                if (!CheckWordSameLanguage(value))
                {
                    throw new FormatException
                                       ($"При вводе фамилии " +
                                        $"использовались " +
                                        $"недопустимые символы");
                }
                else if (!CheckCharacterStylesWords(value, _firstName))
                {
                    throw new ArgumentOutOfRangeException
                                       ($"Фамилия и имя введены с" +
                                        $" использованием разных" +
                                        $" алфавитов");
                }
                _lastName = CorrectionRegister(value);
            }
        }

        /// <summary>
        /// Возвращает строку с информацией о <see cref="Person"/>.
        /// </summary>
        /// <returns>Информация о <see cref="Person"/>.</returns>
        public virtual string GetInfo()
        {
            return $"Имя: {FirstName}\tФамилия: {LastName}\t" +
                    $"Возраст: {Age}\tПол: {Gender}\n";
        }

        /// <summary>
        /// Первая буква большой регистр, последующие малый.
        /// </summary>
        /// <param name="word">Слово.</param>
        /// <returns>Слово.</returns>
        public static string CorrectionRegister(string word)
        {
            string[] words = word.Split('-');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0, 1).ToUpper()
                        + words[i].Substring(1).ToLower();
            }

            return string.Join("-", words);
        }

        /// <summary>
        /// Создает экземпляяр класса <see cref="Person"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Person"/>.</returns>
        public static Person GetRandomPerson()
        {
            Person randomPerson = new Person();
            randomPerson.RandomAge(_ageMin, _ageMax);
            randomPerson.RandomGender();
            randomPerson.RandomNames();

            return randomPerson;
        }

        /// <summary>
        /// Создание рандомного возраста.
        /// </summary>
        protected void RandomAge(int ageMin, int ageMax)
        {
            Random random = new Random();
            Age = random.Next(ageMin, ageMax);
        }

        /// <summary>
        /// Создание рандомного пола.
        /// </summary>
        protected void RandomGender()
        {
            Random random = new Random();
            Gender = (Gender)random.Next(
                                   Enum.GetNames(typeof(Gender)).Length);
        }

        /// <summary>
        /// Создание рандомных имен.
        /// </summary>
        protected void RandomNames()
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

            FirstName = Gender == Gender.Female
                ? RandomString(femFirstNames)
                : RandomString(manFirstNames);

            LastName = numLastNames == 0
                ? RandomString(unisexLastNames)
                : Gender == Gender.Female
                ? RandomString(manLastNames) + "а"
                : RandomString(manLastNames);
        }

        /// <summary>
        /// Проверяет на каком языке написано слово.
        /// </summary>
        /// <param name="word">Проверяемое слово.</param>
        /// true - латиница, false - кириллица </param>
        /// <returns></returns>
        public static bool CheckWordLanguage(string word,
            Language language = Language.English)
        {
            var languageTemplateDictionary = new Dictionary<Language, string>
            {
                {Language.English, "a-zA-Z" },
                {Language.Russian, "а-яА-Я" }
            };

            var tmpTemplate = languageTemplateDictionary[language];

            var regex = $"^(([{tmpTemplate}]+)|"
                       + $"([{tmpTemplate}]+-[{tmpTemplate}]+))$";

            return Regex.IsMatch(word, regex);
        }

        /// <summary>
        /// Проверяет, что слово написано
        /// с использованием символов одного языка.
        /// </summary>
        /// <param name="word">Слово (Имя, Фамилия).</param>
        /// <returns>Булевая переменная.</returns>
        public static bool CheckWordSameLanguage(string word)
        {
            return CheckWordLanguage(word)
                || CheckWordLanguage(word, Language.Russian);
        }

        /// <summary>
        /// Сравнивает стили символов двух слов.
        /// </summary>
        /// <param name="word1">Слово (Имя).</param>
        /// <param name="word2">Слово (Фамилия).</param>
        /// <returns>Булевая переменная.</returns>
        public static bool CheckCharacterStylesWords(string word1,
                                                     string word2)
        {
            return (CheckWordLanguage(word1)
                    && CheckWordLanguage(word2))
                || (CheckWordLanguage(word1, Language.Russian)
                    && CheckWordLanguage(word2, Language.Russian));
        }

        /// <summary>
        /// Производит выбор случайной строки из массива строк. 
        /// </summary>
        /// <param name="strings">Массива строк.</param>
        /// <returns>Строка.</returns>
        protected static string RandomString(string[] strings)
        {
            Random random = new Random();
            return strings[random.Next(strings.Length)];
        }
    }
}

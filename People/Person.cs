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
        public Person(string firstName, string lastName, int age, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        //TODO: RSDN+
        /// <summary>
        /// Gets or sets the <see cref="Person._age"/>.
        /// Получает или задает  возраст.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                //TODO: RSDN+
                if (value < AgeMin || value >= AgeMax)
                {
                    throw new ArgumentOutOfRangeException
                        ($"Введенный возраст выходит из " +
                        $"допустимого прела: {AgeMin} <= age < {AgeMax}");
                }
                else
                {
                    _age = value;
                }

            }
        }

        //TODO: RSDN+
        /// <summary>
        /// Gets or sets the <see cref="Person._firstName"/>.
        /// Получает или задает имя.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }

            set
            {
                if (!WordStyleСompliance(value))
                {
                    throw new FormatException
                                       ($"При вводе имени " +
                                        $"использовались " +
                                        $"недопустимые символы");
                }
                else
                {
                    _firstName = CorrectionRegister(value);
                }
            }
        }

        //TODO: RSDN+
        /// <summary>
        /// Gets or sets the <see cref="Person._gender"/>.
        /// Получает или задает  пол.
        /// </summary>
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Person._lastName"/>.
        /// Получает или задает  фамилию.
        /// </summary>
        public string LastName
        {
            get { return _lastName; }

            set
            {
                //TODO: RSDN+
                if (!WordStyleСompliance(value))
                {
                    throw new FormatException
                                       ($"При вводе фамилии " +
                                        $"использовались " +
                                        $"недопустимые символы");
                }
                else if (!WordsStyleСompliance(value, _firstName))
                {
                    throw new ArgumentOutOfRangeException
                                       ($"Фамилия и имя введены с" +
                                        $" использованием разных" +
                                        $" алфавитов");
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
        /// <returns>Информация о <see cref="Person"/>.</returns>
        public string GetInfo()
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
            //TODO: RSDN+
            string[] words = word.Split('-');
            for (int i = 0; i < words.Length; i++)
            {
                //TODO: RSDN+
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

            //TODO: RSDN+
            // Создание пулла фамилий и имен
            string[] manFirstNames = { "Александр", "Михаил", "Дмитрий",
                                       "Иван", "Олег", "Николай", "Ален" };
            string[] femFirstNames = { "Александра", "Анна", "Мария",
                                       "Ивана", "Ольга", "Елена",
                                                        "Екатерина" };
            string[] unisexLastNames = { "Ямцун", "Ромм", "Резник", "Кулиш",
                                         "Томпсон", "Думер", "Бумер",
                                         "Герман", "Штраус" };
            string[] manLastNames = { "Блохин", "Андреев", "Дорохов",
                                      "Ермилов", "Ефимов", "Золотарев",
                                      "Казаков" };

            Random random = new Random();

            randomPerson.Age = random.Next(AgeMin, AgeMax);
            Gender randomGender = (Gender)random.Next(
                                   Enum.GetNames(typeof(Gender)).Length);

            int numLastNames = random.Next(2);

            if (randomGender == Gender.Female)
            {
                randomPerson.FirstName = femFirstNames[
                                  random.Next(femFirstNames.Length)];

                randomPerson.LastName = numLastNames == 0
                    ? unisexLastNames[random.Next(unisexLastNames.Length)]
                    : manLastNames[random.Next(manLastNames.Length)] + "а";
            }

            else
            {
                randomPerson.FirstName = manFirstNames[
                                  random.Next(manFirstNames.Length)];

                randomPerson.LastName = numLastNames == 0
                    ? unisexLastNames[random.Next(unisexLastNames.Length)]
                    : manLastNames[random.Next(manLastNames.Length)];
            }

            return randomPerson;
        }
        //TODO: XML+
        /// <summary>
        /// Проверяет на соответствии языка.
        /// </summary>
        /// <param name="word">Проверяемое слово.</param>
        /// <param name="styleLetters">Тип языка:
        /// true - латиница, false - кириллица </param>
        /// <returns></returns>
        public static bool LettersStyleСompliance(string word,
                                                  bool styleLetters = true)
        {
            Regex regex = new Regex("^$");

            if (styleLetters)
            {
                //TODO: duplication ?
                regex = new Regex("^(([a-zA-Z]+)|([a-zA-Z]+-[a-zA-Z]+))$");
            }
            else if (!styleLetters)
            {
                //TODO: duplication ?
                regex = new Regex("^(([а-яА-Я]+)|([а-яА-Я]+-[а-яА-Я]+))$");
            }

            return regex.IsMatch(word);
        }

        /// <summary>
        /// Проверяет соответствие стилю (Кириллица и Латиница)
        /// символов слова.
        /// </summary>
        /// <param name="word">Слово (Имя, Фамилия).</param>
        /// <returns>Булевая переменная.</returns>
        public static bool WordStyleСompliance(string word)
        {
            return LettersStyleСompliance(word)
                || LettersStyleСompliance(word, false);
        }

        /// <summary>
        /// Сравнивает стили (Кириллица и Латиница) символов двух слов.
        /// </summary>
        /// <param name="word1">Слово (Имя).</param>
        /// <param name="word2">Слово (Фамилия).</param>
        /// <returns>Булевая переменная.</returns>
        public static bool WordsStyleСompliance(string word1, string word2)
        {
            return (LettersStyleСompliance(word1)
                    && LettersStyleСompliance(word2))
                || (LettersStyleСompliance(word1, false)
                    && LettersStyleСompliance(word2, false));
        }
    }
}

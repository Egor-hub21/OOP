using System.Text.RegularExpressions;

namespace People
{
    /// <summary>
    /// Класс PersonBase, содержащий: имя, фамилию, возраст, пол.
    /// </summary>
    public abstract class PersonBase
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
        public virtual int AgeMin { get; }

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        public virtual int AgeMax { get; } = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBase"/> class.
        /// Конструктор класса <see cref="PersonBase"/>.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        public PersonBase(string firstName, string lastName, int age,
                      Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Gets or sets the <see cref="PersonBase._age"/>.
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
                if (value < AgeMin || value >= AgeMax)
                {
                    throw new ArgumentOutOfRangeException
                        ($"Введенный возраст выходит из " +
                        $"допустимого прела: {AgeMin} <= age < {AgeMax}");
                }

                _age = value;

            }
        }

        /// <summary>
        /// Gets or sets the <see cref="PersonBase._firstName"/>.
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
        /// Gets or sets the <see cref="PersonBase._gender"/>.
        /// Получает или задает  пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PersonBase._lastName"/>.
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
        /// Возвращает строку с информацией о <see cref="PersonBase"/>.
        /// </summary>
        /// <returns>Информация о <see cref="PersonBase"/>.</returns>
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
        /// Проверяет на каком языке написано слово.
        /// </summary>
        /// <param name="word">Проверяемое слово.</param>
        /// <param name="language">Тип языка.</param>
        /// <returns>Логическая переменная.</returns>
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
        /// <returns>Логическая переменная.</returns>
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
        /// <returns>Логическая переменная.</returns>
        public static bool CheckCharacterStylesWords(string word1,
                                                     string word2)
        {
            return (CheckWordLanguage(word1)
                    && CheckWordLanguage(word2))
                || (CheckWordLanguage(word1, Language.Russian)
                    && CheckWordLanguage(word2, Language.Russian));
        }
    }
}

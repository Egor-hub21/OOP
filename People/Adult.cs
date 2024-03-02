namespace People
{
    /// <summary>
    /// Класс взрослый
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// Серия паспорта.
        /// </summary>
        private int _passportSeries;

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        private int _passportNumber;

        /// <summary>
        /// Cодержит неповторяющюся коллекцию паспортных данных.
        /// </summary>
        private static HashSet<int> _unicalPassport
                       = new HashSet<int>();

        /// <summary>
        /// Ссылка на супруга.
        /// </summary>
        private Adult? _spouse;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        protected new const int _ageMin = 18;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамиоия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="passportSeries">Серия паспорта.</param>
        /// <param name="passportNumber">Номер паспорта.</param>
        /// <param name="placeOfWork">Ссылка на супруга.</param>
        public Adult(string firstName, string lastName,
                     int age, Gender gender, int passportSeries,
                     int passportNumber, string placeOfWork, Adult? spouse = null)
            : base(firstName, lastName, age, gender)
        {
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            PlaceOfWork = placeOfWork;
            Spouse = spouse;
        }

        /// <summary>
        /// Конструктор с начальными данными.
        /// </summary>
        public Adult() : this("Неизвестно",
                              "Неизвестно",
                              18,
                              Gender.Male,
                              RandomPassportData(4),
                              RandomPassportData(6),
                              "Безработный")
        { }

        /// <summary>
        /// Gets or sets the <see cref="Adult._passportSeries"/>.
        /// </summary>
        public int PassportSeries
        {
            get
            {
                return _passportSeries;
            }
            set
            {
                DataControl(4, value, _unicalPassport);
                _passportSeries = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Adult._passportNumber"/>.
        /// </summary>
        public int PassportNumber
        {
            get
            {
                return _passportNumber;
            }
            set
            {
                DataControl(6, value, _unicalPassport);
                _passportNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Adult._placeOfWork"/>.
        /// </summary>
        public string PlaceOfWork { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Adult._spouse"/>.
        /// </summary>
        public Adult Spouse
        {
            get { return _spouse; }

            set
            {
                if (value != null && Gender == value.Gender)
                {
                    throw new ArgumentException($"Пол супругов не " +
                                                $"должен совпадать.");
                }
                _spouse = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Adult._age"/>.
        /// Получает или задает  возраст.
        /// </summary>
        public override int Age
        {
            get
            {
                return base.Age;
            }

            set
            {
                if (value < _ageMin || value >= _ageMax)
                {
                    throw new ArgumentOutOfRangeException
                        ($"Введенный возраст выходит из " +
                        $"допустимого прела: {_ageMin} <= age < {_ageMax}");
                }
                base.Age = value;
            }
        }

        /// <summary>
        /// Возвращает строку с информацией о <see cref="Adult"/>.
        /// </summary>
        /// <returns>Информация о <see cref="Adult"/>.</returns>
        public override string GetInfo()
        {
            return Spouse == null
                ? base.GetInfo() +
                  $"Паспортыне данные: {PassportSeries} {PassportNumber}\t" +
                  $"Место работы: {PlaceOfWork}\t" +
                  $"В браке, не состоит.\n"
                : base.GetInfo() +
                  $"Паспортыне данные: {PassportSeries} {PassportNumber}\t" +
                  $"Место работы: {PlaceOfWork}\t" +
                  $"Супруг: {Spouse.FirstName} {Spouse.FirstName}\n";
        }

        /// <summary>
        /// Проверка уникальности паспортных данных.
        /// </summary>
        /// <param name="size">Размерность.</param>
        /// <param name="value">Значение.</param>
        /// <param name="unical">Список, уже существующих значений.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected static void DataControl(int size, int value, HashSet<int> unical)
        {
            if (unical.Contains(value) || value.ToString().Length != size
                || value < 0)
            {
                throw new ArgumentOutOfRangeException
                            ($"Введено некорректное значение!");
            }
            _ = unical.Add(value);
        }

        /// <summary>
        /// Создает экземпляяр класса <see cref="Adult"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Adult"/>.</returns>
        public static Adult GetRandomAdult()
        {
            Adult randomPerson = new Adult();
            randomPerson.RandomAge(_ageMin, _ageMax);
            randomPerson.RandomGender();
            randomPerson.RandomNames();
            randomPerson.RandomWork();
            randomPerson.PassportSeries = RandomPassportData(4);
            randomPerson.PassportNumber = RandomPassportData(6);
            return randomPerson;
        }

        /// <summary>
        /// Генерирует случайное место работы.
        /// </summary>
        protected void RandomWork()
        {
            string[] works = { "СО ЕЭС", "Россети", "Росатом", "ФСК" };

            PlaceOfWork = RandomString(works);
        }

        /// <summary>
        /// Генерирует случайное число из указанного диапазона. 
        /// </summary>
        protected static int RandomPassportData(int size)
        {
            Random random = new Random();
            int value;
            int maxValue = (int)Math.Pow(10, size);
            do
            {
                value = random.Next(maxValue / 10, maxValue);
            }
            while (_unicalPassport.Contains(value)
                   || value.ToString().Length != size
                   || value < 0);

            return value;
        }

    }
}

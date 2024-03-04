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
        protected override int AgeMin { get; } = 18;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамиоия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="passportSeries">Серия паспорта.</param>
        /// <param name="passportNumber">Номер паспорта.</param>
        /// <param name="placeOfWork">Место работы.</param>
        public Adult(string firstName, string lastName,
                     int age, Gender gender, int passportSeries,
                     int passportNumber, string? placeOfWork = null,
                     Adult? spouse = null)
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
                              RandomPassportData(6))
        { }

        /// <summary>
        /// Gets or sets the <see cref="Adult._passportSeries"/>.
        /// </summary>
        public int PassportSeries
        {
            get => _passportSeries;

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
            get => _passportNumber;
            set
            {
                DataControl(6, value, _unicalPassport);
                _passportNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Adult._placeOfWork"/>.
        /// </summary>
        public string? PlaceOfWork { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Adult._spouse"/>.
        /// </summary>
        public Adult? Spouse
        {
            get => _spouse;
            set
            {
                if (value?.Gender == Gender)
                {
                    throw new ArgumentException($"Пол супругов не " +
                                                $"должен совпадать!");
                }
                if (value?.Spouse is not null && value?.Spouse != this)
                {
                    throw new ArgumentException($"Предполагаемый супруг,"
                                                + $" уже в браке!");
                }
                if (Spouse is not null && Spouse != value)
                {
                    throw new ArgumentException($"Adult уже состоит"
                                                + $" в браке!");
                }

                _spouse = value;

                if (value is not null)
                {
                    value._spouse = this;
                }
            }
        }

        /// <summary>
        /// Возвращает строку с информацией о <see cref="Adult"/>.
        /// </summary>
        /// <returns>Информация о <see cref="Adult"/>.</returns>
        public override string GetInfo()
        {
            return base.GetInfo()
                  + $"Паспортыне данные: {PassportSeries} {PassportNumber}\t"
                  + $"{GetInfoPlaceOfWork()}\t"
                  + $"{GetInfoStateOfMarriage()}\n";
        }

        /// <summary>
        /// Возвращиет информацию о работе.
        /// </summary>
        /// <returns>Строка.</returns>
        protected string GetInfoPlaceOfWork()
        {
            return Spouse == null
                ? $"Безработный."
                : $"Место работы:: {PlaceOfWork}";
        }

        /// <summary>
        /// Возвращиет информацию о состоянии брака.
        /// </summary>
        /// <returns>Строка.</returns>
        protected string GetInfoStateOfMarriage()
        {
            return Spouse == null
                ? $"В браке, не состоит."
                : $"Супруг: {Spouse.FirstName} {Spouse.LastName}";
        }

        /// <summary>
        /// Создает экземпляяр класса <see cref="Adult"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Adult"/>.</returns>
        public static Adult GetRandomAdult()
        {
            Adult randomAdult = new Adult();
            randomAdult.RandomGender();
            randomAdult.RandomData();
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
            Adult randomAdult = new Adult();
            randomAdult.Gender = gender;
            randomAdult.RandomData();
            return randomAdult;
        }

        /// <summary>
        /// Генерирует случайный набор даных для объекта <see cref="Adult"/>.
        /// </summary>
        protected override void RandomData()
        {
            base.RandomData();
            RandomWork();
            PassportSeries = RandomPassportData(4);
            PassportNumber = RandomPassportData(6);
        }

        /// <summary>
        /// Генерирует случайное место работы.
        /// </summary>
        protected void RandomWork()
        {
            string?[] works =
            {
                "СО ЕЭС",
                "Россети",
                "Росатом",
                "ФСК",
                null
            };

            PlaceOfWork = RandomString(works);
        }

        /// <summary>
        /// Генерирует случайное число из указанного диапазона. 
        /// </summary>
        /// <param name="size">Количество символов.</param>
        /// <returns>Число.</returns>
        public static int RandomPassportData(int size)
        {
            Random random = new Random();
            int value;
            int maxValue = (int)Math.Pow(10, size);
            while (true)
            {
                value = random.Next(maxValue / 10, maxValue);

                if (!_unicalPassport.Contains(value)
                   && value.ToString().Length == size)
                {
                    return value;
                }
            }
        }

        /// <summary>
        /// Проверка уникальности паспортных данных.
        /// </summary>
        /// <param name="size">Размерность.</param>
        /// <param name="value">Значение.</param>
        /// <param name="unical">Список, уже существующих значений.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static void DataControl(int size, int value, HashSet<int> unical)
        {
            if (unical.Contains(value) || value.ToString().Length != size
                || value < 0)
            {
                throw new ArgumentOutOfRangeException
                            ($"Введено некорректное значение!\n"
                           + $"Введите {size} символов");
            }
            _ = unical.Add(value);
        }

        /// <summary>
        /// Создает супружускую пару.
        /// </summary>
        /// <param name="spouse"></param>
        public void GetMarried(Adult spouse)
        {
            Spouse = spouse;
        }

        /// <summary>
        /// Удаляет супружускую пару.
        /// </summary>
        public void Divorce()
        {
            if (Spouse != null)
            {
                Spouse.Spouse = null;
                Spouse = null;
            }
            else
            {
                throw new NullReferenceException("Adult не состоит"
                                                + " в браке!");
            }
        }

    }
}

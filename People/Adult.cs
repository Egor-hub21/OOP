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
        /// Ссылка на супруга.
        /// </summary>
        private Adult? _spouse;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        public override int AgeMin { get; } = 18;

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
                              1111,
                              111111)
        { }

        /// <summary>
        /// Gets or sets the <see cref="Adult._passportSeries"/>.
        /// </summary>
        public int PassportSeries
        {
            get => _passportSeries;

            set
            {
                ControlNumberSize(value, 4);
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
                ControlNumberSize(value, 6);
                _passportNumber = value;
            }
        }

        /// <summary>
        /// Генерирует исключение при вводе
        /// недопустимого количества цифр.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="size">Размер.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected static void ControlNumberSize(int value, int size)
        {
            if (value.ToString().Length != size)
            {
                throw new ArgumentOutOfRangeException($"Введено некорректное"
                                                     + $" значение!\n"
                                                     + $"Введите {size}"
                                                     + $" символов");
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
            return PlaceOfWork == null
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

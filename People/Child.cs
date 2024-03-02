namespace People
{
    /// <summary>
    /// Класс ребенок
    /// </summary>
    public class Child : Person
    {
        /// <summary>
        /// Ссылка на мать.
        /// </summary>
        public Adult? Mother { get; set; }

        /// <summary>
        /// Ссылка на отца.
        /// </summary>
        public Adult? Father { get; set; }

        /// <summary>
        /// Название места учебы.
        /// </summary>
        public string PlacOfStudy { get; set; }

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        protected new const int _ageMax = 17;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамиоия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="mother">Ссылка на мать.</param>
        /// <param name="father">Ссылка на отца.</param>
        /// <param name="placOfStudy">Название места учебы.</param>
        public Child(string firstName, string lastName,
                     int age, Gender gender, string placOfStudy,
                     Adult? mother = null, Adult? father = null)
            : base(firstName, lastName, age, gender)
        {
            Mother = mother;
            Father = father;
            PlacOfStudy = placOfStudy;
        }

        /// <summary>
        /// Конструктор с начальными данными
        /// </summary>
        public Child() : this("Неизвестно",
                              "Неизвестно",
                              6,
                              Gender.Male,
                              "Домашнее обучение")
        { }

        /// <summary>
        /// Gets or sets the <see cref="Child._age"/>.
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
                //TODO: RSDN+
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
        /// Возвращает строку с информацией о <see cref="Child"/>.
        /// </summary>
        /// <returns>Информация о <see cref="Child"/>.</returns>
        public override string GetInfo()
        {

            if (Mother is null && Father is null)
            {
                return base.GetInfo() + $"Место учебы: {PlacOfStudy}\n";
            }
            else if (Mother is not null && Father is null)
            {
                return base.GetInfo() + $"Место учебы: {PlacOfStudy}\n"
                        + $"Мать: {Mother.FirstName} {Mother.LastName}\t";
            }
            else if (Mother is null && Father is not null)
            {
                return base.GetInfo() + $"Место учебы: {PlacOfStudy}\n"
                        + $"Отец: {Father.FirstName} {Father.LastName}\t";
            }
            else
            {
                return base.GetInfo() + $"Место учебы: {PlacOfStudy}\n"
                        + $"Мать: {Mother.FirstName} {Mother.LastName}\t"
                        + $"Отец: {Father.FirstName} {Father.LastName}\t";
            }
        }

        /// <summary>
        /// Создает экземпляяр класса <see cref="Child"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Child"/>.</returns>
        public static Child GetRandomChild()
        {
            Child randomPerson = new Child();
            randomPerson.RandomAge(_ageMin, _ageMax);
            randomPerson.RandomGender();
            randomPerson.RandomNames();
            randomPerson.Learning();

            return randomPerson;
        }

        /// <summary>
        /// Генерирует случайное место обучения.
        /// </summary>
        protected void Learning()
        {
            string[] preschool =
                                {
                                  "Домашнее обучение",
                                  "Детский сад \"Системное солнышко\""
                                };

            string[] school = { "Домашнее обучение", "СОШ №10", "СОШ №2" };

            if (Age < 2)
            {
                PlacOfStudy = "Домашнее обучение";
            }
            else if (Age < 7)
            {
                PlacOfStudy = RandomString(preschool);
            }
            else
            {
                PlacOfStudy = RandomString(school);
            }
        }
    }
}

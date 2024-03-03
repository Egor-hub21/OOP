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
        private Adult? _mother;

        /// <summary>
        /// Ссылка на отца.
        /// </summary>
        private Adult? _father;

        /// <summary>
        /// Название места учебы.
        /// </summary>
        public string PlacOfStudy { get; set; }

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        protected override int AgeMax { get; } = 17;

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
        /// Gets or sets the <see cref="Child._mother"/>.
        /// </summary>
        public Adult? Mother
        {
            get => _mother;
            set
            {
                ParentException(Mother, value, Gender.Female);

                _mother = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Child._father"/>.
        /// </summary>
        public Adult? Father
        {
            get => _father;
            set
            {
                ParentException(Father, value, Gender.Male);

                _father = value;
            }
        }

        /// <summary>
        /// Метод, выбрасывающий исключения при
        /// некорректном вводе информации о родителе.
        /// </summary>
        /// <param name="oldParent"></param>
        /// <param name="newParent"></param>
        /// <param name="gender"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void ParentException(Adult? oldParent, Adult? newParent,
                                            Gender gender)
        {
            string parentType = gender == Gender.Female
                ? "мать"
                : "отец";

            if (newParent?.Gender != gender && newParent is not null)
            {
                throw new ArgumentException("Неверный пол родителя!");
            }
            if (oldParent is not null)
            {
                throw new ArgumentException($"У ребенка уже есть "
                                            + $"{parentType}!");
            }
        }


        /// <summary>
        /// Возвращает строку с информацией о <see cref="Child"/>.
        /// </summary>
        /// <returns>Информация о <see cref="Child"/>.</returns>
        public override string GetInfo()
        {
            return $"{GetInfoBase()}\n"
                 + $"{GetInfoMother()}"
                 + $"{GetInfoFather()}\n";
        }

        /// <summary>
        /// Возвращает базовую информацию о <see cref="Child"/>.
        /// </summary>
        /// <returns>Строка.</returns>
        protected string GetInfoBase()
        {
            return $"{base.GetInfo()} Место учебы: {PlacOfStudy}";
        }

        /// <summary>
        /// Возвращает информацию о  <see cref="Child.Mother"/>.
        /// </summary>
        /// <returns>Строка.</returns>
        protected string GetInfoMother()
        {
            return Mother is not null
                ? $"Мать: {Mother.FirstName} {Mother.LastName}\t"
                : "";
        }

        /// <summary>
        /// Возвращает информацию о  <see cref="Child.Father"/>.
        /// </summary>
        /// <returns>Строка.</returns>
        protected string GetInfoFather()
        {
            return Father is not null
                ? $"Отец: {Father.FirstName} {Father.LastName}\t"
                : "";
        }

        /// <summary>
        /// Создает экземпляяр класса <see cref="Child"/>
        /// со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Child"/>.</returns>
        public static Child GetRandomChild()
        {
            Child randomPerson = new Child();
            randomPerson.RandomAge();
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
              "Детский сад \"Детский сад Солнышко\""
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

        /// <summary>
        /// Присвоение ребенку родителей.
        /// </summary>
        /// <param name="mother">Мать.</param>
        /// <param name="father">Отец.</param>
        public void Adopt(Adult mother, Adult father)
        {
            Father = father;
            Mother = mother;
        }

        /// <summary>
        /// Присвоение ребенку родителей.
        /// </summary>
        /// <param name="parent">Родитель.</param>
        public void Adopt(Adult parent)
        {
            if (parent.Gender == Gender.Female)
            {
                Mother = parent;
            }
            else
            {
                Father = parent;
            }
        }
    }
}

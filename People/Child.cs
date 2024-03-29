namespace People
{
    /// <summary>
    /// Класс ребенок.
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Ссылка на мать.
        /// </summary>
        private Adult? _mother;

        /// <summary>
        /// Ссылка на отца.
        /// </summary>
        private Adult? _father;

        //TODO: validation

        /// <summary>
        /// Название места учебы.
        /// </summary>
        public string PlaceOfStudy { get; set; }

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        public override int AgeMax { get; } = 17;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="mother">Ссылка на мать.</param>
        /// <param name="father">Ссылка на отца.</param>
        /// <param name="placeOfStudy">Название места учебы.</param>
        public Child(string firstName, string lastName,
                     int age, Gender gender, string placeOfStudy,
                     Adult? mother = null, Adult? father = null)
            : base(firstName, lastName, age, gender)
        {
            Mother = mother;
            Father = father;
            PlaceOfStudy = placeOfStudy;
        }

        /// <summary>
        /// Конструктор с начальными данными.
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
        /// <param name="oldParent">Старый родитель.</param>
        /// <param name="newParent">Новый родитель.</param>
        /// <param name="gender">Пол.</param>
        /// <exception cref="ArgumentException">Исключение.</exception>
        private static void ParentException(Adult? oldParent,
                                            Adult? newParent,
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
            return $"{base.GetInfo()} {GetInfoPlaceOfStudy()}";
        }

        /// <summary>
        /// Возвращает информацию о месте учебы.
        /// </summary>
        /// <returns>Строка.</returns>
        protected string GetInfoPlaceOfStudy()
        {
            return PlaceOfStudy is not null
                ? $"{PlaceOfStudy}\t"
                : "Домашнее обучение";
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
        /// Присвоение ребенку родителя.
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

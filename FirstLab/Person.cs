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
        private int age;

        /// <summary>
        /// Имя.
        /// </summary>
        private string firstName;

        /// <summary>
        /// Гендер.
        /// </summary>
        private Gender gender;

        /// <summary>
        /// Фамилия.
        /// </summary>
        private string lastName;

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
        /// Gets or sets the <see cref="Person.age"/> \ Получает или задает  возраст.
        /// </summary>
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Person.firstName"/> \ Получает или задает имя.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Person.gender"/> \ Получает или задает  пол.
        /// </summary>
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Person.lastName"/> \ Получает или задает  фамилию.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}

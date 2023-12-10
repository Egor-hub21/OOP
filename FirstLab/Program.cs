namespace FirstLab

{
    /// <summary>
    /// Класс Program.
    /// </summary>
    internal class Program
    {

        /// <summary>
        /// Метод Main.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("a. Программное создание двух списков персон, в каждом из которых по три человека.\n");

            PersonList personList1 = new PersonList();
            personList1.AddPerson(GetRandomPerson());
            personList1.AddPerson(GetRandomPerson());
            personList1.AddPerson(GetRandomPerson());

            PersonList personList2 = new PersonList();
            personList2.AddPerson(GetRandomPerson());
            personList2.AddPerson(GetRandomPerson());
            personList2.AddPerson(GetRandomPerson());

            ReadKey();

            Console.WriteLine("b. Вывод содержимого каждого списка на экран.");

            Console.WriteLine("\nПервый список:");
            Console.WriteLine(personList1.PersonInfo());

            Console.WriteLine("\nВторой список:");
            Console.WriteLine(personList2.PersonInfo());

            ReadKey();

            Console.WriteLine("c. Добавление нового человека в первый список");
            personList1.AddPerson(GetRandomPerson());
            Console.WriteLine(personList1.PersonInfo(personList1.GetCount() - 1));

            Console.WriteLine("\nПервый список:");
            Console.WriteLine(personList1.PersonInfo());

            ReadKey();

            Console.WriteLine("d. Копирование второго человека из первого списка в конец второго списка");
            int index = 1;

            personList2.AddPerson(personList1.GetByIndex(index));

            Console.WriteLine("\nВторой человек в первом списке:");
            Console.WriteLine(personList1.PersonInfo(index));

            Console.WriteLine("\nПоследний человек во втором:");
            Console.WriteLine(personList2.PersonInfo(personList2.GetCount() - index));

            ReadKey();

            Console.WriteLine("e. Удаление второго человека из первого списка");
            Console.WriteLine(personList1.PersonInfo(index));
            personList1.DeletePerson(index);

            Console.WriteLine("\nПервый список:");
            Console.WriteLine(personList1.PersonInfo());

            Console.WriteLine("\nВторой список:");
            Console.WriteLine(personList2.PersonInfo());

            ReadKey();

            Console.WriteLine("f. Очистка второго списка");
            personList2.Clear();

            Console.WriteLine("\nВторой список:");
            Console.WriteLine(personList2.PersonInfo());

            Console.WriteLine("\nПервый список:");
            Console.WriteLine(personList1.PersonInfo());

        }

        /// <summary>
        /// Выводит сообщение и запрашивает ввод любой клавиши
        /// для продолжения работы программы.
        /// </summary>
        public static void ReadKey()
        {
            Console.WriteLine("Чтобы продолжить, нажмите любую клавишу.\n");
            _ = Console.ReadKey();
        }

        /// <summary>
        /// Создает экземпляяр класса <see cref="Person"/> со случайным набором полей.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Person"/>.</returns>
        public static Person GetRandomPerson()
        {
            // Создание пулла фамилий и имен
            string[] manFirstNames = { "Александр", "Михаил", "Дмитрий", "Иван", "Олег", "Николай", "Ален" };
            string[] femFirstNames = { "Александра", "Анна", "Мария", "Ивана", "Ольга", "Елена", "Екатерина" };
            string[] unisexLastNames = { "Ямцун", "Ромм", "Резник", "Кулиш", "Томпсон", "Думер", "Бумер", "Герман", "Штраус" };
            string[] manLastNames = { "Блохин", "Андреев", "Дорохов", "Ермилов", "Ефимов", "Золотарев", "Казаков" };

            Random random = new Random();

            int randomAge = random.Next(Person._ageMin, Person._ageMax);
            Gender randomGender = (Gender)random.Next(Enum.GetNames(typeof(Gender)).Length);

            int numLastNames = random.Next(2);

            string randomFirstName;
            string randomLastName;

            if (randomGender == Gender.Female)
            {
                randomFirstName = femFirstNames[random.Next(femFirstNames.Length)];

                randomLastName = numLastNames == 0
                    ? unisexLastNames[random.Next(unisexLastNames.Length)]
                    : manLastNames[random.Next(manLastNames.Length)] + "a";
            }

            else
            {
                randomFirstName = manFirstNames[random.Next(manFirstNames.Length)];

                randomLastName = numLastNames == 0
                    ? unisexLastNames[random.Next(unisexLastNames.Length)]
                    : manLastNames[random.Next(manLastNames.Length)];
            }

            return new Person(randomFirstName, randomLastName, randomAge, randomGender);
        }

        /// <summary>
        /// Чтения <see cref="Person"/> с клавиатуры.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Person"/>.</returns>
        public static Person ConsoleReadPerson()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());
            string enteredGender = Console.ReadLine();

            Gender gender;
            if (enteredGender == "Male")
            {
                gender = Gender.Male;
            }
            else if (enteredGender == "Female")
            {
                gender = Gender.Female;
            }
            else
            {
                throw new Exception("Ошибка ввода!");
            }

            return new Person(firstName, lastName, age, gender);
        }
    }
}

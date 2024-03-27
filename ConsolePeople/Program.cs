using People;

namespace ConsolePeople
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
            var personList = new PersonList();
            AddRandomPerson(10, personList);


            ReadKey();
            Console.WriteLine("1. Вывод содержимого списка на экран:");

            Console.WriteLine(personList.PersonInfo());

            ReadKey();
            Console.WriteLine("2. Тип первого, четвертого и последнего "
                                                  + "элемента списка:");
            Console.WriteLine($"{personList.GetTypePerson(0)}, "
                            + $"{personList.GetTypePerson(3)} и "
                            + $"{personList.GetTypePerson(6)}");

        }

        /// <summary>
        /// Выводит сообщение и запрашивает ввод любой клавиши
        /// для продолжения работы программы.
        /// </summary>
        public static void ReadKey()
        {
            PrintString("Чтобы продолжить, нажмите любую клавишу.\n");
            _ = Console.ReadKey();
        }

        /// <summary>
        /// Вывод строки на экран.
        /// </summary>
        /// <param name="text">Строка.</param>
        public static void PrintString(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Создает список с рандамными людьми.
        /// </summary>
        /// <param name="count">Количество людей.</param>
        /// <param name="peopleList">Список людей.</param>
        public static void AddRandomPerson(int count, PersonList peopleList)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                var typeOfPerson = random.Next(2);
                switch (typeOfPerson)
                {
                    case 0:
                        peopleList.AddPerson(RandomPerson.GetAdult());
                        break;
                    case 1:
                        peopleList.AddPerson(RandomPerson.GetChild());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

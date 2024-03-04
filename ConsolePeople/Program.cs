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
            personList.AddPerson(Person.GetRandomPerson());
            personList.AddPerson(Adult.GetRandomAdult(Gender.Female));
            personList.AddPerson(Adult.GetRandomAdult(Gender.Male));
            personList.ListMarried(2, 1);
            personList.AddPerson(Adult.GetRandomAdult(Gender.Female));
            personList.AddPerson(Adult.GetRandomAdult(Gender.Male));
            personList.ListMarried(3, 4);
            personList.AddPerson(Child.GetRandomChild());
            personList.AdoptChild(5, 1, 2);
            personList.AddPerson(Child.GetRandomChild());
            personList.AdoptChild(6, 3, 4);

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
    }
}

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
            personList.AddPerson(Adult.GetRandomAdult());
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

            Console.WriteLine("b. Вывод содержимого списка на экран:");

            Console.WriteLine(personList.PersonInfo());

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

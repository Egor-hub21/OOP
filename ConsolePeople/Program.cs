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
            RandomPerson.AddRandomPerson(10, personList);

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

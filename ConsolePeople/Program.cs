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
            PrintString("a. Программное создание двух списков " +
                       "персон, в каждом из которых по три человека.\n");

            PersonList personList1 = PersonList.GetRandomPersonList(3);

            PersonList personList2 = PersonList.GetRandomPersonList(2);
            personList2.AddPerson(Person.GetRandomPerson());

            ReadKey();

            PrintString("b. Вывод содержимого " +
                              "каждого списка на экран.");

            PrintString("\nПервый список:");
            PrintString(personList1.PersonInfo());

            PrintString("\nВторой список:");
            PrintString(personList2.PersonInfo());

            ReadKey();

            PrintString("c. Добавление нового " +
                              "человека в первый список");
            personList1.AddPerson(ConsolePerson.ConsoleReadPerson());
            PrintString
                    (personList1.PersonInfo(personList1.Count - 1));

            PrintString("\nПервый список:");
            PrintString(personList1.PersonInfo());

            ReadKey();

            PrintString("d. Копирование второго человека " +
                              "из первого списка в конец второго списка");
            int index = 1;

            personList2.AddPerson(personList1.GetByIndex(index));

            PrintString("\nВторой человек в первом списке:");
            PrintString(personList1.PersonInfo(index));

            PrintString("\nПоследний человек во втором:");
            PrintString
                    (personList2.PersonInfo(personList2.Count - index));

            ReadKey();

            PrintString("e. Удаление второго " +
                              "человека из первого списка");
            PrintString(personList1.PersonInfo(index));
            personList1.DeletePerson(index);

            PrintString("\nПервый список:");
            PrintString(personList1.PersonInfo());

            PrintString("\nВторой список:");
            PrintString(personList2.PersonInfo());

            ReadKey();

            PrintString("f. Очистка второго списка");
            personList2.Clear();

            PrintString("\nВторой список:");
            PrintString(personList2.PersonInfo());

            PrintString("\nПервый список:");
            PrintString(personList1.PersonInfo());
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

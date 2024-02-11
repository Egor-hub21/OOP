using People;

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
            Console.WriteLine("a. Программное создание двух списков " +
                       "персон, в каждом из которых по три человека.\n");

            PersonList personList1 = new PersonList();
            personList1.AddPerson(Child.GetRandomChild());
            personList1.AddPerson(Adult.GetRandomAdult());
            personList1.AddPerson(Adult.GetRandomAdult());

            PersonList personList2 = new PersonList();
            personList2.AddPerson(Person.GetRandomPerson());
            personList2.AddPerson(Person.GetRandomPerson());
            personList2.AddPerson(Person.GetRandomPerson());

            ReadKey();

            Console.WriteLine("b. Вывод содержимого " +
                              "каждого списка на экран.");

            Console.WriteLine("\nПервый список:");
            Console.WriteLine(personList1.PersonInfo());

            Console.WriteLine("\nВторой список:");
            Console.WriteLine(personList2.PersonInfo());

            ReadKey();

            Console.WriteLine("c. Добавление нового " +
                              "человека в первый список");
            personList1.AddPerson(ConsolePerson.ConsoleReadPerson());
            Console.WriteLine
                    (personList1.PersonInfo(personList1.GetCount() - 1));

            Console.WriteLine("\nПервый список:");
            Console.WriteLine(personList1.PersonInfo());

            ReadKey();

            Console.WriteLine("d. Копирование второго человека " +
                              "из первого списка в конец второго списка");
            int index = 1;

            personList2.AddPerson(personList1.GetByIndex(index));

            Console.WriteLine("\nВторой человек в первом списке:");
            Console.WriteLine(personList1.PersonInfo(index));

            Console.WriteLine("\nПоследний человек во втором:");
            Console.WriteLine
                    (personList2.PersonInfo(personList2.GetCount() - index));

            ReadKey();

            Console.WriteLine("e. Удаление второго " +
                              "человека из первого списка");
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
    }
}

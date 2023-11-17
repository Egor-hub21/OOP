using static FirstLab.Gender;

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
            personList1.AddPerson(new Person("1", "1", 1, Male));
            personList1.AddPerson(new Person("2", "2", 2, Female));
            personList1.AddPerson(new Person("3", "3", 3, Male));

            PersonList personList2 = new PersonList();
            personList2.AddPerson(new Person("2", "2", 2, Female));
            personList2.AddPerson(new Person("3", "3", 3, Male));
            personList2.AddPerson(new Person("4", "4", 4, Female));

            ReadKey();

            Console.WriteLine("b. Вывод содержимого каждого списка на экран.");

            Console.WriteLine("\nПервый список:");
            personList1.Print();

            Console.WriteLine("\nВторой список:");
            personList2.Print();

            ReadKey();

            Console.WriteLine("c. Добавление нового человека в первый список");
            personList1.AddPerson(new Person("5", "5", 5, Male));
            personList1.Print(personList1.GetCount() - 1);

            Console.WriteLine("\nПервый список:");
            personList1.Print();

            ReadKey();

            Console.WriteLine("d. Копирование второго человека из первого списка в конец второго списка");
            personList2.AddPerson(personList1.GetByIndex(1));

            Console.WriteLine("\nВторой человек в первом списке:");
            personList1.Print(1);

            Console.WriteLine("\nПоследний человек во втором:");
            personList2.Print(personList2.GetCount() - 1);

            ReadKey();

            Console.WriteLine("e. Удаление второго человека из первого списка");
            personList1.Print(1);
            personList1.DeletePerson(1);

            Console.WriteLine("\nПервый список:");
            personList1.Print();

            Console.WriteLine("\nВторой список:");
            personList2.Print();

            ReadKey();

            Console.WriteLine("f. Очистка второго списка");
            personList2.Clear();

            Console.WriteLine("\nВторой список:");
            personList2.Print();

            Console.WriteLine("\nПервый список:");
            personList1.Print();

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

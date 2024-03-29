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
            RandomPerson.AddRandomPeople(10, personList);

            ReadKey();
            Console.WriteLine("1. Вывод содержимого списка на экран:");

            Console.WriteLine(personList.PersonInfo());

            ReadKey();
            Console.WriteLine("2. Тип первого, четвертого и последнего "
                                                  + "элемента списка:");

            //TODO: добавить специфичный для типа метод +

            Console.WriteLine($"{GetTypePerson(personList, 0)}, "
                            + $"{GetTypePerson(personList, 3)} и "
                            + $"{GetTypePerson(personList, 6)}");

            ReadKey();

            for (int i = 0; i < personList.Count; i++)
            {
                if (personList.GetByIndex(i) is Adult)
                {
                    Adult newAdult = (Adult)personList.GetByIndex(i);
                    Console.WriteLine($"{newAdult.FirstName} {newAdult.LastName}: "
                                                        + $"{newAdult.Work()}");
                }

                else if (personList.GetByIndex(i) is Child)
                {
                    Child newChild = (Child)personList.GetByIndex(i);
                    Console.WriteLine($"{newChild.FirstName} {newChild.LastName}: "
                                                        + $"{newChild.Laze()}");
                }
            }

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
        /// Возвращает тип экземпляра <see cref="PersonBase"/> по индексу в
        /// <see cref="PersonList"/>.
        /// </summary>
        /// <param name="personList">Экземпляр класса <see cref="PersonList"/>.</param>
        /// <param name="index">Индекс.</param>
        /// <returns>Тип.</returns>
        public static Type GetTypePerson(PersonList personList, int index)
        {
            return personList.GetByIndex(index).GetType();
        }
    }
}

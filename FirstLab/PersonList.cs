namespace FirstLab
{
    /// <summary>
    /// Класс PersonList, описывающий абстракцию списка, содержащего объекты класса Person.
    /// </summary>
    public class PersonList
    {
        private List<Person> peopleList;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonList"/> class.
        /// Инициализация списка при создании объекта <see cref="PersonList"/> (Конструктор PersonList).
        /// </summary>
        public PersonList()
        {
            peopleList = new List<Person>();
        }

        /// <summary>
        /// Метод для добавления <see cref="Person"/> в <see cref="PersonList"/>.
        /// </summary>
        /// <param name="person">Экземпляр класса <see cref="Person"/>.</param>
        public void AddPerson(Person person)
        {
            peopleList.Add(person);
        }

        /// <summary>
        /// Метод для вывода информации о i-ном <see cref="Person"/> в списке  <see cref="PersonList"/>.
        /// </summary>
        /// <param name="i">Номер члена в  списке  <see cref="PersonList"/>.</param>
        public void Print(int i)
        {
            if (peopleList.Count - 1 >= i)
            {
                Console.WriteLine($"Индекс: {i}\t" +
                                  $"Имя: {peopleList[i].FirstName}\t" +
                                  $"Фамилия: {peopleList[i].LastName}\t" +
                                  $"Возраст: {peopleList[i].Age}\t" +
                                  $"Пол: {peopleList[i].Gender}\n");
            }
            else
            {
                Console.WriteLine($"Список не содержит {i}-й элемент " +
                                  $"(последний элемент списка:{peopleList.Count - 1})");
            }
        }

        /// <summary>
        /// Метод для вывода информации о  всех  <see cref="Person"/> в списке  <see cref="PersonList"/>.
        /// </summary>
        public void Print()
        {
            int i = 0;
            foreach (Person person in peopleList)
            {
                Console.WriteLine($"Индекс: {i}\t" +
                                  $"Имя: {person.FirstName}\t" +
                                  $"Фамилия: {person.LastName}\t" +
                                  $"Возраст: {person.Age}\t" +
                                  $"Пол: {person.Gender}\n" +
                                  new string('-', 60));
                i++;
            }

            if (peopleList.Count == 0)
            {
                Console.WriteLine("Список пуст!\n");
            }
        }

        /// <summary>
        /// Удаление всех элементов списка <see cref="PersonList"/>.
        /// </summary>
        public void Clear()
        {
            peopleList.Clear();
        }

        /// <summary>
        /// Удаление i-го элемента списка <see cref="PersonList"/>.
        /// </summary>
        /// <param name="i">Номер члена в  списке  <see cref="PersonList"/>.</param>
        public void DeletePerson(int i)
        {
            if (peopleList.Count >= i)
            {
                peopleList.RemoveAt(i);
                Console.WriteLine($"Элемент {i} удален из списка!\n");
            }
            else
            {
                Console.WriteLine($"Список не содержит {i}-й элемент " +
                                  $"(последний элемент списка:{peopleList.Count - 1})");
            }
        }

        /// <summary>
        /// Удаление count элементов списка <see cref="PersonList"/> начиная c i-го элемента .
        /// </summary>
        /// <param name="i">Индекс элемента с которого начинается удаление.</param>
        /// <param name="count">Количество элементов которые подлежат удалению.</param>
        public void DeletePerson(int i, int count)
        {
            if (peopleList.Count >= i + count)
            {
                peopleList.RemoveRange(i, count);
                Console.WriteLine($"Элемент с {i} по {i + count - 1} удален из списка!\n");
            }
            else if (peopleList.Count < i)
            {
                Console.WriteLine($"Список не содержит элемент с индексом {i} " +
                                  $"(последний элемент списка:{peopleList.Count - 1})");
            }
            else
            {
                Console.WriteLine($"Список не содержит {i + count} элементов " +
                                  $"(в списке {peopleList.Count} элементов)");
            }
        }

        /// <summary>
        /// Возращает количество элементов в списке <see cref="PersonList"/>.
        /// </summary>
        /// <returns>Количество элементов в списке <see cref="PersonList"/>.</returns>
        public int GetCount()
        {
            return peopleList.Count;
        }

        /// <summary>
        /// Возращает значение индекса <see cref="Person"/> в списке <see cref="PersonList"/>
        /// (если <see cref="Person"/> не является членом <see cref="PersonList"/> то индекс равен "-1").
        /// </summary>
        /// <param name="setPerson"асс>Экземпляр класса <see cref="Person"/>.</param>
        /// <returns>Индекс экземпляра класса <see cref="Person"/>.</returns>
        public int GetIndex(Person setPerson)
        {
            int index = -1;

            for (int i = 0; i < peopleList.Count; i++)
            {
                if ((peopleList[i].Age == setPerson.Age) && (peopleList[i].FirstName == setPerson.FirstName) &&
                    (peopleList[i].Gender == setPerson.Gender) && (peopleList[i].LastName == setPerson.LastName))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Возращает элемент класса <see cref="PersonList"/> по идексу.
        /// </summary>
        /// <param name="index">Индекс.</param>
        /// <returns>Элемент класса <see cref="PersonList"/>.</returns>
        public Person GetByIndex(int index)
        {
            return peopleList[index];
        }
    }
}

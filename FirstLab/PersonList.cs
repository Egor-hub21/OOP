namespace FirstLab
{
    /// <summary>
    /// Класс PersonList, описывающий абстракцию списка, содержащего объекты класса Person.
    /// </summary>
    public class PersonList
    {
        private List<Person> _peopleList;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonList"/> class.
        /// Инициализация списка при создании объекта <see cref="PersonList"/> (Конструктор PersonList).
        /// </summary>
        public PersonList()
        {
            _peopleList = new List<Person>();
        }

        /// <summary>
        /// Метод для добавления <see cref="Person"/> в <see cref="PersonList"/>.
        /// </summary>
        /// <param name="person">Экземпляр класса <see cref="Person"/>.</param>
        public void AddPerson(Person person)
        {
            _peopleList.Add(person);
        }

        /// <summary>
        /// Метод для вывода информации о i-ном <see cref="Person"/> в списке  <see cref="PersonList"/>.
        /// </summary>
        /// <param name="i">Номер члена в  списке  <see cref="PersonList"/>.</param>
        public void Print(int i)
        {
            if (_peopleList.Count - 1 >= i)
            {
                Console.WriteLine($"Индекс: {i}\t" +
                                  $"Имя: {_peopleList[i].FirstName}\t" +
                                  $"Фамилия: {_peopleList[i].LastName}\t" +
                                  $"Возраст: {_peopleList[i].Age}\t" +
                                  $"Пол: {_peopleList[i].Gender}\n");
            }
            else
            {
                Console.WriteLine($"Список не содержит {i}-й элемент " +
                                  $"(последний элемент списка:{_peopleList.Count - 1})");
            }
        }

        /// <summary>
        /// Метод для вывода информации о  всех  <see cref="Person"/> в списке  <see cref="PersonList"/>.
        /// </summary>
        public void Print()
        {
            int i = 0;
            foreach (Person person in _peopleList)
            {
                Console.WriteLine($"Индекс: {i}\t" +
                                  $"Имя: {person.FirstName}\t" +
                                  $"Фамилия: {person.LastName}\t" +
                                  $"Возраст: {person.Age}\t" +
                                  $"Пол: {person.Gender}\n" +
                                  new string('-', 100));
                i++;
            }

            if (_peopleList.Count == 0)
            {
                Console.WriteLine("Список пуст!\n");
            }
        }

        /// <summary>
        /// Удаление всех элементов списка <see cref="PersonList"/>.
        /// </summary>
        public void Clear()
        {
            _peopleList.Clear();
        }

        /// <summary>
        /// Удаление i-го элемента списка <see cref="PersonList"/>.
        /// </summary>
        /// <param name="i">Номер члена в  списке  <see cref="PersonList"/>.</param>
        public void DeletePerson(int i)
        {
            if (_peopleList.Count >= i)
            {
                _peopleList.RemoveAt(i);
                Console.WriteLine($"Элемент {i} удален из списка!\n");
            }
            else
            {
                Console.WriteLine($"Список не содержит {i}-й элемент " +
                                  $"(последний элемент списка:{_peopleList.Count - 1})");
            }
        }

        /// <summary>
        /// Удаление count элементов списка <see cref="PersonList"/> начиная c i-го элемента .
        /// </summary>
        /// <param name="i">Индекс элемента с которого начинается удаление.</param>
        /// <param name="count">Количество элементов которые подлежат удалению.</param>
        public void DeletePerson(int i, int count)
        {
            if (_peopleList.Count >= i + count)
            {
                _peopleList.RemoveRange(i, count);
                Console.WriteLine($"Элемент с {i} по {i + count - 1} удален из списка!\n");
            }
            else if (_peopleList.Count < i)
            {
                Console.WriteLine($"Список не содержит элемент с индексом {i} " +
                                  $"(последний элемент списка:{_peopleList.Count - 1})");
            }
            else
            {
                Console.WriteLine($"Список не содержит {i + count} элементов " +
                                  $"(в списке {_peopleList.Count} элементов)");
            }
        }

        /// <summary>
        /// Возращает количество элементов в списке <see cref="PersonList"/>.
        /// </summary>
        /// <returns>Количество элементов в списке <see cref="PersonList"/>.</returns>
        public int GetCount()
        {
            return _peopleList.Count;
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

            for (int i = 0; i < _peopleList.Count; i++)
            {
                if ((_peopleList[i].Age == setPerson.Age) && (_peopleList[i].FirstName == setPerson.FirstName) &&
                    (_peopleList[i].Gender == setPerson.Gender) && (_peopleList[i].LastName == setPerson.LastName))
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
            return _peopleList[index];
        }
    }
}

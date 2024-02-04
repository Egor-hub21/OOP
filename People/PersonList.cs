
namespace People
{
    /// <summary>
    /// Класс PersonList, описывающий абстракцию списка, содержащего объекты класса Person.
    /// </summary>
    public class PersonList
    {
        //TODO: XML+
        /// <summary>
        /// Лист класса <see cref="Person"/>.
        /// </summary>
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
        /// Метод для вывода информации о <see cref="Person"/>
        /// по index в списке  <see cref="PersonList"/>.
        /// </summary>
        /// <param name="index">Номер члена в
        /// списке  <see cref="PersonList"/>.</param>
        public string PersonInfo(int index)
        {
            IndexError(index);
            //TODO: duplication+
            return ($"Индекс: {index}\t" +
                     _peopleList[index].GetInfo());

        }

        /// <summary>
        /// Метод для вывода информации о  всех  <see cref="Person"/>
        /// в списке  <see cref="PersonList"/>.
        /// </summary>
        public string PersonInfo()
        {
            string info = "";

            //TODO: to for +
            for (int index = 0; index < _peopleList.Count; index++)
            {
                //TODO: duplication+
                info += (_peopleList[index].GetInfo() +
                         new string('-', 100) + "\n");
            }

            return info;
        }

        /// <summary>
        /// Удаление всех элементов списка <see cref="PersonList"/>.
        /// </summary>
        public void Clear()
        {
            _peopleList.Clear();
        }

        /// <summary>
        /// Удаление элемента по index из списка <see cref="PersonList"/>.
        /// </summary>
        /// <param name="index">Номер члена в
        /// списке <see cref="PersonList"/>.</param>
        public void DeletePerson(int index)
        {
            //TODO: duplication+
            IndexError(index);
            _peopleList.RemoveAt(index);
        }

        /// <summary>
        /// Удаление count элементов списка
        /// <see cref="PersonList"/> начиная c элемента по index.
        /// </summary>
        /// <param name="index">Индекс элемента с
        /// которого начинается удаление.</param>
        /// <param name="count">Количество элементов
        /// которые подлежат удалению.</param>
        public void DeletePerson(int index, int count)
        {
            //TODO: duplication +
            IndexError(index);
            IndexError(index + count);
            _peopleList.RemoveRange(index, count);

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
                if (_peopleList[i].Age == setPerson.Age
                    && _peopleList[i].FirstName == setPerson.FirstName
                    && _peopleList[i].Gender == setPerson.Gender
                    && _peopleList[i].LastName == setPerson.LastName)
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
            IndexError(index);
            return _peopleList[index];
        }

        /// <summary>
        ///  Возвращает сообщение об ошибке при неверном индексе.
        /// </summary>
        /// <param name="index">Индекс.</param>
        /// <returns>Сообщение.</returns>
        private void IndexError(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException($"Введенное число" +
                                                      $" меньше нуля.");
            }
            if (_peopleList.Count - 1 < index)
            {
                throw new ArgumentException($"Список не содержит {index}-й" +
                                            $" элемент (последний элемент " +
                                            $"списка:" +
                                            $"{_peopleList.Count - 1})");
            }
        }
    }
}
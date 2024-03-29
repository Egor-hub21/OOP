namespace People
{
    /// <summary>
    /// Класс PersonList, описывающий абстракцию списка,
    /// содержащего объекты класса Person.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Лист класса <see cref="Person"/>.
        /// </summary>
        private List<Person> _peopleList;

        /// <summary>
        /// Количество записей в листе.
        /// </summary>
        private int _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonList"/> class.
        /// Инициализация списка при создании объекта
        /// <see cref="PersonList"/> (Конструктор PersonList).
        /// </summary>
        public PersonList()
        {
            _peopleList = new List<Person>();
            _count = 0;
        }

        /// <summary>
        /// Gets or sets the <see cref="PersonList._count"/>.
        /// Получает количество записей в листе.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Метод для добавления <see cref="Person"/>
        /// в <see cref="PersonList"/>.
        /// </summary>
        /// <param name="person">Экземпляр класса
        /// <see cref="Person"/>.</param>
        public void AddPerson(Person person)
        {
            _peopleList.Add(person);
            _count++;
        }

        /// <summary>
        /// Метод для вывода информации о <see cref="Person"/>
        /// по index в списке  <see cref="PersonList"/>.
        /// </summary>
        /// <param name="index">Номер члена в
        /// списке  <see cref="PersonList"/>.</param>
        /// <returns>Строка с информацией о персоне.</returns>
        public string PersonInfo(int index)
        {
            CheckIndexValidity(index);

            return ($"Индекс: {index}\t" +
                     _peopleList[index].GetInfo());

        }

        /// <summary>
        /// Метод для вывода информации о  всех  <see cref="Person"/>
        /// в списке  <see cref="PersonList"/>.
        /// </summary>
        /// <returns>Строка с информацией о персоне.</returns>
        public string PersonInfo()
        {
            string info = "";

            for (int index = 0; index < _peopleList.Count; index++)
            {
                info += (_peopleList[index].GetInfo() +
                         new string('-', 100) + "\n");
            }

            return info;
        }

        /// <summary>
        /// Очистка списка <see cref="PersonList"/>.
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
            CheckIndexValidity(index);
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
            CheckIndexValidity(index);
            CheckIndexValidity(index + count);
            _peopleList.RemoveRange(index, count);

        }

        /// <summary>
        /// Возвращает значение индекса <see cref="Person"/>
        /// в списке <see cref="PersonList"/>
        /// (если <see cref="Person"/> не является членом
        /// <see cref="PersonList"/> то индекс равен "-1").
        /// </summary>
        /// <param name="setPerson"асс>Экземпляр класса
        /// <see cref="Person"/>.</param>
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
        /// Возвращает элемент класса <see cref="PersonList"/> по идексу.
        /// </summary>
        /// <param name="index">Индекс.</param>
        /// <returns>Элемент класса <see cref="PersonList"/>.</returns>
        public Person GetByIndex(int index)
        {
            CheckIndexValidity(index);
            return _peopleList[index];
        }

        /// <summary>
        ///  Возвращает сообщение об ошибке при неверном индексе.
        /// </summary>
        /// <param name="index">Индекс.</param>
        private void CheckIndexValidity(int index)
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

        /// <summary>
        /// Добавляет <see cref="Adult"/> супруга по их индексам в листе.
        /// </summary>
        /// <param name="womenIndex">Индекс женщины.</param>
        /// <param name="manIndex">Индекс мужчины.</param>
        public void ListMarried(int womenIndex, int manIndex)
        {
            ConvertAdult(manIndex).CreateMarried(ConvertAdult(womenIndex));
        }

        /// <summary>
        /// Присваивает <see cref="Child"/> родителей по их индексу
        /// в данном листе.
        /// </summary>
        /// <param name="childIndex">Индекс ребенка.</param>
        /// <param name="motherIndex">Индекс матери.</param>
        /// <param name="fatherIndex">Индекс отца.</param>
        public void AdoptChild(int childIndex, int motherIndex, int fatherIndex)
        {
            ConvertChild(childIndex).Adopt(ConvertAdult(motherIndex),
                                           ConvertAdult(fatherIndex));
        }

        /// <summary>
        /// Возвращает тип экземпляра <see cref="Person"/> по индексу в
        /// <see cref="PersonList"/>.
        /// </summary>
        /// <param name="index">Индекс.</param>
        /// <returns>Тип.</returns>
        public Type GetTypePerson(int index)
        {
            return GetByIndex(index).GetType();
        }

        /// <summary>
        /// Преобразовывает <see cref="Person"/> в
        /// <see cref="Child"/> по индексу в
        /// <see cref="PersonList"/>.
        /// <param name="index"></param>
        /// <returns><see cref="Child"/></returns>
        private Child ConvertChild(int index)
        {
            return ((Child)GetByIndex(index));
        }

        /// <summary>
        /// Преобразовывает <see cref="Person"/> в
        /// <see cref="Adult"/> по индексу в
        /// <see cref="PersonList"/>.
        /// </summary>
        /// <param name="index">Индекс.</param>
        /// <returns><see cref="Adult"/>.</returns>
        private Adult ConvertAdult(int index)
        {
            return ((Adult)GetByIndex(index));
        }
    }
}

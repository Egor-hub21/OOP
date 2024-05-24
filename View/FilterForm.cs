using GeometricFigures;
using System.ComponentModel;
using System.Reflection;

namespace View
{
    //TODO: XML +
    /// <summary>
    /// Представляет форму для фильтрации данных.
    /// </summary>
    public partial class FilterForm : Form
    {
        //TODO: +
        /// <summary>
        /// Список фигур.
        /// </summary>
        private BindingList<GeometricFigureBase> _geometricFigures;

        //TODO: +
        /// <summary>
        /// Отфильтрованный список фигур.
        /// </summary>
        private BindingList<GeometricFigureBase> _filteredGeometricFigures;

        //TODO: RSDN +
        /// <summary>
        /// Событие на фильтрацию списка.
        /// </summary>
        public EventHandler FiguresFilteredOut;

        //TODO: XML +
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FilterForm"/>.
        /// </summary>
        /// <param name="geometricFigures">Список 
        /// геометрических фигур для фильтрации.</param>
        public FilterForm(BindingList<GeometricFigureBase> geometricFigures)
        {
            _geometricFigures = geometricFigures;
            InitializeComponent();
            DeactivateElements();
            //TODO: refactor +
            _filterButton.Click += FilterOut;
            _checkBoxArea.CheckedChanged += ActivateAreaBox;
            _checkBoxPerimeter.CheckedChanged += ActivatePerimeterBox;

            _checkBoxTypeCircle.CheckedChanged += ActivateElements;
            _checkBoxTypeRectangle.CheckedChanged += ActivateElements;
            _checkBoxTypeTriangle.CheckedChanged += ActivateElements;

        }

        //TODO: XML +
        /// <summary>
        /// Деактивирует элементы управления на форме.
        /// </summary>
        private void DeactivateElements()
        {
            _checkBoxArea.Enabled = false;
            _checkBoxPerimeter.Enabled = false;

            _areaNumericBox.Enabled = false;
            _perimeterNumericBox.Enabled = false;

            _filterButton.Enabled = false;
        }

        //TODO: XML +
        /// <summary>
        /// Активирует или деактивирует элементы управления
        /// в зависимости от состояния чекбоксов типа фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void ActivateElements(object sender, EventArgs e)
        {
            bool activate = _checkBoxTypeCircle.Checked
                || _checkBoxTypeRectangle.Checked
                || _checkBoxTypeTriangle.Checked;

            _filterButton.Enabled = activate;
            _checkBoxArea.Enabled = activate;
            _checkBoxPerimeter.Enabled = activate;
        }

        //TODO: RSDN +
        /// <summary>
        /// Активация поля ввода Площади.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void ActivateAreaBox(object sender, EventArgs e)
        {
            _areaNumericBox.Enabled = _checkBoxArea.Checked;
        }

        //TODO: RSDN +
        /// <summary>
        /// Активациия поля ввода Периметра.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void ActivatePerimeterBox(object sender, EventArgs e)
        {
            _perimeterNumericBox.Enabled = _checkBoxPerimeter.Checked;
        }

        /// <summary>
        /// Фильтрация списка.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void FilterOut(object sender, EventArgs e)
        {
            _filteredGeometricFigures = new BindingList<GeometricFigureBase>();

            if (_checkBoxTypeCircle.Checked) 
            {
                FilterByType(_geometricFigures, _filteredGeometricFigures,
                    typeof(Circle));
            }
            if (_checkBoxTypeRectangle.Checked)
            {
                FilterByType(_geometricFigures, _filteredGeometricFigures,
                    typeof(GeometricFigures.Rectangle));
            }
            if (_checkBoxTypeTriangle.Checked)
            {
                FilterByType(_geometricFigures, _filteredGeometricFigures,
                    typeof(Triangle));
            }
            if (_checkBoxArea.Checked)
            {
                if (!string.IsNullOrWhiteSpace(_areaNumericBox.Text))
                {
                    _filteredGeometricFigures = 
                        FilterByArea(_filteredGeometricFigures,
                        Convert.ToDouble(_areaNumericBox.Text));
                }
                else 
                {
                    //TODO: +
                    _ = MessageBox.Show("Пожалуйста, заполните Площадь",
                        "Сообщение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            if (_checkBoxPerimeter.Checked)
            {
                if (!string.IsNullOrWhiteSpace(_perimeterNumericBox.Text))
                {
                    _filteredGeometricFigures = 
                        FilterByPerimeter(_filteredGeometricFigures,
                        Convert.ToDouble(_perimeterNumericBox.Text));
                }
                else
                {
                    _ = MessageBox.Show("Пожалуйста, заполните Периметр",
                        "Сообщение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            FiguresFilteredOut.Invoke(this, 
                new FiguresAddedEventArgs(_filteredGeometricFigures));
        }

        /// <summary>
        /// Отфильтровывает список по типу.
        /// </summary>
        /// <typeparam name="T">Тип значений списка.</typeparam>
        /// <param name="originalList">Лист подлежащий фильтрации.</param>
        /// <param name="filteredList">Список в который будут добавленны
        /// отфильтрованные значения</param>
        /// <param name="typeFilter">Тип отфильтрованных значений.</param>
        private static void FilterByType<T>(
            BindingList<T> originalList, BindingList<T> filteredList,
            Type typeFilter) where T : class
        {
            foreach (var item in originalList)
            {
                if (typeFilter.IsInstanceOfType(item))
                {
                    filteredList.Add(item);
                }
            }
        }


        /// <summary>
        /// Отфильтровывает список по Площади.
        /// </summary>
        /// <param name="originalList">Лист подлежащий фильтрации.</param>
        /// <param name="valueArea">Значение Площади.</param>
        /// <returns>Отфильтрованный список.</returns>
        private static BindingList<GeometricFigureBase> FilterByArea(
            BindingList<GeometricFigureBase> originalList, double valueArea)
        {
            BindingList<GeometricFigureBase> filteredList = [];
            foreach (var item in originalList)
            {
                if (item.Area == valueArea)
                {
                    filteredList.Add(item);
                }
            }
            return filteredList;
        }

        /// <summary>
        /// Отфильтровывает список по Периметру.
        /// </summary>
        /// <param name="originalList">Лист пдлежащий ильтрации.</param>
        /// <param name="valuePerimeter">Значение Периметра.</param>
        /// <returns>Отфильтрованный список.</returns>
        private static BindingList<GeometricFigureBase> FilterByPerimeter(
            BindingList<GeometricFigureBase> originalList, double valuePerimeter)
        {
            BindingList<GeometricFigureBase> filteredList = [];
            foreach (var item in originalList)
            {
                if (item.Perimeter == valuePerimeter)
                {
                    filteredList.Add(item);
                }
            }
            return filteredList;
        }
    }
}

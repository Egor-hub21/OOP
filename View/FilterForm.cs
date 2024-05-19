using GeometricFigures;
using System.ComponentModel;
using System.Reflection;

namespace View
{
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Список фигур.
        /// </summary>
        private BindingList<GeometricFigureBase> GeometricFigures 
        { get; set; }

        /// <summary>
        /// Отфильтрованный список фигур.
        /// </summary>
        private BindingList<GeometricFigureBase> FilteredGeometricFigures
        { get; set; }

        /// <summary>
        /// Событие на фильтрацию списка.
        /// </summary>
        public EventHandler figuresFilteredOut;

        public FilterForm(BindingList<GeometricFigureBase> geometricFigures)
        {
            GeometricFigures = geometricFigures;
            InitializeComponent();
            DeactivateElements();
            _filterButton.Click += new EventHandler(FilterOut);
            _checkBoxArea.CheckedChanged += new EventHandler(checkBoxArea_CheckedChanged);
            _checkBoxPerimeter.CheckedChanged += new EventHandler(perimeterNumericBox_CheckedChanged);

            _checkBoxTypeCircle.CheckedChanged += new EventHandler(CheckBox_ActivateElements);
            _checkBoxTypeRectangle.CheckedChanged += new EventHandler(CheckBox_ActivateElements);
            _checkBoxTypeTriangle.CheckedChanged += new EventHandler(CheckBox_ActivateElements);
        }

        private void DeactivateElements()
        {
            _checkBoxArea.Enabled = false;
            _checkBoxPerimeter.Enabled = false;

            _areaNumericBox.Enabled = false;
            _perimeterNumericBox.Enabled = false;

            _filterButton.Enabled = false;
        }

        private void CheckBox_ActivateElements(object sender, EventArgs e)
        {
            bool activate = _checkBoxTypeCircle.Checked
                || _checkBoxTypeRectangle.Checked
                || _checkBoxTypeTriangle.Checked;

            _filterButton.Enabled = activate;
            _checkBoxArea.Enabled = activate;
            _checkBoxPerimeter.Enabled = activate;
        }

        /// <summary>
        /// Флажок активации поля ввода объёма.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxArea_CheckedChanged(object sender, EventArgs e)
        {
            _areaNumericBox.Enabled = _checkBoxArea.Checked;
        }

        /// <summary>
        /// Флажок активации поля ввода Периметра.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void perimeterNumericBox_CheckedChanged(object sender, EventArgs e)
        {
            _perimeterNumericBox.Enabled = _checkBoxPerimeter.Checked;
        }

        /// <summary>
        /// Фильтрация списка.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void FilterOut(object sender, EventArgs e)
        {
            FilteredGeometricFigures = new BindingList<GeometricFigureBase>();

            if (_checkBoxTypeCircle.Checked) 
            {
                FilterByType(GeometricFigures, FilteredGeometricFigures,
                    typeof(Circle));
            }
            if (_checkBoxTypeRectangle.Checked)
            {
                FilterByType(GeometricFigures, FilteredGeometricFigures,
                    typeof(GeometricFigures.Rectangle));
            }
            if (_checkBoxTypeTriangle.Checked)
            {
                FilterByType(GeometricFigures, FilteredGeometricFigures,
                    typeof(Triangle));
            }
            if (_checkBoxArea.Checked)
            {
                if (!string.IsNullOrWhiteSpace(_areaNumericBox.Text))
                {
                    FilteredGeometricFigures = FilterByArea(FilteredGeometricFigures,
                        Convert.ToDouble(_areaNumericBox.Text));
                }
                else 
                {
                    _ = MessageBox.Show("Пожалуйста, заполните Плщадь");
                }
            }
            if (_checkBoxPerimeter.Checked)
            {
                if (!string.IsNullOrWhiteSpace(_perimeterNumericBox.Text))
                {
                    FilteredGeometricFigures = FilterByPerimeter(FilteredGeometricFigures,
                        Convert.ToDouble(_perimeterNumericBox.Text));
                }
                else
                {
                    _ = MessageBox.Show("Пожалуйста, заполните Периметр");
                }
            }
            figuresFilteredOut.Invoke(this, new FiguresAddedEventArgs(FilteredGeometricFigures));
        }

        /// <summary>
        /// Отфильтровывает список по типу.
        /// </summary>
        /// <typeparam name="T">Тип значений списа.</typeparam>
        /// <param name="originalList">Лист пдлежащий ильтрации.</param>
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
        /// <param name="originalList">Лист пдлежащий ильтрации.</param>
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

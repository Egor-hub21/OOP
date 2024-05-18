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
        private BindingList<GeometricFigureBase> GeometricFigures { get; set; }

        /// <summary>
        /// Отфильтрованный список фигур.
        /// </summary>
        private BindingList<GeometricFigureBase> FilteredGeometricFigures
        { get; set; }

        /// <summary>
        /// Событие на фильтрацию списка.
        /// </summary>
        public EventHandler FiguresFilteredOut{ get; set; }

        public FilterForm(BindingList<GeometricFigureBase> geometricFigures)
        {
            GeometricFigures = geometricFigures;
            InitializeComponent();
            DeactivateElements();
            filterButton.Click += new EventHandler(FilterOut);
            checkBoxArea.CheckedChanged += new EventHandler(checkBoxArea_CheckedChanged);
            checkBoxPerimeter.CheckedChanged += new EventHandler(perimeterNumericBox_CheckedChanged);

            checkBoxTypeCircle.CheckedChanged += new EventHandler(CheckBox_ActivateElements);
            checkBoxTypeRectangle.CheckedChanged += new EventHandler(CheckBox_ActivateElements);
            checkBoxTypeTriangle.CheckedChanged += new EventHandler(CheckBox_ActivateElements);
        }

        private void DeactivateElements()
        {
            checkBoxArea.Enabled = false;
            checkBoxPerimeter.Enabled = false;

            areaNumericBox.Enabled = false;
            perimeterNumericBox.Enabled = false;

            filterButton.Enabled = false;
        }

        private void CheckBox_ActivateElements(object sender, EventArgs e)
        {
            bool activate = checkBoxTypeCircle.Checked
                || checkBoxTypeRectangle.Checked
                || checkBoxTypeTriangle.Checked;

            filterButton.Enabled = activate;
            checkBoxArea.Enabled = activate;
            checkBoxPerimeter.Enabled = activate;
        }




        /// <summary>
        /// Флажок активации поля ввода объёма.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxArea_CheckedChanged(object sender, EventArgs e)
        {
            areaNumericBox.Enabled = checkBoxArea.Checked;
        }

        /// <summary>
        /// Флажок активации поля ввода Периметра.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void perimeterNumericBox_CheckedChanged(object sender, EventArgs e)
        {
            perimeterNumericBox.Enabled = checkBoxPerimeter.Checked;
        }

        /// <summary>
        /// Фильтрация списка.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void FilterOut(object sender, EventArgs e)
        {
            FilteredGeometricFigures = new BindingList<GeometricFigureBase>();

            if (checkBoxTypeCircle.Checked) 
            {
                FilterByType(GeometricFigures, FilteredGeometricFigures,
                    typeof(Circle));
            }
            if (checkBoxTypeRectangle.Checked)
            {
                FilterByType(GeometricFigures, FilteredGeometricFigures,
                    typeof(GeometricFigures.Rectangle));
            }
            if (checkBoxTypeTriangle.Checked)
            {
                FilterByType(GeometricFigures, FilteredGeometricFigures,
                    typeof(Triangle));
            }
            if (checkBoxArea.Checked)
            {
                if (!string.IsNullOrWhiteSpace(areaNumericBox.Text))
                {
                    FilteredGeometricFigures = FilterByArea(FilteredGeometricFigures,
                        Convert.ToDouble(areaNumericBox.Text));
                }
                else 
                {
                    _ = MessageBox.Show("Пожалуйста, заполните Плщадь");
                }
            }
            if (checkBoxPerimeter.Checked)
            {
                if (!string.IsNullOrWhiteSpace(perimeterNumericBox.Text))
                {
                    FilteredGeometricFigures = FilterByPerimeter(FilteredGeometricFigures,
                        Convert.ToDouble(perimeterNumericBox.Text));
                }
                else
                {
                    _ = MessageBox.Show("Пожалуйста, заполните Периметр");
                }
            }
            FiguresFilteredOut.Invoke(this, new FiguresAddedEventArgs(FilteredGeometricFigures));
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

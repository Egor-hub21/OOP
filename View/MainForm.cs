using GeometricFigures;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.DataFormats;

namespace View
{
    /// <summary>
    /// Главная форма программы.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список фигур.
        /// </summary>
        private BindingList<GeometricFigureBase> _geometricFigures;

        /// <summary>
        /// Отфильтрованный список фигур.
        /// </summary>
        private BindingList<GeometricFigureBase> _filteredGeometricFigures;

        /// <summary>
        /// Для Сериализации/Десериализации. 
        /// </summary>
        private readonly XmlSerializer _serializer =
            new XmlSerializer(typeof(BindingList<GeometricFigureBase>));

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeFigures();

            _addButton.Click += OpenAddForm;
            _removeButton.Click += DeleteFigure;
            _filterButton.Click += OpenFilterForm;
            _resettingFilterButton.Click += ResetFilter;

            _serializationButton.Click += SerializeFigures;
            _deserializationButton.Click += DeserializeFigures;
        }

        #region Add

        /// <summary>
        /// Cоздает форму для добавления фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void OpenAddForm(object sender, EventArgs e)
        {
            AddForm addForm = Application
                .OpenForms.OfType<AddForm>().FirstOrDefault();

            if (addForm == null)
            {
                addForm = new AddForm();
                addForm.Show();
                addForm.FigureAdded += FigureAdded;
                addForm.FigureDeleted += FigureDeleted;
            }
            else
            {
                addForm.Focus();
            }
        }

        /// <summary>
        /// Добавить фигуру.
        /// </summary>
        /// <param name="sender".>Источник события</param>
        /// <param name="geometricFigure">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void FigureAdded(object sender, EventArgs geometricFigure)
        {
            FigureAddedEventArgs addedEventArgs = geometricFigure as FigureAddedEventArgs;

            _geometricFigures.Add(addedEventArgs?.GeometricFigure);
        }

        /// <summary>
        /// Отмена добавления фигуры.
        /// </summary>
        /// <param name="sender".>Источник события</param>
        /// <param name="geometricFigure">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void FigureDeleted(object sender, EventArgs geometricFigure)
        {
            FigureAddedEventArgs addedEventArgs = geometricFigure as FigureAddedEventArgs;

            _ = _geometricFigures.Remove(addedEventArgs?.GeometricFigure);
        }
        #endregion

        #region Filter

        /// <summary>
        /// Cоздает форму для задания фильтра.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void OpenFilterForm(object sender, EventArgs e)
        {
            FilterForm filterForm = Application
                .OpenForms.OfType<FilterForm>().FirstOrDefault();

            if (filterForm == null)
            {
                filterForm = new FilterForm(_geometricFigures);
                filterForm.FiguresFilteredOut += FiguresFilteredOut;
                filterForm.Show();
            }
            else
            {
                filterForm.Focus();
            }
        }

        /// <summary>
        /// Отфильтровать фигуры.
        /// <param name="sender".>Источник события</param>
        /// <param name="geometricFigure">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void FiguresFilteredOut(object sender, EventArgs geometricFigure)
        {
            FiguresAddedEventArgs filterEventArgs = geometricFigure as FiguresAddedEventArgs;

            _filteredGeometricFigures = filterEventArgs?.GeometricFigure;

            BindDataToGrid(_figureDataGrid, _filteredGeometricFigures);
        }

        /// <summary>
        /// Сбросить фильтр
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void ResetFilter(object sender, EventArgs e)
        {
            BindDataToGrid(_figureDataGrid, _geometricFigures);
        }

        #endregion

        /// <summary>
        /// Инициализация _geometricFigures.
        /// </summary>
        private void InitializeFigures()
        {
            _geometricFigures = new BindingList<GeometricFigureBase>();
            BindDataToGrid(_figureDataGrid, _geometricFigures);
        }

        /// <summary>
        /// Связывание листа с таблицей на форме.
        /// </summary>
        /// <param name="figureDataGrid">Таблица.</param>
        /// <param name="GeometricFigures">Лист фигур.</param>
        public void BindDataToGrid(DataGridView figureDataGrid, 
            BindingList<GeometricFigureBase> GeometricFigures)
        {
            figureDataGrid.DataSource = GeometricFigures;
        }

        /// <summary>
        /// Удаляет фигуру.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void DeleteFigure(object sender, EventArgs e)
        { 
            _figureDataGrid.SelectionMode = 
                DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewRow row in _figureDataGrid.SelectedRows)
            {
                _figureDataGrid.Rows.Remove(row);
            }
        }

        /// <summary>
        /// Сохраненить список в файл.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void SerializeFigures(object sender, EventArgs e)
        {
            if (_geometricFigures.Count == 0 || _geometricFigures is null)
            {
                MessageBox.Show("Список пуст!", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.fig)|*.fig|Все файлы (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName.ToString();
                using (var file = File.Create(path))
                {
                    _serializer.Serialize(file, _geometricFigures);
                }
            }
        }

        /// <summary>
        /// Загрузить список из файла.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void DeserializeFigures(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.fig)|*.fig|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string path = openFileDialog.FileName.ToString();
            try
            {
                using (var file = new StreamReader(path))
                {
                    _geometricFigures = (BindingList<GeometricFigureBase>)
                        _serializer.Deserialize(file);
                }

                _figureDataGrid.DataSource = _geometricFigures;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить файл!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

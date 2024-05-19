using GeometricFigures;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace View
{
    /// <summary>
    /// Главная форма программы.
    /// </summary>
    public partial class MainForm : Form
    {
        //TODO: incapsulation +

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

            _addButton.Click += new EventHandler(OpenAddForm);
            _removeButton.Click += new EventHandler(figureDataGrid_DeletingLine);
            _filterButton.Click += new EventHandler(OpenFilterForm);
            _resettingFilterButton.Click += new EventHandler(ResetFilter);

            _serializationButton.Click += new EventHandler(SerializeFigures);
            _deserializationButton.Click += new EventHandler(DeserializeFigures);
        }

        #region Add
        //TODO: RSDN +
        /// <summary>
        /// Cоздает форму для добавления фигуры.
        /// </summary>
        /// <param name="sender".></param>
        /// <param name="e">.</param>
        private void OpenAddForm(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.figureAdded += new EventHandler(FigureAdded);
            addForm.figureDeleted += new EventHandler(FigureDeleted);

            addForm.Show();
        }

        /// <summary>
        /// Добавить фигуру.
        /// </summary>
        /// <param name="sender".></param>
        /// <param name="geometricFigure">.</param>
        private void FigureAdded(object sender, EventArgs geometricFigure)
        {
            FigureAddedEventArgs addedEventArgs = geometricFigure as FigureAddedEventArgs;

            GeometricFigures.Add(addedEventArgs?.GeometricFigure);
        }

        /// <summary>
        /// Отмена добавления фигуры.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="geometricFigure">.</param>
        private void FigureDeleted(object sender, EventArgs geometricFigure)
        {
            FigureAddedEventArgs addedEventArgs = geometricFigure as FigureAddedEventArgs;

            _ = GeometricFigures.Remove(addedEventArgs?.GeometricFigure);
        }
        #endregion

        #region Filter

        /// <summary>
        /// Cоздает форму для задания фильтра.
        /// </summary>
        /// <param name="sender".></param>
        /// <param name="e">.</param>
        private void OpenFilterForm(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm(GeometricFigures);
            filterForm.figuresFilteredOut += new EventHandler(FiguresFilteredOut);

            filterForm.Show();
        }

        /// <summary>
        /// Отфильтровать фигуры.
        /// </summary>
        /// <param name="sender".></param>
        /// <param name="geometricFigure">.</param>
        private void FiguresFilteredOut(object sender, EventArgs geometricFigure)
        {
            FiguresAddedEventArgs filterEventArgs = geometricFigure as FiguresAddedEventArgs;

            FilteredGeometricFigures = filterEventArgs?.GeometricFigure;

            PopulateDataGridView(_figureDataGrid, FilteredGeometricFigures);
        }

        /// <summary>
        /// Сбросить фильтр
        /// </summary>
        /// <param name="sender".></param>
        /// <param name="e">.</param>
        private void ResetFilter(object sender, EventArgs e)
        {
            PopulateDataGridView(_figureDataGrid, GeometricFigures);
        }

        #endregion


        /// <summary>
        /// Инициализация GeometricFigures.
        /// </summary>
        private void InitializeFigures()
        {
            GeometricFigures = new BindingList<GeometricFigureBase>();
            PopulateDataGridView(_figureDataGrid, GeometricFigures);
        }

        /// <summary>
        /// Связывание листа с таблицей на форме.
        /// </summary>
        /// <param name="figureDataGrid">Таблица.</param>
        /// <param name="GeometricFigures">Лист фигур.</param>
        public void PopulateDataGridView(DataGridView figureDataGrid, 
            BindingList<GeometricFigureBase> GeometricFigures)
        {
            figureDataGrid.DataSource = GeometricFigures;
        }

        /// <summary>
        /// Удаляет фигуру.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void figureDataGrid_DeletingLine(object sender, EventArgs e)
        {

            _figureDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewRow row in _figureDataGrid.SelectedRows)
            {
                _figureDataGrid.Rows.Remove(row);
            }
        }

        /// <summary>
        /// Сохраненить список в файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerializeFigures(object sender, EventArgs e)
        {
            if (GeometricFigures.Count == 0 || GeometricFigures is null)
            {
                MessageBox.Show("Список пуст!");
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
                    _serializer.Serialize(file, GeometricFigures);
                }
            }
        }

        /// <summary>
        /// Загрузить список из файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    GeometricFigures = (BindingList<GeometricFigureBase>)
                        _serializer.Deserialize(file);
                }

                _figureDataGrid.DataSource = GeometricFigures;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить файл!");
            }
        }


    }
}

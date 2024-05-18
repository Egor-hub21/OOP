using GeometricFigures;
using System.ComponentModel;

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
        /// Initializes a new instance of the
        /// <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeFigures();

            addButton.Click += new EventHandler(OpenAddForm);
            removeButton.Click += new EventHandler(figureDataGrid_DeletingLine);
            filterButton.Click += new EventHandler(OpenFilterForm);
            resettingFilterButton.Click += new EventHandler(ResetFilter);
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
            addForm.FigureAdded += new EventHandler(FigureAdded);
            addForm.FigureDeleted += new EventHandler(FigureDeleted);

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
            filterForm.FiguresFilteredOut += new EventHandler(FiguresFilteredOut);

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

            PopulateDataGridView(figureDataGrid, FilteredGeometricFigures);
        }

        /// <summary>
        /// Сбросить фильтр
        /// </summary>
        /// <param name="sender".></param>
        /// <param name="e">.</param>
        private void ResetFilter(object sender, EventArgs e)
        {
            PopulateDataGridView(figureDataGrid, GeometricFigures);
        }

        #endregion


        /// <summary>
        /// Инициализация GeometricFigures.
        /// </summary>
        private void InitializeFigures()
        {
            GeometricFigures = new BindingList<GeometricFigureBase>();
            PopulateDataGridView(figureDataGrid, GeometricFigures);
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
            if (figureDataGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in figureDataGrid.SelectedRows)
                {
                    figureDataGrid.Rows.Remove(row);
                }
            }
            else
            {
                _ = MessageBox.Show("Выделите строку в таблице!");
            }
        }
    }
}

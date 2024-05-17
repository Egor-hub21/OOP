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
        private BindingList<GeometricFigureBase> GeometricFigures { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeFigures();
            PopulateDataGridView();

            addButton.Click += new EventHandler(OpenAddForm);
            removeButton.Click += new EventHandler(figureDataGrid_DeletingLine);
        }

        //TODO: RSDN +
        private void OpenAddForm(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.FigureAdded += new EventHandler(FigureAdded);
            addForm.FigureDeleted += new EventHandler(FigureDeleted);

            addForm.Show();
        }

        private void FigureAdded(object sender, EventArgs geometricFigure)
        {
            FigureAddedEventArgs addedEventArgs = geometricFigure as FigureAddedEventArgs;

            GeometricFigures.Add(addedEventArgs?.GeometricFigure);
        }

        private void FigureDeleted(object sender, EventArgs geometricFigure)
        {
            FigureDeletedEventArgs addedEventArgs = geometricFigure as FigureDeletedEventArgs;

            _ = GeometricFigures.Remove(addedEventArgs?.GeometricFigure);
        }

        private void InitializeFigures()
        {
            GeometricFigures = new BindingList<GeometricFigureBase>
            {
                new Circle(1),
                new GeometricFigures.Rectangle(2,2),
                new Triangle(1,2, new Angle(90)),
            };
        }

        /// <summary>
        /// Связывание листа с таблицей на форме.
        /// </summary>
        public void PopulateDataGridView()
        {
            figureDataGrid.DataSource = GeometricFigures;
        }

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

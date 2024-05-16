using GeometricFigures;
using System.ComponentModel;

namespace View
{
    public partial class MainForm : Form
    {
        public BindingList<GeometricFigureBase> GeometricFigures { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitializeFigures();
            PopulateDataGridView();

            addButton.Click += new EventHandler(openAddForm);
            removeButton.Click += new EventHandler(figureDataGrid_DeletingLine);
        }

        private void openAddForm(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);
            addForm.GeometricFigures = GeometricFigures;
            addForm.Show();
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

        public void PopulateDataGridView()
        {
            figureDataGrid.DataSource = GeometricFigures;
        }

        private void figureDataGrid_DeletingLine(object sender, EventArgs e)
        {
            if (figureDataGrid.SelectedRows.Count > 0)
            {
                // Удаляем выбранные строки из списка
                foreach (DataGridViewRow row in figureDataGrid.SelectedRows)
                {
                    figureDataGrid.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Выделите строку в таблице!");
            }
        }
    }
}

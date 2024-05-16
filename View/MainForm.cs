using GeometricFigures;
using System.ComponentModel;
using System.Windows.Forms;

namespace View
{
    public partial class MainForm : Form
    {
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
            figureDataGrid.Rows.Clear();
            foreach (var figure in GeometricFigures)
            {
                figureDataGrid.Rows.Add(figure.GetType().Name, figure.GetInfo(), figure.GetArea());
            }
        }

        private void figureDataGrid_DeletingLine(object sender, EventArgs e)
        {
            if (figureDataGrid.SelectedRows.Count > 0)
            {
                // Получаем выделенную строку
                int selectedIndex = figureDataGrid.SelectedRows[0].Index;

                GeometricFigures.RemoveAt(selectedIndex);

                PopulateDataGridView();
            }
            else
            {
                MessageBox.Show("Выделите строку в таблице!");
            }
        }
    }
}

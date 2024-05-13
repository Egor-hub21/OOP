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
        }

        private void openAddForm(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
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

        private void PopulateDataGridView()
        {
            figureDataGrid.Rows.Clear();
            foreach (var figure in GeometricFigures)
            {
                figureDataGrid.Rows.Add(figure.GetType().Name, figure.GetInfo(), figure.GetArea());
            }
        }
    }
}

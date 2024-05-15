using System.ComponentModel;
using GeometricFigures;


namespace View
{
    public partial class AddForm : Form
    {
        public BindingList<GeometricFigureBase> GeometricFigures { get; set;}
        public GeometricFigureBase GeometricFigure { get; set; }

        private MainForm mainForm;

        public AddForm(MainForm owner)
        {
            mainForm = owner;
            InitializeComponent();
            comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            okButton.Click += new EventHandler(button1_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool invalidInput;
            if (figureParametersBox is CircleParametersBox circleParametersBox) 
            {
                invalidInput = string.IsNullOrWhiteSpace(circleParametersBox.radiusTextBox.Text);
                if (!invalidInput)
                {
                    GeometricFigures.Add(new Circle
                    {
                        Radius = Convert.ToDouble(circleParametersBox.radiusTextBox.Text),
                    });
                    mainForm.PopulateDataGridView();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields");
                }
            }
            else if (figureParametersBox is RectangleParametersBox rectangleParametersBox)
            {
                invalidInput = string.IsNullOrWhiteSpace(rectangleParametersBox.lengthTextBox.Text)
                          || string.IsNullOrWhiteSpace(rectangleParametersBox.widthSideTextBox.Text);

                if (!invalidInput)
                {
                    GeometricFigures.Add(new GeometricFigures.Rectangle
                    {
                        Length = Convert.ToDouble(rectangleParametersBox.lengthTextBox.Text),
                        Width = Convert.ToDouble(rectangleParametersBox.widthSideTextBox.Text),
                    });
                    mainForm.PopulateDataGridView();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields");
                }
            }
            else if (figureParametersBox is TriangleParametersBox triangleParametersBox)
            {
                invalidInput = string.IsNullOrWhiteSpace(triangleParametersBox.angleTextBox.Text)
                          || string.IsNullOrWhiteSpace(triangleParametersBox.firstSideTextBox.Text)
                          || string.IsNullOrWhiteSpace(triangleParametersBox.secondSideTextBox.Text);

                if (!invalidInput)
                {
                    GeometricFigures.Add(new GeometricFigures.Triangle
                    {
                        Angle = new Angle( Convert.ToDouble(triangleParametersBox.angleTextBox.Text)),
                        FirstSide = Convert.ToDouble(triangleParametersBox.firstSideTextBox.Text),
                        SecondSide = Convert.ToDouble(triangleParametersBox.secondSideTextBox.Text),
                    });
                    mainForm.PopulateDataGridView();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields");
                }
            }
        }
    }
}

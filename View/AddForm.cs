using System.ComponentModel;
using GeometricFigures;


namespace View
{
    public partial class AddForm : Form
    {
        //TODO: incapsulation
        public BindingList<GeometricFigureBase> GeometricFigures { get; set; }
        public GeometricFigureBase GeometricFigure { get; }

        //TODO: incapsulation
        private MainForm mainForm;

        //TODO: remove argument
        public AddForm(MainForm owner)
        {
            mainForm = owner;
            InitializeComponent();
            comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            okButton.Click += new EventHandler(button1_Click);
        }

        public EventHandler FigureAdded;

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controls.Remove(figureParametersBox);

            switch (comboBox.SelectedIndex)
            {
                case 0:
                    figureParametersBox = new CircleParametersBox()
                    {
                        Location = figureParametersBox.Location,
                    };
                    break;
                case 1:
                    figureParametersBox = new RectangleParametersBox()
                    {
                        Location = figureParametersBox.Location,

                    };
                    break;
                case 2:
                    figureParametersBox = new TriangleParametersBox()
                    {
                        Location = figureParametersBox.Location,

                    };
                    break;
                default:
                    figureParametersBox.Visible = true;
                    break;
            }
            Controls.Add(figureParametersBox);
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
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля");
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
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля");
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
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля");
                }
            }
            FigureAdded?.Invoke(this, new FigureAddedEventArgs(GeometricFigure));
        }
    }
}

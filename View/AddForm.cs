using GeometricFigures;

namespace View
{
    /// <summary>
    /// Форма для добавление фигуры. 
    /// </summary>
    public partial class AddForm : Form
    {
        //TODO: remove argument +

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AddForm"/> class.
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
            FillComboBox();
            comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            okButton.Click += new EventHandler(okButton_Click);
            cancelButton.Click += new EventHandler(cancel_Click);
        }

        /// <summary>
        /// Фигура.
        /// </summary>
        private GeometricFigureBase GeometricFigure { get; set; }

        /// <summary>
        /// Событие на добавление фигуры.
        /// </summary>
        public EventHandler FigureAdded { get; set; }

        /// <summary>
        /// Событие на удаление фигуры.
        /// </summary>
        public EventHandler FigureDeleted { get; set; }

        /// <summary>
        /// Заполняет ComboBox данными.
        /// </summary>
        private void FillComboBox()
        {
            List<string> myList = new() 
                { "Circle", "Rectangle", "Triangle" };
            comboBox.DataSource = myList;
            comboBox.SelectedItem = myList[0];
            SetFigureParametersBox();
        }

        /// <summary>
        /// Отображение ввода данных.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFigureParametersBox();
        }

        /// <summary>
        /// Определяет вид FigureParametersBox.
        /// </summary>
        private void SetFigureParametersBox()
        {
            Controls.Remove(figureParametersBox);

            Dictionary<int, FigureParametersBox> figureParametersBoxes =
                new()
            {
                {
                    0,
                    new CircleParametersBox()
                    {
                        Location = figureParametersBox.Location,
                    }
                },
                {
                    1,
                    new RectangleParametersBox()
                    {
                        Location = figureParametersBox.Location,
                    }
                },
                {
                    2,
                    new TriangleParametersBox()
                    {
                        Location = figureParametersBox.Location,
                    }
                },
            };

            figureParametersBox = figureParametersBoxes[comboBox.SelectedIndex];

            Controls.Add(figureParametersBox);
        }

        /// <summary>
        /// Добавление фигуры.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void okButton_Click(object sender, EventArgs e)
        {
            Dictionary<Type, Action<string>> catchDictionary =
                new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        _ = MessageBox.Show($"Возникло исключение {message}");
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        _ = MessageBox.Show($"Возникло исключение {message}");
                    }
                },
            };

            Dictionary<Type, Func<GeometricFigureBase>> geometricFigures
                = new()
            {
                {
                    typeof(CircleParametersBox),
                    () =>
                    {
                        return new Circle
                            {
                                Radius = Convert.ToDouble(
                                    ((CircleParametersBox)figureParametersBox)
                                    .RadiusTextBox.Text),
                            };
                    }
                },
                {
                    typeof(RectangleParametersBox),
                    () =>
                    {
                        return new GeometricFigures.Rectangle
                        {
                            Length = Convert.ToDouble(
                                ((RectangleParametersBox)figureParametersBox).
                                LengthTextBox.Text),
                            Width = Convert.ToDouble(
                                ((RectangleParametersBox)figureParametersBox)
                                .WidthSideTextBox.Text),
                        };
                    }

                },
                {
                    typeof(TriangleParametersBox),
                    () =>
                    {
                        return new Triangle
                        {
                            Angle = new Angle( Convert.ToDouble(
                                ((TriangleParametersBox)figureParametersBox)
                                .AngleTextBox.Text)),
                            FirstSide = Convert.ToDouble(
                                ((TriangleParametersBox)figureParametersBox)
                                .FirstSideTextBox.Text),
                            SecondSide = Convert.ToDouble(
                                ((TriangleParametersBox)figureParametersBox)
                                .SecondSideTextBox.Text),
                        };
                    }

                },

            };
            Dictionary<Type, Func<bool>> invalidInputs = new()
            {
                {
                    typeof(CircleParametersBox),
                    () =>
                    {
                        return string.IsNullOrWhiteSpace(
                            ((CircleParametersBox)figureParametersBox)
                            .RadiusTextBox.Text);
                    }
                },
                {
                    typeof(RectangleParametersBox),
                    () =>
                    {
                        return string.IsNullOrWhiteSpace(
                                ((RectangleParametersBox)figureParametersBox)
                                .LengthTextBox.Text)
                            || string.IsNullOrWhiteSpace(
                                ((RectangleParametersBox)figureParametersBox)
                            .WidthSideTextBox.Text);
                    }
                },
                {
                    typeof(TriangleParametersBox),
                    () =>
                    {
                        return string.IsNullOrWhiteSpace(
                            ((TriangleParametersBox)figureParametersBox)
                            .AngleTextBox.Text)
                        || string.IsNullOrWhiteSpace(
                            ((TriangleParametersBox)figureParametersBox)
                            .FirstSideTextBox.Text)
                        || string.IsNullOrWhiteSpace(
                            ((TriangleParametersBox)figureParametersBox)
                            .SecondSideTextBox.Text);
                    }
                },
            };

            if (!invalidInputs[figureParametersBox.GetType()].Invoke())
            {
                try
                {
                    GeometricFigure = geometricFigures[figureParametersBox.GetType()].Invoke();
                }
                catch (Exception ex)
                {
                    catchDictionary[ex.GetType()].Invoke(ex.Message);
                }
            }
            else
            {
                _ = MessageBox.Show("Пожалуйста, заполните все поля");
            }

            if (GeometricFigure is not null)
            {
                FigureAdded?.Invoke(this, new FigureAddedEventArgs(GeometricFigure));
            }
        }

        /// <summary>
        /// Отмена добаления фигуры.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void cancel_Click(object sender, EventArgs e)
        {
            if (GeometricFigure is not null)
            {
                FigureDeleted?.Invoke(this, new FigureDeletedEventArgs(GeometricFigure));
            }
        }

    }
}

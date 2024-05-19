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
            _comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            _okButton.Click += new EventHandler(okButton_Click);
            _cancelButton.Click += new EventHandler(cancel_Click);
#if DEBUG
            _randomButton.Click += new EventHandler(randomButton_Click);
#endif
        }

        /// <summary>
        /// Фигура.
        /// </summary>
        private GeometricFigureBase GeometricFigure { get; set; }

        /// <summary>
        /// Событие на добавление фигуры.
        /// </summary>
        public EventHandler figureAdded;

        /// <summary>
        /// Событие на удаление фигуры.
        /// </summary>
        public EventHandler figureDeleted;

        /// <summary>
        /// Заполняет ComboBox данными.
        /// </summary>
        private void FillComboBox()
        {
            TypeFigures[] colorsArray = 
                (TypeFigures[])Enum.GetValues(typeof(TypeFigures));

            _comboBox.DataSource = colorsArray;
            _comboBox.SelectedItem = colorsArray.GetValue(0);
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
            Controls.Remove(_figureParametersBox);

            Dictionary<TypeFigures, FigureParametersBox> figureParametersBoxes =
                new()
            {
                {
                    TypeFigures.Circle,
                    new CircleParametersBox()
                    {
                        Location = _figureParametersBox.Location,
                    }
                },
                {
                    TypeFigures.Rectangle,
                    new RectangleParametersBox()
                    {
                        Location = _figureParametersBox.Location,
                    }
                },
                {
                    TypeFigures.Triangle,
                    new TriangleParametersBox()
                    {
                        Location = _figureParametersBox.Location,
                    }
                },
            };

            _figureParametersBox = 
                figureParametersBoxes[(TypeFigures)_comboBox.SelectedItem];

            Controls.Add(_figureParametersBox);
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
                                    ((CircleParametersBox)_figureParametersBox)
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
                                ((RectangleParametersBox)_figureParametersBox).
                                LengthTextBox.Text),
                            Width = Convert.ToDouble(
                                ((RectangleParametersBox)_figureParametersBox)
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
                                ((TriangleParametersBox)_figureParametersBox)
                                .AngleTextBox.Text)),
                            FirstSide = Convert.ToDouble(
                                ((TriangleParametersBox)_figureParametersBox)
                                .FirstSideTextBox.Text),
                            SecondSide = Convert.ToDouble(
                                ((TriangleParametersBox)_figureParametersBox)
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
                            ((CircleParametersBox)_figureParametersBox)
                            .RadiusTextBox.Text);
                    }
                },
                {
                    typeof(RectangleParametersBox),
                    () =>
                    {
                        return string.IsNullOrWhiteSpace(
                                ((RectangleParametersBox)_figureParametersBox)
                                .LengthTextBox.Text)
                            || string.IsNullOrWhiteSpace(
                                ((RectangleParametersBox)_figureParametersBox)
                            .WidthSideTextBox.Text);
                    }
                },
                {
                    typeof(TriangleParametersBox),
                    () =>
                    {
                        return string.IsNullOrWhiteSpace(
                            ((TriangleParametersBox)_figureParametersBox)
                            .AngleTextBox.Text)
                        || string.IsNullOrWhiteSpace(
                            ((TriangleParametersBox)_figureParametersBox)
                            .FirstSideTextBox.Text)
                        || string.IsNullOrWhiteSpace(
                            ((TriangleParametersBox)_figureParametersBox)
                            .SecondSideTextBox.Text);
                    }
                },
            };

            if (!invalidInputs[_figureParametersBox.GetType()].Invoke())
            {
                try
                {
                    GeometricFigure = geometricFigures[_figureParametersBox.GetType()].Invoke();
                }
                catch (Exception ex)
                {
                    catchDictionary[ex.GetType()].Invoke(ex.Message);
                }
            }
            else
            {
                _ = MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }

            if (GeometricFigure is not null)
            {
                figureAdded?.Invoke(this, new FigureAddedEventArgs(GeometricFigure));
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
                figureDeleted?.Invoke(this, new FigureAddedEventArgs(GeometricFigure));
            }
        }

#if DEBUG
        /// <summary>
        /// Заполнение полей рандомными данными
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void randomButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int minValue = 1;
            int maxValue = 179;

            Dictionary<Type, Action> geometricFigures
                = new()
            {
                {
                    typeof(CircleParametersBox),
                    () =>
                    {
                        ((CircleParametersBox)_figureParametersBox)
                            .RadiusTextBox.Text = 
                                $"{random.Next(minValue,maxValue)}";
                    }
                },
                {
                    typeof(RectangleParametersBox),
                    () =>
                    {
                        ((RectangleParametersBox)_figureParametersBox)
                            .LengthTextBox.Text =
                                $"{random.Next(minValue,maxValue)}";
                        ((RectangleParametersBox)_figureParametersBox)
                            .WidthSideTextBox.Text =
                                $"{random.Next(minValue,maxValue)}";
                    }

                },
                {
                    typeof(TriangleParametersBox),
                    () =>
                    {
                        ((TriangleParametersBox)_figureParametersBox)
                            .AngleTextBox.Text  =
                                $"{random.Next(minValue,maxValue)}";
                        ((TriangleParametersBox)_figureParametersBox)
                            .FirstSideTextBox.Text =
                                $"{random.Next(minValue,maxValue)}";
                        ((TriangleParametersBox)_figureParametersBox)
                            .SecondSideTextBox.Text =
                                $"{random.Next(minValue,maxValue)}";
                    }

                },
            };
           
            geometricFigures[_figureParametersBox.GetType()].Invoke();
        }
#endif

    }
}

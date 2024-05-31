using GeometricFigures;

namespace View
{
    /// <summary>
    /// Форма для добавление фигуры. 
    /// </summary>
    public partial class AddForm : Form
    {

        /// <summary>
        /// Словарь, который сопоставляет строковые названия фигур их
        /// соответствующим значениям перечисления <see cref="TypeFigures"/>.
        /// </summary>
        private readonly Dictionary<string, TypeFigures> _figuresTypes = new()
        {
            {"Круг", TypeFigures.Circle},
            {"Прямоугольник", TypeFigures.Rectangle},
            {"Треугольник", TypeFigures.Triangle},
        };

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AddForm"/> class.
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
            FillComboBox();
            _comboBox.SelectedIndexChanged += ChangeDisplayParametersBox;
            _okButton.Click += AddFigure;
            _cancelButton.Click += CancelAddingFigure;
#if DEBUG
            _randomButton.Click += SetRandomParameters;
#endif
        }

        /// <summary>
        /// Фигура.
        /// </summary>
        private GeometricFigureBase GeometricFigure;

        /// <summary>
        /// Событие на добавление фигуры.
        /// </summary>
        public EventHandler FigureAdded;

        /// <summary>
        /// Событие на удаление фигуры.
        /// </summary>
        public EventHandler FigureDeleted;

        /// <summary>
        /// Заполняет ComboBox данными.
        /// </summary>
        private void FillComboBox()
        {
            List<string> keysList = _figuresTypes.Keys.ToList();
            _comboBox.DataSource = keysList;
            _comboBox.SelectedItem = keysList[0];
            ChangeDisplayParametersBox();
        }

        /// <summary>
        /// Отображение ввода данных.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void ChangeDisplayParametersBox(object sender, EventArgs e)
        {
            ChangeDisplayParametersBox();
        }

        /// <summary>
        /// Определяет вид FigureParametersBox.
        /// </summary>
        private void ChangeDisplayParametersBox()
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
                figureParametersBoxes[_figuresTypes[(string)_comboBox.SelectedItem]];

            Controls.Add(_figureParametersBox);
        }

        /// <summary>
        /// Добавление фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void AddFigure(object sender, EventArgs e)
        {
            Dictionary<Type, Action<string>> catchDictionary =
                new Dictionary<Type, Action<string>>()
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (string message) =>
                    {
                        _ = MessageBox.Show($"Возникло исключение {message}",
                            "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                },
                {
                    typeof(FormatException),
                    (string message) =>
                    {
                        _ = MessageBox.Show($"Возникло исключение {message}",
                            "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
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
                        var figureParametersBox =
                            GetFigureParameterBox<CircleParametersBox>
                                (_figureParametersBox);
                        return new Circle
                            {
                                Radius = Convert.ToDouble(figureParametersBox
                                    .RadiusTextBox.Text),
                            };
                    }
                },
                {
                    typeof(RectangleParametersBox),
                    () =>
                    {
                        var figureParametersBox =
                            GetFigureParameterBox<RectangleParametersBox>
                                (_figureParametersBox);
                        return new GeometricFigures.Rectangle
                        {
                            Length = Convert.ToDouble(figureParametersBox
                                .LengthTextBox.Text),
                            Width = Convert.ToDouble(figureParametersBox
                                .WidthSideTextBox.Text),
                        };
                    }

                },
                {
                    typeof(TriangleParametersBox),
                    () =>
                    {
                        var figureParametersBox =
                            GetFigureParameterBox<TriangleParametersBox>
                                (_figureParametersBox);
                        return new Triangle
                        (
                            firstSide: Convert.ToDouble(figureParametersBox
                                .FirstSideTextBox.Text),
                            secondSide: Convert.ToDouble(figureParametersBox
                                .SecondSideTextBox.Text),
                            angle: Convert.ToDouble(
                                figureParametersBox.AngleTextBox.Text)
                        );
                    }

                },

            };
            Dictionary<Type, Func<bool>> invalidInputs = new()
            {
                {
                    typeof(CircleParametersBox),
                    () =>
                    {

                        var figureParametersBox =
                            GetFigureParameterBox<CircleParametersBox>
                                (_figureParametersBox);
                        return string.IsNullOrWhiteSpace(figureParametersBox
                            .RadiusTextBox.Text);
                    }
                },
                {
                    typeof(RectangleParametersBox),
                    () =>
                    {
                         var figureParametersBox =
                            GetFigureParameterBox<RectangleParametersBox>
                                (_figureParametersBox);
                        return string.IsNullOrWhiteSpace(figureParametersBox
                                .LengthTextBox.Text)
                            || string.IsNullOrWhiteSpace(figureParametersBox
                                .WidthSideTextBox.Text);
                    }
                },
                {
                    typeof(TriangleParametersBox),
                    () =>
                    {
                        var figureParametersBox =
                            GetFigureParameterBox<TriangleParametersBox>
                                (_figureParametersBox);
                        return string.IsNullOrWhiteSpace(figureParametersBox
                            .AngleTextBox.Text)
                        || string.IsNullOrWhiteSpace(figureParametersBox
                            .FirstSideTextBox.Text)
                        || string.IsNullOrWhiteSpace(figureParametersBox
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
                    return;
                }
            }

            else
            {
                _ = MessageBox.Show("Пожалуйста, заполните все поля",
                        "Сообщение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return;
            }

            if (GeometricFigure is not null)
            {
                FigureAdded?
                    .Invoke(this, new FigureAddedEventArgs(GeometricFigure));
            }
        }

        /// <summary>
        /// Отмена добаления фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void CancelAddingFigure(object sender, EventArgs e)
        {
            if (GeometricFigure is not null)
            {
                FigureDeleted?
                    .Invoke(this, new FigureAddedEventArgs(GeometricFigure));
            }
        }

        /// <summary>
        /// Приводит FigureParametersBox к соответствующему типу.
        /// </summary>
        /// <typeparam name="T">Тип FigureParametersBox.</typeparam>
        /// <param name="figureParametersBox">Область для
        /// ввода параметров фигуры.</param>
        /// <returns>Приведенная область для 
        /// ввода параметров фигуры.</returns>
        private T GetFigureParameterBox<T>(
            FigureParametersBox figureParametersBox)
            where T : FigureParametersBox
        {
            return (T)figureParametersBox;
        }

#if DEBUG
        /// <summary>
        /// Заполнение полей рандомными данными.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void SetRandomParameters(object sender, EventArgs e)
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
                        var figureParametersBox =
                            GetFigureParameterBox<CircleParametersBox>
                                (_figureParametersBox);
                        figureParametersBox.RadiusTextBox.Text =
                                $"{random.Next(minValue,maxValue)}";
                    }
                },
                {
                    typeof(RectangleParametersBox),
                    () =>
                    {
                        var figureParametersBox =
                            GetFigureParameterBox<RectangleParametersBox>
                                (_figureParametersBox);
                        figureParametersBox.LengthTextBox.Text =
                                $"{random.Next(minValue,maxValue)}";
                        figureParametersBox.WidthSideTextBox.Text =
                                $"{random.Next(minValue,maxValue)}";
                    }

                },
                {
                    typeof(TriangleParametersBox),
                    () =>
                    {
                        var figureParametersBox =
                            GetFigureParameterBox<TriangleParametersBox>
                                (_figureParametersBox);
                        figureParametersBox.AngleTextBox.Text  =
                                $"{random.Next(minValue,maxValue)}";
                        figureParametersBox.FirstSideTextBox.Text =
                                $"{random.Next(minValue,maxValue)}";
                        figureParametersBox.SecondSideTextBox.Text =
                                $"{random.Next(minValue,maxValue)}";
                    }

                },
            };

            geometricFigures[_figureParametersBox.GetType()].Invoke();
        }
#endif

    }
}

namespace View
{
    partial class FilterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private CheckBox checkBoxTypeCircle;
        private CheckBox checkBoxTypeRectangle;
        private CheckBox checkBoxTypeTriangle;
        private CheckBox checkBoxArea;
        private CheckBox checkBoxPerimeter;

        private NumericBox areaNumericBox;
        private NumericBox perimeterNumericBox;

        private Button filterButton;

        private GroupBox filterGroupBox;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            int startPointX = 20;
            int startPointY = 20;
            int incrementX = 120;
            int incrementY = 30;
            Size sizeCheckBox = new System.Drawing.Size(80, 25);
            Size sizeNumericBox = new System.Drawing.Size(140, 25);
            // 
            // checkBoxTypeCircle 
            // 
            checkBoxTypeCircle = new CheckBox()
            {
                AutoSize = true,
                Location = CreatePoint(1),
                Size = sizeCheckBox,
                Name = "checkTypeCircle",
                TabIndex = 1,
                Text = "Окружность",
                UseVisualStyleBackColor = true,
            };
            // 
            // checkBoxTypeRectangle
            // 
            checkBoxTypeRectangle = new CheckBox()
            {
                AutoSize = true,
                Location = CreatePoint(2),
                Size = sizeCheckBox,
                Name = "checkTypeRectangle",
                TabIndex = 1,
                Text = "Прямоугольник",
                UseVisualStyleBackColor = true,
            };
            // 
            // checkBoxTypeTriangle 
            // 
            checkBoxTypeTriangle = new CheckBox()
            {
                AutoSize = true,
                Location = CreatePoint(3),
                Size = sizeCheckBox,
                Name = "checkTypeTriangle",
                TabIndex = 1,
                Text = "Треугольник",
                UseVisualStyleBackColor = true,
            };
            // 
            // checkBoxArea
            // 
            checkBoxArea = new CheckBox()
            {
                AutoSize = true,
                Location = CreatePoint(4),
                Size = sizeCheckBox,
                Name = "checkArea",

                TabIndex = 1,
                Text = "Площадь",
                UseVisualStyleBackColor = true,
            };
            // 
            // checkBoxPerimeter
            // 
            checkBoxPerimeter = new CheckBox()
            {
                AutoSize = true,
                Location = CreatePoint(5),
                Size = sizeCheckBox,
                Name = "checkPerimeter",
                TabIndex = 1,
                Text = "Периметр",
                UseVisualStyleBackColor = true,
            };
            // 
            // areaNumericBox
            // 
            areaNumericBox = new NumericBox()
            {
                Location = CreatePoint(1, incrementX, 0, 
                startPointX, startPointY + incrementY * 4),
                Size = sizeNumericBox,
                Name = "areaNumericBox",
                TabIndex = 2,
            };
            // 
            // perimeterNumericBox
            // 
            perimeterNumericBox = new NumericBox()
            {
                Location = CreatePoint(1, incrementX, 0,
                startPointX, startPointY + incrementY * 5),
                Size = sizeNumericBox,
                Name = "perimeterNumericBox",
                TabIndex = 2,
            };
            // 
            // filterButton
            // 
            filterButton = new Button()
            {
                Location = new System.Drawing.Point(20, 230),
                Name = "filterButton",
                Size = new System.Drawing.Size(200, 30),
                TabIndex = 1,
                Text = "Фильтровать",
                UseVisualStyleBackColor = true,
            };
            // 
            // filterGroupBox
            // 
            filterGroupBox = new GroupBox() 
            {
                Text = "Фильтры",
                Location = new Point(20, 20),
                Size = new Size(300, 200),
                Name = "filterGroupBox",
            };
            filterGroupBox.Controls.Add(checkBoxTypeCircle);
            filterGroupBox.Controls.Add(checkBoxTypeRectangle);
            filterGroupBox.Controls.Add(checkBoxTypeTriangle);
            filterGroupBox.Controls.Add(checkBoxArea);
            filterGroupBox.Controls.Add(checkBoxPerimeter);

            filterGroupBox.Controls.Add(areaNumericBox);
            filterGroupBox.Controls.Add(perimeterNumericBox);
            // 
            // FilterForm
            // 
            int widhtForm = 340;//400;
            int heightForm = 260;//200;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = new System.Drawing.Size(widhtForm, heightForm);
            Text = "FilterForm";
            Name = "FilterForm";
            Controls.Add(filterGroupBox);
            Controls.Add(filterButton);
        }

        /// <summary>
        /// Создание точки.
        /// </summary>
        /// <param name="number">.</param>
        /// <param name="startPointX">.</param>
        /// <param name="startPointY">.</param>
        /// <param name="incrementX">.</param>
        /// <param name="incrementY">.</param>
        /// <returns></returns>
        private Point CreatePoint(int number, int incrementX = 0,
            int incrementY = 30, int startPointX = 20,
            int startPointY = 20) => new Point(
                number * incrementX + startPointX,
                number * incrementY + startPointY);

        #endregion
    }
}
namespace View
{
    partial class FilterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private CheckBox _checkBoxTypeCircle;
        private CheckBox _checkBoxTypeRectangle;
        private CheckBox _checkBoxTypeTriangle;
        private CheckBox _checkBoxArea;
        private CheckBox _checkBoxPerimeter;

        private NumericBox _areaNumericBox;
        private NumericBox _perimeterNumericBox;

        private Button _filterButton;

        private GroupBox _filterGroupBox;

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
            _checkBoxTypeCircle = new CheckBox();
            _checkBoxTypeRectangle = new CheckBox();
            _checkBoxTypeTriangle = new CheckBox();
            _checkBoxArea = new CheckBox();
            _checkBoxPerimeter = new CheckBox();
            _perimeterNumericBox = new NumericBox();
            _areaNumericBox = new NumericBox();
            _filterButton = new Button();
            _filterGroupBox = new GroupBox();
            _filterGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // _checkBoxTypeCircle
            // 
            _checkBoxTypeCircle.AutoSize = true;
            _checkBoxTypeCircle.Location = new Point(20, 20);
            _checkBoxTypeCircle.Name = "_checkBoxTypeCircle";
            _checkBoxTypeCircle.Size = new Size(94, 19);
            _checkBoxTypeCircle.TabIndex = 1;
            _checkBoxTypeCircle.Text = "Окружность";
            _checkBoxTypeCircle.UseVisualStyleBackColor = true;
            // 
            // _checkBoxTypeRectangle
            // 
            _checkBoxTypeRectangle.AutoSize = true;
            _checkBoxTypeRectangle.Location = new Point(20, 50);
            _checkBoxTypeRectangle.Name = "_checkBoxTypeRectangle";
            _checkBoxTypeRectangle.Size = new Size(115, 19);
            _checkBoxTypeRectangle.TabIndex = 1;
            _checkBoxTypeRectangle.Text = "Прямоугольник";
            _checkBoxTypeRectangle.UseVisualStyleBackColor = true;
            // 
            // _checkBoxTypeTriangle
            // 
            _checkBoxTypeTriangle.AutoSize = true;
            _checkBoxTypeTriangle.Location = new Point(20, 80);
            _checkBoxTypeTriangle.Name = "_checkBoxTypeTriangle";
            _checkBoxTypeTriangle.Size = new Size(96, 19);
            _checkBoxTypeTriangle.TabIndex = 1;
            _checkBoxTypeTriangle.Text = "Треугольник";
            _checkBoxTypeTriangle.UseVisualStyleBackColor = true;
            // 
            // _checkBoxArea
            // 
            _checkBoxArea.AutoSize = true;
            _checkBoxArea.Location = new Point(20, 110);
            _checkBoxArea.Name = "_checkBoxArea";
            _checkBoxArea.Size = new Size(78, 19);
            _checkBoxArea.TabIndex = 1;
            _checkBoxArea.Text = "Площадь";
            _checkBoxArea.UseVisualStyleBackColor = true;
            // 
            // _checkBoxPerimeter
            // 
            _checkBoxPerimeter.Location = new Point(20, 140);
            _checkBoxPerimeter.Name = "_checkBoxPerimeter";
            _checkBoxPerimeter.Size = new Size(90, 25);
            _checkBoxPerimeter.TabIndex = 1;
            _checkBoxPerimeter.Text = "Периметр";
            _checkBoxPerimeter.UseVisualStyleBackColor = true;
            // 
            // _perimeterNumericBox
            // 
            _perimeterNumericBox.Location = new Point(143, 141);
            _perimeterNumericBox.Name = "_perimeterNumericBox";
            _perimeterNumericBox.Size = new Size(140, 23);
            _perimeterNumericBox.TabIndex = 2;
            // 
            // _areaNumericBox
            // 
            _areaNumericBox.Location = new Point(143, 108);
            _areaNumericBox.Name = "_areaNumericBox";
            _areaNumericBox.Size = new Size(140, 23);
            _areaNumericBox.TabIndex = 2;
            // 
            // _filterButton
            // 
            _filterButton.Location = new Point(111, 198);
            _filterButton.Name = "_filterButton";
            _filterButton.Size = new Size(200, 30);
            _filterButton.TabIndex = 1;
            _filterButton.Text = "Фильтровать";
            _filterButton.UseVisualStyleBackColor = true;
            // 
            // _filterGroupBox
            // 
            _filterGroupBox.Controls.Add(_checkBoxTypeCircle);
            _filterGroupBox.Controls.Add(_checkBoxTypeRectangle);
            _filterGroupBox.Controls.Add(_checkBoxTypeTriangle);
            _filterGroupBox.Controls.Add(_checkBoxArea);
            _filterGroupBox.Controls.Add(_checkBoxPerimeter);
            _filterGroupBox.Controls.Add(_areaNumericBox);
            _filterGroupBox.Controls.Add(_perimeterNumericBox);
            _filterGroupBox.Location = new Point(12, 12);
            _filterGroupBox.Name = "_filterGroupBox";
            _filterGroupBox.Size = new Size(299, 180);
            _filterGroupBox.TabIndex = 0;
            _filterGroupBox.TabStop = false;
            _filterGroupBox.Text = "Фильтры";
            // 
            // FilterForm
            // 
            ClientSize = new Size(323, 235);
            Controls.Add(_filterGroupBox);
            Controls.Add(_filterButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FilterForm";
            Text = "Фильтр";
            _filterGroupBox.ResumeLayout(false);
            _filterGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
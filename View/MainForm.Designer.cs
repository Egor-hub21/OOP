using GeometricFigures;
using System.ComponentModel;
using System.Windows.Forms;

namespace View
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button _addButton;
        private Button _removeButton;
        private Button _filterButton;
        private Button _resettingFilterButton;
        private Button _serializationButton;
        private Button _deserializationButton;
        private DataGridView _figureDataGrid;
        private GroupBox _figuresGroupBox;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            _addButton = new Button();
            _removeButton = new Button();
            _filterButton = new Button();
            _resettingFilterButton = new Button();
            _serializationButton = new Button();
            _deserializationButton = new Button();
            _figureDataGrid = new DataGridView();
            _figuresGroupBox = new GroupBox();
            ((ISupportInitialize)_figureDataGrid).BeginInit();
            _figuresGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // _addButton
            // 
            _addButton.Location = new Point(722, 152);
            _addButton.Name = "_addButton";
            _addButton.Size = new Size(75, 23);
            _addButton.TabIndex = 1;
            _addButton.Text = "Добавить";
            // 
            // _removeButton
            // 
            _removeButton.Location = new Point(722, 181);
            _removeButton.Name = "_removeButton";
            _removeButton.Size = new Size(75, 23);
            _removeButton.TabIndex = 2;
            _removeButton.Text = "Удалить";
            // 
            // _filterButton
            // 
            _filterButton.Location = new Point(722, 268);
            _filterButton.Name = "_filterButton";
            _filterButton.Size = new Size(75, 23);
            _filterButton.TabIndex = 3;
            _filterButton.Text = "Фильтр";
            // 
            // _resettingFilterButton
            // 
            _resettingFilterButton.Location = new Point(722, 297);
            _resettingFilterButton.Name = "_resettingFilterButton";
            _resettingFilterButton.Size = new Size(75, 23);
            _resettingFilterButton.TabIndex = 4;
            _resettingFilterButton.Text = "Сброс";
            // 
            // _serializationButton
            // 
            _serializationButton.Location = new Point(722, 73);
            _serializationButton.Name = "_serializationButton";
            _serializationButton.Size = new Size(75, 23);
            _serializationButton.TabIndex = 5;
            _serializationButton.Text = "Сохранить";
            // 
            // _deserializationButton
            // 
            _deserializationButton.Location = new Point(722, 44);
            _deserializationButton.Name = "_deserializationButton";
            _deserializationButton.Size = new Size(75, 23);
            _deserializationButton.TabIndex = 6;
            _deserializationButton.Text = "Открыть";
            // 
            // _figureDataGrid
            // 
            _figureDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _figureDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            _figureDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            _figureDataGrid.Dock = DockStyle.Fill;
            _figureDataGrid.Location = new Point(3, 19);
            _figureDataGrid.Name = "_figureDataGrid";
            _figureDataGrid.ReadOnly = true;
            _figureDataGrid.Size = new Size(679, 273);
            _figureDataGrid.TabIndex = 0;
            // 
            // _figuresGroupBox
            // 
            _figuresGroupBox.Controls.Add(_figureDataGrid);
            _figuresGroupBox.Location = new Point(12, 25);
            _figuresGroupBox.Name = "_figuresGroupBox";
            _figuresGroupBox.Size = new Size(685, 295);
            _figuresGroupBox.TabIndex = 0;
            _figuresGroupBox.TabStop = false;
            _figuresGroupBox.Text = "Список фигур";
            // 
            // MainForm
            // 
            ClientSize = new Size(824, 347);
            Controls.Add(_figuresGroupBox);
            Controls.Add(_addButton);
            Controls.Add(_removeButton);
            Controls.Add(_filterButton);
            Controls.Add(_resettingFilterButton);
            Controls.Add(_serializationButton);
            Controls.Add(_deserializationButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Фигуры на плоскости";
            ((ISupportInitialize)_figureDataGrid).EndInit();
            _figuresGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        /// <summary>
        /// Присваивает Кнопке дефолтные параметры.
        /// </summary>
        /// <param name="button">Кнопка.</param>
        private void SetButtonDefaults(Button button)
        {
            button.Font = new Font("Arial", 10);
            button.Size = new Size(80, 30);
            button.ForeColor = Color.Black;
            button.BackColor = Color.LightGray;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.DarkGray;
        }

        #endregion
    }
}

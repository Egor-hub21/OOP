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

        private GroupBox figuresGroupBox;
        private Button addButton;
        private Button removeButton;
        private DataGridView figureDataGrid;

        public BindingList<GeometricFigureBase> GeometricFigures { get; set; }

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
            // 
            // addButton
            // 
            addButton = new MyButton()
            {
                Text = "Add",
                Location = new Point(670, 60),
                Name = "addButton",
            };
            // 
            // removeButton
            // 
            removeButton = new MyButton()
            {
                Text = "Remove",
                Location = new Point(670, 120),
                Name = "removeButton",
            };
            //
            // figureDataGrid
            //
            figureDataGrid = new DataGridView()
            {
                Location = new Point(0, 20),
                Dock = DockStyle.Fill,
                Name = "figureDataGrid",
                //AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
            };
            figureDataGrid.Columns.Add("Type", "Тип");
            figureDataGrid.Columns.Add("Parameters", "Параметры");
            figureDataGrid.Columns.Add("Square", "Площадь");
            figureDataGrid.Columns[0].Width = 100;
            figureDataGrid.Columns[1].Width = 350;
            figureDataGrid.Columns[2].Width = 100;

            // 
            // figuresGroupBox
            // 
            figuresGroupBox = new GroupBox()
            {
                Text = "Список фигур",
                Location = new Point(50, 50),
                Size = new Size(600, 300),
                Name = "ListOfFigures",
            };
            figuresGroupBox.Controls.Add(figureDataGrid);
            // 
            // MainForm
            // 
            int widhtForm = 800;
            int heightForm = 400;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ClientSize = new Size(widhtForm, heightForm);
            this.Text = "MainForm";
            this.Name = "MainForm";
            ResumeLayout(false);
            this.Controls.Add(figuresGroupBox);
            this.Controls.Add(addButton);
            this.Controls.Add(removeButton);
        }

#endregion
    }
}

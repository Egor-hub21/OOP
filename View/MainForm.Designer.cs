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

        private Button addButton;
        private Button removeButton;
        private Button filterButton;
        private Button resettingFilterButton;
        private DataGridView figureDataGrid;
        private GroupBox figuresGroupBox;

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
            // filterButton
            // 
            filterButton = new MyButton()
            {
                Text = "Filter",
                Location = new Point(670, 180),
                Name = "filterButton",
            };
            // 
            // resettingFilterButton
            // 
            resettingFilterButton = new MyButton()
            {
                Text = "Resetting",
                Location = new Point(670, 240),
                Name = "resettingFilterButton",
            };
            //
            // figureDataGrid
            //
            figureDataGrid = new DataGridView()
            {
                Location = new Point(0, 20),
                Dock = DockStyle.Fill,
                Name = "figureDataGrid",
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
            };
            figureDataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
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
            ClientSize = new Size(widhtForm, heightForm);
            Text = "MainForm";
            Name = "MainForm";
            ResumeLayout(false);
            Controls.Add(figuresGroupBox);
            Controls.Add(addButton);
            Controls.Add(removeButton);
            Controls.Add(filterButton);
            Controls.Add(resettingFilterButton);
        }

#endregion
    }
}

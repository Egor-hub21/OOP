using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            // Создаем новую GroupBox
            GroupBox myGroupBox = new GroupBox();

            // Устанавливаем свойства GroupBox
            myGroupBox.Text = "Моя GroupBox";
            myGroupBox.Location = new Point(50, 50);
            myGroupBox.Size = new Size(500, 500);

            DataGridView dataGridView = new DataGridView();

            dataGridView.Location = new Point(10, 20);
            dataGridView.Size = new Size(400, 200);

            myGroupBox.Controls.Add(dataGridView);

            // Добавьте столбцы и строки в DataGridView по вашему усмотрению
            dataGridView.Columns.Add("Column1", "Column Header 1");
            dataGridView.Columns.Add("Column2", "Column Header 2");
            dataGridView.Rows.Add("Row 1 Data 1", "Row 1 Data 2");
            dataGridView.Rows.Add("Row 2 Data 1", "Row 2 Data 2");

            Button addButton = new Button();

            addButton.Text = "Add";
            addButton.Location = new Point(100, 300);
            addButton.Size = new Size(100, 50);
            addButton.Name = "addButton";

            Button removeButton = new Button();

            removeButton.Text = "Remove";
            removeButton.Location = new Point(200, 300);
            removeButton.Size = new Size(100, 50);
            removeButton.Name = "removeButton";

            myGroupBox.Controls.Add(addButton);
            myGroupBox.Controls.Add(removeButton);

            Controls.Add(myGroupBox);
        }
    }
}

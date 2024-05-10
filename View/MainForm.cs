namespace View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Button addButton = new Button();

            addButton.Text = "Добавить";
            addButton.Location = new Point(100, 100);
            addButton.Size = new Size(100, 100);
            addButton.Name = "addButton";

            addButton.Click += new EventHandler(button1_Click);

            this.Controls.Add(addButton);
        }
    }
}

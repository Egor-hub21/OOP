namespace View
{
    public class MyButton : Button
    {
        public MyButton()
        {
            Font = new Font("Arial", 10);
            Size = new Size(80, 30);
            ForeColor = Color.Black;
            BackColor = Color.LightGray;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.DarkGray;
        }
    }
}

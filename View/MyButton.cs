namespace View
{
    /// <summary>
    /// .
    /// </summary>
    public class MyButton : Button
    {

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MyButton"/> class.
        /// </summary>
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

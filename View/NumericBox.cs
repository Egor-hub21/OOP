namespace View
{
    /// <summary>
    /// TextBox для вввода числовых данных.
    /// </summary>
    public class NumericBox : TextBox
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NumericBox"/> class.
        /// </summary>
        public NumericBox()
        {
            KeyPress += new KeyPressEventHandler(textBox_KeyPress);
        }

        //TODO: RSDN
        /// <summary>
        /// Корректировка ввода данных.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;

            if ((symbol == '.') && Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if ((symbol == ',') && Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(symbol) && symbol != (char)Keys.Back && symbol != ',' && symbol != '.')
            {
                e.Handled = true;
            }

            if (symbol == '.')
            {
                e.KeyChar = ',';
            }
        }
    }
}

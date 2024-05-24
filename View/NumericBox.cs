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
            KeyPress += new KeyPressEventHandler(ValidateNumericInput);
        }

        //TODO: RSDN +
        /// <summary>
        /// Корректировка ввода данных.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Объект <see cref="EventArgs"/>,
        /// содержащий данные события.</param>
        private void ValidateNumericInput(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;

            // Проверка, если символ является точкой или запятой
            // и в тексте уже есть запятая, блокируем ввод
            if ((symbol == '.' || symbol == ',')
                && Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            // Если символ не является цифрой, не является
            // клавишей Backspace, запятой или точкой, блокируем ввод
            if (!char.IsDigit(symbol) && symbol != (char)Keys.Back 
                && symbol != ',' && symbol != '.')
            {
                e.Handled = true;
            }

            // Если символ является точкой, заменяем его на запятую
            if (symbol == '.')
            {
                e.KeyChar = ',';
            }
        }
    }
}

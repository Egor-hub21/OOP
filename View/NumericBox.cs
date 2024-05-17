using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWinForms
{
    public class NumericBox : TextBox
    {
        public NumericBox()
        {
            KeyPress += textBox_KeyPress;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            //TODO: refactor
            if ((symbol == 46) && Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if ((symbol == 44) && Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(symbol) && symbol != 8 && symbol != 44 && symbol != 46)
            {
                e.Handled = true;
            }
            if (symbol == 46)
            {
                e.KeyChar = ',';
            }
        }
    }
}

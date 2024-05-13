using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeometricFigures;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace View
{
    public partial class AddForm : Form
    {
        public BindingList<GeometricFigureBase> GeometricFigures { get; set;}
        public GeometricFigureBase GeometricFigure { get; set; }

        public AddForm()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
        }
    }
}

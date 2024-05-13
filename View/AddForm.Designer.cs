namespace View
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MyButton okButton;
        private MyButton cancelButton;
        private ComboBox comboBox;

        private FigureParametersBox figureParametersBox;


        /// <summary>
        /// Clean up any resources being used.
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

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Controls.Remove(figureParametersBox);
            figureParametersBox.Dispose();
            CircleParametersBox groupBoxCircle = new()
            {
                Location = new Point(200, 50),
                Size = new Size(200, 200),
                Text = "CircleParameters",
            };

            RectangleParametersBox groupBoxRectangle = new()
            {
                Location = new Point(200, 50),
                Size = new Size(200, 200),
                Text = "RectangleParameters",
            };

            TriangleParametersBox groupBoxTriangle  = new()
            {
                Location = new Point(200, 50),
                Size = new Size(200, 200),
                Text = "TriangleParameters",
            };
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    figureParametersBox = groupBoxCircle;
                    break;
                case 1:
                    figureParametersBox = groupBoxRectangle;
                    break;
                case 2:
                    figureParametersBox = groupBoxTriangle;
                    break;
                default:
                    figureParametersBox.Visible = false;

                    break;
            }
            this.Controls.Add(figureParametersBox);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // okButton
            // 
            okButton = new MyButton()
            {
                Text = "Ok",
                Location = new Point(50, 170),
                Name = "okButton",
            };
            // 
            // cancelButton
            // 
            cancelButton = new MyButton()
            {
                Text = "Cancel",
                Location = new Point(50, 210),
                Name = "cancelButton",
            };
            // 
            // comboBox
            // 
            List<string> myList = new List<string> { "Circle", "Rectangle", "Triangle" };
            comboBox = new ComboBox()
            {
                Location = new Point(50, 50),
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = myList,
            };
            // 
            // groupBoxCircle
            // 
            figureParametersBox = new FigureParametersBox()
            {
                Location = new Point(200, 50),
                Size = new Size(200, 200),
                Text = "FigureParameters",
            };
            // 
            // AddForm
            // 
            int widhtForm = 450;//400;
            int heightForm = 300;//200;

            FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ClientSize = new System.Drawing.Size(widhtForm, heightForm);
            Name = "AddForm";
            Text = "AddForm";
            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);
            this.Controls.Add(comboBox);
            //this.Controls.Add(figureParametersBox);
        }

        #endregion
    }
}
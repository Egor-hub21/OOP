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
#if DEBUG
        private MyButton randomButton;
#endif


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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
#if DEBUG
            // 
            // randomButton
            // 
            randomButton = new MyButton()
            {
                Text = "Random",
                Location = new Point(50, 250),
                Name = "randomButton",
            };
#endif
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
            comboBox = new ComboBox()
            {
                Location = new Point(50, 50),
                DropDownStyle = ComboBoxStyle.DropDownList,
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
            ClientSize = new System.Drawing.Size(widhtForm, heightForm);
            Name = "AddForm";
            Text = "AddForm";
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Controls.Add(comboBox);
            Controls.Add(figureParametersBox);
#if DEBUG
            Controls.Add(randomButton);
#endif
        }

        #endregion
    }
}

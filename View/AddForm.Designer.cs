namespace View
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button _okButton;
        private Button _cancelButton;
        private ComboBox _comboBox;
        private FigureParametersBox _figureParametersBox;
#if DEBUG
        private Button _randomButton;
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
            _randomButton = new Button();
#endif
            _okButton = new Button();
            _cancelButton = new Button();
            _comboBox = new ComboBox();
            _figureParametersBox = new FigureParametersBox();
            SuspendLayout();
#if DEBUG
            // 
            // _randomButton
            // 
            _randomButton.Location = new Point(12, 71);
            _randomButton.Name = "_randomButton";
            _randomButton.Size = new Size(75, 23);
            _randomButton.TabIndex = 4;
            _randomButton.Text = "Заполнить";
#endif
            // 
            // _okButton
            // 
            _okButton.Location = new Point(12, 100);
            _okButton.Name = "_okButton";
            _okButton.Size = new Size(75, 23);
            _okButton.TabIndex = 0;
            _okButton.Text = "Добавить";
            // 
            // _cancelButton
            // 
            _cancelButton.Location = new Point(12, 129);
            _cancelButton.Name = "_cancelButton";
            _cancelButton.Size = new Size(75, 23);
            _cancelButton.TabIndex = 1;
            _cancelButton.Text = "Отменить";
            // 
            // _comboBox
            // 
            _comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBox.Location = new Point(12, 12);
            _comboBox.Name = "_comboBox";
            _comboBox.Size = new Size(121, 23);
            _comboBox.TabIndex = 2;
            // 
            // _figureParametersBox
            // 
            _figureParametersBox.Location = new Point(158, 12);
            _figureParametersBox.Name = "_figureParametersBox";
            _figureParametersBox.Size = new Size(200, 140);
            _figureParametersBox.TabIndex = 3;
            _figureParametersBox.TabStop = false;
            _figureParametersBox.Text = "Параметры фигуры";
            // 
            // AddForm
            // 
            ClientSize = new Size(370, 167);
            Controls.Add(_okButton);
            Controls.Add(_cancelButton);
            Controls.Add(_comboBox);
            Controls.Add(_figureParametersBox);
#if DEBUG
            Controls.Add(_randomButton);
#endif
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddForm";
            Text = "Добавить фигуру";
            ResumeLayout(false);
        }

        #endregion
    }
}

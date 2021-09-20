
namespace HeadphonesShop.PresentationWF.Forms.Admin.Headphones
{
    partial class AddHeadphonesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._minFTextBox = new System.Windows.Forms.TextBox();
            this._maxFTextBox = new System.Windows.Forms.TextBox();
            this._companyComboBox = new System.Windows.Forms.ComboBox();
            this._designComboBox = new System.Windows.Forms.ComboBox();
            this._nameLabel = new System.Windows.Forms.Label();
            this._minFreqLabel = new System.Windows.Forms.Label();
            this._maxFreqabel = new System.Windows.Forms.Label();
            this._companyLabel = new System.Windows.Forms.Label();
            this._designLabel = new System.Windows.Forms.Label();
            this._backButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(288, 101);
            this._nameTextBox.MaxLength = 127;
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(201, 23);
            this._nameTextBox.TabIndex = 0;
            // 
            // _minFTextBox
            // 
            this._minFTextBox.Location = new System.Drawing.Point(288, 130);
            this._minFTextBox.Name = "_minFTextBox";
            this._minFTextBox.Size = new System.Drawing.Size(201, 23);
            this._minFTextBox.TabIndex = 1;
            // 
            // _maxFTextBox
            // 
            this._maxFTextBox.Location = new System.Drawing.Point(288, 159);
            this._maxFTextBox.Name = "_maxFTextBox";
            this._maxFTextBox.Size = new System.Drawing.Size(201, 23);
            this._maxFTextBox.TabIndex = 2;
            // 
            // _companyComboBox
            // 
            this._companyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._companyComboBox.FormattingEnabled = true;
            this._companyComboBox.Location = new System.Drawing.Point(288, 188);
            this._companyComboBox.Name = "_companyComboBox";
            this._companyComboBox.Size = new System.Drawing.Size(201, 23);
            this._companyComboBox.TabIndex = 3;
            // 
            // _designComboBox
            // 
            this._designComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._designComboBox.FormattingEnabled = true;
            this._designComboBox.Location = new System.Drawing.Point(288, 217);
            this._designComboBox.Name = "_designComboBox";
            this._designComboBox.Size = new System.Drawing.Size(201, 23);
            this._designComboBox.TabIndex = 4;
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(243, 104);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(39, 15);
            this._nameLabel.TabIndex = 5;
            this._nameLabel.Text = "Name";
            // 
            // _minFreqLabel
            // 
            this._minFreqLabel.AutoSize = true;
            this._minFreqLabel.Location = new System.Drawing.Point(197, 133);
            this._minFreqLabel.Name = "_minFreqLabel";
            this._minFreqLabel.Size = new System.Drawing.Size(85, 15);
            this._minFreqLabel.TabIndex = 6;
            this._minFreqLabel.Text = "Min Frequensy";
            // 
            // _maxFreqabel
            // 
            this._maxFreqabel.AutoSize = true;
            this._maxFreqabel.Location = new System.Drawing.Point(195, 162);
            this._maxFreqabel.Name = "_maxFreqabel";
            this._maxFreqabel.Size = new System.Drawing.Size(87, 15);
            this._maxFreqabel.TabIndex = 7;
            this._maxFreqabel.Text = "Max Frequensy";
            // 
            // _companyLabel
            // 
            this._companyLabel.AutoSize = true;
            this._companyLabel.Location = new System.Drawing.Point(223, 191);
            this._companyLabel.Name = "_companyLabel";
            this._companyLabel.Size = new System.Drawing.Size(59, 15);
            this._companyLabel.TabIndex = 8;
            this._companyLabel.Text = "Company";
            // 
            // _designLabel
            // 
            this._designLabel.AutoSize = true;
            this._designLabel.Location = new System.Drawing.Point(239, 220);
            this._designLabel.Name = "_designLabel";
            this._designLabel.Size = new System.Drawing.Size(43, 15);
            this._designLabel.TabIndex = 9;
            this._designLabel.Text = "Design";
            // 
            // _backButton
            // 
            this._backButton.Location = new System.Drawing.Point(12, 415);
            this._backButton.Name = "_backButton";
            this._backButton.Size = new System.Drawing.Size(75, 23);
            this._backButton.TabIndex = 10;
            this._backButton.Text = "Back";
            this._backButton.UseVisualStyleBackColor = true;
            this._backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(713, 415);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 11;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // AddHeadphonesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._backButton);
            this.Controls.Add(this._designLabel);
            this.Controls.Add(this._companyLabel);
            this.Controls.Add(this._maxFreqabel);
            this.Controls.Add(this._minFreqLabel);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._designComboBox);
            this.Controls.Add(this._companyComboBox);
            this.Controls.Add(this._maxFTextBox);
            this.Controls.Add(this._minFTextBox);
            this.Controls.Add(this._nameTextBox);
            this.Name = "AddHeadphonesForm";
            this.Text = "AddHeadphonesForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddHeadphonesFormClosed);
            this.Load += new System.EventHandler(this.AddHeadphonesFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.TextBox _minFTextBox;
        private System.Windows.Forms.TextBox _maxFTextBox;
        private System.Windows.Forms.ComboBox _companyComboBox;
        private System.Windows.Forms.ComboBox _designComboBox;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label _minFreqLabel;
        private System.Windows.Forms.Label _maxFreqabel;
        private System.Windows.Forms.Label _companyLabel;
        private System.Windows.Forms.Label _designLabel;
        private System.Windows.Forms.Button _backButton;
        private System.Windows.Forms.Button _addButton;
    }
}
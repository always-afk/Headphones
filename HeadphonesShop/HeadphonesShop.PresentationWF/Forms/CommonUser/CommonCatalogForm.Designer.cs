
namespace HeadphonesShop.PresentationWF.Forms.CommonUser
{
    partial class CommonCatalogForm
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
            this._headphonesTable = new System.Windows.Forms.DataGridView();
            this._backButton = new System.Windows.Forms.Button();
            this._nameLabel = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._radioFav = new System.Windows.Forms.GroupBox();
            this._favRadioButton = new System.Windows.Forms.RadioButton();
            this._allRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this._headphonesTable)).BeginInit();
            this._radioFav.SuspendLayout();
            this.SuspendLayout();
            // 
            // _headphonesTable
            // 
            this._headphonesTable.AllowUserToAddRows = false;
            this._headphonesTable.AllowUserToDeleteRows = false;
            this._headphonesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._headphonesTable.Location = new System.Drawing.Point(13, 106);
            this._headphonesTable.Name = "_headphonesTable";
            this._headphonesTable.ReadOnly = true;
            this._headphonesTable.RowTemplate.Height = 25;
            this._headphonesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._headphonesTable.Size = new System.Drawing.Size(776, 282);
            this._headphonesTable.TabIndex = 5;
            // 
            // _backButton
            // 
            this._backButton.Location = new System.Drawing.Point(12, 394);
            this._backButton.Name = "_backButton";
            this._backButton.Size = new System.Drawing.Size(75, 23);
            this._backButton.TabIndex = 4;
            this._backButton.Text = "Back";
            this._backButton.UseVisualStyleBackColor = true;
            this._backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(13, 13);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(39, 15);
            this._nameLabel.TabIndex = 6;
            this._nameLabel.Text = "Name";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(58, 10);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(100, 23);
            this._nameTextBox.TabIndex = 7;
            this._nameTextBox.TextChanged += new System.EventHandler(this.NameTextBoxChanged);
            // 
            // _radioFav
            // 
            this._radioFav.Controls.Add(this._favRadioButton);
            this._radioFav.Controls.Add(this._allRadioButton);
            this._radioFav.Location = new System.Drawing.Point(416, 12);
            this._radioFav.Name = "_radioFav";
            this._radioFav.Size = new System.Drawing.Size(200, 88);
            this._radioFav.TabIndex = 8;
            this._radioFav.TabStop = false;
            // 
            // _favRadioButton
            // 
            this._favRadioButton.AutoSize = true;
            this._favRadioButton.Location = new System.Drawing.Point(7, 48);
            this._favRadioButton.Name = "_favRadioButton";
            this._favRadioButton.Size = new System.Drawing.Size(74, 19);
            this._favRadioButton.TabIndex = 1;
            this._favRadioButton.TabStop = true;
            this._favRadioButton.Text = "Favourite";
            this._favRadioButton.UseVisualStyleBackColor = true;
            // 
            // _allRadioButton
            // 
            this._allRadioButton.AutoSize = true;
            this._allRadioButton.Location = new System.Drawing.Point(7, 23);
            this._allRadioButton.Name = "_allRadioButton";
            this._allRadioButton.Size = new System.Drawing.Size(39, 19);
            this._allRadioButton.TabIndex = 0;
            this._allRadioButton.TabStop = true;
            this._allRadioButton.Text = "All";
            this._allRadioButton.UseVisualStyleBackColor = true;
            // 
            // CommonCatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._radioFav);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._headphonesTable);
            this.Controls.Add(this._backButton);
            this.Name = "CommonCatalogForm";
            this.Text = "CommonCatalogForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommonCatalogFormClosed);
            this.Load += new System.EventHandler(this.CommonCatalogFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this._headphonesTable)).EndInit();
            this._radioFav.ResumeLayout(false);
            this._radioFav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _headphonesTable;
        private System.Windows.Forms.Button _backButton;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.GroupBox _radioFav;
        private System.Windows.Forms.RadioButton _favRadioButton;
        private System.Windows.Forms.RadioButton _allRadioButton;
    }
}
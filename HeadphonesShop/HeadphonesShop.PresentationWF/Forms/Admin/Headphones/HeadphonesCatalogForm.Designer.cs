
namespace HeadphonesShop.PresentationWF.Forms.Admin.Headphones
{
    partial class HeadphonesCatalogForm
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
            this._backButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this._headphonesTable = new System.Windows.Forms.DataGridView();
            this._editButton = new System.Windows.Forms.Button();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._headphonesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // _backButton
            // 
            this._backButton.Location = new System.Drawing.Point(12, 415);
            this._backButton.Name = "_backButton";
            this._backButton.Size = new System.Drawing.Size(75, 23);
            this._backButton.TabIndex = 1;
            this._backButton.Text = "Back";
            this._backButton.UseVisualStyleBackColor = true;
            this._backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(713, 415);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 2;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _headphonesTable
            // 
            this._headphonesTable.AllowUserToAddRows = false;
            this._headphonesTable.AllowUserToDeleteRows = false;
            this._headphonesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._headphonesTable.Location = new System.Drawing.Point(12, 83);
            this._headphonesTable.Name = "_headphonesTable";
            this._headphonesTable.ReadOnly = true;
            this._headphonesTable.RowTemplate.Height = 25;
            this._headphonesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._headphonesTable.Size = new System.Drawing.Size(776, 282);
            this._headphonesTable.TabIndex = 3;
            // 
            // _editButton
            // 
            this._editButton.Location = new System.Drawing.Point(632, 415);
            this._editButton.Name = "_editButton";
            this._editButton.Size = new System.Drawing.Size(75, 23);
            this._editButton.TabIndex = 5;
            this._editButton.Text = "Edit";
            this._editButton.UseVisualStyleBackColor = true;
            this._editButton.Click += new System.EventHandler(this.EditButtonClick);
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(60, 12);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(100, 23);
            this._nameTextBox.TabIndex = 9;
            this._nameTextBox.TextChanged += new System.EventHandler(this.NameTextBoxChanged);
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(15, 15);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(39, 15);
            this._nameLabel.TabIndex = 8;
            this._nameLabel.Text = "Name";
            // 
            // HeadphonesCatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._editButton);
            this.Controls.Add(this._headphonesTable);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._backButton);
            this.Name = "HeadphonesCatalogForm";
            this.Text = "HeadphonesCatalogForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HeadphonesCatalogFormClosed);
            this.Load += new System.EventHandler(this.HeadphonesCatalogFormLoad);
            this.VisibleChanged += new System.EventHandler(this.HeadphonesCatalogForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this._headphonesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _backButton;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.DataGridView _headphonesTable;
        private System.Windows.Forms.Button _editButton;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label _nameLabel;
    }
}
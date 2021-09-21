
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
            ((System.ComponentModel.ISupportInitialize)(this._headphonesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // _headphonesTable
            // 
            this._headphonesTable.AllowUserToAddRows = false;
            this._headphonesTable.AllowUserToDeleteRows = false;
            this._headphonesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._headphonesTable.Location = new System.Drawing.Point(12, 62);
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
            // CommonCatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._headphonesTable);
            this.Controls.Add(this._backButton);
            this.Name = "CommonCatalogForm";
            this.Text = "CommonCatalogForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommonCatalogFormClosed);
            this.Load += new System.EventHandler(this.CommonCatalogFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this._headphonesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _headphonesTable;
        private System.Windows.Forms.Button _backButton;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.TextBox _nameTextBox;
    }
}
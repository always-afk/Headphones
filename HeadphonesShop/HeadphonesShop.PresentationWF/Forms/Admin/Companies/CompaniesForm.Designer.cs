
namespace HeadphonesShop.PresentationWF.Forms.Admin.Companies
{
    partial class CompaniesForm
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
            this._companiesTable = new System.Windows.Forms.TableLayoutPanel();
            this._addButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _companiesTable
            // 
            this._companiesTable.ColumnCount = 2;
            this._companiesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._companiesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._companiesTable.Location = new System.Drawing.Point(12, 12);
            this._companiesTable.Name = "_companiesTable";
            this._companiesTable.RowCount = 3;
            this._companiesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this._companiesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this._companiesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this._companiesTable.Size = new System.Drawing.Size(200, 426);
            this._companiesTable.TabIndex = 0;
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(284, 12);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 1;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(284, 41);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 2;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // CompaniesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 450);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._companiesTable);
            this.Name = "CompaniesForm";
            this.Text = "CompaniesForm";
            this.Activated += new System.EventHandler(this.CompaniesFormActivated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompaniesFormClosed);
            this.Load += new System.EventHandler(this.CompaniesFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _companiesTable;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _saveButton;
    }
}
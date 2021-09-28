
namespace HeadphonesShop.PresentationWF.Forms.Admin.Designs
{
    partial class DesignsForm
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
            this._addButton = new System.Windows.Forms.Button();
            this._designsTable = new System.Windows.Forms.TableLayoutPanel();
            this._saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(345, 334);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _designsTable
            // 
            this._designsTable.ColumnCount = 2;
            this._designsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._designsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._designsTable.Location = new System.Drawing.Point(12, 12);
            this._designsTable.Name = "_designsTable";
            this._designsTable.RowCount = 3;
            this._designsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._designsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._designsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._designsTable.Size = new System.Drawing.Size(408, 241);
            this._designsTable.TabIndex = 1;
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(345, 363);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 2;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            // 
            // DesignsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 392);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._designsTable);
            this.Controls.Add(this._addButton);
            this.Name = "DesignsForm";
            this.Text = "DesignsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DesignsFormClosed);
            this.Load += new System.EventHandler(this.DesignsFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.TableLayoutPanel _designsTable;
        private System.Windows.Forms.Button _saveButton;
    }
}
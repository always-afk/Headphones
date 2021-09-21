
namespace HeadphonesShop.PresentationWF.Forms.Admin.Users
{
    partial class AllUsersForm
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
            this._saveButton = new System.Windows.Forms.Button();
            this._usersTable = new System.Windows.Forms.TableLayoutPanel();
            this._loginLabel = new System.Windows.Forms.Label();
            this._isAdminLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _backButton
            // 
            this._backButton.Location = new System.Drawing.Point(12, 404);
            this._backButton.Name = "_backButton";
            this._backButton.Size = new System.Drawing.Size(75, 23);
            this._backButton.TabIndex = 1;
            this._backButton.Text = "Back";
            this._backButton.UseVisualStyleBackColor = true;
            this._backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(713, 404);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 2;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // _usersTable
            // 
            this._usersTable.ColumnCount = 3;
            this._usersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._usersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._usersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._usersTable.Location = new System.Drawing.Point(12, 50);
            this._usersTable.Name = "_usersTable";
            this._usersTable.RowCount = 1;
            this._usersTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._usersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this._usersTable.Size = new System.Drawing.Size(776, 277);
            this._usersTable.TabIndex = 3;
            // 
            // _loginLabel
            // 
            this._loginLabel.AutoSize = true;
            this._loginLabel.Location = new System.Drawing.Point(12, 32);
            this._loginLabel.Name = "_loginLabel";
            this._loginLabel.Size = new System.Drawing.Size(37, 15);
            this._loginLabel.TabIndex = 4;
            this._loginLabel.Text = "Login";
            // 
            // _isAdminLabel
            // 
            this._isAdminLabel.AutoSize = true;
            this._isAdminLabel.Location = new System.Drawing.Point(269, 32);
            this._isAdminLabel.Name = "_isAdminLabel";
            this._isAdminLabel.Size = new System.Drawing.Size(51, 15);
            this._isAdminLabel.TabIndex = 5;
            this._isAdminLabel.Text = "IsAdmin";
            // 
            // AllUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._isAdminLabel);
            this.Controls.Add(this._loginLabel);
            this.Controls.Add(this._usersTable);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._backButton);
            this.Name = "AllUsersForm";
            this.Text = "AllUsersForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AllUsersFormClosed);
            this.Load += new System.EventHandler(this.AllUsersFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _backButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.TableLayoutPanel _usersTable;
        private System.Windows.Forms.Label _loginLabel;
        private System.Windows.Forms.Label _isAdminLabel;
    }
}
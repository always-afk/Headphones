
namespace HeadphonesShop.PresentationWF.Forms.Admin.Designs
{
    partial class AddDesignForm
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
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(251, 238);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(126, 65);
            this._nameTextBox.MaxLength = 31;
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(100, 23);
            this._nameTextBox.TabIndex = 1;
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(66, 68);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(39, 15);
            this._nameLabel.TabIndex = 2;
            this._nameLabel.Text = "Name";
            // 
            // AddDesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 293);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._addButton);
            this.Name = "AddDesignForm";
            this.Text = "AddDesignForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddDesignFormClosed);
            this.Load += new System.EventHandler(this.AddDesignFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label _nameLabel;
    }
}
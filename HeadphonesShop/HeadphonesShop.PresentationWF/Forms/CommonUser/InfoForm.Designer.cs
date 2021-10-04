
namespace HeadphonesShop.PresentationWF.Forms.CommonUser
{
    partial class InfoForm
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
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._nameLabel = new System.Windows.Forms.Label();
            this._FreqLabel = new System.Windows.Forms.Label();
            this._companyLabel = new System.Windows.Forms.Label();
            this._designLabel = new System.Windows.Forms.Label();
            this._favCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(400, 12);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(388, 347);
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(12, 12);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(38, 15);
            this._nameLabel.TabIndex = 1;
            this._nameLabel.Text = "label1";
            // 
            // _FreqLabel
            // 
            this._FreqLabel.AutoSize = true;
            this._FreqLabel.Location = new System.Drawing.Point(12, 99);
            this._FreqLabel.Name = "_FreqLabel";
            this._FreqLabel.Size = new System.Drawing.Size(38, 15);
            this._FreqLabel.TabIndex = 2;
            this._FreqLabel.Text = "label2";
            // 
            // _companyLabel
            // 
            this._companyLabel.AutoSize = true;
            this._companyLabel.Location = new System.Drawing.Point(12, 158);
            this._companyLabel.Name = "_companyLabel";
            this._companyLabel.Size = new System.Drawing.Size(38, 15);
            this._companyLabel.TabIndex = 3;
            this._companyLabel.Text = "label3";
            // 
            // _designLabel
            // 
            this._designLabel.AutoSize = true;
            this._designLabel.Location = new System.Drawing.Point(12, 208);
            this._designLabel.Name = "_designLabel";
            this._designLabel.Size = new System.Drawing.Size(38, 15);
            this._designLabel.TabIndex = 4;
            this._designLabel.Text = "label4";
            // 
            // _favCheckBox
            // 
            this._favCheckBox.AutoSize = true;
            this._favCheckBox.Location = new System.Drawing.Point(400, 366);
            this._favCheckBox.Name = "_favCheckBox";
            this._favCheckBox.Size = new System.Drawing.Size(75, 19);
            this._favCheckBox.TabIndex = 5;
            this._favCheckBox.Text = "Favourite";
            this._favCheckBox.UseVisualStyleBackColor = true;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._favCheckBox);
            this.Controls.Add(this._designLabel);
            this.Controls.Add(this._companyLabel);
            this.Controls.Add(this._FreqLabel);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._pictureBox);
            this.Name = "InfoForm";
            this.Text = "InfoForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InfoFormClosed);
            this.Load += new System.EventHandler(this.InfoFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label _FreqLabel;
        private System.Windows.Forms.Label _companyLabel;
        private System.Windows.Forms.Label _designLabel;
        private System.Windows.Forms.CheckBox _favCheckBox;
    }
}
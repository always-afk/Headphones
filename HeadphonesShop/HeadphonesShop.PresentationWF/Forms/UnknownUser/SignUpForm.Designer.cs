
namespace HeadphonesShop.PresentationWF.Forms.UnknownUser
{
    partial class SignUpForm
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
            this._registerButton = new System.Windows.Forms.Button();
            this._loginLabel = new System.Windows.Forms.Label();
            this._loginTextBox = new System.Windows.Forms.TextBox();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._passTextBox = new System.Windows.Forms.TextBox();
            this._rePasswordLabel = new System.Windows.Forms.Label();
            this._repassTextBox = new System.Windows.Forms.TextBox();
            this._backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _registerButton
            // 
            this._registerButton.Location = new System.Drawing.Point(62, 156);
            this._registerButton.Name = "_registerButton";
            this._registerButton.Size = new System.Drawing.Size(75, 23);
            this._registerButton.TabIndex = 0;
            this._registerButton.Text = "Register";
            this._registerButton.UseVisualStyleBackColor = true;
            this._registerButton.Click += new System.EventHandler(this.RegisterButtonClick);
            // 
            // _loginLabel
            // 
            this._loginLabel.AutoSize = true;
            this._loginLabel.Location = new System.Drawing.Point(112, 21);
            this._loginLabel.Name = "_loginLabel";
            this._loginLabel.Size = new System.Drawing.Size(37, 15);
            this._loginLabel.TabIndex = 1;
            this._loginLabel.Text = "Login";
            // 
            // _loginTextBox
            // 
            this._loginTextBox.Location = new System.Drawing.Point(155, 18);
            this._loginTextBox.Name = "_loginTextBox";
            this._loginTextBox.Size = new System.Drawing.Size(100, 23);
            this._loginTextBox.TabIndex = 2;
            // 
            // _passwordLabel
            // 
            this._passwordLabel.AutoSize = true;
            this._passwordLabel.Location = new System.Drawing.Point(92, 50);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(57, 15);
            this._passwordLabel.TabIndex = 3;
            this._passwordLabel.Text = "Password";
            // 
            // _passTextBox
            // 
            this._passTextBox.Location = new System.Drawing.Point(155, 47);
            this._passTextBox.Name = "_passTextBox";
            this._passTextBox.Size = new System.Drawing.Size(100, 23);
            this._passTextBox.TabIndex = 4;
            // 
            // _rePasswordLabel
            // 
            this._rePasswordLabel.AutoSize = true;
            this._rePasswordLabel.Location = new System.Drawing.Point(44, 79);
            this._rePasswordLabel.Name = "_rePasswordLabel";
            this._rePasswordLabel.Size = new System.Drawing.Size(105, 15);
            this._rePasswordLabel.TabIndex = 5;
            this._rePasswordLabel.Text = "Re-enter password";
            // 
            // _repassTextBox
            // 
            this._repassTextBox.Location = new System.Drawing.Point(155, 76);
            this._repassTextBox.Name = "_repassTextBox";
            this._repassTextBox.Size = new System.Drawing.Size(100, 23);
            this._repassTextBox.TabIndex = 6;
            // 
            // _backButton
            // 
            this._backButton.Location = new System.Drawing.Point(277, 156);
            this._backButton.Name = "_backButton";
            this._backButton.Size = new System.Drawing.Size(75, 23);
            this._backButton.TabIndex = 7;
            this._backButton.Text = "Back";
            this._backButton.UseVisualStyleBackColor = true;
            this._backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 213);
            this.Controls.Add(this._backButton);
            this.Controls.Add(this._repassTextBox);
            this.Controls.Add(this._rePasswordLabel);
            this.Controls.Add(this._passTextBox);
            this.Controls.Add(this._passwordLabel);
            this.Controls.Add(this._loginTextBox);
            this.Controls.Add(this._loginLabel);
            this.Controls.Add(this._registerButton);
            this.Name = "SignUpForm";
            this.Text = "SignUpForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SignUpFormClosed);
            this.Load += new System.EventHandler(this.SignUpFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _registerButton;
        private System.Windows.Forms.Label _loginLabel;
        private System.Windows.Forms.TextBox _loginTextBox;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.TextBox _passTextBox;
        private System.Windows.Forms.Label _rePasswordLabel;
        private System.Windows.Forms.TextBox _repassTextBox;
        private System.Windows.Forms.Button _backButton;
    }
}
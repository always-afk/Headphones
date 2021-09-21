
namespace HeadphonesShop.PresentationWF.Forms.UnknownUser
{
    partial class SignInForm
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
            this._loginLabel = new System.Windows.Forms.Label();
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this._signInButton = new System.Windows.Forms.Button();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._signUpButton = new System.Windows.Forms.Button();
            this._loginTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _loginLabel
            // 
            this._loginLabel.AutoSize = true;
            this._loginLabel.Location = new System.Drawing.Point(106, 52);
            this._loginLabel.Name = "_loginLabel";
            this._loginLabel.Size = new System.Drawing.Size(37, 15);
            this._loginLabel.TabIndex = 0;
            this._loginLabel.Text = "Login";
            // 
            // _passwordTextBox
            // 
            this._passwordTextBox.Location = new System.Drawing.Point(149, 114);
            this._passwordTextBox.Name = "_passwordTextBox";
            this._passwordTextBox.PasswordChar = '*';
            this._passwordTextBox.Size = new System.Drawing.Size(100, 23);
            this._passwordTextBox.TabIndex = 2;
            // 
            // _signInButton
            // 
            this._signInButton.Location = new System.Drawing.Point(68, 198);
            this._signInButton.Name = "_signInButton";
            this._signInButton.Size = new System.Drawing.Size(75, 23);
            this._signInButton.TabIndex = 3;
            this._signInButton.Text = "Sign In";
            this._signInButton.UseVisualStyleBackColor = true;
            this._signInButton.Click += new System.EventHandler(this.SignInButtonClick);
            // 
            // _passwordLabel
            // 
            this._passwordLabel.AutoSize = true;
            this._passwordLabel.Location = new System.Drawing.Point(86, 117);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(57, 15);
            this._passwordLabel.TabIndex = 3;
            this._passwordLabel.Text = "Password";
            // 
            // _signUpButton
            // 
            this._signUpButton.Location = new System.Drawing.Point(220, 198);
            this._signUpButton.Name = "_signUpButton";
            this._signUpButton.Size = new System.Drawing.Size(75, 23);
            this._signUpButton.TabIndex = 4;
            this._signUpButton.Text = "Sign Up";
            this._signUpButton.UseVisualStyleBackColor = true;
            this._signUpButton.Click += new System.EventHandler(this.SignUpButtonClick);
            // 
            // _loginTextBox
            // 
            this._loginTextBox.Location = new System.Drawing.Point(149, 49);
            this._loginTextBox.Name = "_loginTextBox";
            this._loginTextBox.Size = new System.Drawing.Size(100, 23);
            this._loginTextBox.TabIndex = 1;
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 252);
            this.Controls.Add(this._loginTextBox);
            this.Controls.Add(this._signUpButton);
            this.Controls.Add(this._passwordLabel);
            this.Controls.Add(this._signInButton);
            this.Controls.Add(this._passwordTextBox);
            this.Controls.Add(this._loginLabel);
            this.Name = "SignInForm";
            this.Text = "SignInForm";
            this.VisibleChanged += new System.EventHandler(this.SignInVisibleChange);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _loginLabel;
        private System.Windows.Forms.TextBox _passwordTextBox;
        private System.Windows.Forms.Button _signInButton;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.Button _signUpButton;
        private System.Windows.Forms.TextBox _loginTextBox;
    }
}
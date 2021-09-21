using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.BusinessLogic.Services.Implementation;
using HeadphonesShop.Common.Entities;

namespace HeadphonesShop.PresentationWF.Forms.UnknownUser
{
    public partial class SignInForm : Form
    {
        private readonly ISignInService _signInService;
        public SignInForm()
        {
            InitializeComponent();

            _signInService = new SignInService();
        }

        private void SignUpButtonClick(object sender, EventArgs e)
        {
            Form form = new SignUpForm(this);
            form.Show();
        }

        private void SignInButtonClick(object sender, EventArgs e)
        {
            var user = new User()
            {
                Login = _loginTextBox.Text,
                Password = _passwordTextBox.Text
            };
            user = _signInService.SignIn(user);
            if(user is null)
            {
                MessageBox.Show("Can't find this user");
                return;
            }
            else
            {
                if (user.IsAdmin)
                {
                    Form form = new Admin.Headphones.HeadphonesCatalogForm(this);
                    form.Show();
                }
                else
                {
                    Form form = new CommonUser.CommonCatalogForm(this);
                    form.Show();
                }
            }
        }

        private void SignInVisibleChange(object sender, EventArgs e)
        {
            _loginTextBox.Text = null;
            _passwordTextBox.Text = null;
        }
    }
}

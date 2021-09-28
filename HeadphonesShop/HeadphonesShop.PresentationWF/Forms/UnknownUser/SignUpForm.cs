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
    public partial class SignUpForm : Form
    {
        private readonly Form _form;
        private readonly ISignUpService _signUpService;
        private readonly SimpleInjector.Container _container;

        private const int MAXLOGIN = 16;
        private const int MINLOGIN = 6;
        private const int MAXPASS = 16;
        private const int MINPASS = 6;

        public SignUpForm(Form form, SimpleInjector.Container container)
        {
            InitializeComponent();

            _form = form;
            _container = container;
            _signUpService = _container.GetInstance<ISignUpService>();
        }

        private void SignUpFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;
        }

        private void SignUpFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {
            var login = _loginTextBox.Text;
            var log = "";
            foreach(var l in login)
            {
                log += Char.ToLower(l);
            }
            var pass = _passTextBox.Text;
            var repass = _repassTextBox.Text;
            if(Validate(log, pass, repass))
            {
                var user = new User()
                {
                    Login = log,
                    Password = pass,
                    Role = new Role()
                    {
                        Name = "Common user"
                    }
                };
                if (_signUpService.SignUp(user))
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Such user is already exists");
                }
            }
            else
            {
                MessageBox.Show("Incorrect input");
            }
        }

        private bool Validate(string login, string password, string repassword)
        {
            return login.Length <= MAXLOGIN && 
                login.Length >= MINLOGIN && 
                password.Length <= MAXPASS && 
                password.Length >= MINPASS && 
                password == repassword;
        }
    }
}

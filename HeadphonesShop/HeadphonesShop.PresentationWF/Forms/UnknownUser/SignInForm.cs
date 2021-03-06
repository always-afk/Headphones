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
using SimpleInjector;
using SimpleInjector.Lifestyles;
using HeadphonesShop.DataAccess.Context;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using HeadphonesShop.DataAccess.Repository.Implementation;
using HeadphonesShop.DataAccess.Services.Interfaces;
using HeadphonesShop.DataAccess.Services.Implementation;
using SimpleInjector.Diagnostics;

namespace HeadphonesShop.PresentationWF.Forms.UnknownUser
{
    public partial class SignInForm : Form
    {
        private readonly IAccountService _accountService;
        private readonly SimpleInjector.Container _container;
        public SignInForm()
        {
            InitializeComponent();

            _container = new SimpleInjector.Container();

            Register();

            _accountService = _container.GetInstance<IAccountService>();
        }

        private void Register()
        {
            _container.Register<IHeadphonesService, HeadphonesService>();
            _container.Register<IAccountService, AccountService>();
            _container.Register<IUsersService, UsersService>();
            _container.Register<ICompanyService, CompanyService>();
            _container.Register<IDesignService, DesignService>();

            RegisterContext();
            _container.Register<ICompaniesRepository, CompaniesRepository>();
            _container.Register<IDesignRepository, DesignRepository>();
            _container.Register<IHeadphonesRepository, HeadphonesRepository>();
            _container.Register<IUnitOfWork, UnitOfWork>();
            _container.Register<IUsersRepository, UsersRepository>();
            _container.Register<IMapper, Mapper>();

            _container.Verify();
        }

        void RegisterContext()
        {

            var registration =
                Lifestyle.Singleton.CreateRegistration(typeof(HeadphonesDBContext), _container);

            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
            "Forms should be disposed by app code; not by the container.");

            _container.AddRegistration(typeof(HeadphonesDBContext), registration);

        }

        private void SignUpButtonClick(object sender, EventArgs e)
        {
            Form form = new SignUpForm(this, _container);
            form.Show();
        }

        private void SignInButtonClick(object sender, EventArgs e)
        {
            var user = new User()
            {
                Login = _loginTextBox.Text,
                Password = _passwordTextBox.Text
            };
            user = _accountService.SignIn(user);
            if(user is null)
            {
                MessageBox.Show("Can't find this user");
                return;
            }
            else
            {
                if (user.Role.Name == "admin")
                {
                    Form form = new Admin.Headphones.HeadphonesCatalogForm(this, user, _container);
                    form.Show();
                }
                else
                {
                    Form form = new CommonUser.CommonCatalogForm(this, _container, user);
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

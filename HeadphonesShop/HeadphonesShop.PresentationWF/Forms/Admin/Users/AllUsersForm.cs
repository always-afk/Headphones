using HeadphonesShop.BusinessLogic.Services.Implementation;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadphonesShop.PresentationWF.Forms.Admin.Users
{
    public partial class AllUsersForm : Form
    {
        private readonly Form _form;
        private readonly User _user;
        private readonly SimpleInjector.Container _container;
        private readonly IUsersService _usersService;
        private List<User> _users;
        public AllUsersForm(Form form, User user, SimpleInjector.Container container)
        {
            InitializeComponent();

            _form = form;
            _user = user;
            _container = container;
            _usersService = _container.GetInstance<IUsersService>();
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AllUsersFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
           
        }

        private void AllUsersFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;
            //_users = _usersService.GetOtherUsers(_user).ToList();
            //Fill(_users);
        }

        private void Fill(List<User> users)
        {
            _usersTable.Controls.Clear();
            _usersTable.AutoSize = true;
            _usersTable.RowCount = users.Count;
            
            int row = 0;
            foreach(var user in users)
            {
                int column = 0;
                var login = new Label();
                login.Text = user.Login;
                _usersTable.Controls.Add(login, column, row);
                column += 1;
                var admin = new CheckBox();
                admin.Checked = user.Role.Name == "admin";
                _usersTable.Controls.Add(admin, column, row);
                column += 1;
                var del = new Button();
                del.Text = "Delete";
                del.Click += DeleteClick;
                del.TabIndex = users.IndexOf(user) + 100;
                _usersTable.Controls.Add(del, column, row);
                column += 1;
                row += 1;
            }
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            var button = (sender as Button);
            if (button is not null)
            {
                var user = _users.ElementAt(button.TabIndex - 100);
                _users.Remove(user);
            }
            Fill(_users);
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            var j = 0;
            for (var i = 1; i < _usersTable.Controls.Count; i += 3)
            {
                //_users[j].IsAdmin = 
                if((_usersTable.Controls[i] as CheckBox).Checked)
                {
                    _users[j].Role.Name = "Admin";
                }
                else
                {
                    _users[j].Role.Name = "Common user";
                }
                j += 1;
            }
            //_users.Add(_user);
            //_usersService.Update(_users);
            Close();
        }
    }
}

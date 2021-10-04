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

namespace HeadphonesShop.PresentationWF.Forms.CommonUser
{
    public partial class CommonCatalogForm : Form
    {
        private readonly Form _form;
        private readonly DataTable _table;
        private readonly IHeadphonesService _headphonesService;
        private readonly IUsersService _usersService;
        private readonly SimpleInjector.Container _container;
        private readonly User _user;
        private List<Headphones> _headphones;
        private string[] prop = { "Name", "MinFrequancy", "MaxFrequancy", "Company", "Design" };
        public CommonCatalogForm(Form form, SimpleInjector.Container container, User user)
        {
            InitializeComponent();

            _form = form;
            _table = new DataTable();
            _container = container;
            _user = user;
            _headphonesService = _container.GetInstance<IHeadphonesService>();
            _usersService = _container.GetInstance<IUsersService>();
        }

        private void CommonCatalogFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;

            _headphones = _headphonesService.GetAllHeadphones();

            foreach (var p in prop)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = p;
                _table.Columns.Add(column);
            }

            Fill(_headphones);

            _headphonesTable.DataSource = _table;
            _allRadioButton.Checked = true;
        }

        private void CommonCatalogFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void Fill(IEnumerable<Headphones> headphones)
        {
            _table.Rows.Clear();

            foreach (var h in headphones)
            {
                var row = _table.NewRow();
                row.ItemArray = new object[] { h.Name, h.MinFrequency, h.MaxFrequency, h.Company.Name, h.Design.Name };
                _table.Rows.Add(row);
            }
        }

        private void NameTextBoxChanged(object sender, EventArgs e)
        {
            Fill(_headphones.Where(h => h.Name.StartsWith(_nameTextBox.Text)));
        }

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            if (_allRadioButton.Checked)
            {
                Fill(_headphones);
            }
            else if (_favRadioButton.Checked)
            {
                Fill(_user.FavHeadphones);
            }
        }

        private void InfoButtonClick(object sender, EventArgs e)
        {
            var name = _headphonesTable.CurrentRow.Cells[0].Value.ToString();
            var minF = Convert.ToDouble(_headphonesTable.CurrentRow.Cells[1].Value.ToString());
            var maxF = Convert.ToDouble(_headphonesTable.CurrentRow.Cells[2].Value.ToString());
            var company = _headphonesTable.CurrentRow.Cells[3].Value.ToString();
            var desi = _headphonesTable.CurrentRow.Cells[4].Value.ToString();
            var selectedhead = new Headphones()
            {
                Name = name,
                MinFrequency = minF,
                MaxFrequency = maxF,
                Company = new Company()
                {
                    Name = company
                },
                Design = new Design()
                {
                    Name = desi
                }
            };
            Form form = new InfoForm(this, _user, selectedhead);
            form.Show();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            _usersService.Update(_user);
        }
    }
}

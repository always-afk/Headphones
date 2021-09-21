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

namespace HeadphonesShop.PresentationWF.Forms.Admin.Headphones
{
    public partial class HeadphonesCatalogForm : Form
    {
        private readonly Form _form;
        private readonly DataTable _table;
        private readonly IHeadphonesService _headphonesService;
        private readonly Common.Entities.User _user;
        private List<Common.Entities.Headphones> _headphones;
        private string[] prop = { "Name", "MinFrequancy", "MaxFrequancy", "Company", "Design" };
        public HeadphonesCatalogForm(Form form, Common.Entities.User user)
        {
            InitializeComponent();

            _form = form;
            _user = user;
            _table = new DataTable();
            _headphonesService = new HeadphonesService();
        }

        private void HeadphonesCatalogFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;
            _headphones = _headphonesService.GetAllHeadphones();

            foreach(var p in prop) 
            {
                DataColumn column = new DataColumn();
                column.ColumnName = p;
                _table.Columns.Add(column);
            }

            Fill(_headphones);

            _headphonesTable.DataSource = _table;
        }

        private void HeadphonesCatalogFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            Form form = new AddHeadphonesForm(this, _headphonesService);
            form.Show();
        }

        private void HeadphonesCatalogForm_VisibleChanged(object sender, EventArgs e)
        {
            Fill(_headphones);
        }

        private void EditButtonClick(object sender, EventArgs e)
        {
            var name = _headphonesTable.CurrentRow.Cells[0].Value.ToString();
            var minF = Convert.ToDouble(_headphonesTable.CurrentRow.Cells[1].Value.ToString());
            var maxF = Convert.ToDouble(_headphonesTable.CurrentRow.Cells[2].Value.ToString());
            var company = _headphonesTable.CurrentRow.Cells[3].Value.ToString();
            var desi = _headphonesTable.CurrentRow.Cells[4].Value.ToString();
            var selectedhead = new Common.Entities.Headphones()
            {
                Name = name,
                MinFrequency = minF,
                MaxFrequency = maxF,
                Company = new Common.Entities.Company()
                {
                    Name = company
                },
                Design = new Common.Entities.Design()
                {
                    Name = desi
                }
            };
            Form form = new EditHeadphonesForm(this, _headphonesService, selectedhead);
            form.Show();
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void Fill(IEnumerable<Common.Entities.Headphones> headphones)
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

        private void UsersButtonClick(object sender, EventArgs e)
        {
            Form form = new Users.AllUsersForm(this, _user);
            form.Show();
        }
    }
}

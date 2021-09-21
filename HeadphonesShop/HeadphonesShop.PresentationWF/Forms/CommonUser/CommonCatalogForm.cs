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
        private readonly SimpleInjector.Container _container;
        private List<Headphones> _headphones;
        private string[] prop = { "Name", "MinFrequancy", "MaxFrequancy", "Company", "Design" };
        public CommonCatalogForm(Form form, SimpleInjector.Container container)
        {
            InitializeComponent();

            _form = form;
            _table = new DataTable();
            _container = container;
            _headphonesService = _container.GetInstance<IHeadphonesService>();
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
    }
}

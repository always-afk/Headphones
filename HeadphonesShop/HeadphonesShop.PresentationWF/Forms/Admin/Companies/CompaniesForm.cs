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

namespace HeadphonesShop.PresentationWF.Forms.Admin.Companies
{
    public partial class CompaniesForm : Form
    {
        private readonly Form _form;        
        private readonly ICompanyService _companyService;
        private List<Company> _companies;
        public CompaniesForm(Form form, ICompanyService companyService)
        {
            InitializeComponent();

            _form = form;
            _companyService = companyService;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            Form form = new AddCompanyForm(this, _companyService);
            form.Show();
        }

        private void CompaniesFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;

            _companies = _companyService.GetAllCompanies().ToList();
            Fill(_companies);
        }
        private void Fill(IEnumerable<Company> companies)
        {
            _companiesTable.Controls.Clear();
            _companiesTable.RowCount = companies.Count();

            for(var i = 0;i<companies.Count(); i++)
            {
                var compName = new Label();
                compName.Text = companies.ElementAt(i).Name;
                var but = new Button();
                but.Text = "Delete";
                but.TabIndex = 100 + i;
                but.Click += DeleteButtonClick;
                _companiesTable.Controls.Add(compName, 0, i);
                _companiesTable.Controls.Add(but, 1, i);
            }
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            var i = (sender as Button).TabIndex;
            _companies.RemoveAt(i - 100);
            Fill(_companies);
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            _companyService.Save(_companies);
        }

        private void CompaniesFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
        }

        private void CompaniesFormActivated(object sender, EventArgs e)
        {
            _companies = _companyService.GetAllCompanies().ToList();
            Fill(_companies);
        }
    }
}

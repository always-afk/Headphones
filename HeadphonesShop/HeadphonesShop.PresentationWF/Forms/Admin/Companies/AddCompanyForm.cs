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
    public partial class AddCompanyForm : Form
    {
        private readonly Form _form;
        private readonly ICompanyService _companyService;
        public AddCompanyForm(Form form, ICompanyService companyService)
        {
            InitializeComponent();

            _form = form;
            _companyService = companyService;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            var company = new Company()
            {
                Name = _nameTextBox.Text
            };
            if (_companyService.Add(company))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void AddCompanyFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
        }

        private void AddCompanyFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;
        }
    }
}

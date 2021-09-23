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
using HeadphonesShop.Common.Entities;

namespace HeadphonesShop.PresentationWF.Forms.Admin.Headphones
{
    public partial class AddHeadphonesForm : Form
    {
        private readonly Form _form;
        private readonly SimpleInjector.Container _container;
        private readonly IHeadphonesService _headphonesService;
        private readonly ICompanyService _companyService;
        private readonly IDesignService _designService;
        public AddHeadphonesForm(Form form, SimpleInjector.Container container)
        {
            InitializeComponent();

            _form = form;
            _container = container;
            _headphonesService = _container.GetInstance<IHeadphonesService>();
            _companyService = _container.GetInstance<ICompanyService>();
            _designService = _container.GetInstance<IDesignService>();
        }

        private void AddHeadphonesFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;

            foreach(var c in _companyService.GetAllCompanies())
            {
                _companyComboBox.Items.Add(c.Name);
            }
            _companyComboBox.SelectedIndex = 0;

            foreach(var d in _designService.GetAllDesigns())
            {
                _designComboBox.Items.Add(d.Name);
            }
            _designComboBox.SelectedIndex = 0;
        }

        private void AddHeadphonesFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            var minf = _minFTextBox.Text;
            var maxf = _maxFTextBox.Text;
            if (_nameTextBox.Text.Length > 0 && maxf.Length > 0 && minf.Length > 0 && minf.All(Char.IsDigit) && maxf.All(Char.IsDigit))
            {
                var max = Convert.ToDouble(maxf);
                var min = Convert.ToDouble(minf);
                var head = new Common.Entities.Headphones();
                head.Name = _nameTextBox.Text;
                head.MinFrequency = min;
                head.MaxFrequency = max;
                head.Company = new Company()
                {
                    Name = _companyComboBox.SelectedItem.ToString()
                };
                head.Design = new Design()
                {
                    Name = _designComboBox.SelectedItem.ToString()
                };

                if (_headphonesService.Add(head))
                {
                    MessageBox.Show("Complete");
                    Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}

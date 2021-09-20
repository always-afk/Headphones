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

namespace HeadphonesShop.PresentationWF.Forms.Admin.Headphones
{
    public partial class EditHeadphonesForm : Form
    {
        private readonly Form _form;
        private readonly IHeadphonesService _headphonesService;
        private readonly Common.Entities.Headphones _headphones;
        public EditHeadphonesForm(Form form, IHeadphonesService headphonesService, Common.Entities.Headphones headphones)
        {
            InitializeComponent();

            _form = form;
            _headphonesService = headphonesService;
            _headphones = headphones;
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void EditHeadphonesFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
        }

        private void EditHeadphonesFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;
            _nameTextBox.Text = _headphones.Name;
            _minFTextBox.Text = _headphones.MinFrequency.ToString();
            _maxFTextBox.Text = _headphones.MaxFrequency.ToString();
            foreach(var c in _headphonesService.GetAllCompanies())
            {
                _companyComboBox.Items.Add(c.Name);
            }
            _companyComboBox.SelectedItem = _headphones.Company.Name;
            foreach(var d in _headphonesService.GetAllDesigns())
            {
                _designComboBox.Items.Add(d.Name);
            }
            _designComboBox.SelectedItem = _headphones.Design.Name;
        }
    }
}

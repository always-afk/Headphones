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
    public partial class InfoForm : Form
    {
        private readonly Form _form;
        private readonly Headphones _headphones;
        private readonly User _user;
        public InfoForm(Form form, User user, Headphones headphones)
        {
            InitializeComponent();

            _form = form;
            _headphones = headphones;
            _user = user;
        }

        private void InfoFormLoad(object sender, EventArgs e)
        {
            _nameLabel.Text = $"Model: {_headphones.Name}";
            _FreqLabel.Text = $"Fequancy: {_headphones.MinFrequency} - {_headphones.MaxFrequency}";
            _companyLabel.Text = $"Company: {_headphones.Company.Name}";
            _designLabel.Text = $"Design: {_headphones.Design.Name}";
            if(!(String.IsNullOrEmpty(_headphones.Picture) || _headphones.Picture == "None"))
            {
                _pictureBox.Image = Image.FromFile(_headphones.Picture);
            }
            if(_user.FavHeadphones.Any(h => h.Name == _headphones.Name))
            {
                _favCheckBox.Checked = true;
            }
            else
            {
                _favCheckBox.Checked = false;
            }
        }

        private void InfoFormClosed(object sender, FormClosedEventArgs e)
        {
            if(_favCheckBox.Checked && !_user.FavHeadphones.Any(h => h.Name == _headphones.Name))
            {
                _user.FavHeadphones.Add(_headphones);
            }
            else if(!_favCheckBox.Checked && _user.FavHeadphones.Any(h => h.Name == _headphones.Name))
            {
                var hToRem = _user.FavHeadphones.Where(h => h.Name == _headphones.Name).FirstOrDefault();
                _user.FavHeadphones.Remove(hToRem);
            }
        }
    }
}

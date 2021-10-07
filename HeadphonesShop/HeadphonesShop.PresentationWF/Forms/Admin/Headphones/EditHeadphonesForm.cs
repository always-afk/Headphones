using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private readonly SimpleInjector.Container _container;
        public EditHeadphonesForm(Form form, Common.Entities.Headphones headphones, SimpleInjector.Container container)
        {
            InitializeComponent();

            _form = form;
            _container = container;
            _headphonesService = _container.GetInstance<IHeadphonesService>();
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
            if(!(_headphones.Picture == "None" || String.IsNullOrEmpty(_headphones.Picture)))
            {
                try
                {
                    _pictureBox.Image = Image.FromFile(_headphones.Picture);
                }
                catch (Exception)
                {
                    _pictureBox.Image = null;
                }
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            var minf = _minFTextBox.Text;
            var maxf = _maxFTextBox.Text;
            if (_nameTextBox.Text.Length > 0 && maxf.Length > 0 && minf.Length > 0 && minf.All(Char.IsDigit) && maxf.All(Char.IsDigit))
            {
                var max = Convert.ToDouble(maxf);
                var min = Convert.ToDouble(minf);
                var head = new Common.Entities.Headphones();
                head.Name = _headphones.Name;
                head.MinFrequency = min;
                head.MaxFrequency = max;
                head.Picture = _pictureBox.ImageLocation;
                head.Company = new Company()
                {
                    Name = _companyComboBox.SelectedItem.ToString()
                };
                head.Design = new Design()
                {
                    Name = _designComboBox.SelectedItem.ToString()
                };

                _headphonesService.Update(head);
                Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            _headphonesService.Delete(_headphones);
            Close();
        }

        private void PictureButtonClick(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                //openFileDialog.Filter = "txt file (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            try
            {
                //_pictureBox.Image = Image.FromFile(filePath);
                _pictureBox.ImageLocation = filePath;
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}

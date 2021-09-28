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

namespace HeadphonesShop.PresentationWF.Forms.Admin.Designs
{
    public partial class DesignsForm : Form
    {
        private readonly Form _form;
        private readonly IDesignService _designService;
        private List<Design> _designs;
        public DesignsForm(Form form, IDesignService designService)
        {
            InitializeComponent();

            _form = form;
            _designService = designService;
        }

        private void DesignsFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;
            _designs = _designService.GetAllDesigns().ToList();

            Fill();
        }

        private void Fill()
        {
            _designsTable.RowCount = _designs.Count;
            for (int i = 0; i < _designs.Count; i++)
            {
                var l = new Label();
                l.Text = _designs[i].Name;
                var b = new Button();
                b.Text = "Delete";
                b.Click += Delete;
                _designsTable.Controls.Add(l, 0, i);
                _designsTable.Controls.Add(b, 1, i);
            }
        }

        private void DesignsFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            Form form = new AddDesignForm(this, _designService);
            form.Show();
        }

        private void Delete(object sender, EventArgs e)
        {
            var b = (sender as Button);
            if(b is not null)
            {
                _designs.RemoveAt((_designsTable.Controls.IndexOf(b) + 1) / 2);
            }
            Fill();
        }
    }
}

using HeadphonesShop.BusinessLogic.Services.Interfaces;
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
        public DesignsForm(Form form, IDesignService designService)
        {
            InitializeComponent();

            _form = form;
            _designService = designService;
        }

        private void DesignsFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;
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
    }
}

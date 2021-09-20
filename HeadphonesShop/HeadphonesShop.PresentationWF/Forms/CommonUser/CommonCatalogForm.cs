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
        public CommonCatalogForm(Form form)
        {
            InitializeComponent();

            _form = form;
        }

        private void CommonCatalogFormLoad(object sender, EventArgs e)
        {
            _form.Visible = false;
        }

        private void CommonCatalogFormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Visible = true;
        }
    }
}

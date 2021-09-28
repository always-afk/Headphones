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
    public partial class AddDesignForm : Form
    {
        private readonly Form _form;
        private readonly IDesignService _designService;
        public AddDesignForm(Form form, IDesignService designService)
        {
            InitializeComponent();

            _form = form;
            _designService = designService;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            var des = new Design();
        }
    }
}

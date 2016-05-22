using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Inventory
{
    public partial class FrmEditItem : Form
    {
        private string id;
        public FrmEditItem(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}

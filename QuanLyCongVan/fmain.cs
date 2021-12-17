using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCongVan
{
    public partial class fmain : Form
    {
        public fmain()
        {
            InitializeComponent();
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            this.Hide();
            fquanlingdung qlnd = new fquanlingdung();
            qlnd.ShowDialog();
        }

        private void btnVbdi_Click(object sender, EventArgs e)
        {

        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            fthongke f = new fthongke();
            
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            fdangnhap fdn = new fdangnhap();
            this.Hide();
            fdn.ShowDialog();
        }
    }
}

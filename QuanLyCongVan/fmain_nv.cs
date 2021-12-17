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
    public partial class fmain_nv : Form
    {
        public fmain_nv()
        {
            InitializeComponent();
        }

        private void btnTk_Click(object sender, EventArgs e)
        {

        }
        private void btnQlcv_Click(object sender, EventArgs e)
        {
           fquanlycongvan qlcv = new fquanlycongvan();
            this.Hide();
           qlcv.ShowDialog();
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
           // fthongke tk = new fthongke();
            //tk.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            fdangnhap dn = new fdangnhap();
            dn.ShowDialog();
            this.Hide();
        }
    }
}

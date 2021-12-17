using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCongVan
{

    public partial class fdangnhap : Form
    {
        List<tk> listTk;
        public int loginStatus;
        public fdangnhap()
        {
            InitializeComponent();
            loginStatus = 0;
        }
        public SqlConnection conn = new SqlConnection(@"Data Source=TRANPHAI\SQLEXPRESS;Initial Catalog=QLCongVan_CNPM;Integrated Security=True");
        private void btnLogin_Click(object sender, EventArgs e)
        {
        try
            
            {
                conn.Open();
                tk taikhoan = new tk();
                taikhoan.User = txbUser.Text;
                taikhoan.Pass = txbPass.Text;
                if (txbUser.Text.Trim() == "" || txbPass.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(txbUser.Text.Trim().Length <3 || txbUser.Text.Trim().Length > 64 || txbPass.Text.Trim().Length < 3 || txbPass.Text.Trim().Length > 64)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    listTk = new List<tk>();
                    {
                        new tk() { User = txbUser.Text, Pass = txbPass.Text };
                    }

                    string sql = "SELECT * from QuanLyNguoiDung where Tendangnhap ='" + taikhoan.User + "' and Matkhau = '" + taikhoan.Pass + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dta = cmd.ExecuteReader();

                    if (dta.Read() == true)
                    {
                        loginStatus = dta.GetInt32(4);
                        taikhoan.Quyen = dta.GetInt32(4);
                        if (loginStatus == 0)
                        {
                            fmain frm = new fmain();
                            frm.Show();
                            this.Hide();
                        }
                        else if (loginStatus == 1)
                        {
                            fmain_nv frmnv = new fmain_nv();
                            frmnv.Show();
                            this.Hide();
                        }
                        else if (loginStatus == 2)
                        {
                            fxemcongvan fxem = new fxemcongvan();
                            fxem.Show();
                            this.Hide();
                        }

                    }
                    else
                    {
                        MessageBox.Show("tài khoản không tồn tại", "thông báo");
                    }
                }


            }
           catch 
            {
                MessageBox.Show("Đăng nhập không thành công, xin đăng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
    }
}

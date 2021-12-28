using QuanLyCongVan.DAO;
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
    public partial class fquanlingdung : Form
    {
        
        public fquanlingdung()
        {
            InitializeComponent();
            locationlist();
        }
        Dataprovider provider = new Dataprovider();
        SqlConnection conn = new SqlConnection(@"Data Source=TRANPHAI\SQLEXPRESS;Initial Catalog=QLCongVan_CNPM;Integrated Security=True");
        int flag;
        public void locationlist()
        {

            /*   string query = "SELECT * FROM dbo.QLTK";

               dgvTaiKhoan.DataSource = provider.ExcuteQuery(query);

               SqlDataAdapter sda = new SqlDataAdapter("SELECT * from QuanLyNguoiDung", conn); 
            */

            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * from QuanLyNguoiDung", conn);
            ad.Fill(dt);
            dgvTaiKhoan.Rows.Clear();

            foreach (DataRow data in dt.Rows)
            {
                int aa = dgvTaiKhoan.Rows.Add();

                dgvTaiKhoan.Rows[aa].Cells[0].Value = data["Manguoidung"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[1].Value = data["Tennguoidung"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[2].Value = data["Tendangnhap"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[3].Value = data["Matkhau"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[4].Value = data["Quyen"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[5].Value = data["idPhongban"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[6].Value = data["SDT"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[7].Value = data["Email"].ToString();
            }


        }
        public void locationlist_2(string dk)
        {

            /*   string query = "SELECT * FROM dbo.QLTK";

               dgvTaiKhoan.DataSource = provider.ExcuteQuery(query);

               SqlDataAdapter sda = new SqlDataAdapter("SELECT * from QLTK", conn); 
            */

            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(dk, conn);
            ad.Fill(dt);
            dgvTaiKhoan.Rows.Clear();

            foreach (DataRow data in dt.Rows)
            {
                int aa = dgvTaiKhoan.Rows.Add();
                dgvTaiKhoan.Rows[aa].Cells[0].Value = data["Manguoidung"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[1].Value = data["Tennguoidung"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[2].Value = data["Tendangnhap"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[3].Value = data["Matkhau"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[4].Value = data["Quyen"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[5].Value = data["idPhongban"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[6].Value = data["SDT"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[7].Value = data["Email"].ToString();
            }


        }

        void AnHienBtn(bool dk)
        {
            btnThem.Enabled = dk;
            btnCapNhat.Enabled = dk;
            btnXoa.Enabled = dk;
            btnLuu.Enabled = !dk;
            // btnHuy.Enabled = !dk;
        }
        void Lammoi()
        {
            txtManguoidung.Text = "";
            txtfullname.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
            cbMaphongban.Text = "";
            cbQuyen.Text = "";

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            AnHienBtn(false);

            flag = 0; //Thêm 
            Lammoi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (flag == 0)
            {
                if (txtManguoidung.Text.Trim() == "" ||  txtfullname.Text.Trim() == "" || txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "" || cbQuyen.Text.Trim() == "" || cbMaphongban.Text.Trim() == "" || txtSdt.Text.Trim() == "" || txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtManguoidung.Text.Trim().Length <3 || txtfullname.Text.Trim().Length>64|| txtUsername.Text.Trim().Length <3 || txtUsername.Text.Trim().Length > 64 || txtPassword.Text.Trim().Length <3 || txtPassword.Text.Trim().Length > 64 || txtSdt.Text.Trim().Length < 9 || txtSdt.Text.Trim().Length > 11)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();

                }
                else
                {
                    string sql0 = "SELECT * from QuanLyNguoiDung where Tendangnhap ='" + txtUsername.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql0, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    if (dta.Read() == true)
                    {
                        if (txtUsername.Text == dta.GetString(2))
                        {
                            MessageBox.Show("Trùng UserName");
                        }
                    }
                    else
                    {
                        try
                        {
                            tk tk = new tk();
                            tk.Manguoidung = txtManguoidung.Text;
                            tk.Fullname = txtfullname.Text;
                            tk.User = txtUsername.Text;
                            tk.Pass = txtPassword.Text;
                            tk.Quyen = int.Parse(cbQuyen.Text);
                            tk.Maphongban = cbMaphongban.Text;
                            tk.Sdt = txtSdt.Text;
                            tk.Email = txtEmail.Text;

                            string sql = "INSERT INTO QuanLyNguoiDung (Manguoidung,Tennguoidung,Tendangnhap,Matkhau,Quyen,idPhongban,SDT,Email) VALUES(" + "N" + "'" + tk.Manguoidung + "'" + "," + "N" + "'" + tk.Fullname + "'" + "," + "N" + "'" + tk.User + "',N'" + tk.Pass + "'," + tk.Quyen + ",N" + "'" + tk.Maphongban + "'" + "," + "N" + "'" + tk.Sdt + "'" + "," + "N" + "'" + tk.Email + "'" + ")";
                            provider.InsertQuery(sql);
                            //string query = "SELECT * FROM dbo.QuanLyNguoiDung";

                            //dgvTaiKhoan.DataSource = provider.ExcuteQuery(query);
                            
                        }
                        catch
                        {
                            MessageBox.Show("Trung ID ");
                        }
                    }
                    conn.Close();
                    locationlist();
                }
            }
            else
            {
                tk tk = new tk();
                tk.Fullname = txtfullname.Text;
                tk.User = txtUsername.Text;
                tk.Pass = txtPassword.Text;
                tk.Quyen = int.Parse(cbQuyen.Text);
                tk.Maphongban = cbMaphongban.Text;
                tk.Sdt = txtSdt.Text;
                tk.Email = txtEmail.Text;
                string sql = "UPDATE QuanLyNguoiDung SET Tennguoidung = " + "N" + "'" + tk.Fullname + "'" + "," + "Tendangnhap =" + "N" + "'" + tk.User + "'" + "," + "Matkhau =" + "N'" + tk.Pass + "'" + "," + "Quyen =" + tk.Quyen + ",idPhongban= " + "N" + "'" + tk.Maphongban + "'" + "," + "SDT= " + "N" + "'" + tk.Sdt + "'" + ","+ "Email= " + "N" + "'" + tk.Email +"'"+ " WHERE Tendangnhap =" + "N'" + tk.User + "'";

                provider.InsertQuery(sql);
                locationlist();
            }
            
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if ((dgvTaiKhoan.SelectedRows.Count < 0) || (txtUsername.Text.Trim() == ""))
            {
                MessageBox.Show("Vui lòng chọn  Văn bản đến bạn muốn sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnHienBtn(true);
            }
            else
            {
                AnHienBtn(false);
                txtManguoidung.Enabled = false;
                txtUsername.Enabled = false;
                flag = 1;//Sửa
                //LamTuoi();
            }
        }
        int dong;

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dong = e.RowIndex;
                txtManguoidung.Text = dgvTaiKhoan.Rows[dong].Cells[0].Value.ToString();
                txtfullname.Text = dgvTaiKhoan.Rows[dong].Cells[1].Value.ToString();
                txtUsername.Text = dgvTaiKhoan.Rows[dong].Cells[2].Value.ToString();
                txtPassword.Text = dgvTaiKhoan.Rows[dong].Cells[3].Value.ToString();
                cbQuyen.Text = dgvTaiKhoan.Rows[dong].Cells[4].Value.ToString();
                cbMaphongban.Text = dgvTaiKhoan.Rows[dong].Cells[5].Value.ToString();
                txtSdt.Text = dgvTaiKhoan.Rows[dong].Cells[6].Value.ToString();
                txtEmail.Text = dgvTaiKhoan.Rows[dong].Cells[7].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if ((dgvTaiKhoan.SelectedRows.Count < 0) || (txtManguoidung.Text.Trim() == ""))
            {
                MessageBox.Show("Vui lòng chọn  Văn bản đến muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult kq = MessageBox.Show("Bạn có thực sư muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (System.Windows.Forms.DialogResult.Yes == kq)
                {
                    try
                    {
                        tk tk = new tk();
                        tk.Manguoidung = txtManguoidung.Text;
                        string sql = "DELETE FROM QuanLyNguoiDung WHERE  Manguoidung = " + "'" + tk.Manguoidung + "'";
                        provider.InsertQuery(sql);
                        locationlist();
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

             
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtPassword.Enabled = true;
            Lammoi();
            AnHienBtn(true);
        }


        public void Search(string coloum, string condition)
        {
            DataTable dt = new DataTable();
            //string sql = "SELECT * from CongVanDi where" + coloum + "LIKE" + "'%" + condition + "%'";
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * from QuanLyNguoiDung where " + coloum + " LIKE " + " '%" + condition + "%'", conn);
            ad.Fill(dt);
            dgvTaiKhoan.Rows.Clear();
            foreach (DataRow data in dt.Rows)
            {
                int aa = dgvTaiKhoan.Rows.Add();
                dgvTaiKhoan.Rows[aa].Cells[0].Value = data["Manguoidung"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[1].Value = data["Tennguoidung"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[2].Value = data["Tendangnhap"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[3].Value = data["Matkhau"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[4].Value = data["Quyen"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[5].Value = data["idPhongban"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[6].Value = data["SDT"].ToString();
                dgvTaiKhoan.Rows[aa].Cells[7].Value = data["Email"].ToString();
            }


        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cbSearch.Text == "" || txtSearch.Text == "")
            {
                locationlist();
            }
            else if (cbSearch.Text == "Quyen")
            {
                string condition = "SELECT * from QuanLyNguoiDung where Quyen =" + txtSearch.Text;
                locationlist_2(condition);
            }
            else { Search(cbSearch.Text, txtSearch.Text); }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            fmain f = new fmain();
            this.Hide();
            f.ShowDialog();
        }
        void LoadCombo_phongban()
        {
            conn.Open();
            var cmd = new SqlCommand("select * from PhongBan", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbMaphongban.DisplayMember = "idPhongban";
            cbMaphongban.DataSource = dt;

            txtTenphongban.DataBindings.Add(new Binding("Text", cbMaphongban.DataSource, "Tenphongban"));

            conn.Close();
        }
        void LoadCombo_quyen()
        {
            conn.Open();
            var cmd = new SqlCommand("select * from Quyen", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbQuyen.DisplayMember = "MaQuyen";
            cbQuyen.DataSource = dt;

            txtQuyen.DataBindings.Add(new Binding("Text", cbQuyen.DataSource, "TenQuyen"));

            conn.Close();
        }
        private void fquanlingdung_Load(object sender, EventArgs e)
        {
            LoadCombo_phongban();
            LoadCombo_quyen();
        }
    }
}

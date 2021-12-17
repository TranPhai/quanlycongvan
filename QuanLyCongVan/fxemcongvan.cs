using QuanLyCongVan.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCongVan
{
    public partial class fxemcongvan : Form
    {
        public fxemcongvan()
        {
            InitializeComponent();
        }
        Dataprovider provider = new Dataprovider();
        SqlConnection conn = new SqlConnection(@"Data Source=TRANPHAI\SQLEXPRESS;Initial Catalog=QLCongVan_CNPM;Integrated Security=True");

        public void locationlist()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("select * from Congvanden" + " where  Madonvinhan = '" +  cbMadvnhan.Text + "'" , conn);
            ad.Fill(dt);
            dtgvVanban.Rows.Clear();
            foreach (DataRow data in dt.Rows)
            {
                int aa = dtgvVanban.Rows.Add();

                dtgvVanban.Rows[aa].Cells[0].Value = data["id"].ToString();
                dtgvVanban.Rows[aa].Cells[1].Value = data["SoCv"].ToString();
                dtgvVanban.Rows[aa].Cells[2].Value = data["idLoaiCV"].ToString();
                dtgvVanban.Rows[aa].Cells[3].Value = data["Chude"].ToString();
                dtgvVanban.Rows[aa].Cells[4].Value = data["Noiphathanh"].ToString();
                dtgvVanban.Rows[aa].Cells[5].Value = data["Madonvinhan"].ToString();
                dtgvVanban.Rows[aa].Cells[6].Value = data["Ngaynhan"].ToString();
                dtgvVanban.Rows[aa].Cells[7].Value = data["Ngayluu"].ToString();
                dtgvVanban.Rows[aa].Cells[8].Value = data["Trichyeu"].ToString();
                dtgvVanban.Rows[aa].Cells[9].Value = data["Nguoiky"].ToString();
                dtgvVanban.Rows[aa].Cells[10].Value = data["Filetaptin"].ToString();
                dtgvVanban.Rows[aa].Cells[11].Value = data["DoKhan"].ToString();
                dtgvVanban.Rows[aa].Cells[12].Value = data["Nguoiduyet"].ToString();
                dtgvVanban.Rows[aa].Cells[13].Value = data["TinhTrang"].ToString();
                dtgvVanban.Rows[aa].Cells[14].Value = data["Manguoidung"].ToString();
                dtgvVanban.Rows[aa].Cells[15].Value = data["SoTrang"].ToString();
                dtgvVanban.Rows[aa].Cells[16].Value = data["DoMat"].ToString();
            }


        }

        // cong van di 
        public void locationlist_vbd()
        {

            DataTable dt = new DataTable();
            // string sql = "select * from Congvandi" + " where Ngaynhan between '" + date1 + "'" + "and" + "'" + date2 + "'";
            SqlDataAdapter ad = new SqlDataAdapter("select * from Congvandi" + " where  Madonvinhan = '" + cbMadvnhan.Text + "'", conn);
            ad.Fill(dt);
            dtgvVanban.Rows.Clear();
            foreach (DataRow data in dt.Rows)
            {
                int aa = dtgvVanban.Rows.Add();

                dtgvVanban_vbd.Rows[aa].Cells[0].Value = data["id"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[1].Value = data["SoCv"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[2].Value = data["idLoaiCV"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[3].Value = data["Chude"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[4].Value = data["Madonvinhan"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[5].Value = data["Ngaygui"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[6].Value = data["Ngayluu"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[7].Value = data["Trichyeu"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[8].Value = data["Nguoiky"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[9].Value = data["Filetaptin"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[10].Value = data["DoKhan"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[11].Value = data["Nguoiduyet"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[12].Value = data["TinhTrang"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[13].Value = data["Manguoidung"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[14].Value = data["SoTrang"].ToString();
                dtgvVanban_vbd.Rows[aa].Cells[15].Value = data["DoMat"].ToString();
            }


        }

        void LoadCombobox_Donvi()
        {
            conn.Open();
            var cmd = new SqlCommand("select * from DonVi", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbMadvnhan.DisplayMember = "Madonvi";
            cbMadvnhan.DataSource = dt;
            txtMadonvinhan.DataBindings.Add(new Binding("Text", cbMadvnhan.DataSource, "Tendonvi"));
            conn.Close();
        }
        private void fxemcongvan_Load(object sender, EventArgs e)
        {
            LoadCombobox_Donvi();
            //LoadCombobox_loaivb();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if(cbLoaivb.Text =="" || cbMadvnhan.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(cbLoaivb.Text == "Công văn đến")
            {
                dtgvVanban.Visible = true;
                dtgvVanban_vbd.Visible = false;
                locationlist();
            }
            else if (cbLoaivb.Text == "Công văn đi")
            {
                dtgvVanban.Visible = false;
                dtgvVanban_vbd.Visible = true;
                dtgvVanban_vbd.Location = dtgvVanban.Location;
                locationlist_vbd();
            }
            else if (cbLoaivb.Text == "Tất cả")
            {
                dtgvVanban.Visible = true;
                dtgvVanban_vbd.Visible = true;
                dtgvVanban_vbd.Location = new Point(13, 420);
                
                locationlist_vbd();
                locationlist();
            }
        }
        int dong;
        private void dtgvVanban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dong = e.RowIndex;
                txtfile.Text = dtgvVanban.Rows[dong].Cells[10].Value.ToString();

            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtfile.Text == "") { MessageBox.Show("Nhập địa chỉ file"); }
            else
            {
                string url = txtfile.Text.Replace("D:\\", "");
                string file = @"D:\" + url;
                // string file1 = @"";
                Process.Start(file);
            }
        }
    }
}

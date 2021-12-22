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
    public partial class fthongke : Form
    {
        public fthongke()
        {
            InitializeComponent();
        }
        Dataprovider provider = new Dataprovider();
        SqlConnection conn = new SqlConnection(@"Data Source=TRANPHAI\SQLEXPRESS;Initial Catalog=QLCongVan_CNPM;Integrated Security=True");
        public void locationlist()
        {
            string date1 = dtpFrom.Value.ToString("yyyy - MM - dd");
            string date2 = dtpTo.Value.ToString("yyyy - MM - dd");
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("select * from Congvanden" + " where  Ngaynhan between '" + date1 + "'" + "and" + "'" + date2  + "'", conn);
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
            string date1 = dtpFrom.Value.ToString("yyyy - MM - dd");
            string date2 = dtpTo.Value.ToString("yyyy - MM - dd");
            SqlDataAdapter ad = new SqlDataAdapter("select * from CongVanDi" + " where  Ngaygui between '" + date1 + "'" + "and" + "'" + date2 + "'", conn);
            
            DataTable dt = new DataTable();
            //SqlDataAdapter ad = new SqlDataAdapter("SELECT * from CongVanDi", conn);
            ad.Fill(dt);
            dtgvVanban_vbd.Rows.Clear();
            foreach (DataRow data in dt.Rows)
            {
                int aa = dtgvVanban_vbd.Rows.Add();

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




        private void btnShow_Click(object sender, EventArgs e)
        {
            lbDatetime.Text = " Từ ngày " + dtpFrom.Value + " Đến ngày " + dtpTo.Value;
            if (cbLoaicongvan.Text =="Công văn đến")
            {
                lbTitle.Text = "Danh sách công văn đến";
                dtgvVanban.Visible = true;
                dtgvVanban_vbd.Visible = false;

                lbSum.Visible = true;
                lbTong.Visible = true;
                lbSum_vbd.Visible = false;
                lbTong_vbd.Visible = false;

                locationlist();
                loadSum();
            }
            else if (cbLoaicongvan.Text == "Công văn đi")
            {
                dtgvVanban_vbd.Visible = true;
                dtgvVanban.Visible = false;

                lbSum.Visible = false;
                lbTong.Visible = false;
                lbSum_vbd.Visible = true;
                lbTong_vbd.Visible = true;

                lbTitle.Text = "Danh sách công văn đi";
                dtgvVanban_vbd.Location = dtgvVanban.Location;
                lbSum_vbd.Location = lbSum.Location;
                lbTong_vbd.Location = lbTong.Location;
                loadSum_vbd();
                locationlist_vbd();
            }
            else if(cbLoaicongvan.Text == "Tất cả")
            {
                lbTitle.Text = "Danh sách công văn đến/đi";
                dtgvVanban.Visible = true;
                dtgvVanban_vbd.Visible = true;

                lbSum.Visible = true;
                lbTong.Visible = true;
                lbSum_vbd.Visible = true;
                lbTong_vbd.Visible = true;
                dtgvVanban_vbd.Location= new Point(35, 378);
                lbSum_vbd.Location = new Point(60, 560);
                lbTong_vbd.Location = new Point(150, 560);
                locationlist_vbd();
                locationlist();
                loadSum();
                loadSum_vbd();

            }
        }
        void loadSum()
        {
            conn.Open();
            string date1 = dtpFrom.Value.ToString("yyyy - MM - dd");
            string date2 = dtpTo.Value.ToString("yyyy - MM - dd");
 
            string sql="select count(id) as Sum from CongVanDen " + " where  Ngaynhan between '" + date1 + "'" + "and" + "'" + date2 + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {
                try { 
                    int a = dta.GetInt32(0);
                    lbTong.Text = a.ToString();
                    }
                catch
                {

                }
            }
            conn.Close();
        }
        void loadSum_vbd()
        {
            conn.Open();
            string date1 = dtpFrom.Value.ToString("yyyy - MM - dd");
            string date2 = dtpTo.Value.ToString("yyyy - MM - dd");

            string sql = "select count(id) as Sum from CongVanDi " + " where  Ngaygui between '" + date1 + "'" + "and" + "'" + date2 + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {
                try
                {
                    int a = dta.GetInt32(0);
                    lbTong_vbd.Text = a.ToString();
                }
                catch
                {

                }
            }
            conn.Close();
        }

        private void fthongke_Load(object sender, EventArgs e)
        {

        }
    }
}

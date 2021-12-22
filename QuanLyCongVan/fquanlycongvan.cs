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
    public partial class fquanlycongvan : Form
    {
        public fquanlycongvan()
        {
            InitializeComponent();
            locationlist();
            locationlist_vbd();


        }

        private void quanlycongvan_Load(object sender, EventArgs e)
        {

        }
        int flag;
        Dataprovider provider = new Dataprovider();
        SqlConnection conn = new SqlConnection(@"Data Source=TRANPHAI\SQLEXPRESS;Initial Catalog=QLCongVan_CNPM;Integrated Security=True");

        public void locationlist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * from CongVanDen", conn);
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
        public void locationlistWithCondition(string condition)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(condition, conn);
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
        void AnHienBtn(bool dk)
        {
            btnThem.Enabled = dk;
            btnSua.Enabled = dk;
            btnXoa.Enabled = dk;
            btnLuu.Enabled = !dk;
            //btnHuy.Enabled = !dk;
        }
        public void Lammoi()
        {
            txtMa.Text = "";
            txbKihieu.Text = "";
            cbMadvnhan.Text = "";
            cbNoibh.Text = "";
            cbTinhtrang.Text = "";

            cbLoaivb.Text = "";
            txbChude.Text = "";
            txtNguoiky.Text = "";
            txtNguoiduyet.Text = "";
            cbManguoidung.Text = "";

            cbDokhan.Text = "";
            dtpNgaynhan.Text = "";
            dtpNgayluu.Text = "";
            numSotrang.Text = "";
            cbDomat.Text = "";

            txtfile.Text = "";
            txtTrichyeu.Text = "";


        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            AnHienBtn(false);

            flag = 0; //Thêm 
            Lammoi();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if
              (
            txbKihieu.Text == "" ||
            cbMadvnhan.Text == "" ||
            cbNoibh.Text == "" ||
            cbTinhtrang.Text == "" ||

            cbLoaivb.Text == "" ||
            txbChude.Text == "" ||
            txtNguoiky.Text == "" ||
            txtNguoiduyet.Text == "" ||
            cbManguoidung.Text == "" ||

            cbDokhan.Text == "" ||
            dtpNgaynhan.Text == "" ||
            dtpNgayluu.Text == "" ||
            numSotrang.Text == "" ||
            cbDomat.Text == "" ||

            txtfile.Text == "" ||
            txtTrichyeu.Text == "" 
                )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                if (flag == 0)
                {
                    /*
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter("Select id from CongVanDen where id=" + int.Parse(txtMa.Text), conn);
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã  văn bản đến đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    */
                    {

                        // cmd.CommandText = "insert into Congvanden(id,Kihieu,Kieucongvan,Loaicongvan,Chude,Noiphathanh,Ngayphathanh,Ngaynhan,Ngayluu,Trichyeu,Nguoiky,Filetaptin) values('"
                        string sql = "insert into CongVanDen(SoCv,idLoaiCV,Chude,Noiphathanh,Madonvinhan,Ngaynhan,Ngayluu,Trichyeu,Nguoiky,Filetaptin,DoKhan,Nguoiduyet,TinhTrang,Manguoidung,SoTrang,DoMat) values("
                           
                           + "N'" + txbKihieu.Text.ToString()
                           + "',N'" + cbLoaivb.Text.ToString()
                           + "',N'" + txbChude.Text.ToString()
                           + "',N'" + cbNoibh.Text.ToString()
                           + "',N'" + cbMadvnhan.Text.ToString()
                           + "','" + dtpNgaynhan.Value.ToString("yyyy-MM-dd")
                           + "','" + dtpNgayluu.Value.ToString("yyyy - MM - dd")
                           + "',N'" + txtTrichyeu.Text.ToString()
                           + "',N'" + txtNguoiky.Text.ToString()
                           + "',N'" + txtfile.Text.ToString() 
                           + "',N'" + cbDokhan.Text.ToString()
                           + "',N'" + txtNguoiduyet.Text.ToString()
                           + "',N'" + cbTinhtrang.Text.ToString()
                           + "',N'" + cbManguoidung.Text.ToString()
                           + "'," + Decimal.ToInt32(numSotrang.Value)
                            + ",N'" + cbDomat.Text.ToString()
                           + "')";
                        // cmd.Connection.Open();
                        // cmd.ExecuteNonQuery();
                        //cmd.Connection.Close();
                        provider.InsertQuery(sql);
                    }

                }
                else
                {
                    string sql = "Update Congvanden set SoCv = " + "N'" + txbKihieu.Text.ToString()
                            + "',idLoaiCV=N'" + cbLoaivb.Text.ToString()
                            + "',Chude=N'" + txbChude.Text.ToString()
                            + "',Noiphathanh=N'" + cbNoibh.Text.ToString()
                            + "',Madonvinhan=N'" + cbMadvnhan.Text.ToString()
                            + "',Ngaynhan=N'" + dtpNgaynhan.Value.ToString("yyyy-MM-dd")
                            + "',Ngayluu=N'" + dtpNgayluu.Value.ToString("yyyy - MM - dd")
                            + "',Trichyeu=N'" + txtTrichyeu.Text.ToString()
                            + "',Nguoiky=N'" + txtNguoiky.Text.ToString()
                            + "',Filetaptin=N'" + txtfile.Text.ToString()

                            + "',DoKhan=N'" + cbDokhan.Text.ToString()
                            + "',Nguoiduyet=N'" + txtNguoiduyet.Text.ToString()
                            + "',TinhTrang=N'" + cbTinhtrang.Text.ToString()
                            + "',Manguoidung=N'" + cbManguoidung.Text.ToString()
                            + "',SoTrang=N'" + Decimal.ToInt32(numSotrang.Value)
                            + "',DoMat=N'" + cbDomat.Text.ToString()
                            + "'where id='" + txtMa.Text.ToString() + "'";
                    // cmd.Connection.Open();
                    // cmd.ExecuteNonQuery();
                    //cmd.Connection.Close();
                    provider.InsertQuery(sql);

                }
            }
            locationlist();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if ((dtgvVanban.SelectedRows.Count < 0) || (txtMa.Text.Trim() == ""))
            {
                MessageBox.Show("Vui lòng chọn  Văn bản đến bạn muốn sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnHienBtn(true);
            }
            else
            {
                AnHienBtn(false);

                txtMa.Enabled = false;
                flag = 1;//Sửa
                //LamTuoi();
            }
        }
        int dong;
        private void dtgvVanbanden_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dong = e.RowIndex;

                txtMa.Text = dtgvVanban.Rows[dong].Cells[0].Value.ToString();
                txbKihieu.Text = dtgvVanban.Rows[dong].Cells[1].Value.ToString();
                cbLoaivb.Text = dtgvVanban.Rows[dong].Cells[2].Value.ToString();
                txbChude.Text = dtgvVanban.Rows[dong].Cells[3].Value.ToString();
                cbNoibh.Text = dtgvVanban.Rows[dong].Cells[4].Value.ToString();
                cbMadvnhan.Text = dtgvVanban.Rows[dong].Cells[5].Value.ToString();
                dtpNgaynhan.Text = dtgvVanban.Rows[dong].Cells[6].Value.ToString();
                dtpNgayluu.Text = dtgvVanban.Rows[dong].Cells[7].Value.ToString();
                txtTrichyeu.Text = dtgvVanban.Rows[dong].Cells[8].Value.ToString();
                txtNguoiky.Text = dtgvVanban.Rows[dong].Cells[9].Value.ToString();
                txtfile.Text = dtgvVanban.Rows[dong].Cells[10].Value.ToString();
                cbDokhan.Text = dtgvVanban.Rows[dong].Cells[11].Value.ToString();
                txtNguoiduyet.Text = dtgvVanban.Rows[dong].Cells[12].Value.ToString();
                cbTinhtrang.Text = dtgvVanban.Rows[dong].Cells[13].Value.ToString();
                cbManguoidung.Text = dtgvVanban.Rows[dong].Cells[14].Value.ToString();
                numSotrang.Text = dtgvVanban.Rows[dong].Cells[15].Value.ToString();
                cbDomat.Text = dtgvVanban.Rows[dong].Cells[16].Value.ToString();


            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Lammoi();
            AnHienBtn(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            fmain_nv fnv = new fmain_nv();
            this.Hide();
            fnv.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if ((dtgvVanban.SelectedRows.Count < 0) || (txtMa.Text.Trim() == ""))
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
                        string sql = "DELETE FROM CongVanDen WHERE id= '" + txtMa.Text.ToString() + "'";
                        provider.InsertQuery(sql);
                        locationlist();
                        Lammoi();
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Văn bản nội bộ";
            open.Filter = "|*.doc;*.pdf;*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {

                txtfile.Text = open.FileName;
            }
        }
        void LoadCombobox_loaivb()
        {
            conn.Open();
            var cmd = new SqlCommand("select * from LoaiCongVan", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbLoaivb.DisplayMember = "idLoaiCV";
            cbLoaivb.DataSource = dt;
            txtLoaicv.DataBindings.Add(new Binding("Text", cbLoaivb.DataSource, "TenloaiCV"));
            cbLoaivb_vbd.DisplayMember = "idLoaiCV";
            cbLoaivb_vbd.DataSource = dt;
            txtLoaicv_vbd.DataBindings.Add(new Binding("Text", cbLoaivb_vbd.DataSource, "TenloaiCV"));
            conn.Close();
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
           
            //vanbandi
            cbMadvnhan_vbd.DisplayMember = "Madonvi";
            cbMadvnhan_vbd.DataSource = dt;
            
            txtMadonvinhan_vbd.DataBindings.Add(new Binding("Text", cbMadvnhan_vbd.DataSource, "Tendonvi"));
            conn.Close();
        }
        void LoadCombobox_noibanhanh()
        {
            conn.Open();
            var cmd = new SqlCommand("select * from CoQuanNgoai", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();

            cbNoibh.DisplayMember = "Macoquan";
            cbNoibh.DataSource = dt;

            txtNoibanhanh.DataBindings.Add(new Binding("Text", cbNoibh.DataSource, "Tencoquan"));

        }
        void LoadCombobox_thuthu()
        {
            conn.Open();
            var cmd = new SqlCommand("select * from QuanLyNguoiDung where Quyen = 1 ", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbManguoidung.DisplayMember = "Manguoidung";
            cbManguoidung.DataSource = dt;
            //công văn đi
            cbManguoidung_vbd.DisplayMember = "Manguoidung";
            cbManguoidung_vbd.DataSource = dt;
            conn.Close();
        }
        private void fquanlycongvan_Load(object sender, EventArgs e)
        {
            LoadCombobox_loaivb();
            LoadCombobox_Donvi();
            LoadCombobox_thuthu();
            LoadCombobox_noibanhanh();
        }

        public void Search(string coloum, string condition)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * from CongVanDen where" + coloum + "LIKE" + "'%" + condition + "%'";
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * from CongVanDen where " + coloum +" LIKE " +" '%"+ condition+"%'", conn);
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbSearch.Text == "" || txtSearch.Text == "")
            {
                locationlist();
            }
            else if (cbSearch.Text == "SoTrang")
            {
                string condition = "SELECT * from CongVanDen where SoTrang =" + txtSearch.Text;
                locationlistWithCondition(condition);
            }
            else { Search(cbSearch.Text, txtSearch.Text); }
        }





        // Văn bản đi
        public void locationlist_vbd()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * from CongVanDi", conn);
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
        public void locationlistWithCondition_vbd(string condition)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(condition, conn);
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
        void AnHienBtn_vbd(bool dk)
        {
            btnThem_vbd.Enabled = dk;
            btnSua_vbd.Enabled = dk;
            btnXoa_vbd.Enabled = dk;
            btnLuu_vbd.Enabled = !dk;
            //btnHuy.Enabled = !dk;
        }
        public void Lammoi_vbd()
        {
            txtMa_vbd.Text = "";
            txbKihieu_vbd.Text = "";
            cbMadvnhan_vbd.Text = "";
            cbTinhtrang_vbd.Text = "";

            cbLoaivb_vbd.Text = "";
            txbChude_vbd.Text = "";
            txtNguoiky_vbd.Text = "";
            txtNguoiduyet_vbd.Text = "";
            cbManguoidung_vbd.Text = "";

            cbDokhan_vbd.Text = "";
            dtpNgaynhan_vbd.Text = "";
            dtpNgayluu_vbd.Text = "";
            numSotrang_vbd.Text = "";
            cbDomat_vbd.Text = "";

            txtfile_vbd.Text = "";
            txtTrichyeu_vbd.Text = "";


        }
        private void btnThem_Click_vbd(object sender, EventArgs e)
        {
            AnHienBtn_vbd(false);

            flag = 0; //Thêm 
            Lammoi_vbd();

        }

        private void btnLuu_Click_vbd(object sender, EventArgs e)
        {

            if
              (
            txbKihieu_vbd.Text == "" ||
            cbMadvnhan_vbd.Text == "" ||
            cbTinhtrang_vbd.Text == "" ||

            cbLoaivb_vbd.Text == "" ||
            txbChude_vbd.Text == "" ||
            txtNguoiky_vbd.Text == "" ||
            txtNguoiduyet_vbd.Text == "" ||
            cbManguoidung_vbd.Text == "" ||

            cbDokhan_vbd.Text == "" ||
            dtpNgaynhan_vbd.Text == "" ||
            dtpNgayluu_vbd.Text == "" ||
            numSotrang_vbd.Text == "" ||
            cbDomat_vbd.Text == "" ||

            txtfile_vbd.Text == "" ||
            txtTrichyeu_vbd.Text == ""
                )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                if (flag == 0)
                {
                    /*
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter("Select id from CongVanDi where id=" + int.Parse(txtMa_vbd.Text), conn);
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã  văn bản đi đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    */
                    {

                        // cmd.CommandText = "insert into Congvanden(id,Kihieu,Kieucongvan,Loaicongvan,Chude,Noiphathanh,Ngayphathanh,Ngaynhan,Ngayluu,Trichyeu,Nguoiky,Filetaptin) values('"
                        string sql = "insert into CongVanDi(SoCv,idLoaiCV,Chude,Madonvinhan,Ngaygui,Ngayluu,Trichyeu,Nguoiky,Filetaptin,DoKhan,Nguoiduyet,TinhTrang,Manguoidung,SoTrang,DoMat) values("
                           + "N'" + txbKihieu_vbd.Text.ToString()
                           + "',N'" + cbLoaivb_vbd.Text.ToString()
                           + "',N'" + txbChude_vbd.Text.ToString()
                           + "',N'" + cbMadvnhan_vbd.Text.ToString()
                           + "','" + dtpNgaynhan_vbd.Value.ToString("yyyy-MM-dd")
                           + "','" + dtpNgayluu_vbd.Value.ToString("yyyy - MM - dd")
                           + "',N'" + txtTrichyeu_vbd.Text.ToString()
                           + "',N'" + txtNguoiky_vbd.Text.ToString()
                           + "',N'" + txtfile_vbd.Text.ToString()
                           + "',N'" + cbDokhan_vbd.Text.ToString()
                           + "',N'" + txtNguoiduyet_vbd.Text.ToString()
                           + "',N'" + cbTinhtrang_vbd.Text.ToString()
                           + "',N'" + cbManguoidung_vbd.Text.ToString()
                           + "'," + Decimal.ToInt32(numSotrang_vbd.Value)
                            + ",N'" + cbDomat_vbd.Text.ToString()
                           + "')";
                        // cmd.Connection.Open();
                        // cmd.ExecuteNonQuery();
                        //cmd.Connection.Close();
                        provider.InsertQuery(sql);
                    }

                }
                else
                {
                    string sql = "Update Congvandi set SoCv = " + "N'" + txbKihieu_vbd.Text.ToString()
                            + "',idLoaiCV=N'" + cbLoaivb_vbd.Text.ToString()
                            + "',Chude=N'" + txbChude_vbd.Text.ToString()
                            + "',Madonvinhan=N'" + cbMadvnhan_vbd.Text.ToString()
                            + "',Ngaynhan=N'" + dtpNgaynhan_vbd.Value.ToString("yyyy-MM-dd")
                            + "',Ngayluu=N'" + dtpNgayluu_vbd.Value.ToString("yyyy - MM - dd")
                            + "',Trichyeu=N'" + txtTrichyeu_vbd.Text.ToString()
                            + "',Nguoiky=N'" + txtNguoiky_vbd.Text.ToString()
                            + "',Filetaptin=N'" + txtfile_vbd.Text.ToString()

                            + "',DoKhan=N'" + cbDokhan_vbd.Text.ToString()
                            + "',Nguoiduyet=N'" + txtNguoiduyet_vbd.Text.ToString()
                            + "',TinhTrang=N'" + cbTinhtrang_vbd.Text.ToString()
                            + "',Manguoidung=N'" + cbManguoidung_vbd.Text.ToString()
                            + "',SoTrang=N'" + Decimal.ToInt32(numSotrang_vbd.Value)
                            + "',DoMat=N'" + cbDomat_vbd.Text.ToString()
                            + "'where id='" + txtMa_vbd.Text.ToString() + "'";
                    // cmd.Connection.Open();
                    // cmd.ExecuteNonQuery();
                    //cmd.Connection.Close();
                    provider.InsertQuery(sql);

                }
            }
            locationlist_vbd();
        }

        private void btnSua_Click_vbd(object sender, EventArgs e)
        {
            if ((dtgvVanban.SelectedRows.Count < 0) || (txtMa_vbd.Text.Trim() == ""))
            {
                MessageBox.Show("Vui lòng chọn  Văn bản đến bạn muốn sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnHienBtn_vbd(true);
            }
            else
            {
                AnHienBtn_vbd(false);

                txtMa_vbd.Enabled = false;
                flag = 1;//Sửa
                //LamTuoi();
            }
        }
        int dong_vbd;
        private void dtgvVanbanden_CellClick_vbd(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dong_vbd = e.RowIndex;

                txtMa_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[0].Value.ToString();
                txbKihieu_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[1].Value.ToString();
                cbLoaivb_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[2].Value.ToString();
                txbChude_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[3].Value.ToString();
                cbMadvnhan_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[4].Value.ToString();
                dtpNgaynhan_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[5].Value.ToString();
                dtpNgayluu_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[6].Value.ToString();
                txtTrichyeu_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[7].Value.ToString();
                txtNguoiky_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[8].Value.ToString();
                txtfile_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[9].Value.ToString();
                cbDokhan_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[10].Value.ToString();
                txtNguoiduyet_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[11].Value.ToString();
                cbTinhtrang_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[12].Value.ToString();
                cbManguoidung_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[13].Value.ToString();
                numSotrang_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[14].Value.ToString();
                cbDomat_vbd.Text = dtgvVanban_vbd.Rows[dong_vbd].Cells[15].Value.ToString();


            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click_vbd(object sender, EventArgs e)
        {
            Lammoi_vbd();
            AnHienBtn_vbd(true);
        }

        private void btnThoat_Click_vbd(object sender, EventArgs e)
        {
            fmain_nv fnv = new fmain_nv();
            this.Hide();
            fnv.ShowDialog();
        }

        private void btnXoa_Click_vbd(object sender, EventArgs e)
        {
            if ((dtgvVanban.SelectedRows.Count < 0) || (txtMa_vbd.Text.Trim() == ""))
            {
                MessageBox.Show("Vui lòng chọn  Văn bản đi muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult kq = MessageBox.Show("Bạn có thực sư muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (System.Windows.Forms.DialogResult.Yes == kq)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM CongVanDi WHERE id= '" + txtMa_vbd.Text.ToString() + "'";
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        locationlist_vbd();
                        Lammoi_vbd();
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnfile_Click_vbd(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Văn bản đi";
            open.Filter = "|*.doc;*.pdf;*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {

                txtfile_vbd.Text = open.FileName;
            }
        }

        public void Search_vbd(string coloum, string condition)
        {
            DataTable dt = new DataTable();
            //string sql = "SELECT * from CongVanDi where" + coloum + "LIKE" + "'%" + condition + "%'";
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * from CongVanDi where " + coloum + " LIKE " + " '%" + condition + "%'", conn);
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
                dtgvVanban_vbd.Rows[aa].Cells[5].Value = data["Ngaynhan"].ToString();
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
        private void btnSearch_Click_vbd(object sender, EventArgs e)
        {
            if (cbSearch.Text == "" || txtSearch.Text == "")
            {
                locationlist_vbd();
            }
            else if (cbSearch_vbd.Text == "SoTrang")
            {
                string condition = "SELECT * from CongVanDi where SoTrang =" + txtSearch_vbd.Text;
                locationlistWithCondition_vbd(condition);
            }
            else { Search(cbSearch_vbd.Text, txtSearch_vbd.Text); }
        }




        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtfile.Text == "") { MessageBox.Show("Nhập địa chỉ file"); }
            else {
                string url = txtfile.Text.Replace("D:\\", "");
                string file = @"D:\" + url;
                // string file1 = @"";
                Process.Start(file);
            }

        }

        private void btnOpen_cvd_Click(object sender, EventArgs e)
        {
            if (txtfile.Text == "") { MessageBox.Show("Nhập địa chỉ file"); }
            else {
                string url = txtfile_vbd.Text.Replace("D:\\", "");
                string file = @"D:\" + url;
                // string file1 = @"";
                Process.Start(file);
            }
            
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            fmail fmail = new fmail();
            this.Hide();
            fmail.ShowDialog();
        }

    }
}

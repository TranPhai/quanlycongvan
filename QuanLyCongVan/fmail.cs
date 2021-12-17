using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace QuanLyCongVan
{
    public partial class fmail : Form
    {
        public fmail()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=TRANPHAI\SQLEXPRESS;Initial Catalog=QLCongVan_CNPM;Integrated Security=True");
        void LoadCombobox_Macongvan()
        {
            conn.Open();
            var cmd = new SqlCommand("select id,Madonvinhan,Filetaptin,Diachi,Email from CongVanDi,CoQuanNgoai where CongVanDi.Madonvinhan=CoQuanNgoai.Macoquan", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbMacongvan.DisplayMember = "id";
            cbMacongvan.DataSource = dt;
            txtFile.DataBindings.Add(new Binding("Text", cbMacongvan.DataSource, "Filetaptin"));
            txtDiachi.DataBindings.Add(new Binding("Text", cbMacongvan.DataSource, "Diachi"));
            txtEmailNguoinhan.DataBindings.Add(new Binding("Text", cbMacongvan.DataSource, "Email"));
            conn.Close();
        }
        private void btnGui_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Port = Convert.ToInt32(txtSMPTport.Text.Trim());
                clientDetails.Host = txtSMPTserver.Text.Trim();
               // clientDetails.EnableSsl = cbSSL.Checked;
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential(txtMailnguoigui.Text.Trim(), txtPass.Text.Trim());

                MailMessage mailDetals = new MailMessage();
                mailDetals.From = new MailAddress(txtMailnguoigui.Text.Trim());
                mailDetals.To.Add(txtEmailNguoinhan.Text.Trim());
                mailDetals.Subject = txtTieuDe.Text.Trim();
               // mailDetals.IsBodyHtml = cbSSL.Checked;
                mailDetals.IsBodyHtml = true;
                mailDetals.Body = txtNoidung.Text.Trim();
                string url = txtFile.Text.Replace("D:\\", "");
                mailDetals.Attachments.Add(new Attachment(@"D:\" + url));
                clientDetails.Send(mailDetals);
                MessageBox.Show("Email da dc gui");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void fmail_Load(object sender, EventArgs e)
        {
            LoadCombobox_Macongvan();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongVan
{
    class tk
    {
        private string manguoidung;
        private string fullname;
        private string usename;
        private string pass;
        private int quyen;
        private string maphongban;
        private string sdt;
        private string email;
        public string Manguoidung
        {
            get { return manguoidung; }
            set { manguoidung = value; }
        }
        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
        public string User
        {

            set { usename = value; }
            get { return usename; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public int Quyen
        {
            get { return quyen; }
            set { quyen = value; }
        }
        public string Maphongban
        {
            get { return maphongban; }
            set { maphongban = value; }
        }
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.Model
{
    class ChiTietVatTuObj
    {
        string MaPN, MaPX, MaHang, SLNhap, SLXuat, TonDK;

        public string SLNhap1
        {
            get
            {
                return SLNhap;
            }

            set
            {
                SLNhap = value;
            }
        }

        public string MaPN1
        {
            get
            {
                return MaPN;
            }

            set
            {
                MaPN = value;
            }
        }
        public string MaPX1
        {
            get
            {
                return MaPX;
            }

            set
            {
                MaPX = value;
            }
        }

        public string MaHang1
        {
            get
            {
                return MaHang;
            }

            set
            {
                MaHang = value;
            }
        }

        public string SLXuat1
        {
            get
            {
                return SLXuat;
            }

            set
            {
                SLXuat = value;
            }
        }

        public string TonDK1
        {
            get
            {
                return TonDK;
            }

            set
            {
                TonDK = value;
            }
        }

        public ChiTietVatTuObj() { }
        public ChiTietVatTuObj(string MaPN, string MaPX, string MaHang, string SLNhap, string SLXuat, string TonDK)
        {
            this.MaPN = MaPN;
            this.MaPX = MaPX;
            this.MaHang = MaHang;
            this.SLNhap = SLNhap;
            this.SLXuat = SLXuat;
            this.TonDK = TonDK;
        }
    }
}

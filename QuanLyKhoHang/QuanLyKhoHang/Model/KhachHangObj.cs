using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.Model
{
    class KhachHangObj
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }

        public KhachHangObj() { }
        public KhachHangObj(string maKH, string tenKH, string SDT, string diaChi)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SDT = SDT;
            this.DiaChi = diaChi;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.Model
{
    class HangHoaObj
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string DonViTinh { get; set; }
        public string Ton { get; set; }

        public HangHoaObj() { }
        public HangHoaObj(string maHang, string tenHang, string donViTinh, string ton)
        {
            this.MaHang = maHang;
            this.TenHang = tenHang;
            this.DonViTinh = donViTinh;
            this.Ton = ton;
        }
    }
}

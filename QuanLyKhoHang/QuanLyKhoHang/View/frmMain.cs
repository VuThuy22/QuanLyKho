using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho11.View;

namespace QuanLyKhoHang.View
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuNhap1 m = new PhieuNhap1();
            m.Show();
            this.Hide();
        }

        private void phiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuXuat m = new frmPhieuXuat();
            m.Show();
            this.Hide();
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang m = new frmKhachHang();
            m.Show();
            this.Hide();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaCungCap m = new frmNhaCungCap();
            m.Show();
            this.Hide();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHangHoa m = new frmHangHoa();
            m.Show();
            this.Hide();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho m = new frmKho();
            m.Show();
            this.Hide();
        }
    }
}

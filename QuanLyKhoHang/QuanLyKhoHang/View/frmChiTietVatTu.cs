using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoHang.Controller;
using QuanLyKhoHang.Model;

namespace QuanLyKhoHang.View
{
    public partial class frmChiTietVatTu : Form
    {
        public frmChiTietVatTu()
        {
            InitializeComponent();
        }
        ChiTietVatTu ctctl = new ChiTietVatTu();
        ChiTietVatTuObj ctobj = new ChiTietVatTuObj();


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void Binding()
        {

            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("Text", dgvChiTiet.DataSource, "MaHang");
            txtMaPN.DataBindings.Clear();
            txtMaPN.DataBindings.Add("Text", dgvChiTiet.DataSource, "MaPN");
            txtMaPX.DataBindings.Clear();
            txtMaPX.DataBindings.Add("Text", dgvChiTiet.DataSource, "MaPX");
            txtSLNhap.DataBindings.Clear();
            txtSLNhap.DataBindings.Add("Text", dgvChiTiet.DataSource, "SLNhap");
            txtSLXuat.DataBindings.Clear();
            txtSLXuat.DataBindings.Add("Text", dgvChiTiet.DataSource, "SLXuat");
            txtTon.DataBindings.Clear();
            txtTon.DataBindings.Add("Text", dgvChiTiet.DataSource, "TonDK");
        }
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaHang.Text = dgvChiTiet.CurrentRow.Cells["MaHang"].Value.ToString();
                    txtMaPN.Text = dgvChiTiet.CurrentRow.Cells["MaPN"].Value.ToString();
                    txtMaPX.Text = dgvChiTiet.CurrentRow.Cells["MaPX"].Value.ToString();
                    txtSLNhap.Text = dgvChiTiet.CurrentRow.Cells["SLNhap"].Value.ToString();
                    txtSLXuat.Text = dgvChiTiet.CurrentRow.Cells["SLXuat"].Value.ToString();
                    txtTon.Text = dgvChiTiet.CurrentRow.Cells["TonDK"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmChiTietVatTu_Load(object sender, EventArgs e)
        {
            dgvChiTiet.DataSource = ctctl.GetData();
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            Binding();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            frmMain ds = new frmMain();
            this.Hide();
            ds.Show();
        }
    }
}

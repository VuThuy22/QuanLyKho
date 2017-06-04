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
    public partial class frmKhachHang : Form
    {
        KhachHangCtl khctl = new KhachHangCtl();
        KhachHangObj khobj = new KhachHangObj();
        int flag = 0;
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            txtMaKH.Text = dgvKhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
        }
        public void dis_en(bool e)
        {
            txtMaKH.Enabled = e;
            txtTenKH.Enabled = e;
            txtDiaChi.Enabled = e;
            txtSDT.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }
        private void clean()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            // cbbMaNV.Clear();
            txtSDT.Clear();

        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = khctl.GetData();
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dis_en(false);
            LoadData();
        }
        private void GanDuLieu(KhachHangObj kh1obj)
        {
            kh1obj.MaKH = txtMaKH.Text.ToString().Trim();
            kh1obj.TenKH = txtTenKH.Text.ToString().Trim();
            kh1obj.DiaChi = txtDiaChi.Text.ToString().Trim();
            kh1obj.SDT = txtSDT.Text.ToString().Trim();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            clean();
            dis_en(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thật sự muốn xóa ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (dr == DialogResult.Yes)
                {
                    if (khctl.DelKhachHang(txtMaKH.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmKhachHang_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóakhông thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            GanDuLieu(khobj);
            if (flag == 0)   // thêm
            {
                if (khctl.AddKhachHang(khobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmKhachHang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (khctl.UpdateKhachHang(khobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmKhachHang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            frmKhachHang_Load(sender, e);
            dis_en(false);
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                    txtTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                    txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                    txtSDT.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            frmMain ds = new frmMain();
            this.Hide();
            ds.Show();
        }
    }
}

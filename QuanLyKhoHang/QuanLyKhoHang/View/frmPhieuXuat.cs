﻿using System;
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
    public partial class frmPhieuXuat : Form
    {
        public frmPhieuXuat()
        {
            InitializeComponent();
        }
        PhieuXuatCtl pnctl = new PhieuXuatCtl();
        PhieuXuatObj pnobj = new PhieuXuatObj();
        ChiTietPhieuXuatCtl ctctl = new ChiTietPhieuXuatCtl();
        ChiTietPhieuXuatObj ctobj = new ChiTietPhieuXuatObj();
        int flag = 0;
        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = pnctl.GetData();
            dgvPhieuXuat.DataSource = dt;
            Binding();
            dis_en(false);
        }
        public void Load_cbbMaKH()
        {
            KhachHangCtl kh = new KhachHangCtl();
            cbbMaKho.DataSource = kh.GetData();
            cbbMaKho.DisplayMember = "MaKH";
            cbbMaKho.ValueMember = "MaKH";
        }
        public void Load_cbbMaKho()
        {
            KhoCtl kh = new KhoCtl();
            cbbMaKho.DataSource = kh.GetData();
            cbbMaKho.DisplayMember = "MaKho";
            cbbMaKho.ValueMember = "MaKho";
        }



        private void Load_cmbMaHang()
        {
            HangHoaCtl hh = new HangHoaCtl();
            cbbMaHang.DataSource = hh.GetData();
            cbbMaHang.DisplayMember = "MaHang";
            cbbMaHang.ValueMember = "MaHang";
        }
        private void Binding()
        {

            txtMaPX.DataBindings.Clear();
            txtMaPX.DataBindings.Add("Text", dgvPhieuXuat.DataSource, "MaPX");
            dtpNgayXuat.DataBindings.Clear();
            dtpNgayXuat.DataBindings.Add("Text", dgvPhieuXuat.DataSource, "NgayXuat");
            cbbMaKho.DataBindings.Clear();
            cbbMaKho.DataBindings.Add("Text", dgvPhieuXuat.DataSource, "MaKho");
            cbbMaKH.DataBindings.Clear();
            cbbMaKH.DataBindings.Add("Text", dgvPhieuXuat.DataSource, "MaKH");


        }
        // hàm load giữ liệu
        private void Binding1()
        {

            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dgvChiTiet.DataSource, "DonGia");
            cbbMaHang.DataBindings.Clear();
            cbbMaHang.DataBindings.Add("Text", dgvChiTiet.DataSource, "MaHang");
            txtSLThuc.DataBindings.Clear();
            txtSLThuc.DataBindings.Add("Text", dgvChiTiet.DataSource, "SLThuc");
            txtThanhTien.DataBindings.Clear();
            txtThanhTien.DataBindings.Add("Text", dgvChiTiet.DataSource, "ThanhTien");
        }
        // Hàm gán dữ liệu 
        private void GanDuLieu1(ChiTietPhieuXuatObj ctobj)
        {
            ctobj.MaPX1 = txtMaPX.Text.ToString().Trim();
            ctobj.MaHang1 = cbbMaHang.Text.ToString().Trim();
            ctobj.DonGia1 = txtDonGia.Text.ToString().Trim();
            ctobj.SLThuc1 = txtSLThuc.Text.ToString().Trim();
            ctobj.ThanhTien1 = txtThanhTien.Text.ToString().Trim();
        }
        // hàm bôi đen các ô
        public void dis_en(bool e)
        {
            txtMaPX.Enabled = e;
            cbbMaKho.Enabled = e;
            cbbMaKH.Enabled = e;
            dtpNgayXuat.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
            btnLuuCT.Enabled = e;
            btnSuaCT.Enabled = !e;
            btnXoaCT.Enabled = !e;
        }
        private void Clear()
        {
            txtMaPX.Clear();
            txtDonGia.Clear();
            txtSLThuc.Clear();
            txtThanhTien.Clear();
        }
        private void GanDuLieu(PhieuXuatObj pnobj)
        {
            pnobj.MaPX = txtMaPX.Text.ToString().Trim();
            pnobj.MaKho = cbbMaKho.Text.ToString().Trim();
            pnobj.MaKH = cbbMaKH.Text.ToString().Trim();
            pnobj.NgayXuat = dtpNgayXuat.Value;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            dis_en(true);
            Clear();
            Load_cmbMaHang();
            Load_cbbMaKho();
            Load_cbbMaKH();




        }
        // nhán vào buttom sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
            Load_cbbMaKho();
            Load_cbbMaKH();
            Load_cmbMaHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thật sự muốn xóa ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (dr == DialogResult.Yes)
                {
                    ctctl.DeleteChiTietPhieuXuat(txtMaPX.Text.Trim());
                    if (pnctl.DeletePhieuXuat(txtMaPX.Text.Trim()))
                    {

                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmPhieuXuat_Load(sender, e);
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
            GanDuLieu(pnobj);
            if (flag == 0)   // thêm
            {
                if (pnctl.AddPhieuXuat(pnobj))
                {
                    GanDuLieu1(ctobj);
                    if (ctctl.AddChiTietPhieuXuat(ctobj))
                        MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Thêm chi tiết không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (pnctl.UpdatePhieuXuat(pnobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmPhieuXuat_Load(sender, e);

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            frmPhieuXuat_Load(sender, e);
            dis_en(false);
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            flag = 0;
            Load_cmbMaHang();
            txtDonGia.Clear();
            txtSLThuc.Clear();
            txtThanhTien.Clear();
            txtDonGia.Enabled = true;
            txtSLThuc.Enabled = true;
            txtThanhTien.Enabled = true;
            cbbMaHang.Enabled = true;
            btnLuuCT.Enabled = true;
            btnSuaCT.Enabled = false;
            btnXoaCT.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            flag = 1;
            Load_cmbMaHang();
            txtDonGia.Enabled = true;
            txtSLThuc.Enabled = true;
            txtThanhTien.Enabled = true;
            btnLuuCT.Enabled = true;
            btnSuaCT.Enabled = false;
            btnXoaCT.Enabled = false;
        }

        private void btnLuuCT_Click(object sender, EventArgs e)
        {
            GanDuLieu1(ctobj);
            if (flag == 0)   // thêm
            {
                if (ctctl.AddChiTietPhieuXuat(ctobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else        
            {
                if (flag == 1)
                {
                    if (ctctl.UpdateChiTietPhieuXuat(ctobj))
                    {
                        MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            frmPhieuXuat_Load(sender, e);
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thật sự muốn xóa ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (dr == DialogResult.Yes)
                {
                    if (ctctl.DeleteChiTietPhieuXuat(cbbMaHang.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                frmPhieuXuat_Load(sender, e);
            }
        }

        private void txtMaPX_TextChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new System.Data.DataTable();
                dt = ctctl.GetData(txtMaPX.Text.Trim());
                dgvChiTiet.DataSource = dt;


            }
            catch
            {
                dgvChiTiet.DataSource = null;
            }
            Binding1();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            frmMain ds = new frmMain();
            this.Hide();
            ds.Show();
        }

        private void txtThanhTien_MouseClick(object sender, MouseEventArgs e)
        {
            txtThanhTien.Text = (Int32.Parse(txtDonGia.Text) * Int32.Parse(txtSLThuc.Text)).ToString();
        }
    }
}

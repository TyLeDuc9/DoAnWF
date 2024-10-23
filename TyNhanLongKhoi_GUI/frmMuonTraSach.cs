using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TyNhanLongKhoi_BUS;
using TyNhanLongKhoi_DAL;

namespace TyNhanLongKhoi_GUI
{
    public partial class frmMuonTraSach : DevExpress.XtraEditors.XtraForm
    {
        public frmMuonTraSach()
        {
            InitializeComponent();
        }
        private ChiTietMuonTraLibrary chiTietMuonTraLibrary = new ChiTietMuonTraLibrary();
        private QLSachLibrary sachLibrary = new QLSachLibrary();
        private void frmMuonTraSach_Load(object sender, EventArgs e)
        {

            var listChiTiet= chiTietMuonTraLibrary.GetAll();
            LayDanhSach(listChiTiet);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        try
        {
             ChiTietPhieuMuon ct = new ChiTietPhieuMuon();
             ct.MaPhieu = txtMaPhieu.Text;
             ct.SoThe = txtSoThe.Text; 
             ct.MaSach = txtMaSach.Text;
             ct.TinhTrang = txtTinhTrang.Text;
             ct.NgayMuon = dtpNgayMuon.Value;
             ct.NgayTra = dtpNgayTra.Value;
             ct.SLSachMuon = int.Parse(txtSLSachMuon.Text);
             Sach sach = sachLibrary.FindById(ct.MaSach);
        if (sach == null || ct.SLSachMuon > sach.SoLuong)
        {
            XtraMessageBox.Show("Số lượng sách mượn không được vượt quá số lượng có sẵn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

            chiTietMuonTraLibrary.InsertOrUpdate(ct);
            var listCT = chiTietMuonTraLibrary.GetAll();
            LayDanhSach(listCT);
            MessageBox.Show("Thêm sửa thành công!");
        }
        catch (Exception ex)
        {
             MessageBox.Show(ex.Message);
         }
   
        }
        private void LayDanhSach(List<ChiTietPhieuMuon> listCT)
        {

            dgvChiTiet.Rows.Clear();
            foreach (var item in listCT)
            {
                int index = dgvChiTiet.Rows.Add();
                dgvChiTiet.Rows[index].Cells[0].Value = item.MaPhieu;
                dgvChiTiet.Rows[index].Cells[1].Value = item.SoThe;
                dgvChiTiet.Rows[index].Cells[2].Value = item.MaSach;
                dgvChiTiet.Rows[index].Cells[3].Value = item.NgayMuon;
                dgvChiTiet.Rows[index].Cells[4].Value = item.NgayTra;
                dgvChiTiet.Rows[index].Cells[5].Value = item.TinhTrang;
                dgvChiTiet.Rows[index].Cells[6].Value = item.SLSachMuon;


            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát", "Confirm", MessageBoxButtons.YesNo
             , MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhieu.Text = dgvChiTiet.SelectedRows[0].Cells[0].Value.ToString();
            ChiTietPhieuMuon ct = chiTietMuonTraLibrary.FindById(txtMaPhieu.Text);
            if (ct != null)
            {
                txtMaPhieu.Text = ct.MaPhieu;
                txtSoThe.Text = ct.SoThe;
                txtMaSach.Text = ct.MaSach;
                dtpNgayMuon.Value = ct.NgayMuon.Value;
                dtpNgayTra.Value = ct.NgayTra.Value;
                txtTinhTrang.Text = ct.TinhTrang;
                txtSLSachMuon.Text = ct.SLSachMuon + " ";

            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            try
            {
                string mp = txtMaPhieu.Text.Trim();
                ChiTietPhieuMuon ToDelete = chiTietMuonTraLibrary.FindById(mp);
                if (ToDelete == null)
                {
                    MessageBox.Show("Không tìm thấy mã phiếu để xóa.");
                    return;
                }
                chiTietMuonTraLibrary.Delete(ToDelete);
                var listPhieu = chiTietMuonTraLibrary.GetAll();
                LayDanhSach(listPhieu);
                MessageBox.Show("Xóa phiếu mượn thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

     

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    MessageBox.Show("Vui lòng nhập mã phiếu hoặc số thẻ để tìm kiếm.");
                    return;
                }

                var results =chiTietMuonTraLibrary.Search(searchTerm);
                LayDanhSach(results);

                if (results.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy mã phiếu hoặc số thẻ nào.");
                }
                else
                {
                    MessageBox.Show($"Đã tìm thấy {results.Count} kết quả.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        private async void btnGiaHan_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieu = txtMaPhieu.Text.Trim();
                DateTime ngayGiaHan = dtpNgayTra.Value;
                if (string.IsNullOrEmpty(maPhieu))
                {
                    XtraMessageBox.Show("Mã phiếu không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime today = DateTime.Today;
                DateTime maxGiaHanDate = today.AddDays(14);
                if (ngayGiaHan < today || ngayGiaHan > maxGiaHanDate)
                {
                    XtraMessageBox.Show("Ngày gia hạn phải nằm trong khoảng từ hôm nay đến 14 ngày tới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGiaHan.Enabled = false;

                bool result = await chiTietMuonTraLibrary.GiaHanSachAsync(maPhieu, ngayGiaHan);

                if (result)
                {
                    var listCT = chiTietMuonTraLibrary.GetAll();
                    LayDanhSach(listCT);
                    XtraMessageBox.Show("Gia hạn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Gia hạn sách không thành công. Vui lòng kiểm tra thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                XtraMessageBox.Show("Định dạng không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi gia hạn sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGiaHan.Enabled = true;
            }

        }
    }
}
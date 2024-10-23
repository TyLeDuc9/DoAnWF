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
    public partial class frmPhieuMuon : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuMuon()
        {
            InitializeComponent();
        }

        private PhieuMuonLibrary phieuMuonLibrary = new PhieuMuonLibrary();
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuMuon phieuMuon = new PhieuMuon();
                phieuMuon.MaPhieu = txtPhieuMuon.Text;
                phieuMuon.MaNhanVien = txtMaNV.Text;
                phieuMuon.SoThe=txtSoThe.Text;
                phieuMuon.NgayLapPhieu = dtpNgayLap.Value;

                phieuMuonLibrary.InsertOrUpdate(phieuMuon);

                var listPhieu =phieuMuonLibrary.GetAll();
                LayDanhSach(listPhieu);
                XtraMessageBox.Show("Thêm/sửa thành công!", "Thông báo", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmPhieuMuon_Load(object sender, EventArgs e)
        {

            var listPhieuMuons = phieuMuonLibrary.GetAll();
            LayDanhSach(listPhieuMuons);
            
        }
        private void LayDanhSach(List<PhieuMuon> listPhieu)
        {

            dgvPhieu.Rows.Clear();
            foreach (var item in listPhieu)
            {
                int index = dgvPhieu.Rows.Add();
                dgvPhieu.Rows[index].Cells[0].Value = item.MaPhieu;
                dgvPhieu.Rows[index].Cells[2].Value = item.MaNhanVien;
                dgvPhieu.Rows[index].Cells[1].Value = item.SoThe;
                dgvPhieu.Rows[index].Cells[3].Value = item.NgayLapPhieu;
            }
        }

        private void dgvPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           txtPhieuMuon.Text =dgvPhieu.SelectedRows[0].Cells[0].Value.ToString();
           PhieuMuon phieuMuon = phieuMuonLibrary.FindById(txtPhieuMuon.Text);
            if (phieuMuon != null)
            {

                    txtSoThe.Text = phieuMuon.SoThe;
                    txtMaNV.Text = phieuMuon.MaNhanVien;
                    dtpNgayLap.Value = phieuMuon.NgayLapPhieu.Value;

                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string mp = txtPhieuMuon.Text.Trim();
                 PhieuMuon ToDelete = phieuMuonLibrary.FindById(mp);
                if (ToDelete == null)
                {
                    XtraMessageBox.Show("Không tìm thấy mã độc giả để xóa.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                phieuMuonLibrary.Delete(ToDelete);
                var listPhieu = phieuMuonLibrary.GetAll();
                LayDanhSach(listPhieu);

                XtraMessageBox.Show("Xóa phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

            try
            {
                PhieuMuon phieuMuon = new PhieuMuon();
                phieuMuon.MaPhieu = txtPhieuMuon.Text;
                phieuMuon.MaNhanVien = txtMaNV.Text;
                phieuMuon.SoThe = txtSoThe.Text;
                phieuMuon.NgayLapPhieu = dtpNgayLap.Value;

                phieuMuonLibrary.InsertOrUpdate(phieuMuon);

                var listPhieu = phieuMuonLibrary.GetAll();
                LayDanhSach(listPhieu);
                XtraMessageBox.Show("Lưu thông tin phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
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

                var results = phieuMuonLibrary.Search(searchTerm);
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

        private void dgvPhieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
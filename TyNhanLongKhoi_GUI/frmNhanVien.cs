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
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private NhanVienLibrary nhanVienLibrary = new NhanVienLibrary();


        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            var listNhanViens = nhanVienLibrary.GetAll();
            LayDanhSachNhanVien(listNhanViens);
    

        }
        private void LayDanhSachNhanVien(List<NhanVien> listNhanVien)
        {
           
            dgvNhanVien.Rows.Clear();
            foreach (var item in listNhanVien)
            {
                int index = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[index].Cells[0].Value = item.MaNhanVien;
                dgvNhanVien.Rows[index].Cells[1].Value = item.HoTen;
                dgvNhanVien.Rows[index].Cells[2].Value = item.NgaySinh;
                dgvNhanVien.Rows[index].Cells[3].Value = item.Email;
                dgvNhanVien.Rows[index].Cells[4].Value = item.SDT;
                dgvNhanVien.Rows[index].Cells[5].Value = item.GioiTinh;


            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNhanVien = txtMaNhanVien.Text;
            nhanVien.NgaySinh = dtpNgaySinh.Value.Date;
            nhanVien.HoTen = txtHoTenNhanVien.Text;
            nhanVien.Email = txtEmailNhanVien.Text;
            nhanVien.SDT = txtSDTNhanVien.Text;
            nhanVien.GioiTinh = cbGioiTinh.Text;

            nhanVienLibrary.InsertOrUpdate(nhanVien);

            var listNhanViens = nhanVienLibrary.GetAll();
            LayDanhSachNhanVien(listNhanViens);
                XtraMessageBox.Show("Thêm/sửa thành công!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNhanVien.Text = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
            NhanVien nhanVien = nhanVienLibrary.FindById(txtMaNhanVien.Text);
            if (nhanVien != null)
            {
                txtMaNhanVien.Text = nhanVien.MaNhanVien;

                if (nhanVien.NgaySinh.HasValue)
                {
                    dtpNgaySinh.Value = nhanVien.NgaySinh.Value.Date; 
                }
                else
                {
                    dtpNgaySinh.Value = DateTime.Now; 
                }

                txtHoTenNhanVien.Text = nhanVien.HoTen;
                txtEmailNhanVien.Text = nhanVien.Email;
                txtSDTNhanVien.Text = nhanVien.SDT;
                cbGioiTinh.Text = nhanVien.GioiTinh;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNhanVien = txtMaNhanVien.Text.Trim();
                NhanVien nhanVienToDelete = nhanVienLibrary.FindById(maNhanVien);
                if (nhanVienToDelete == null)
                {
                    XtraMessageBox.Show("Không tìm thấy mã nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                nhanVienLibrary.Delete(nhanVienToDelete);
                var listNhanVien = nhanVienLibrary.GetAll();
                LayDanhSachNhanVien(listNhanVien);
                XtraMessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
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
            string searchTerm = txtTimKiemNhanVien.Text.Trim(); 
            var results = nhanVienLibrary.Search(searchTerm);

            LayDanhSachNhanVien(results);

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.MaNhanVien = txtMaNhanVien.Text;
                nhanVien.NgaySinh = dtpNgaySinh.Value.Date;
                nhanVien.HoTen = txtHoTenNhanVien.Text;
                nhanVien.Email = txtEmailNhanVien.Text;
                nhanVien.SDT = txtSDTNhanVien.Text;
                nhanVien.GioiTinh = cbGioiTinh.Text;

                nhanVienLibrary.InsertOrUpdate(nhanVien);

                var listNhanViens = nhanVienLibrary.GetAll();
                LayDanhSachNhanVien(listNhanViens);

                XtraMessageBox.Show("Lưu thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
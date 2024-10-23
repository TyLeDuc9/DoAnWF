using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TyNhanLongKhoi_BUS;
using TyNhanLongKhoi_DAL;

namespace TyNhanLongKhoi_GUI
{
    public partial class frmQuanLySach : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLySach()
        {
            InitializeComponent();
     
        }
        private QLSachLibrary sachLibrary = new QLSachLibrary();
        private void frmQuanLySach_Load(object sender, EventArgs e)
        {

            var listSachs = sachLibrary.GetAll();
            LayDanhSachSach(listSachs);
        }
        private void LayDanhSachSach(List<Sach> listSach)
        {

            dgvSach.Rows.Clear();
            foreach (var item in listSach)
            {
                int index = dgvSach.Rows.Add();
                dgvSach.Rows[index].Cells[0].Value = item.MaSach;
                dgvSach.Rows[index].Cells[1].Value = item.TenSach;
                dgvSach.Rows[index].Cells[2].Value = item.MaTacGia;
                dgvSach.Rows[index].Cells[3].Value = item.MaNXB;
                dgvSach.Rows[index].Cells[4].Value = item.TheLoai;
                dgvSach.Rows[index].Cells[5].Value = item.NamXB;
                dgvSach.Rows[index].Cells[6].Value = item.SoLuong;



            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try { 
            Sach sach = new Sach();
            sach.MaSach = txtMaSach.Text;
            sach.TenSach = txtTenSach.Text;
            sach.MaTacGia = txtMaTacGia.Text;
            sach.MaNXB = txtMaNXB.Text;
            sach.TheLoai = txtTheLoai.Text;
            sach.NamXB = txtNamXB.Text;
            sach.SoLuong = int.Parse(txtSoLuong.Text);
            sachLibrary.InsertOrUpdate(sach);
            var listSachs = sachLibrary.GetAll();
            LayDanhSachSach(listSachs);
                XtraMessageBox.Show("Thêm/sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maSach = txtMaSach.Text.Trim();
                Sach sToDelete =sachLibrary.FindById(maSach);

                if (sToDelete == null)
                {
                    XtraMessageBox.Show("Không tìm thấy mã sách giả để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sachLibrary.Delete(sToDelete);

                var listSach =sachLibrary.GetAll();
                LayDanhSachSach(listSach);

                MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSach.Text = dgvSach.SelectedRows[0].Cells[0].Value.ToString();
            Sach sach = sachLibrary.FindById(txtMaSach.Text);
            if (sach != null)
            {
                txtMaSach.Text = sach.MaSach;
                txtTenSach.Text = sach.TenSach;
                txtMaTacGia.Text = sach.MaTacGia;
                txtMaNXB.Text = sach.MaNXB;
                txtTheLoai.Text = sach.TheLoai;
                txtNamXB.Text = sach.NamXB;
                txtSoLuong.Text = sach.SoLuong + "";

            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                Sach s= new Sach();
                s.MaSach = txtMaSach.Text;  
                s.TenSach = txtTenSach.Text;
                s.MaTacGia = txtMaTacGia.Text;
                s.MaNXB= txtMaNXB.Text;
                s.MaNXB = txtTheLoai.Text;
                s.NamXB = txtNamXB.Text;
                s.SoLuong = int.Parse(txtSoLuong.Text);
                sachLibrary.InsertOrUpdate(s);
                var listSach = sachLibrary.GetAll();
                LayDanhSachSach(listSach);

                XtraMessageBox.Show("Lưu thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            string searchTerm = txtTimKiem.Text.Trim();
            var results = sachLibrary.Search(searchTerm);

            LayDanhSachSach(results);

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sách nào");
            }
        }

        private void lblMaSach_Click(object sender, EventArgs e)
        {

        }
    }
}
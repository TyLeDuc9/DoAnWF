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
    public partial class frmDocGia : DevExpress.XtraEditors.XtraForm
    {
        public frmDocGia()
        {
            InitializeComponent();
        }
        private DocGiaLibrary docGiaLibrary = new DocGiaLibrary();
        private void frmDocGia_Load(object sender, EventArgs e)
        {

            var listDocGias = docGiaLibrary.GetAll();
            LayDanhSachDocGia(listDocGias);

        }
        private void LayDanhSachDocGia(List<DocGia> listDocGia)
        {

            dgvDocGia.Rows.Clear();
            foreach (var item in listDocGia)
            {
                int index = dgvDocGia.Rows.Add();
                dgvDocGia.Rows[index].Cells[0].Value = item.MaDocGia;
                dgvDocGia.Rows[index].Cells[1].Value = item.SoThe;
                dgvDocGia.Rows[index].Cells[2].Value = item.TenDocGia;
                dgvDocGia.Rows[index].Cells[3].Value = item.SDT;
                dgvDocGia.Rows[index].Cells[4].Value = item.Email;
                dgvDocGia.Rows[index].Cells[5].Value = item.DiaChi;

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maDocGia = txtMaDocGia.Text.Trim();
                DocGia docGiaToDelete = docGiaLibrary.FindById(maDocGia);
                if (docGiaToDelete == null)
                {
                    XtraMessageBox.Show("Không tìm thấy mã độc giả để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                docGiaLibrary.Delete(docGiaToDelete);
                var listDocGia = docGiaLibrary.GetAll();
                LayDanhSachDocGia(listDocGia);
                XtraMessageBox.Show("Xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaDocGia.Text = dgvDocGia.SelectedRows[0].Cells[0].Value.ToString();
            DocGia docGia = docGiaLibrary.FindById(txtMaDocGia.Text);
            if (docGia != null)
            {
                txtSoThe.Text = docGia.SoThe;
                txtHoTenDocGia.Text = docGia.TenDocGia;
                txtSDTDocGia.Text = docGia.SDT;
                txtEmailDocGia.Text = docGia.Email;
                txtDiaChi.Text = docGia.DiaChi;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DocGia docGia = docGiaLibrary.FindById(txtSoThe.Text);
            try
            {
                 docGia = new DocGia();
                docGia.MaDocGia = txtMaDocGia.Text;
                docGia.SoThe = txtSoThe.Text;
                docGia.TenDocGia = txtHoTenDocGia.Text;
                docGia.SDT = txtSDTDocGia.Text;
                docGia.Email = txtEmailDocGia.Text;
                docGia.DiaChi = txtDiaChi.Text;
                docGiaLibrary.InsertOrUpdate(docGia);
                var listDocGias = docGiaLibrary.GetAll();
                LayDanhSachDocGia(listDocGias);
                XtraMessageBox.Show("Thêm/sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();
            var results = docGiaLibrary.Search(searchTerm);

            LayDanhSachDocGia(results);

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy độc giả nào");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
           
                DocGia docGia = new DocGia();
                docGia.MaDocGia = txtMaDocGia.Text;
                docGia.SoThe = txtSoThe.Text;
                docGia.TenDocGia = txtHoTenDocGia.Text;
                docGia.SDT = txtSDTDocGia.Text;
                docGia.Email = txtEmailDocGia.Text;
                docGia.DiaChi = txtDiaChi.Text;
                docGiaLibrary.InsertOrUpdate(docGia);
                var listDocGias = docGiaLibrary.GetAll();
                LayDanhSachDocGia(listDocGias);
                XtraMessageBox.Show("Lưu thông tin độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
     }
    }
}
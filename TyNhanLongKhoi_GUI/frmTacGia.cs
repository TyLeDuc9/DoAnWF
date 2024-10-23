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
    public partial class frmTacGia : DevExpress.XtraEditors.XtraForm
    {
        public frmTacGia()
        {
            InitializeComponent();
        }
        private TacGiaLibrary tacGiaLibrary= new TacGiaLibrary();

        private void grbQuanLyNhanVien_Enter(object sender, EventArgs e)
        {

        }

        private void frmTacGia_Load(object sender, EventArgs e)
        {

            var listTacGias = tacGiaLibrary.GetAll();
            LayDanhSachTacGia(listTacGias);
        }
        private void LayDanhSachTacGia(List<TacGia> listTacGia)
        {

            dgvTacGia.Rows.Clear();
            foreach (var item in listTacGia)
            {
                int index = dgvTacGia.Rows.Add();
                dgvTacGia.Rows[index].Cells[0].Value = item.MaTacGia;
                dgvTacGia.Rows[index].Cells[1].Value = item.TenTacGia;
                dgvTacGia.Rows[index].Cells[2].Value = item.DiaChi;
                dgvTacGia.Rows[index].Cells[3].Value = item.Email;
                dgvTacGia.Rows[index].Cells[4].Value = item.SDT;
            }
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaTacGia.Text = dgvTacGia.SelectedRows[0].Cells[0].Value.ToString();
            TacGia tacGia= tacGiaLibrary.FindById(txtMaTacGia.Text);
            if (tacGia != null)
            {

                txtMaTacGia.Text = tacGia.MaTacGia;
                txtTenTacGia.Text = tacGia.TenTacGia;
                txtDiaChi.Text=tacGia.DiaChi;
                txtEmail.Text = tacGia.Email;
                txtSDT.Text = tacGia.SDT;

      
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try { 
            TacGia tacGia=new TacGia();
            tacGia.MaTacGia=txtMaTacGia.Text;
            tacGia.TenTacGia = txtTenTacGia.Text;
            tacGia.DiaChi = txtDiaChi.Text;
            tacGia.Email = txtEmail.Text;
            tacGia.SDT = txtSDT.Text;
            tacGiaLibrary.InsertOrUpdate(tacGia);
            var listTacGias = tacGiaLibrary.GetAll();
            LayDanhSachTacGia(listTacGias);
                XtraMessageBox.Show("Thêm/sửa thành công!", "Thông báo", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            try
            {
                string maTG = txtMaTacGia.Text.Trim();
                TacGia Delete = tacGiaLibrary.FindById(maTG);

                if (Delete == null)
                {
                    return;
                }
                tacGiaLibrary.Delete(Delete);

                var listTG = tacGiaLibrary.GetAll();
                LayDanhSachTacGia(listTG);

                XtraMessageBox.Show("Xóa tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                TacGia tacGia = new TacGia();
                tacGia.MaTacGia=txtMaTacGia.Text;
                tacGia.TenTacGia = txtTenTacGia.Text;
                tacGia.DiaChi = txtDiaChi.Text;
                tacGia.Email=txtEmail.Text;
                tacGia.SDT=txtSDT.Text;

                tacGiaLibrary.InsertOrUpdate(tacGia);
                var listTG = tacGiaLibrary.GetAll();
                LayDanhSachTacGia(listTG);
                XtraMessageBox.Show("Lưu thông tin tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimTacGia.Text.Trim();
            var results = tacGiaLibrary.Search(searchTerm);

            LayDanhSachTacGia(results);

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tác giả nào");
            }
        }

       
    }
}
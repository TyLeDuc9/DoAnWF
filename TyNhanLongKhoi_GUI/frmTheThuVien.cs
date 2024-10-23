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
    public partial class frmTheThuVien : DevExpress.XtraEditors.XtraForm
    {
        public frmTheThuVien()
        {
            InitializeComponent();
        }
        private TheLibrary theLibrary = new TheLibrary();

        private void frmTheThuVien_Load(object sender, EventArgs e)
        {
            var listSoThes = theLibrary.GetAll();
            LayDanhSachThe(listSoThes);

        }
        private void LayDanhSachThe(List<TheThuVien> listThe)
        {

            dgvTheThuVien.Rows.Clear();
            foreach (var item in listThe)
            {
                int index = dgvTheThuVien.Rows.Add();
                dgvTheThuVien.Rows[index].Cells[0].Value = item.SoThe;
                dgvTheThuVien.Rows[index].Cells[1].Value = item.HoTen;
                dgvTheThuVien.Rows[index].Cells[2].Value = item.NienKhoa;

            }
        }

        private void dgvTheThuVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtSoThe.Text = dgvTheThuVien.SelectedRows[0].Cells[0].Value.ToString();
            TheThuVien theThuVien = theLibrary.FindById(txtSoThe.Text);
            if (theThuVien != null)
            {

                txtSoThe.Text = theThuVien.SoThe;
                txtTenThe.Text = theThuVien.HoTen;
                txtNienKhoa.Text = theThuVien.NienKhoa;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            try
            {
                TheThuVien theThuVien = new TheThuVien();
                theThuVien.SoThe = txtSoThe.Text;
                theThuVien.HoTen = txtTenThe.Text;
                theThuVien.NienKhoa = txtNienKhoa.Text;
                theLibrary.InsertOrUpdate(theThuVien);
                var listSoThes = theLibrary.GetAll();
                LayDanhSachThe(listSoThes);
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
            TheThuVien theThuVien = new TheThuVien();
            theThuVien.SoThe = txtSoThe.Text;
            theLibrary.Delete(theThuVien);
            var listThe = theLibrary.GetAll();
            LayDanhSachThe(listThe);

                MessageBox.Show("Xóa tác thẻ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            string searchTerm =txtTimKiem.Text.Trim();
            var results = theLibrary.Search(searchTerm);

            LayDanhSachThe(results);

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thẻ nào");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                TheThuVien theThuVien = new TheThuVien();
                theThuVien.SoThe = txtSoThe.Text;
                theThuVien.HoTen = txtTenThe.Text;
                theThuVien.NienKhoa = txtNienKhoa.Text;
                theLibrary.InsertOrUpdate(theThuVien);
                var listSoThes = theLibrary.GetAll();
                LayDanhSachThe(listSoThes);
                XtraMessageBox.Show("Lưu thông thẻ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }
    }
}
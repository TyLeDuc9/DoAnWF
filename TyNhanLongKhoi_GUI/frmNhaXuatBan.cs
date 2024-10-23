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
    public partial class frmNhaXuatBan : DevExpress.XtraEditors.XtraForm
    {
        public frmNhaXuatBan()
        {
            InitializeComponent();
        }
        private NXBLibrary nxbLibrary = new NXBLibrary();

        private void frmNhaXuatBan_Load(object sender, EventArgs e)
        {

            var listNXBs = nxbLibrary.GetAll();
            LayDanhSachNXB(listNXBs);
        }
        private void LayDanhSachNXB(List<NhaXB> listNXB)
        {

            dgvNXB.Rows.Clear();
            foreach (var item in listNXB)
            {
                int index = dgvNXB.Rows.Add();
                dgvNXB.Rows[index].Cells[0].Value = item.MaNXB;
                dgvNXB.Rows[index].Cells[1].Value = item.TenNXB;
                dgvNXB.Rows[index].Cells[2].Value = item.DiaChi;
                dgvNXB.Rows[index].Cells[3].Value = item.Email;
                dgvNXB.Rows[index].Cells[4].Value = item.SDT;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try { 
            NhaXB xB = new NhaXB();
            xB.MaNXB=txtMaNXB.Text;
            xB.TenNXB = txtTenNXB.Text;
            xB.DiaChi=txtDiaChi.Text;
            xB.Email=txtEmail.Text;
            xB.SDT = txtSDT.Text;
            nxbLibrary.InsertOrUpdate(xB);
            var listNXBs = nxbLibrary.GetAll();
            LayDanhSachNXB(listNXBs);
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
                string maNXB = txtMaNXB.Text.Trim();
                NhaXB nxbToDelete = nxbLibrary.FindById(maNXB);

                if (nxbToDelete == null)
                {
                    return;
                }
                nxbLibrary.Delete(nxbToDelete);

                var listNXB = nxbLibrary.GetAll();
                LayDanhSachNXB(listNXB);

                XtraMessageBox.Show("Xóa NXB thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNXB.Text = dgvNXB.SelectedRows[0].Cells[0].Value.ToString();
            NhaXB nhaXB= nxbLibrary.FindById(txtMaNXB.Text);
            if (nhaXB != null)
            {

                txtMaNXB.Text = nhaXB.MaNXB;
                txtTenNXB.Text=nhaXB.TenNXB;
                txtDiaChi.Text=nhaXB.DiaChi;
                txtEmail.Text=nhaXB.Email;
                txtSDT.Text=nhaXB.SDT;


            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            string searchTerm = txtTimKiemNXB.Text.Trim();
            var results = nxbLibrary.Search(searchTerm);

            LayDanhSachNXB(results);

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy NXB nào");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                NhaXB xB = new NhaXB();
                xB.MaNXB = txtMaNXB.Text;
                xB.TenNXB = txtTenNXB.Text;
                xB.DiaChi = txtDiaChi.Text;
                xB.Email= txtEmail.Text;
                xB.SDT = txtSDT.Text;
                nxbLibrary.InsertOrUpdate(xB);
                var listNXB = nxbLibrary.GetAll();
                LayDanhSachNXB(listNXB);

                XtraMessageBox.Show("Lưu thông tin NXB thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }
    }
}
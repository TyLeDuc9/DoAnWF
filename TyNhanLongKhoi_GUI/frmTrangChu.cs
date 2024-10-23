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

namespace TyNhanLongKhoi_GUI
{
    public partial class frmTrangChu : DevExpress.XtraEditors.XtraForm
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {

        }

        private void mnuDocGia_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDocGia frmDocGia = new frmDocGia();
            frmDocGia.ShowDialog();
            this.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
            this.Show();
        }

        private void mnuQLSach_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmQuanLySach frmQuanLySach = new frmQuanLySach();
            frmQuanLySach.ShowDialog();
            this.Show();
        }

        private void mnuPhieuMuon_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPhieuMuon frm = new frmPhieuMuon();
            frm.ShowDialog();
            this.Show();
        }

        private void mnuBaoCao_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmBaoCaoThongKe f = new frmBaoCaoThongKe();
            f.ShowDialog();
            this.Show();
        }

        private void mnuLienHe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTroGiup frmTroGiup = new frmTroGiup();
            frmTroGiup.ShowDialog();
            this.Show();
        }

        private void frmMuonTra_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMuonTraSach frm = new frmMuonTraSach();
            frm.ShowDialog();
            this.Show();
        }

        private void mnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát", "Confirm", MessageBoxButtons.YesNo
                 , MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void mnuNXB_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhaXuatBan f=new frmNhaXuatBan();
            f.ShowDialog();
            this.Show();
        }

        private void mnuTacGia_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTacGia f=new frmTacGia();
            f.ShowDialog();
            this.Show();
        }

        private void mnuTheThuVien_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmTheThuVien f = new frmTheThuVien();
            f.ShowDialog();
            this.Show();

        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmDangNhap loginForm = new frmDangNhap();
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}
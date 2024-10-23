using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TyNhanLongKhoi_BUS;

namespace TyNhanLongKhoi_GUI
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtDangNhap.Text;
            string password = txtMatKhau.Text;

            DangNhapLibrary loginService = new DangNhapLibrary();
            if (loginService.ValidateLogin(username, password))
            {
                this.Hide();
                frmTrangChu f = new frmTrangChu();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtDangNhap_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void chkMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkMatKhau.Checked;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtDangNhap.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            chkMatKhau.Checked = false;
        }
    }
}
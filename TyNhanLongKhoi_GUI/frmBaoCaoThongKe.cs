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
    public partial class frmBaoCaoThongKe : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCaoThongKe()
        {
            InitializeComponent();
            thongKeLibrary = new ThongKeLibrary();


        }
        private ThongKeLibrary thongKeLibrary;




        private async void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            await LoadAllBooks();
        }

        private async void radSachChoMuon_CheckedChanged(object sender, EventArgs e)
        {

            if (radSachChoMuon.Checked)
            {
                await LoadBorrowedBooks();
            }
        }

        private async void radTatCaSach_CheckedChanged(object sender, EventArgs e)
        {

            if (radTatCaSach.Checked)
            {
                await LoadAllBooks();
            }

        }

        private async Task LoadAllBooks()
        {
            var books = await thongKeLibrary.GetAllBooksAsync();

            // Chọn các thuộc tính cụ thể để hiển thị trong DataGridView
            var displayBooks = books.Select(b => new
            {
                b.MaSach,
                b.TenSach,
                b.MaTacGia,
                b.MaNXB,
                b.TheLoai,
                b.SoLuong
            }).ToList();

            dataGridView1.DataSource = displayBooks;
        }


        private async Task LoadBorrowedBooks()
        {
            var borrowedBooks = await thongKeLibrary.GetBorrowedBooksAsync();
            var displayChiTiet = borrowedBooks.Select(c => new
            {
                c.MaPhieu,
                c.SoThe,
                c.MaSach,
                c.TinhTrang,
                c.NgayMuon,
                c.NgayTra,
                c.SLSachMuon
            }).ToList();
            dataGridView1.DataSource=displayChiTiet;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
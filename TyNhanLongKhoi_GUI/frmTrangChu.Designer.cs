namespace TyNhanLongKhoi_GUI
{
    partial class frmTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrangChu));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocGia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLSach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNXB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTacGia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTheThuVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMuonTra = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhieuMuon = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMuonTra = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLienHe = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDanhMuc,
            this.mnuMuonTra,
            this.mnuBaoCao,
            this.mnuThoat});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(816, 28);
            this.menuStrip2.TabIndex = 7;
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.BackColor = System.Drawing.Color.White;
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.mnThoat});
            this.mnuHeThong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuHeThong.Image = ((System.Drawing.Image)(resources.GetObject("mnuHeThong.Image")));
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(114, 24);
            this.mnuHeThong.Text = "Hệ Thống";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("mnuDangXuat.Image")));
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(224, 26);
            this.mnuDangXuat.Text = "Đăng Xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnThoat
            // 
            this.mnThoat.Image = ((System.Drawing.Image)(resources.GetObject("mnThoat.Image")));
            this.mnThoat.Name = "mnThoat";
            this.mnThoat.Size = new System.Drawing.Size(224, 26);
            this.mnThoat.Text = "Thoát";
            this.mnThoat.Click += new System.EventHandler(this.mnThoat_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.AutoSize = false;
            this.mnuDanhMuc.BackColor = System.Drawing.Color.White;
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDocGia,
            this.mnuNhanVien,
            this.mnuQLSach,
            this.mnuNXB,
            this.mnuTacGia,
            this.mnuTheThuVien});
            this.mnuDanhMuc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("mnuDanhMuc.Image")));
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.mnuDanhMuc.Size = new System.Drawing.Size(102, 24);
            this.mnuDanhMuc.Text = "Danh Mục";
            // 
            // mnuDocGia
            // 
            this.mnuDocGia.BackColor = System.Drawing.Color.White;
            this.mnuDocGia.Image = ((System.Drawing.Image)(resources.GetObject("mnuDocGia.Image")));
            this.mnuDocGia.Name = "mnuDocGia";
            this.mnuDocGia.Size = new System.Drawing.Size(224, 26);
            this.mnuDocGia.Text = "Độc Giả";
            this.mnuDocGia.Click += new System.EventHandler(this.mnuDocGia_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.BackColor = System.Drawing.Color.White;
            this.mnuNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("mnuNhanVien.Image")));
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(224, 26);
            this.mnuNhanVien.Text = "Nhân Viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuQLSach
            // 
            this.mnuQLSach.BackColor = System.Drawing.Color.White;
            this.mnuQLSach.Image = ((System.Drawing.Image)(resources.GetObject("mnuQLSach.Image")));
            this.mnuQLSach.Name = "mnuQLSach";
            this.mnuQLSach.Size = new System.Drawing.Size(224, 26);
            this.mnuQLSach.Text = "Quản Lý Sách";
            this.mnuQLSach.Click += new System.EventHandler(this.mnuQLSach_Click);
            // 
            // mnuNXB
            // 
            this.mnuNXB.Image = ((System.Drawing.Image)(resources.GetObject("mnuNXB.Image")));
            this.mnuNXB.Name = "mnuNXB";
            this.mnuNXB.Size = new System.Drawing.Size(224, 26);
            this.mnuNXB.Text = "Nhà Xuất Bản";
            this.mnuNXB.Click += new System.EventHandler(this.mnuNXB_Click);
            // 
            // mnuTacGia
            // 
            this.mnuTacGia.Image = ((System.Drawing.Image)(resources.GetObject("mnuTacGia.Image")));
            this.mnuTacGia.Name = "mnuTacGia";
            this.mnuTacGia.Size = new System.Drawing.Size(224, 26);
            this.mnuTacGia.Text = "Tác Giả";
            this.mnuTacGia.Click += new System.EventHandler(this.mnuTacGia_Click);
            // 
            // mnuTheThuVien
            // 
            this.mnuTheThuVien.Image = ((System.Drawing.Image)(resources.GetObject("mnuTheThuVien.Image")));
            this.mnuTheThuVien.Name = "mnuTheThuVien";
            this.mnuTheThuVien.Size = new System.Drawing.Size(224, 26);
            this.mnuTheThuVien.Text = "Thẻ Thư Viện";
            this.mnuTheThuVien.Click += new System.EventHandler(this.mnuTheThuVien_Click);
            // 
            // mnuMuonTra
            // 
            this.mnuMuonTra.BackColor = System.Drawing.Color.White;
            this.mnuMuonTra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPhieuMuon,
            this.frmMuonTra});
            this.mnuMuonTra.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMuonTra.Image = ((System.Drawing.Image)(resources.GetObject("mnuMuonTra.Image")));
            this.mnuMuonTra.Name = "mnuMuonTra";
            this.mnuMuonTra.Size = new System.Drawing.Size(156, 24);
            this.mnuMuonTra.Text = "Mượn-Trả Sách";
            // 
            // mnuPhieuMuon
            // 
            this.mnuPhieuMuon.Image = ((System.Drawing.Image)(resources.GetObject("mnuPhieuMuon.Image")));
            this.mnuPhieuMuon.Name = "mnuPhieuMuon";
            this.mnuPhieuMuon.Size = new System.Drawing.Size(270, 26);
            this.mnuPhieuMuon.Text = "Phiếu Mượn";
            this.mnuPhieuMuon.Click += new System.EventHandler(this.mnuPhieuMuon_Click);
            // 
            // frmMuonTra
            // 
            this.frmMuonTra.Image = ((System.Drawing.Image)(resources.GetObject("frmMuonTra.Image")));
            this.frmMuonTra.Name = "frmMuonTra";
            this.frmMuonTra.Size = new System.Drawing.Size(270, 26);
            this.frmMuonTra.Text = "Chi Tiết Mượn-Trả Sách";
            this.frmMuonTra.Click += new System.EventHandler(this.frmMuonTra_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.BackColor = System.Drawing.Color.White;
            this.mnuBaoCao.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("mnuBaoCao.Image")));
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(177, 24);
            this.mnuBaoCao.Text = "Báo cáo-Thống Kê";
            this.mnuBaoCao.Click += new System.EventHandler(this.mnuBaoCao_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.BackColor = System.Drawing.Color.White;
            this.mnuThoat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLienHe});
            this.mnuThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuThoat.Image = ((System.Drawing.Image)(resources.GetObject("mnuThoat.Image")));
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(111, 24);
            this.mnuThoat.Text = "Trợ Giúp";
            // 
            // mnuLienHe
            // 
            this.mnuLienHe.Image = ((System.Drawing.Image)(resources.GetObject("mnuLienHe.Image")));
            this.mnuLienHe.Name = "mnuLienHe";
            this.mnuLienHe.Size = new System.Drawing.Size(224, 26);
            this.mnuLienHe.Text = "Liên Hệ";
            this.mnuLienHe.Click += new System.EventHandler(this.mnuLienHe_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(816, 529);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 560);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang Chủ Hutech";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuDocGia;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuQLSach;
        private System.Windows.Forms.ToolStripMenuItem mnuNXB;
        private System.Windows.Forms.ToolStripMenuItem mnuTacGia;
        private System.Windows.Forms.ToolStripMenuItem mnuMuonTra;
        private System.Windows.Forms.ToolStripMenuItem mnuPhieuMuon;
        private System.Windows.Forms.ToolStripMenuItem frmMuonTra;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuLienHe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuTheThuVien;
    }
}
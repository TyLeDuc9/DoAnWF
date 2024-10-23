namespace TyNhanLongKhoi_GUI
{
    partial class frmBaoCaoThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoThongKe));
            this.grbThongKe = new System.Windows.Forms.GroupBox();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.radSachChoMuon = new System.Windows.Forms.RadioButton();
            this.radTatCaSach = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTKe = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grbThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongKe
            // 
            this.grbThongKe.BackColor = System.Drawing.Color.LightBlue;
            this.grbThongKe.Controls.Add(this.btnThoat);
            this.grbThongKe.Controls.Add(this.radSachChoMuon);
            this.grbThongKe.Controls.Add(this.radTatCaSach);
            this.grbThongKe.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongKe.ForeColor = System.Drawing.Color.Red;
            this.grbThongKe.Location = new System.Drawing.Point(4, 105);
            this.grbThongKe.Name = "grbThongKe";
            this.grbThongKe.Size = new System.Drawing.Size(704, 130);
            this.grbThongKe.TabIndex = 23;
            this.grbThongKe.TabStop = false;
            this.grbThongKe.Text = "Tùy Chọn Thống Kê";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(475, 46);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(119, 45);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            // 
            // radSachChoMuon
            // 
            this.radSachChoMuon.AutoSize = true;
            this.radSachChoMuon.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSachChoMuon.ForeColor = System.Drawing.Color.Black;
            this.radSachChoMuon.Location = new System.Drawing.Point(267, 58);
            this.radSachChoMuon.Name = "radSachChoMuon";
            this.radSachChoMuon.Size = new System.Drawing.Size(146, 23);
            this.radSachChoMuon.TabIndex = 13;
            this.radSachChoMuon.TabStop = true;
            this.radSachChoMuon.Text = "Sách Cho Mượn";
            this.radSachChoMuon.UseVisualStyleBackColor = true;
            this.radSachChoMuon.CheckedChanged += new System.EventHandler(this.radSachChoMuon_CheckedChanged);
            // 
            // radTatCaSach
            // 
            this.radTatCaSach.AutoSize = true;
            this.radTatCaSach.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTatCaSach.ForeColor = System.Drawing.Color.Black;
            this.radTatCaSach.Location = new System.Drawing.Point(109, 58);
            this.radTatCaSach.Name = "radTatCaSach";
            this.radTatCaSach.Size = new System.Drawing.Size(116, 23);
            this.radTatCaSach.TabIndex = 12;
            this.radTatCaSach.TabStop = true;
            this.radTatCaSach.Text = "Tất Cả Sách";
            this.radTatCaSach.UseVisualStyleBackColor = true;
            this.radTatCaSach.CheckedChanged += new System.EventHandler(this.radTatCaSach_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 241);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(704, 293);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lblTKe
            // 
            this.lblTKe.AutoSize = true;
            this.lblTKe.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTKe.ForeColor = System.Drawing.Color.Red;
            this.lblTKe.Location = new System.Drawing.Point(266, 27);
            this.lblTKe.Name = "lblTKe";
            this.lblTKe.Size = new System.Drawing.Size(166, 25);
            this.lblTKe.TabIndex = 22;
            this.lblTKe.Text = "Thống Kê Sách";
            this.lblTKe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 534);
            this.Controls.Add(this.grbThongKe);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTKe);
            this.Name = "frmBaoCaoThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo - Thống Kê";
            this.Load += new System.EventHandler(this.frmBaoCaoThongKe_Load);
            this.grbThongKe.ResumeLayout(false);
            this.grbThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongKe;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.RadioButton radSachChoMuon;
        private System.Windows.Forms.RadioButton radTatCaSach;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTKe;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyNhanLongKhoi_DAL;

namespace TyNhanLongKhoi_BUS
{
    public class ChiTietMuonTraLibrary
    {
        public List<ChiTietPhieuMuon> GetAll()
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.ChiTietPhieuMuons.ToList();
        }

        public ChiTietPhieuMuon FindById(string maPhieu)
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.ChiTietPhieuMuons.FirstOrDefault(p => p.MaPhieu== maPhieu);
        }
        public void InsertOrUpdate(ChiTietPhieuMuon ct)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                ChiTietPhieuMuon dbUpdate = context.ChiTietPhieuMuons.FirstOrDefault(p => p.MaPhieu == ct.MaPhieu);
                if (dbUpdate != null)
                {
                    dbUpdate.SoThe = ct.SoThe;
                    dbUpdate.MaSach=ct.MaSach;
                    dbUpdate.NgayMuon=ct.NgayMuon;
                    dbUpdate.NgayTra=ct.NgayTra;
                    dbUpdate.TinhTrang = ct.TinhTrang;
                    dbUpdate.SLSachMuon=ct.SLSachMuon;

                    context.SaveChanges();
                }
                else
                {

                    context.ChiTietPhieuMuons.Add(ct);
                    context.SaveChanges();
                }
            }
        }
        public List<ChiTietPhieuMuon> Search(string searchTerm)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                return context.ChiTietPhieuMuons
                    .Where(nv => nv.MaPhieu.Contains(searchTerm) || nv.SoThe.Contains(searchTerm))
                    .ToList();
            }
        }
        public void Save(ChiTietPhieuMuon ct)
        {
            if (ct== null)
            {
                throw new ArgumentNullException(nameof(ct), "Mã phiếu hoặc số thẻ không được null.");
            }
            if (string.IsNullOrWhiteSpace(ct.MaPhieu))
            {
                throw new ArgumentException("Mã phiếu hoặc số thẻ không được để trống.");
            }

            InsertOrUpdate(ct);
        }


        public void Delete(ChiTietPhieuMuon ct)
        {
            if (string.IsNullOrWhiteSpace(ct.MaPhieu))
            {
                return;
            }

            using (QLTVContextDB context = new QLTVContextDB())
            {
                ChiTietPhieuMuon delete = context.ChiTietPhieuMuons.FirstOrDefault(p => p.MaPhieu == ct.MaPhieu);
                if (delete != null)
                {
                    context.ChiTietPhieuMuons.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
        public async Task<bool> GiaHanSachAsync(string maPhieu, DateTime ngayGiaHan)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                throw new ArgumentException("Mã phiếu không được để trống.");
            }

            using (var context = new QLTVContextDB())
            {
                var phieuMuon = await context.ChiTietPhieuMuons.FirstOrDefaultAsync(p => p.MaPhieu == maPhieu);

                if (phieuMuon == null)
                {
                    throw new InvalidOperationException("Mã phiếu không tồn tại.");
                }

                if (ngayGiaHan <= phieuMuon.NgayTra)
                {
                    throw new ArgumentException("Ngày gia hạn phải sau ngày trả sách hiện tại.");
                }

                phieuMuon.NgayTra = ngayGiaHan;

                await context.SaveChangesAsync();

                return true;
            }
        }



    }
}

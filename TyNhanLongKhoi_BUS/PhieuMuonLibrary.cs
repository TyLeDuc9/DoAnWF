using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyNhanLongKhoi_DAL;

namespace TyNhanLongKhoi_BUS
{
     public class PhieuMuonLibrary
    {
        public List<PhieuMuon> GetAll()
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.PhieuMuons.ToList();
        }

        public void InsertOrUpdate(PhieuMuon phieu)
        {
            QLTVContextDB context = new QLTVContextDB();
            PhieuMuon dbUpdate = context.PhieuMuons.FirstOrDefault(s=> s.MaPhieu == phieu.MaPhieu);
            if (dbUpdate != null)
            {
                dbUpdate.MaPhieu = phieu.MaPhieu;
                dbUpdate.MaNhanVien = phieu.MaNhanVien;
                dbUpdate.TheThuVien = phieu.TheThuVien;
                dbUpdate.NgayLapPhieu = phieu.NgayLapPhieu;
                context.SaveChanges();
            }
            else
            {
                context.PhieuMuons.Add(phieu);
                context.SaveChanges();
            }
        }

        public PhieuMuon FindById(string maPhieu)
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.PhieuMuons.FirstOrDefault(p => p.MaPhieu == maPhieu);
        }

        public void Delete(PhieuMuon phieuMuon)
        {
            if (string.IsNullOrWhiteSpace(phieuMuon.MaPhieu))
            {
                return;
            }

            using (QLTVContextDB context = new QLTVContextDB())
            {
                PhieuMuon delete = context.PhieuMuons.FirstOrDefault(p => p.MaPhieu == phieuMuon.MaPhieu);
                if (delete != null)
                {
                    context.PhieuMuons.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
        public List<PhieuMuon> Search(string searchTerm)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                return context.PhieuMuons
                    .Where(nv => nv.MaPhieu.Contains(searchTerm) || nv.SoThe.Contains(searchTerm))
                    .ToList();
            }
        }
        public void SaveNhanVien(PhieuMuon phieuMuon)
        {
            if (phieuMuon== null)
            {
                throw new ArgumentNullException(nameof(phieuMuon), "Mã phiếu không được null.");
            }
            if (string.IsNullOrWhiteSpace(phieuMuon.MaPhieu))
            {
                throw new ArgumentException("Mã phiếu không được để trống.");
            }

            InsertOrUpdate(phieuMuon);
        }

    }
}

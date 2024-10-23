using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyNhanLongKhoi_DAL;

namespace TyNhanLongKhoi_BUS
{
    public class QLSachLibrary
    {
        public List<Sach> GetAll()
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.Saches.ToList();
        }

        public void InsertOrUpdate(Sach sach)
        {
            QLTVContextDB context = new QLTVContextDB();
            Sach dbUpdate = context.Saches.FirstOrDefault(p => p.MaSach == sach.MaSach);
            if (dbUpdate != null)
            {
                dbUpdate.MaSach = sach.MaSach;
                dbUpdate.TenSach = sach.TenSach;
                dbUpdate.MaTacGia = sach.MaTacGia;
                dbUpdate.TacGia = sach.TacGia;
                dbUpdate.MaNXB = sach.MaNXB;
                dbUpdate.TheLoai = sach.TheLoai;
                dbUpdate.NamXB = sach.NamXB;
                dbUpdate.SoLuong = sach.SoLuong;
                context.SaveChanges();
            }
            else
            {
                context.Saches.Add(sach);
                context.SaveChanges();
            }
        }

        public Sach FindById(string maSach)
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.Saches.FirstOrDefault(p => p.MaSach == maSach);
        }

        public void Delete(Sach sach)
        {
            if (sach.MaSach is null || sach.MaSach == "")
            {
                return;
            }
            else
            {
                QLTVContextDB context = new QLTVContextDB();
                Sach delete = context.Saches.FirstOrDefault(p => p.MaSach == sach.MaSach);
                if (delete != null)
                {
                    context.Saches.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
        public List<Sach> Search(string searchTerm)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                return context.Saches
                    .Where(s => s.MaSach.Contains(searchTerm) || s.TenSach.Contains(searchTerm))
                    .ToList();
            }
        }
        public void SaveSach(Sach sach)
        {
            if (sach == null)
            {
                throw new ArgumentNullException(nameof(sach), "Sách không được null.");
            }
            if (string.IsNullOrWhiteSpace(sach.MaSach))
            {
                throw new ArgumentException("Mã sách không được để trống.");
            }

            InsertOrUpdate(sach);
          
        }
    }
}

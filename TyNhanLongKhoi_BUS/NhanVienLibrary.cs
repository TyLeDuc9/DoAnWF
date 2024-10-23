using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyNhanLongKhoi_DAL;
using System.Text.RegularExpressions;
using System.Data.Entity;

namespace TyNhanLongKhoi_BUS
{
    public class NhanVienLibrary
    {
        public List<NhanVien> GetAll()
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.NhanViens.ToList();
        }
       
        public NhanVien FindById(string maNhanVien)
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.NhanViens.FirstOrDefault(p => p.MaNhanVien == maNhanVien);
        }
        public void InsertOrUpdate(NhanVien nhanVien)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                NhanVien dbUpdate = context.NhanViens.FirstOrDefault(p => p.MaNhanVien == nhanVien.MaNhanVien);
                if (dbUpdate != null)
                {
            
                    dbUpdate.NgaySinh = nhanVien.NgaySinh;
                    dbUpdate.HoTen = nhanVien.HoTen;
                    dbUpdate.Email = nhanVien.Email;
                    dbUpdate.SDT = nhanVien.SDT;     
                    dbUpdate.GioiTinh = nhanVien.GioiTinh;
                    context.SaveChanges();
                }
                else
                {

                    context.NhanViens.Add(nhanVien);
                    context.SaveChanges();
                }
            }
        }
        public List<NhanVien> Search(string searchTerm)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                return context.NhanViens
                    .Where(nv => nv.MaNhanVien.Contains(searchTerm) || nv.HoTen.Contains(searchTerm))
                    .ToList();
            }
        }
        public void SaveNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null)
            {
                throw new ArgumentNullException(nameof(nhanVien), "Nhân viên không được null.");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.MaNhanVien))
            {
                throw new ArgumentException("Mã nhân viên không được để trống.");
            }

            InsertOrUpdate(nhanVien);
        }


        public void Delete(NhanVien nhanVien)
        {
            if (string.IsNullOrWhiteSpace(nhanVien.MaNhanVien))
            {
                return;
            }

            using (QLTVContextDB context = new QLTVContextDB())
            {
                NhanVien delete = context.NhanViens.FirstOrDefault(p => p.MaNhanVien == nhanVien.MaNhanVien);
                if (delete != null)
                {
                    context.NhanViens.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
    }
}

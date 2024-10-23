using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyNhanLongKhoi_DAL;

namespace TyNhanLongKhoi_BUS
{
    public class TheLibrary
    {
        public List<TheThuVien> GetAll()
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.TheThuViens.ToList();
        }
        public TheThuVien FindById(string soThe)
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.TheThuViens.FirstOrDefault(p => p.SoThe == soThe);
        }
        public void InsertOrUpdate(TheThuVien theThuVien)
        {
            QLTVContextDB context = new QLTVContextDB();
            TheThuVien dbUpdate = context.TheThuViens.FirstOrDefault(p => p.SoThe == theThuVien.SoThe);
            if (dbUpdate != null)
            {

                dbUpdate.SoThe = theThuVien.SoThe;
                dbUpdate.HoTen = theThuVien.HoTen;
                dbUpdate.NienKhoa = theThuVien.NienKhoa;
                context.SaveChanges();
            }
            else
            {
                context.TheThuViens.Add(theThuVien);
                context.SaveChanges();
            }
        }

        public void Delete(TheThuVien theThuVien)
        {
            if (theThuVien.SoThe is null || theThuVien.SoThe == "")
            {
                return;
            }
            else
            {
                QLTVContextDB context = new QLTVContextDB();
                TheThuVien delete = context.TheThuViens.FirstOrDefault(p => p.SoThe == theThuVien.SoThe);
                if (delete != null)
                {
                    context.TheThuViens.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
        public List<TheThuVien> Search(string searchTerm)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                return context.TheThuViens
                    .Where(t => t.SoThe.Contains(searchTerm) || t.HoTen.Contains(searchTerm))
                    .ToList();
            }
        }
        public void SaveThe(TheThuVien theThuVien)
        {
            if (theThuVien == null)
            {
                throw new ArgumentNullException(nameof(theThuVien), "Thẻ không được null.");
            }
            if (string.IsNullOrWhiteSpace(theThuVien.SoThe))
            {
                throw new ArgumentException("Mã thẻ không được để trống.");
            }

            InsertOrUpdate(theThuVien);
        }

    }
}

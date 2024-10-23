using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TyNhanLongKhoi_DAL;

namespace TyNhanLongKhoi_BUS
{
    public class TacGiaLibrary
    {
        public List<TacGia> GetAll()
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.TacGias.ToList();
        }
        public TacGia FindById(string maTacGia)
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.TacGias.FirstOrDefault(p => p.MaTacGia == maTacGia);
        }
        public void InsertOrUpdate(TacGia tacGia)
        {
            QLTVContextDB context = new QLTVContextDB();
            TacGia dbUpdate = context.TacGias.FirstOrDefault(p => p.MaTacGia==tacGia.MaTacGia);
            if (dbUpdate != null)
            { 
                dbUpdate.MaTacGia=tacGia.MaTacGia;
                dbUpdate.TenTacGia = tacGia.TenTacGia;
                dbUpdate.DiaChi = tacGia.DiaChi;
                dbUpdate.Email=tacGia.Email;
                dbUpdate.SDT = tacGia.SDT;
               

                context.SaveChanges();
            }
            else
            {
                context.TacGias.Add(tacGia);
                context.SaveChanges();
            }
        }

        public void Delete(TacGia tacGia)
        {
            if (tacGia.MaTacGia is null || tacGia.MaTacGia == "")
            {
                return;
            }
            else
            {
                QLTVContextDB context = new QLTVContextDB();
                TacGia delete = context.TacGias.FirstOrDefault(p => p.MaTacGia == tacGia.MaTacGia);
                if (delete != null)
                {
                    context.TacGias.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
        public List<TacGia> Search(string searchTerm)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                return context.TacGias
                    .Where(tg => tg.MaTacGia.Contains(searchTerm) || tg.TenTacGia.Contains(searchTerm))
                    .ToList();
            }
        }
        public void SaveTacGia(TacGia tacGia)
        {
            if (tacGia == null)
            {
                throw new ArgumentNullException(nameof(tacGia), "Tác giả không được null.");
            }
            if (string.IsNullOrWhiteSpace(tacGia.MaTacGia))
            {
                throw new ArgumentException("Mã Tác giả không được để trống.");
            }

            InsertOrUpdate(tacGia);
        }
    }
}

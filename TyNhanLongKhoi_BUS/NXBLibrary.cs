using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TyNhanLongKhoi_DAL;

namespace TyNhanLongKhoi_BUS
{
    public class NXBLibrary
    {
        public List<NhaXB> GetAll()
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.NhaXBs.ToList();
        }
     
        public NhaXB FindById(string maNXB)
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.NhaXBs.FirstOrDefault(p => p.MaNXB == maNXB);
        }
        public void InsertOrUpdate(NhaXB nhaXB)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                NhaXB dbUpdate = context.NhaXBs.FirstOrDefault(p => p.MaNXB == nhaXB.MaNXB);
                if (dbUpdate != null)
                {
                    dbUpdate.TenNXB = nhaXB.TenNXB;
                    dbUpdate.DiaChi = nhaXB.DiaChi;
                    dbUpdate.Email = nhaXB.Email;
                    dbUpdate.SDT = nhaXB.SDT;

                    context.SaveChanges();
                }
                else
                {

                    context.NhaXBs.Add(nhaXB);
                    context.SaveChanges();
                }

            }
        }
        public List<NhaXB> Search(string searchTerm)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                return context.NhaXBs
                    .Where(nxb => nxb.MaNXB.Contains(searchTerm) || nxb.TenNXB.Contains(searchTerm))
                    .ToList();
            }
        }
        public void SaveNXB(NhaXB nhaXB)
        {
            if (nhaXB == null)
            {
                throw new ArgumentNullException(nameof(nhaXB), "NXB không được null.");
            }
            if (string.IsNullOrWhiteSpace(nhaXB.MaNXB))
            {
                throw new ArgumentException("Mã NXB không được để trống.");
            }

            InsertOrUpdate(nhaXB);
        }
        public void Delete(NhaXB nhaXB)
        {
            if (nhaXB.MaNXB is null || nhaXB.MaNXB == "")
            {
                return;
            }
            else
            {
                QLTVContextDB context = new QLTVContextDB();
                NhaXB delete = context.NhaXBs.FirstOrDefault(p => p.MaNXB == nhaXB.MaNXB);
                if (delete != null)
                {
                    context.NhaXBs.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
  
    }
}

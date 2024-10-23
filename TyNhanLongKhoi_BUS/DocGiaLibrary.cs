
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TyNhanLongKhoi_BUS;
using TyNhanLongKhoi_DAL;
namespace TyNhanLongKhoi_BUS
{
    public class DocGiaLibrary
    {
        public List<DocGia> GetAll()
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.DocGias.ToList();
        }
      

        public void InsertOrUpdate(DocGia docGia)
        {
            QLTVContextDB context = new QLTVContextDB();
            DocGia dbUpdate = context.DocGias.FirstOrDefault(p => p.MaDocGia == docGia.MaDocGia);
            if (dbUpdate != null)
            {
                dbUpdate.SoThe = docGia.SoThe;
                dbUpdate.TenDocGia = docGia.TenDocGia;
                dbUpdate.SDT = docGia.SDT;
                dbUpdate.Email = docGia.Email;
                dbUpdate.DiaChi = docGia.DiaChi;

                context.SaveChanges();
            }
            else
            {
                context.DocGias.Add(docGia);
                context.SaveChanges();
            }
        }
        public DocGia FindById(string maDocGia)
        {
            QLTVContextDB context = new QLTVContextDB();
            return context.DocGias.FirstOrDefault(p => p.MaDocGia == maDocGia);
        }

        public void Delete(DocGia docGia)
        {
            if (docGia.MaDocGia is null || docGia.MaDocGia == "")
            {
                return;
            }
            else
            {
                QLTVContextDB context = new QLTVContextDB();
                DocGia delete = context.DocGias.FirstOrDefault(p => p.MaDocGia == docGia.MaDocGia);
                if (delete != null)
                {
                    context.DocGias.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
        public List<DocGia> Search(string searchTerm)
        {
            using (QLTVContextDB context = new QLTVContextDB())
            {
                return context.DocGias
                    .Where(dg => dg.MaDocGia.Contains(searchTerm) || dg.TenDocGia.Contains(searchTerm))
                    .ToList();
            }
        }

        public void SaveDocGia(DocGia docGia)
        {
            if (docGia == null)
            {
                throw new ArgumentNullException(nameof(docGia), "Độc giả không được null.");
            }
            if (string.IsNullOrWhiteSpace(docGia.MaDocGia))
            {
                throw new ArgumentException("Mã độc giả không được để trống.");
            }

            InsertOrUpdate(docGia);
        }
    }
}

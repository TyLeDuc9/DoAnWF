using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyNhanLongKhoi_DAL;

namespace TyNhanLongKhoi_BUS
{
    public class ThongKeLibrary
    {
        public async Task<List<Sach>> GetAllBooksAsync()
        {
            using (var context = new QLTVContextDB())
            {
                return await context.Saches.ToListAsync();
            }
        }

        public async Task<List<ChiTietPhieuMuon>> GetBorrowedBooksAsync()
        {
            using (var context = new QLTVContextDB())
            {
                //var borrowedBookIds = await context.ChiTietPhieuMuons
                //    .Where(c => c.NgayTra == null) 
                //    .Select(c => c.MaSach)
                //    .ToListAsync();

                //return await context.ChiTietPhieuMuons
                //    .Where(s => borrowedBookIds.Contains(s.MaSach))
                //    .ToListAsync();
                return await context.ChiTietPhieuMuons.ToListAsync();
            }
        }
    }

}





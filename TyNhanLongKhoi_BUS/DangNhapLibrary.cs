using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyNhanLongKhoi_BUS
{
    public class DangNhapLibrary
    {
        private Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "admin", "123456" },
            { "user1", "012345" },
            { "user2", "234567" }
        };

        public bool ValidateLogin(string username, string password)
        {
            return users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

        public List<string> GetUserRoles(string username)
        {
            if (username == "admin")
            {
                return new List<string> { "Admin", "User" };
            }
            else
            {
                return new List<string> { "User" };
            }
        }
    }
}

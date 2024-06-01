using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Users
    {
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? FullName { get; set; }
        public string? UniEmail { get; set; }
        public string? Password { get; set; }
        public string? LinkedInAccountLink{ get; set; }
        public string? FacebookAccountLink { get; set; }
        public string? InstagramAccountLink { get; set; }
        public string? GitHupAccountLink { get; set; }
        public string? ProfilePictureName { get; set; }
        public string?  PhoneNumber { get; set; }

    }
}

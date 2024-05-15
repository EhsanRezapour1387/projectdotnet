using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectdotnet.Models.Data
{
    public class Tbl_User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
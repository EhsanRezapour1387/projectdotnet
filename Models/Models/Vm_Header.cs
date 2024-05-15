using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectdotnet.Models.Models
{
    public class Vm_Header
    {
           public int Vm_id { get; set; }
        public string Vm_Title { get; set; }
        public string Vm_Detail { get; set; }
        public string Vm_image { get; set; }
        public IFormFile Vm_img { get; set; }
        public string Vm_Link { get; set; }
    }
}
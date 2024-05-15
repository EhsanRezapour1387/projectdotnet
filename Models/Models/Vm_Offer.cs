using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectdotnet.Models.Models
{
    public class Vm_Offer
    {
        public int Vm_Id { get; set; }
        public string Vm_Title { get; set; }
        public string Vm_Detail { get; set; }
        public string Vm_Image { get; set; }
        public IFormFile Vm_Img { get; set; }
        public string Vm_Link { get; set; }
    }
}
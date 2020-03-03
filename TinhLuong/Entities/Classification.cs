using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuong.Entities
{
    class Classification
    {
        public string Date { get; set; }
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string Rank { get; set; }
     }
    class ExtraOvertime
    {
        public string Date { get; set; }
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string NumberOvertime { get; set; }
        public string Extratime{ get; set; }
    }
}

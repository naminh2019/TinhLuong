using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuong.Entities;

namespace TinhLuong
{
    public class TotalChamCong
    {
        public int MaNV { get; set; }
        public List<ChamCong> _ChamCongs { get; set; }
        public Keeptime sKeeptime { get; set; }
    }
}

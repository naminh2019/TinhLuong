using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuong.Entities
{
    public class ChamCong
    {
        public int MaNhanVien { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan InMorning { get; set; }
        public TimeSpan OutMorning { get; set; }
        public TimeSpan InAfternoon { get; set; }
        public TimeSpan OutAfternoon { get; set; }
        public TimeSpan InOvertime { get; set; }
        public TimeSpan OutOvertime { get; set; }
        public TimeSpan NumberOvertime { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

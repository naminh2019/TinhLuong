using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhLuong.Utils
{
    public class MouseEvent
    {
        public static void MouseOnEnter(object sender, EventArgs e)
        {
            Label Mouse_Enter = sender as Label;
            Mouse_Enter.ForeColor = Color.White;
        }
        public static void MouseOnLeave(object sender, EventArgs e)
        {
            Label Mouse_Enter = sender as Label;
            Mouse_Enter.ForeColor = Color.DarkGray;
        }
    }
}

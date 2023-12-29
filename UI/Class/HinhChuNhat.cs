using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class HinhChuNhat:HinhVe
    {
        public HinhChuNhat():base()
        {

        }
        public override void Paint_Paint(ref Graphics g,  DrawObject aa)
        {

            //Ve Hinh Chu Nhat
            int x = Math.Min(aa.cX, aa.x);
            int y = Math.Min(aa.cY, aa.y);
            aa.khung = new Rectangle(x, y, Math.Abs(aa.sX), Math.Abs(aa.sY));
            g.DrawRectangle(aa.Pen, aa.khung);
        }
        public override void Paint_Resize(ref Graphics g,  DrawObject aa)
        {
            g.DrawRectangle(aa.Pen, aa.khung);
        }
        public override void VeChinhThuc(DrawObject aa)
        {
            aa.isResize = false;
            aa.G.DrawRectangle(aa.Pen, aa.khung);
            aa.pictureBox.Refresh();
            aa.dragHandle = -1;
            aa.khung = new Rectangle(aa.pictureBox.Top, 0, 0, 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class Ellipse : HinhVe
    {
        public Ellipse() : base()
        {

        }
        public override void Paint_Paint(ref Graphics g, DrawObject aa)
        {

            int x = Math.Min(aa.cX, aa.x);
            int y = Math.Min(aa.cY, aa.y);
            //draw elip
            aa.khung = new Rectangle(x, y, Math.Abs(aa.sX), Math.Abs(aa.sY));
            g.DrawEllipse(aa.Pen, aa.khung);
            aa.khung = new Rectangle(x, y, Math.Abs(aa.sX), Math.Abs(aa.sY));
        }
        public override void Paint_Resize(ref Graphics g, DrawObject aa)
        {
            g.DrawEllipse(aa.Pen, aa.khung);
        }
        public override void VeChinhThuc(DrawObject aa)
        {
            aa.isResize = false;

            aa.G.DrawEllipse(aa.Pen, aa.khung);
            aa.pictureBox.Refresh();
            aa.dragHandle = -1;
            aa.khung = new Rectangle(aa.pictureBox.Top, 0, 0, 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class Line : HinhVe
    {
        public Line() : base()
        {

        }
        public override void Paint_Paint(ref Graphics g, DrawObject aa)
        {
            aa.khung = new Rectangle(aa.cX, aa.cY, aa.sX, aa.sY);
            g.DrawLine(aa.Pen, aa.cX, aa.cY, aa.x, aa.y);
        }
        public override void Paint_Resize(ref Graphics g, DrawObject aa)
        {
            g.DrawLine(aa.Pen, aa.khung.Left, aa.khung.Top, aa.khung.Right, aa.khung.Bottom);
        }
        public override void VeChinhThuc(DrawObject aa)
        {
            aa.isResize = false;
            aa.G.DrawLine(aa.Pen, aa.khung.Left, aa.khung.Top, aa.khung.Right, aa.khung.Bottom); ;
            aa.pictureBox.Refresh();
            aa.dragHandle = -1;
            aa.khung = new Rectangle(aa.pictureBox.Top, 0, 0, 0);
        }
    }
}

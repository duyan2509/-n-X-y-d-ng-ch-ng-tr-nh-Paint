using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class Select : HinhVe
    {
        private Pen resizePen { get; set; }
        public Select() : base()
        {
            resizePen = new Pen(Color.Blue, 1f);
            resizePen.DashPattern = new float[] { 7, 2 };
        }
        public override void Paint_Paint(ref Graphics g, DrawObject aa)
        {
            int x = Math.Min(aa.cX, aa.x);
            int y = Math.Min(aa.cY, aa.y);
            aa.khung = new Rectangle(x, y, Math.Abs(aa.sX), Math.Abs(aa.sY));
            //this.Cursor = Cursors.Cross;
            g.DrawRectangle(resizePen, aa.khung);
        }
        public override void Paint_Resize(ref Graphics g, DrawObject aa)
        {
            Image clipboardImage = Clipboard.GetImage();
            if (clipboardImage != null)
                g.DrawImage(clipboardImage, aa.khung);
        }
        public override void VeChinhThuc(DrawObject aa)
        {
            aa.isResize = false;
            Image clipboardImage = Clipboard.GetImage();
            if (clipboardImage != null)
            {
                aa.G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                aa.G.DrawImage(clipboardImage, aa.khung);
                aa.pictureBox.Refresh();
                aa.dragHandle = -1;
                aa.khung = new Rectangle(aa.pictureBox.Top, 0, 0, 0);
            }
        }
    }
}

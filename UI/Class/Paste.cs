using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class Paste : HinhVe
    {
        public Paste() : base()
        {
            resizePen = new Pen(Color.White, 1f);
            resizePen.DashPattern = new float[] { 7, 2 };
        }
        public override void Paint_Paint(ref Graphics g, DrawObject aa)
        {
            //paste
            int x = Math.Min(aa.cX, aa.x);
            int y = Math.Min(aa.cY, aa.y);
            Image clipboardImage = Clipboard.GetImage();
            if (clipboardImage != null)
            {
                aa.khung = new Rectangle(0, 0, clipboardImage.Width, clipboardImage.Height);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(clipboardImage, aa.khung);
            }
            // ve khung
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
                aa.Paint = false;
            }
        }
    }
}

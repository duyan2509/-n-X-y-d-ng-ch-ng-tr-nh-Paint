using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Star : HinhVe
    {
        public Star() : base()
        {

        }
        public override void Paint_Paint(ref Graphics g, DrawObject aa)
        {

            int x = Math.Min(aa.cX, aa.x);
            int y = Math.Min(aa.cY, aa.y);
            int lX = Math.Max(aa.cX, aa.x);
            int lY = Math.Max(aa.cY, aa.y);
            aa.khung = new Rectangle(x, y, Math.Abs(aa.sX), Math.Abs(aa.sY));
            // Ve ngoi sao


            Point p1 = new Point(x + (aa.khung.Width / 2), y);
            Point p2 = new Point(lX - (5 * aa.khung.Width / 14), y + (3 * (aa.khung.Height) / 8));
            Point p3 = new Point(lX, y + (3 * (aa.khung.Height) / 8));
            Point p4 = new Point(lX - (2 * aa.khung.Width / 7), lY - (5 * aa.khung.Height / 14));
            Point p5 = new Point(lX - (3 * aa.khung.Width / 14), lY);
            Point p6 = new Point(x + aa.khung.Width / 2, lY - (3 * aa.khung.Height / 14));
            Point p7 = new Point(x + (3 * aa.khung.Width / 14), lY);
            Point p8 = new Point(x + (2 * aa.khung.Width / 7), lY - (5 * aa.khung.Height / 14));
            Point p9 = new Point(x, y + (3 * (aa.khung.Height) / 8));
            Point p10 = new Point(x + (5 * aa.khung.Width / 14), y + (3 * (aa.khung.Height) / 8));
            Point[] pArray = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

            g.DrawPolygon(aa.Pen, pArray);
        }
        public override void Paint_Resize(ref Graphics g, DrawObject aa)
        {
            int x = aa.khung.X;
            int y = aa.khung.Y;
            int lX = aa.khung.X + aa.khung.Width;
            int lY = aa.khung.Y + aa.khung.Height;
            Point p1 = new Point(x + (aa.khung.Width / 2), y);
            Point p2 = new Point(lX - (5 * aa.khung.Width / 14), y + (3 * (aa.khung.Height) / 8));
            Point p3 = new Point(lX, y + (3 * (aa.khung.Height) / 8));
            Point p4 = new Point(lX - (2 * aa.khung.Width / 7), lY - (5 * aa.khung.Height / 14));
            Point p5 = new Point(lX - (3 * aa.khung.Width / 14), lY);
            Point p6 = new Point(x + aa.khung.Width / 2, lY - (3 * aa.khung.Height / 14));
            Point p7 = new Point(x + (3 * aa.khung.Width / 14), lY);
            Point p8 = new Point(x + (2 * aa.khung.Width / 7), lY - (5 * aa.khung.Height / 14));
            Point p9 = new Point(x, y + (3 * (aa.khung.Height) / 8));
            Point p10 = new Point(x + (5 * aa.khung.Width / 14), y + (3 * (aa.khung.Height) / 8));
            Point[] pArray = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

            g.DrawPolygon(aa.Pen, pArray);
        }
        public override void VeChinhThuc(DrawObject aa)
        {
            aa.isResize = false;

            int x = aa.khung.X;
            int y = aa.khung.Y;
            int lX = aa.khung.X + aa.khung.Width;
            int lY = aa.khung.Y + aa.khung.Height;
            Point p1 = new Point(x + (aa.khung.Width / 2), y);
            Point p2 = new Point(lX - (5 * aa.khung.Width / 14), y + (3 * (aa.khung.Height) / 8));
            Point p3 = new Point(lX, y + (3 * (aa.khung.Height) / 8));
            Point p4 = new Point(lX - (2 * aa.khung.Width / 7), lY - (5 * aa.khung.Height / 14));
            Point p5 = new Point(lX - (3 * aa.khung.Width / 14), lY);
            Point p6 = new Point(x + aa.khung.Width / 2, lY - (3 * aa.khung.Height / 14));
            Point p7 = new Point(x + (3 * aa.khung.Width / 14), lY);
            Point p8 = new Point(x + (2 * aa.khung.Width / 7), lY - (5 * aa.khung.Height / 14));
            Point p9 = new Point(x, y + (3 * (aa.khung.Height) / 8));
            Point p10 = new Point(x + (5 * aa.khung.Width / 14), y + (3 * (aa.khung.Height) / 8));
            Point[] pArray = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

            aa.G.DrawPolygon(aa.Pen, pArray);
            aa.pictureBox.Refresh();
            aa.dragHandle = -1;
            aa.khung = new Rectangle(aa.pictureBox.Top, 0, 0, 0);
        }
    }
}

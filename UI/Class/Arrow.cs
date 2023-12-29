using System;
using System.Drawing;
using System.Windows;
using Point = System.Drawing.Point;

namespace UI
{
    public class Arrow : HinhVe
    {
        public Arrow() : base()
        {

        }
        public override void Paint_Paint(ref Graphics g, DrawObject aa)
        {

            int x = Math.Min(aa.cX, aa.x);
            int y = Math.Min(aa.cY, aa.y);
            int lX = Math.Max(aa.cX, aa.x);
            int lY = Math.Max(aa.cY, aa.y);
            aa.khung = new Rectangle(x, y, Math.Abs(aa.sX), Math.Abs(aa.sY));
            // Ve Mui Ten
            Point p1 = new Point(lX, y + (aa.khung.Height / 2));
            Point p2 = new Point(lX - (aa.khung.Width / 3), y);
            Point p3 = new Point(lX - (aa.khung.Width / 3), y + (aa.khung.Height / 3));
            Point p4 = new Point(x, y + (aa.khung.Height / 3));
            Point p5 = new Point(x, lY - (aa.khung.Height / 3));
            Point p6 = new Point(lX - (aa.khung.Width / 3), lY - (aa.khung.Height / 3));
            Point p7 = new Point(lX - (aa.khung.Width / 3), lY);
            Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

            g.DrawPolygon(aa.Pen, pArray);
        }
        public override void Paint_Resize(ref Graphics g, DrawObject aa)
        {
            int x = aa.khung.X;
            int y = aa.khung.Y;
            int lX = aa.khung.X + aa.khung.Width;
            int lY = aa.khung.Y + aa.khung.Height;
            Point p1 = new Point(lX, y + (aa.khung.Height / 2));
            Point p2 = new Point(lX - (aa.khung.Width / 3), y);
            Point p3 = new Point(lX - (aa.khung.Width / 3), y + (aa.khung.Height / 3));
            Point p4 = new Point(x, y + (aa.khung.Height / 3));
            Point p5 = new Point(x, lY - (aa.khung.Height / 3));
            Point p6 = new Point(lX - (aa.khung.Width / 3), lY - (aa.khung.Height / 3));
            Point p7 = new Point(lX - (aa.khung.Width / 3), lY);
            Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

            g.DrawPolygon(aa.Pen, pArray);
        }
        public override void VeChinhThuc(DrawObject aa)
        {
            aa.isResize = false;

            int x = aa.khung.X;
            int y = aa.khung.Y;
            int lX = aa.khung.X + aa.khung.Width;
            int lY = aa.khung.Y + aa.khung.Height;
            Point p1 = new Point(lX, y + (aa.khung.Height / 2));
            Point p2 = new Point(lX - (aa.khung.Width / 3), y);
            Point p3 = new Point(lX - (aa.khung.Width / 3), y + (aa.khung.Height / 3));
            Point p4 = new Point(x, y + (aa.khung.Height / 3));
            Point p5 = new Point(x, lY - (aa.khung.Height / 3));
            Point p6 = new Point(lX - (aa.khung.Width / 3), lY - (aa.khung.Height / 3));
            Point p7 = new Point(lX - (aa.khung.Width / 3), lY);
            Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

            aa.G.DrawPolygon(aa.Pen, pArray);
            aa.pictureBox.Refresh();
            aa.dragHandle = -1;
            aa.khung = new Rectangle(aa.pictureBox.Top, 0, 0, 0);
        }
    }
}

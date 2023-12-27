using System;
using System.Drawing;
using System.Windows;
using Point = System.Drawing.Point;

namespace UI
{
    public class Hexagon : HinhVe
    {
        public Hexagon() : base()
        {

        }


        public override void Paint_Paint(ref Graphics g, DrawObject aa)
        {
            // Ve Hinh Luc Giac
            int x = Math.Min(aa.cX, aa.x);
            int y = Math.Min(aa.cY, aa.y);
            int lX = Math.Max(aa.cX, aa.x);
            int lY = Math.Max(aa.cY, aa.y);
            aa.khung = new Rectangle(x, y, Math.Abs(aa.sX), Math.Abs(aa.sY));
            // Calculate the points for the hexagon
            Point p1 = new Point(x + (aa.khung.Width) / 4, y); // Top vertex
            Point p2 = new Point(lX - (aa.khung.Width) / 4, y); // Top-right vertex
            Point p3 = new Point(lX, y + (aa.khung.Height) / 2); // Right vertex
            Point p4 = new Point(lX - (aa.khung.Width) / 4, lY); // Bottom-right vertex
            Point p5 = new Point(x + (aa.khung.Width) / 4, lY); // Bottom-left vertex
            Point p6 = new Point(x, y + (aa.khung.Height) / 2);  // Bottom-left vertex
            Point[] pArray = { p1, p2, p3, p4, p5, p6 };

            g.DrawPolygon(aa.Pen, pArray);
        }
        public override void Paint_Resize(ref Graphics g, DrawObject aa)
        {
            int x = aa.khung.X;
            int y = aa.khung.Y;
            int lX = aa.khung.X + aa.khung.Width;
            int lY = aa.khung.Y + aa.khung.Height;
            Point p1 = new Point(x + (aa.khung.Width) / 4, y);
            Point p2 = new Point(lX - (aa.khung.Width) / 4, y);
            Point p3 = new Point(lX, y + (aa.khung.Height) / 2);
            Point p4 = new Point(lX - (aa.khung.Width) / 4, lY);
            Point p5 = new Point(x + (aa.khung.Width) / 4, lY);
            Point p6 = new Point(x, y + (aa.khung.Height) / 2);
            Point[] pArray = { p1, p2, p3, p4, p5, p6 };

            g.DrawPolygon(aa.Pen, pArray);
        }
        public override void VeChinhThuc(DrawObject aa)
        {
            aa.isResize = false;

            int x = aa.khung.X;
            int y = aa.khung.Y;
            int lX = aa.khung.X + aa.khung.Width;
            int lY = aa.khung.Y + aa.khung.Height;
            Point p1 = new Point(x + (aa.khung.Width) / 4, y);
            Point p2 = new Point(lX - (aa.khung.Width) / 4, y);
            Point p3 = new Point(lX, y + (aa.khung.Height) / 2);
            Point p4 = new Point(lX - (aa.khung.Width) / 4, lY);
            Point p5 = new Point(x + (aa.khung.Width) / 4, lY);
            Point p6 = new Point(x, y + (aa.khung.Height) / 2);
            Point[] pArray = { p1, p2, p3, p4, p5, p6 };
            aa.G.DrawPolygon(aa.Pen, pArray);
            aa.pictureBox.Refresh();
            aa.dragHandle = -1;
            aa.khung = new Rectangle(aa.pictureBox.Top, 0, 0, 0);
        }
    }
}

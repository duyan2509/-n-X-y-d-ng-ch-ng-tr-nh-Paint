using System;
using System.Drawing;
using System.Windows;
using Point = System.Drawing.Point;

namespace UI
{
    public class RightTriangle : HinhVe
    {
        public RightTriangle() : base()
        {

        }


        public override void Paint_Paint(ref Graphics g, DrawObject aa)
        {
            // Ve Tam Giac Vuong
            int x = Math.Min(aa.cX, aa.x);
            int y = Math.Min(aa.cY, aa.y);
            int lX = Math.Max(aa.cX, aa.x);
            int lY = Math.Max(aa.cY, aa.y);
            aa.khung = new Rectangle(x, y, Math.Abs(aa.sX), Math.Abs(aa.sY));
            Point dinhA = new Point(x, y);
            Point dinhB = new Point(x, lY);
            Point dinhC = new Point(lX, lY);

            Point[] dinhArray = { dinhA, dinhB, dinhC };

            g.DrawPolygon(aa.Pen, dinhArray);
        }
        public override void Paint_Resize(ref Graphics g, DrawObject aa)
        {
            Point dinhA = new Point(aa.khung.X, aa.khung.Y);
            Point dinhB = new Point(aa.khung.X, aa.khung.Y + aa.khung.Height);
            Point dinhC = new Point(aa.khung.X + aa.khung.Width, aa.khung.Y + aa.khung.Height);
            Point[] dinhArray = { dinhC, dinhA, dinhB };
            g.DrawPolygon(aa.Pen, dinhArray);
        }
        public override void VeChinhThuc(DrawObject aa)
        {
            aa.isResize = false;
            Point dinhA = new Point(aa.khung.X, aa.khung.Y);
            Point dinhB = new Point(aa.khung.X, aa.khung.Y + aa.khung.Height);
            Point dinhC = new Point(aa.khung.X + aa.khung.Width, aa.khung.Y + aa.khung.Height);
            Point[] dinhArray = { dinhC, dinhA, dinhB };
            aa.G.DrawPolygon(aa.Pen, dinhArray);
            aa.pictureBox.Refresh();
            aa.dragHandle = -1;
            aa.khung = new Rectangle(aa.pictureBox.Top, 0, 0, 0);
        }
    }
}

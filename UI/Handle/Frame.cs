using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Brushes = System.Drawing.Brushes;

namespace UI
{
    public partial class Form1 : Form
    {
        private Rectangle updateKhung(Rectangle rtg, Rectangle khung)
        {
            if (rtg.Width > 5 && rtg.Height > 5)
                khung = rtg;
            else if (rtg.Width <= 5 && rtg.Height > 5)
                khung = new Rectangle(khung.X, rtg.Y, khung.Width, rtg.Height);
            else if (rtg.Height <= 5 && rtg.Width > 5)
                khung = new Rectangle(rtg.X, khung.Y, rtg.Width, khung.Height);
            return khung;
        }
        private Point GetHandlePoint(int value)
        {
            int tmp = tcMain.SelectedIndex;

            //trả về vị trí điểm điều khiển 
            Point result = Point.Empty;


            if (value == 0)
                result = new Point(a[tmp].khung.Left, a[tmp].khung.Top);
            else if (value == 1)
                result = new Point(a[tmp].khung.Left + (a[tmp].khung.Width / 2), a[tmp].khung.Top);
            else if (value == 2)
                result = new Point(a[tmp].khung.Right, a[tmp].khung.Top);
            else if (value == 3)
                result = new Point(a[tmp].khung.Right, a[tmp].khung.Top + (a[tmp].khung.Height / 2));
            else if (value == 4)
                result = new Point(a[tmp].khung.Right, a[tmp].khung.Bottom);
            else if (value == 5)
                result = new Point(a[tmp].khung.Left + (a[tmp].khung.Width / 2), a[tmp].khung.Bottom);
            else if (value == 6)
                result = new Point(a[tmp].khung.Left, a[tmp].khung.Bottom);
            else if (value == 7)
                result = new Point(a[tmp].khung.Left, a[tmp].khung.Top + (a[tmp].khung.Height / 2));
            return result;
        }
        private int GetHandleIndexUnderMouse(Point mouseLocation)
        {
            int tmp = tcMain.SelectedIndex;

            // Kiểm tra xem con trỏ chuột có nằm trong khu vực của các điểm resize không
            for (int i = 0; i < 8; i++)
            {
                Point handlePoint = GetHandlePoint(i);
                Rectangle handleRect = new Rectangle(handlePoint.X - 5 / 2, handlePoint.Y - 5 / 2, 5, 5);

                if (handleRect.Contains(mouseLocation))
                {
                    return i; // Trả về chỉ số của điểm resize nếu con trỏ nằm trong khu vực của nó
                }
            }

            return -1; // Trả về -1 nếu con trỏ không nằm trong khu vực của bất kỳ điểm resize nào
        }
        private Rectangle GetHandleRect(int stt)
        {
            // trả về diện tích điểm điều khiển theo stt
            Point p = GetHandlePoint(stt);
            p.Offset(-2, -2);
            return new Rectangle(p, new Size(5, 5));
        }



    }
}
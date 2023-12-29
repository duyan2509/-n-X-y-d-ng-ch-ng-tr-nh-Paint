using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Brushes = System.Drawing.Brushes;

namespace UI
{
    public partial class FormMain : Form
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
        private void updateFrameBaseOnHandlesPoint(Point e)
        {
            int tmp = tcMain.SelectedIndex;
            if (a[tmp].dragHandle == 0)
            {
                int diffY = a[tmp].dragPoint.Y - e.Y;
                int diffX = a[tmp].dragPoint.X - e.X;
                Rectangle rtg = new Rectangle();
                rtg = new Rectangle(a[tmp].khungCu.Left - diffX, a[tmp].khungCu.Top - diffY, a[tmp].khungCu.Width + diffX, a[tmp].khungCu.Height + diffY);
                if (a[tmp].resizeIndex == 5)//line
                    a[tmp].khung = rtg;
                else
                    a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                a[tmp].pictureBox.Cursor = Cursors.SizeNWSE;
            }
            else if (a[tmp].dragHandle == 1)
            {
                int diff = a[tmp].dragPoint.Y - e.Y;
                Rectangle rtg = new Rectangle();
                rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top - diff, a[tmp].khungCu.Width, a[tmp].khungCu.Height + diff);
                if (a[tmp].resizeIndex == 5)
                    a[tmp].khung = rtg;
                else
                    a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                a[tmp].pictureBox.Cursor = Cursors.SizeNS;
            }
            else if (a[tmp].dragHandle == 2)
            {
                int diffY = a[tmp].dragPoint.Y - e.Y;
                int diffX = a[tmp].dragPoint.X - e.X;
                Rectangle rtg = new Rectangle();
                rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top - diffY, a[tmp].khungCu.Width - diffX, a[tmp].khungCu.Height + diffY);
                if (a[tmp].resizeIndex == 5)
                    a[tmp].khung = rtg;
                else
                    a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                a[tmp].pictureBox.Cursor = Cursors.SizeNESW;
            }
            else if (a[tmp].dragHandle == 3)
            {
                int diff = a[tmp].dragPoint.X - e.X;
                Rectangle rtg = new Rectangle();
                rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top, a[tmp].khungCu.Width - diff, a[tmp].khungCu.Height);
                if (a[tmp].resizeIndex == 5)
                    a[tmp].khung = rtg;
                else
                    a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                a[tmp].pictureBox.Cursor = Cursors.SizeWE;
            }
            else if (a[tmp].dragHandle == 4)
            {
                int diffY = a[tmp].dragPoint.Y - e.Y;
                int diffX = a[tmp].dragPoint.X - e.X;
                Rectangle rtg = new Rectangle();
                rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top, a[tmp].khungCu.Width - diffX, a[tmp].khungCu.Height - diffY);
                if (a[tmp].resizeIndex == 5)
                    a[tmp].khung = rtg;
                else
                    a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                a[tmp].pictureBox.Cursor = Cursors.SizeNWSE;
            }
            else if (a[tmp].dragHandle == 5)
            {
                int diff = a[tmp].dragPoint.Y - e.Y;
                Rectangle rtg = new Rectangle();
                rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top, a[tmp].khungCu.Width, a[tmp].khungCu.Height - diff);
                if (a[tmp].resizeIndex == 5)
                    a[tmp].khung = rtg;
                else
                    a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                a[tmp].pictureBox.Cursor = Cursors.SizeNS;
            }
            else if (a[tmp].dragHandle == 6)
            {
                int diffY = a[tmp].dragPoint.Y - e.Y;
                int diffX = a[tmp].dragPoint.X - e.X;
                Rectangle rtg = new Rectangle();
                rtg = new Rectangle(a[tmp].khungCu.Left - diffX, a[tmp].khungCu.Top, a[tmp].khungCu.Width + diffX, a[tmp].khungCu.Height - diffY);
                if (a[tmp].resizeIndex == 5)
                    a[tmp].khung = rtg;
                else
                    a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                a[tmp].pictureBox.Cursor = Cursors.SizeNESW;
            }
            else if (a[tmp].dragHandle == 7)
            {
                int diff = a[tmp].dragPoint.X - e.X;
                Rectangle rtg = new Rectangle();
                rtg = new Rectangle(a[tmp].khungCu.Left - diff, a[tmp].khungCu.Top, a[tmp].khungCu.Width + diff, a[tmp].khungCu.Height);
                if (a[tmp].resizeIndex == 5)
                    a[tmp].khung = rtg;
                else
                    a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                a[tmp].pictureBox.Cursor = Cursors.SizeWE;
            }
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

                Rectangle handleFrame = a[tmp].khung;

                if (handleRect.Contains(mouseLocation))
                {
                    return i; // Trả về chỉ số của điểm resize nếu con trỏ nằm trong khu vực của nó
                }
                else if (handleFrame.Contains(mouseLocation))
                {
                    return 9;
                }
            }

           

            return -1; // Trả về -1 nếu con trỏ không nằm trong khu vực của bất kỳ điểm resize nào
        }
        private Rectangle GetHandleRect(int stt)
        {
            // trả về diện tích điểm điều khiển theo stt
            Point p = GetHandlePoint(stt);
            p.Offset(-2, -2);
            return new Rectangle(p, new Size(7, 7));
        }



    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Stack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }
        private Rectangle areaRect = new Rectangle(100, 100, 300, 300); // hinh da ve 
        private Rectangle oldRect;// hinh cu
        private int dragHandle = -1;// stt o dieu khien
        private Point dragPoint; // o dieu khien

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dragHandle == 0)
                {
                    int diffY = dragPoint.Y - e.Location.Y;
                    int diffX = dragPoint.X - e.Location.X;
                    areaRect = new Rectangle(oldRect.Left - diffX, oldRect.Top - diffY, oldRect.Width + diffX, oldRect.Height + diffY);
                }
                else if (dragHandle == 1)
                {
                    int diff=dragPoint.Y-e.Location.Y;
                    areaRect = new Rectangle(oldRect.Left, oldRect.Top-diff, oldRect.Width, oldRect.Height+diff);
                }
                else if (dragHandle == 2)
                {
                    int diffY = dragPoint.Y - e.Location.Y;
                    int diffX = dragPoint.X - e.Location.X;
                    areaRect = new Rectangle(oldRect.Left , oldRect.Top - diffY, oldRect.Width - diffX, oldRect.Height + diffY);
                }
                else if (dragHandle == 3)
                {
                    int diff = dragPoint.X - e.Location.X;
                    areaRect = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diff, oldRect.Height);
                }
                else if (dragHandle == 4)
                {
                    int diffY = dragPoint.Y - e.Location.Y;
                    int diffX = dragPoint.X - e.Location.X;
                    areaRect = new Rectangle(oldRect.Left, oldRect.Top , oldRect.Width - diffX, oldRect.Height - diffY);
                }
                else if (dragHandle == 5)
                {
                    int diff = dragPoint.Y - e.Location.Y;
                    areaRect = new Rectangle(oldRect.Left, oldRect.Top , oldRect.Width, oldRect.Height - diff);
                }
                else if (dragHandle == 6)
                {
                    int diffY = dragPoint.Y - e.Location.Y;
                    int diffX = dragPoint.X - e.Location.X;
                    areaRect = new Rectangle(oldRect.Left -diffX, oldRect.Top, oldRect.Width + diffX, oldRect.Height - diffY);
                }
                else if (dragHandle == 7)
                {
                    int diff = dragPoint.X - e.Location.X;
                    areaRect = new Rectangle(oldRect.Left - diff, oldRect.Top, oldRect.Width + diff, oldRect.Height);
                }

                if (dragHandle >-1)
                    pictureBox1.Invalidate();
                base.OnMouseMove(e);
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (GetHandleRect(i).Contains(e.Location))
                {
                    dragHandle = i;
                    oldRect = areaRect;
                    dragPoint = GetHandlePoint(i);
                }
            }
            base.OnMouseDown(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragHandle = 0;
            base.OnMouseUp(e);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red, areaRect);

            // ve diem dieu khien
            for (int i = 0; i < 8; i++)
            {
                e.Graphics.FillRectangle(Brushes.DarkRed, GetHandleRect(i));
            }
            base.OnPaint(e);
        }
        private Point GetHandlePoint(int value)
        {
            //trả về vị trí điểm điều khiển 
            Point result = Point.Empty;

            if (value == 0)
                result = new Point(areaRect.Left, areaRect.Top);
            else if (value == 1)
                result = new Point(areaRect.Left + (areaRect.Width / 2), areaRect.Top);
            else if (value == 2)
                result = new Point(areaRect.Right, areaRect.Top);
            else if (value == 3)
                result = new Point(areaRect.Right, areaRect.Top + (areaRect.Height / 2));
            else if (value == 4)
                result = new Point(areaRect.Right, areaRect.Bottom);
            else if (value == 5)
                result = new Point(areaRect.Left + (areaRect.Width / 2), areaRect.Bottom);
            else if (value == 6)
                result = new Point(areaRect.Left, areaRect.Bottom);
            else if (value == 7)
                result = new Point(areaRect.Left, areaRect.Top + (areaRect.Height / 2));

            return result;
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

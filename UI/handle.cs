using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;


using System.Windows.Forms;
using System.Drawing.Drawing2D;
using UI.Shape;
using Brushes = System.Drawing.Brushes;

namespace UI
{
    public partial class Form1:Form
    {
        private void handleMouseClick(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (tmp < a.Count)
            {
                if (a[tmp].Fill)
                {
                    Point temp = e.Location;
                    int selectedShapeIndex = -1;
                    for (int i = 0; i < a[tmp].region.Count; i++)
                    {
                        if (a[tmp].region[i].IsVisible(temp))
                        {
                            selectedShapeIndex = i;
                            break;
                        }
                    }

                    if (selectedShapeIndex != -1)
                    {
                        a[tmp].G.FillRegion(a[tmp].brush, a[tmp].region[selectedShapeIndex]);
                        selectedShapeIndex = -1;
                    }
                    if (a[tmp].index < 6)
                        a[tmp].Fill = false;
                }
                
            }
        }
        private void handlePaint(object sender, PaintEventArgs e)
        {
            
            int tmp = tcMain.SelectedIndex;
            if (tmp < a.Count)
            {
                Graphics g = e.Graphics;
                //Ve hinh khi dang nhan chuot
                if (a[tmp].Paint)
                {
                    if (a[tmp].index == 2)//example
                    {
                        int x = Math.Min(a[tmp].cX, a[tmp].x);
                        int y = Math.Min(a[tmp].cY, a[tmp].y);
                        //draw elip
                        g.DrawEllipse(a[tmp].Pen, x, y,Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));

                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));

                        if (a[tmp].visibleFrame)
                        {
                            g.DrawRectangle(a[tmp].Pen, a[tmp].khung);


                            for (int i = 0; i < 8; i++)
                            {
                                e.Graphics.FillRectangle(Brushes.DarkRed, GetHandleRect(i));
                            }
                        }
                    }
                    if (a[tmp].index == 3)
                    {
                        //vuong: ve theo canh nho hon
                        int side = Math.Abs(a[tmp].sX);
                        if (Math.Abs(a[tmp].sX) > Math.Abs(a[tmp].sY))
                            side = Math.Abs(a[tmp].sY);
                        Point point1 = new Point(a[tmp].cX, a[tmp].cY);
                        Point point3 = new Point(a[tmp].cX, a[tmp].cY);
                        if (a[tmp].x > a[tmp].cX)
                            point3.X += side;
                        else if (a[tmp].x < a[tmp].cX)
                            point3.X -= side;
                        if (a[tmp].y > a[tmp].cY)
                            point3.Y += side;
                        else if (a[tmp].y < a[tmp].cY)
                            point3.Y -= side;
                        Point point2 = new Point(point1.X, point3.Y);
                        Point point4 = new Point(point3.X, point1.Y);
                        Point[] ptsArray = { point1, point2, point3, point4 };
                        g.DrawPolygon(a[tmp].Pen, ptsArray);
                    }
                    if (a[tmp].index == 4)
                    {
                        //ve hinh tron
                        int side = 0;
                        if (Math.Abs(a[tmp].sX) > Math.Abs(a[tmp].sY))
                            side = Math.Abs(a[tmp].sY);
                        else
                            side = Math.Abs(a[tmp].sX);
                        int dauW = 1;
                        int dauH = 1;
                        if (a[tmp].sX < 0)
                            dauW = -1;
                        if (a[tmp].sY < 0)
                            dauH = -1;
                        g.DrawEllipse(a[tmp].Pen, a[tmp].cX, a[tmp].cY, dauW * side, dauH * side);





                    }
                    if (a[tmp].index == 5)
                    {
                        //Ve line
                        g.DrawLine(a[tmp].Pen, a[tmp].cX, a[tmp].cY, a[tmp].x, a[tmp].y);
                    }
                    if (a[tmp].index == 7)
                    {
                        //Ve Hinh Chu Nhat
                        a[tmp].khung=new Rectangle(a[tmp].cX, a[tmp].cY, a[tmp].sX, a[tmp].sY);
                        g.DrawRectangle(a[tmp].Pen, a[tmp].khung);


                        for (int i = 0; i < 8; i++)
                        {
                            e.Graphics.FillRectangle(Brushes.DarkRed, GetHandleRect(i));
                        }
                    }
                    if (a[tmp].index == 8)
                    {
                        //Ve Tam Giac Can
                        Point dinhA = new Point(a[tmp].cX, a[tmp].cY);
                        Point dinhB = new Point(a[tmp].cX + a[tmp].sX, a[tmp].cY);
                        Point dinhC = new Point(a[tmp].cX + a[tmp].sX / 2, a[tmp].cY + a[tmp].sY);
                        Point[] dinhArray = { dinhA, dinhB, dinhC };

                        g.DrawPolygon(a[tmp].Pen, dinhArray);
                    }
                    if (a[tmp].index == 9)
                    {
                        // Ve Tam Giac Vuong
                        Point dinhA = new Point(a[tmp].cX, a[tmp].cY);
                        Point dinhB = new Point(a[tmp].cX, a[tmp].cY + a[tmp].sY);
                        Point dinhC = new Point(a[tmp].cX + a[tmp].sX, a[tmp].cY);

                        Point[] dinhArray = { dinhA, dinhB, dinhC };

                        g.DrawPolygon(a[tmp].Pen, dinhArray);
                    }
                    if (a[tmp].index == 10)
                    {
                        // Ve Hinh Luc Giac
                        Point p1 = new Point(a[tmp].cX + a[tmp].sX / 4, a[tmp].cY);
                        Point p2 = new Point(a[tmp].cX + 3 * a[tmp].sX / 4, a[tmp].cY);
                        Point p3 = new Point(a[tmp].cX, a[tmp].cY + a[tmp].sY / 2);
                        Point p4 = new Point(a[tmp].cX + a[tmp].sX, a[tmp].cY + a[tmp].sY / 2);
                        Point p5 = new Point(a[tmp].cX + a[tmp].sX / 4, a[tmp].cY + a[tmp].sY);
                        Point p6 = new Point(a[tmp].cX + 3 * a[tmp].sX / 4, a[tmp].cY + a[tmp].sY);
                        Point[] pArray = { p1, p2, p4, p6, p5, p3 };

                        g.DrawPolygon(a[tmp].Pen, pArray);
                    }
                    if (a[tmp].index == 11)
                    {
                        // Ve Mui Ten
                        Point p1 = new Point(a[tmp].cX, a[tmp].cY + a[tmp].sY / 3);
                        Point p2 = new Point(a[tmp].cX + 2 * a[tmp].sX / 3, a[tmp].cY + a[tmp].sY / 3);
                        Point p3 = new Point(a[tmp].cX + 2 * a[tmp].sX / 3, a[tmp].cY);
                        Point p4 = new Point(a[tmp].cX + a[tmp].sX, a[tmp].cY + a[tmp].sY / 2);
                        Point p5 = new Point(a[tmp].cX + 2 * a[tmp].sX / 3, a[tmp].cY + a[tmp].sY);
                        Point p6 = new Point(a[tmp].cX + 2 * a[tmp].sX / 3, a[tmp].cY + 2 * a[tmp].sY / 3);
                        Point p7 = new Point(a[tmp].cX, a[tmp].cY + 2 * a[tmp].sY / 3);
                        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

                        g.DrawPolygon(a[tmp].Pen, pArray);

                        a[tmp].khung = new Rectangle(p1.X, p3.Y, Math.Abs(p4.X-p1.X),Math.Abs(p3.Y-p5.Y));
                        g.DrawRectangle(a[tmp].Pen, a[tmp].khung);


                        for (int i = 0; i < 8; i++)
                        {
                            e.Graphics.FillRectangle(Brushes.DarkRed, GetHandleRect(i));
                        }
                    }


                }
                if (a[tmp].isResize)
                {
                    g.DrawRectangle(a[tmp].Pen, a[tmp].khung);


                    if (a[tmp].index == 2)
                        g.DrawEllipse(a[tmp].Pen, a[tmp].khung);
                    else if (a[tmp].index == 3 || a[tmp].index == 7)
                        g.DrawRectangle(a[tmp].Pen, a[tmp].khung);
                    else if (a[tmp].index == 8 || a[tmp].index == 9 || a[tmp].index == 10 || a[tmp].index == 11)
                    {
                        Point p1 = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height / 3);
                        Point p2 = new Point(a[tmp].khung.X + 2 * a[tmp].khung.Width / 3, a[tmp].khung.Y + a[tmp].khung.Height / 3);
                        Point p3 = new Point(a[tmp].khung.X + 2 * a[tmp].khung.Width / 3, a[tmp].khung.Y);
                        Point p4 = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height / 2);
                        Point p5 = new Point(a[tmp].khung.X + 2 * a[tmp].khung.Width / 3, a[tmp].khung.Y + a[tmp].khung.Height);
                        Point p6 = new Point(a[tmp].khung.X + 2 * a[tmp].khung.Width / 3, a[tmp].khung.Y + 2 * a[tmp].khung.Height / 3);
                        Point p7 = new Point(a[tmp].khung.X, a[tmp].khung.Y + 2 * a[tmp].khung.Height / 3);
                        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

                        g.DrawPolygon(a[tmp].Pen, pArray);
                    }
                        //a[tmp].index==8|| a[tmp].index == 9 || a[tmp].index == 10 ||


                    for (int i = 0; i < 8; i++)
                    {
                        g.FillRectangle(Brushes.DarkRed, GetHandleRect(i));
                    }
                }

            }

        }
        private void handleMouseUp(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;

            if (tmp < a.Count)
            {
                a[tmp].Paint = false;
                a[tmp].resizeIndex = a[tmp].index;
                a[tmp].isResize = true;

                a[tmp].visibleFrame = true;
                a[tmp].pictureBox.Invalidate();
            }
        }
        private void handleMouseMove(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if(e.Button==MouseButtons.Left)
            {
                if (tmp < a.Count)
                {
                    if (a[tmp].Paint)
                    {
                        if (a[tmp].index == 1)
                        {
                            //pen
                            a[tmp].px = e.Location;
                            a[tmp].G.DrawLine(a[tmp].Pen, a[tmp].px, a[tmp].py);
                            a[tmp].py = a[tmp].px;
                        }
                        if (a[tmp].index == 15)
                        {
                            //eraser
                            a[tmp].px = e.Location;
                            a[tmp].G.DrawLine(a[tmp].Eraser, a[tmp].px, a[tmp].py);
                            a[tmp].py = a[tmp].px;
                        }
                        a[tmp].pictureBox.Invalidate();

                    }
                    if (a[tmp].isResize)
                    {
                        if (a[tmp].dragHandle == 0)
                        {
                            int diffY = a[tmp].dragPoint.Y - e.Location.Y;
                            int diffX = a[tmp].dragPoint.X - e.Location.X;
                            a[tmp].khung = new Rectangle(a[tmp].khungCu.Left - diffX, a[tmp].khungCu.Top - diffY, a[tmp].khungCu.Width + diffX, a[tmp].khungCu.Height + diffY);
                        }
                        else if (a[tmp].dragHandle == 1)
                        {
                            int diff = a[tmp].dragPoint.Y - e.Location.Y;
                            a[tmp].khung = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top - diff, a[tmp].khungCu.Width, a[tmp].khungCu.Height + diff);
                        }
                        else if (a[tmp].dragHandle == 2)
                        {
                            int diffY = a[tmp].dragPoint.Y - e.Location.Y;
                            int diffX = a[tmp].dragPoint.X - e.Location.X;
                            a[tmp].khung = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top - diffY, a[tmp].khungCu.Width - diffX, a[tmp].khungCu.Height + diffY);
                        }
                        else if (a[tmp].dragHandle == 3)
                        {
                            int diff = a[tmp].dragPoint.X - e.Location.X;
                            a[tmp].khung = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top, a[tmp].khungCu.Width - diff, a[tmp].khungCu.Height);
                        }
                        else if (a[tmp].dragHandle == 4)
                        {
                            int diffY = a[tmp].dragPoint.Y - e.Location.Y;
                            int diffX = a[tmp].dragPoint.X - e.Location.X;
                            a[tmp].khung = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top, a[tmp].khungCu.Width - diffX, a[tmp].khungCu.Height - diffY);
                        }
                        else if (a[tmp].dragHandle == 5)
                        {
                            int diff = a[tmp].dragPoint.Y - e.Location.Y;
                            a[tmp].khung = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top, a[tmp].khungCu.Width, a[tmp].khungCu.Height - diff);
                        }
                        else if (a[tmp].dragHandle == 6)
                        {
                            int diffY = a[tmp].dragPoint.Y - e.Location.Y;
                            int diffX = a[tmp].dragPoint.X - e.Location.X;
                            a[tmp].khung = new Rectangle(a[tmp].khungCu.Left - diffX, a[tmp].khungCu.Top, a[tmp].khungCu.Width + diffX, a[tmp].khungCu.Height - diffY);
                        }
                        else if (a[tmp].dragHandle == 7)
                        {
                            int diff = a[tmp].dragPoint.X - e.Location.X;
                            a[tmp].khung = new Rectangle(a[tmp].khungCu.Left - diff, a[tmp].khungCu.Top, a[tmp].khungCu.Width + diff, a[tmp].khungCu.Height);
                        }


                        if (a[tmp].dragHandle > -1)
                            a[tmp].pictureBox.Invalidate();
                        else
                        {
                            //handle move
                            
                            int newX = a[tmp].khung.Left + e.X - a[tmp].cX;
                            int newY = a[tmp].khung.Top + e.Y - a[tmp].cY;
                            a[tmp].khung = new Rectangle(newX, newY, a[tmp].khung.Width, a[tmp].khung.Height); // chinh sua net dut

                            a[tmp].pictureBox.Invalidate();
                            a[tmp].cX = e.X;
                            a[tmp].cY = e.Y;
                        }

                    }
                    a[tmp].x = e.X;
                    a[tmp].y = e.Y;
                    // Tinh sX,sY de truyen len control_Paint
                    a[tmp].sX = a[tmp].x - a[tmp].cX;
                    a[tmp].sY = a[tmp].y - a[tmp].cY;
                }

                
            }
        }
        private void handleMouseDown(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (tmp < a.Count)
            {
                int checkODK = 0;
                for (int i = 0; i < 8; i++)
                    if (GetHandleRect(i).Contains(e.Location))
                        checkODK = 1;
                if (checkODK == 0 && !a[tmp].khung.IsEmpty  && !a[tmp].khung.Contains(e.Location) )
                {
                    // ve chinh thuc
                    a[tmp].visibleFrame = false;
                    if (a[tmp].resizeIndex == 7)
                    {
                        a[tmp].isResize = false;
                        a[tmp].G.DrawRectangle(a[tmp].Pen, a[tmp].khung);
                        a[tmp].pictureBox.Refresh();
                        a[tmp].dragHandle = -1;
                        a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                    }
                    else if (a[tmp].resizeIndex == 2)
                    {
                        a[tmp].isResize = false;
                        
                        a[tmp].G.DrawEllipse(a[tmp].Pen, a[tmp].khung);
                        a[tmp].pictureBox.Refresh();
                        a[tmp].dragHandle = -1;
                        a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                    }
                    else if (a[tmp].resizeIndex == 11)
                    {
                        a[tmp].isResize = false;

                        Point p1 = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height / 3);
                        Point p2 = new Point(a[tmp].khung.X + 2 * a[tmp].khung.Width / 3, a[tmp].khung.Y + a[tmp].khung.Height / 3);
                        Point p3 = new Point(a[tmp].khung.X + 2 * a[tmp].khung.Width / 3, a[tmp].khung.Y);
                        Point p4 = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height / 2);
                        Point p5 = new Point(a[tmp].khung.X + 2 * a[tmp].khung.Width / 3, a[tmp].khung.Y + a[tmp].khung.Height);
                        Point p6 = new Point(a[tmp].khung.X + 2 * a[tmp].khung.Width / 3, a[tmp].khung.Y + 2 * a[tmp].khung.Height / 3);
                        Point p7 = new Point(a[tmp].khung.X, a[tmp].khung.Y + 2 * a[tmp].khung.Height / 3);
                        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

                        a[tmp].G.DrawPolygon(a[tmp].Pen, pArray);
                        a[tmp].pictureBox.Refresh();
                        a[tmp].dragHandle = -1;
                        a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                    }
                }


                if (a[tmp].isResize)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (GetHandleRect(i).Contains(e.Location))
                        {
                            a[tmp].dragHandle = i;
                            a[tmp].khungCu = a[tmp].khung;
                            a[tmp].dragPoint = GetHandlePoint(i);
                        }
                    }

                    if (checkODK == 0 &&!a[tmp].khung.IsEmpty && a[tmp].khung.Contains(e.Location))
                    {
                        a[tmp].dragHandle = -1;
                        a[tmp].cX = e.X;
                        a[tmp].cY = e.Y;
                        //MessageBox.Show("2");
                        //a[tmp].isResize = false;
                        //a[tmp].G.DrawRectangle(a[tmp].Pen, a[tmp].khung);
                        //a[tmp].pictureBox.Refresh();
                        //a[tmp].dragHandle = -1;
                        //a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                    }

                }
                else
                {
                    a[tmp].Paint = true;
                    a[tmp].py = e.Location;
                    a[tmp].cX = e.X;
                    a[tmp].cY = e.Y;
                }
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

        private Rectangle GetHandleRect(int stt)
        {
            // trả về diện tích điểm điều khiển theo stt
            Point p = GetHandlePoint(stt);
            p.Offset(-2, -2);
            return new Rectangle(p, new Size(5, 5));
        }
        
       
        private void handleClickPenButton(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (tmp < a.Count)
            {
                a[tmp].index = 1;
            }

        }
        private void handleClickEraseButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 15;
                    
                }
            }
        }
        private void handleClickFillButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].Fill = true;
                    a[tmp].index = 6;
                }
            }
        }
        private void handleClickTextButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {

            }
        }
        private void handleClickBrushButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {

            }
        }
        private void handleClickEllipseButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 2;
                }
            }
        }
        private void handleClickSquareButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 3;
                }
            }
        }
     
        private void handleClickCircleButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 4;
                }
            }
        }

        private void handleClickRectangleButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 7;
                }
            }
        }

        
        private void handleClickTriangleButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 8;
                }
            }
        }
        private void handleClickright_TriangleButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 9;
                }
            }
        }
        private void handleClickHexagonButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 10;
                }
            }
        }
        private void handleClickArrowButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 11;
                }
            }
        }
        private void handleClickStarButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 12;
                }
            }
        }
    }
}

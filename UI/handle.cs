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
                    if (a[tmp].index == 2)
                    {
                        //draw elip
                        g.DrawEllipse(a[tmp].Pen, a[tmp].cX, a[tmp].cY, a[tmp].sX, a[tmp].sY);
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
                        g.DrawRectangle(a[tmp].Pen, a[tmp].cX, a[tmp].cY, a[tmp].sX, a[tmp].sY);
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

                //Ve hinh chinh thuc sau khi tha chuot
                if (a[tmp].index == 2)
                {
                    //draw elip
                    a[tmp].G.DrawEllipse(a[tmp].Pen, a[tmp].cX, a[tmp].cY, a[tmp].sX, a[tmp].sY);
                    //tao region
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(a[tmp].cX, a[tmp].cY, a[tmp].sX, a[tmp].sY);
                    a[tmp].region.Add(new Region(path));
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
                    a[tmp].G.DrawPolygon(a[tmp].Pen, ptsArray);
                    //tao region
                    GraphicsPath path = new GraphicsPath();
                    path.AddPolygon(ptsArray);
                    a[tmp].region.Add(new Region(path));
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
                    a[tmp].G.DrawEllipse(a[tmp].Pen, a[tmp].cX, a[tmp].cY, dauW * side, dauH * side);
                    //tao region
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(a[tmp].cX, a[tmp].cY, dauW * side, dauH * side);
                    a[tmp].region.Add(new Region(path));

                }
                if (a[tmp].index == 5)
                {
                    //Ve line
                    a[tmp].G.DrawLine(a[tmp].Pen, a[tmp].cX, a[tmp].cY, a[tmp].x, a[tmp].y);
                }
                if (a[tmp].index == 7)
                {
                    //Ve Hinh Chu Nhat
                    HinhChuNhat hcn=new HinhChuNhat(new PointF(a[tmp].cX, a[tmp].cY),new PointF(a[tmp].x, a[tmp].y));
                    a[tmp].G.DrawRectangle(a[tmp].Pen, a[tmp].cX, a[tmp].cY, a[tmp].sX, a[tmp].sY);
                    hcn.VeKhung(a[tmp].G);
                    hcn.VeDiemDieuKhien(a[tmp].G);
                    a[tmp].pictureBox.MouseDown += hcn.Mouse_Down;
                    a[tmp].pictureBox.MouseUp+= hcn.Mouse_Up;
                    a[tmp].pictureBox.MouseMove += hcn.Mouse_Move;







                }
                if (a[tmp].index == 8)
                {
                    //Ve Tam Giac Can
                    Point dinhA = new Point(a[tmp].cX, a[tmp].cY);
                    Point dinhB = new Point(a[tmp].cX + a[tmp].sX, a[tmp].cY);
                    Point dinhC = new Point(a[tmp].cX + a[tmp].sX / 2, a[tmp].cY + a[tmp].sY);

                    Point[] dinhArray = { dinhA, dinhB, dinhC };

                    a[tmp].G.DrawPolygon(a[tmp].Pen, dinhArray);
                }
                if (a[tmp].index == 9)
                {
                    // Ve Tam Giac Vuong
                    Point dinhA = new Point(a[tmp].cX, a[tmp].cY);
                    Point dinhB = new Point(a[tmp].cX , a[tmp].cY + a[tmp].sY);
                    Point dinhC = new Point(a[tmp].cX + a[tmp].sX, a[tmp].cY);

                    Point[] dinhArray = { dinhA, dinhB, dinhC };

                    a[tmp].G.DrawPolygon(a[tmp].Pen, dinhArray);
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

                    a[tmp].G.DrawPolygon(a[tmp].Pen, pArray);
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

                    a[tmp].G.DrawPolygon(a[tmp].Pen, pArray);
                }
                if (a[tmp].index == 12)
                {
                    // Ve Ngoi Sao

                }
            }
        }
        private void handleMouseMove(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
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
                }
                Refresh();

                a[tmp].x = e.X;
                a[tmp].y = e.Y;
                // Tinh sX,sY de truyen len control_Paint
                a[tmp].sX = a[tmp].x - a[tmp].cX;
                a[tmp].sY = a[tmp].y - a[tmp].cY;
            }
        }
        private void handleMouseDown(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (tmp < a.Count)
            {
                a[tmp].Paint = true;
                a[tmp].py = e.Location;
                a[tmp].cX = e.X;
                a[tmp].cY = e.Y;
            }
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

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
using ComponentFactory.Krypton.Toolkit;

namespace UI
{
    public partial class Form1:Form
    {
        private bool checkFirstDraw = false;
        private void handleMouseClick(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (tmp < a.Count)
            {
                if (a[tmp].Fill)
                {
                    a[tmp].listBitmap.Add(new Bitmap(a[tmp].pictureBox.Image));
                    a[tmp].iBitmap++;
                    Fill(e.X,e.Y,dlgColor.Color);
                    a[tmp].listBitmap[a[tmp].listBitmap.Count - 1] = new Bitmap(a[tmp].pictureBox.Image);
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
                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                        g.DrawEllipse(a[tmp].Pen, a[tmp].khung);

                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));

                    }
                    if (a[tmp].index == 5)
                    {
                        //Ve line
                        a[tmp].khung = new Rectangle(a[tmp].cX, a[tmp].cY, a[tmp].sX, a[tmp].sY);

                        g.DrawLine(a[tmp].Pen, a[tmp].cX, a[tmp].cY, a[tmp].x, a[tmp].y);
                    }
                    if (a[tmp].index == 3 )
                    {
                        //copy
                        int x = Math.Min(a[tmp].cX, a[tmp].x);
                        int y = Math.Min(a[tmp].cY, a[tmp].y);
                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                        // ve khung
                        g.DrawRectangle(resizePen, a[tmp].khung);
                    }
                    if (a[tmp].index == 4)
                    {
                        //paste
                        int x = Math.Min(a[tmp].cX, a[tmp].x);
                        int y = Math.Min(a[tmp].cY, a[tmp].y);
                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                        // ve khung
                        g.DrawRectangle(resizePen, a[tmp].khung);
                    }
                    if (a[tmp].index == 7)
                    {
                        //Ve Hinh Chu Nhat
                        int x = Math.Min(a[tmp].cX, a[tmp].x);
                        int y = Math.Min(a[tmp].cY, a[tmp].y);
                        a[tmp].khung=new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                        g.DrawRectangle(a[tmp].Pen, a[tmp].khung);
                    }
                    if (a[tmp].index == 8)
                    {
                        //Ve Tam Giac Can
                        int x = Math.Min(a[tmp].cX, a[tmp].x);
                        int y = Math.Min(a[tmp].cY, a[tmp].y);
                        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                        int lY = Math.Max(a[tmp].cY, a[tmp].y);

                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));


                        Point dinhA = new Point(lX, lY);
                        Point dinhB = new Point(x, lY);
                        Point dinhC = new Point((lX + x) /2 , y);
                        Point[] dinhArray = { dinhC, dinhA, dinhB };
                        g.DrawPolygon(a[tmp].Pen, dinhArray);
                       
                    }
                    if (a[tmp].index == 9)
                    {
                        // Ve Tam Giac Vuong
                        int x = Math.Min(a[tmp].cX, a[tmp].x);
                        int y = Math.Min(a[tmp].cY, a[tmp].y);
                        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                        int lY = Math.Max(a[tmp].cY, a[tmp].y);
                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                        Point dinhA = new Point(x, y);
                        Point dinhB = new Point(x, lY);
                        Point dinhC = new Point(lX, lY);

                        Point[] dinhArray = { dinhA, dinhB, dinhC };

                        g.DrawPolygon(a[tmp].Pen, dinhArray);
                    }
                    if (a[tmp].index == 10)
                    {
                        // Ve Hinh Luc Giac
                        int x = Math.Min(a[tmp].cX, a[tmp].x);
                        int y = Math.Min(a[tmp].cY, a[tmp].y);
                        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                        int lY = Math.Max(a[tmp].cY, a[tmp].y);
                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                        // Calculate the points for the hexagon
                        Point p1 = new Point(x + (a[tmp].khung.Width) / 4, y); // Top vertex
                        Point p2 = new Point(lX - (a[tmp].khung.Width) / 4, y); // Top-right vertex
                        Point p3 = new Point(lX, y + (a[tmp].khung.Height) / 2); // Right vertex
                        Point p4 = new Point(lX - (a[tmp].khung.Width) / 4, lY); // Bottom-right vertex
                        Point p5 = new Point(x + (a[tmp].khung.Width) / 4, lY); // Bottom-left vertex
                        Point p6 = new Point(x, y + (a[tmp].khung.Height) / 2);  // Bottom-left vertex
                        Point[] pArray = { p1, p2, p3, p4, p5, p6 };

                        g.DrawPolygon(a[tmp].Pen, pArray);
                    }
                    if (a[tmp].index == 11)
                    {
                        int x = Math.Min(a[tmp].cX, a[tmp].x);
                        int y = Math.Min(a[tmp].cY, a[tmp].y);
                        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                        int lY = Math.Max(a[tmp].cY, a[tmp].y);
                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                        // Ve Mui Ten
                        Point p1 = new Point(lX, y + (a[tmp].khung.Height / 2)); 
                        Point p2 = new Point(lX - (a[tmp].khung.Width / 3), y); 
                        Point p3 = new Point(lX - (a[tmp].khung.Width / 3), y + (a[tmp].khung.Height / 3)); 
                        Point p4 = new Point(x, y + (a[tmp].khung.Height / 3)); 
                        Point p5 = new Point(x, lY - (a[tmp].khung.Height / 3)); 
                        Point p6 = new Point(lX - (a[tmp].khung.Width / 3), lY - (a[tmp].khung.Height / 3)); 
                        Point p7 = new Point(lX - (a[tmp].khung.Width / 3), lY); 
                        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

                        g.DrawPolygon(a[tmp].Pen, pArray);
                    }
                    if(a[tmp].index == 12)
                    {
                        // Ve ngoi sao
                        int x = Math.Min(a[tmp].cX, a[tmp].x);
                        int y = Math.Min(a[tmp].cY, a[tmp].y);
                        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                        int lY = Math.Max(a[tmp].cY, a[tmp].y);
                        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));

                        Point p1 = new Point(x + (a[tmp].khung.Width / 2), y);
                        Point p2 = new Point(lX - (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                        Point p3 = new Point(lX, y + (3 * (a[tmp].khung.Height) / 8));
                        Point p4 = new Point(lX - (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                        Point p5 = new Point(lX - (3 * a[tmp].khung.Width / 14), lY);
                        Point p6 = new Point(x + a[tmp].khung.Width / 2, lY - (3 * a[tmp].khung.Height / 14));
                        Point p7 = new Point(x + (3 * a[tmp].khung.Width / 14), lY);
                        Point p8 = new Point(x + (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                        Point p9 = new Point(x, y + (3 * (a[tmp].khung.Height) / 8));
                        Point p10 = new Point(x + (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

                        g.DrawPolygon(a[tmp].Pen, pArray);
                    }
                    checkFirstDraw = true;
                }
                if (a[tmp].isResize)
                {   
                    if(a[tmp].index == 3 || a[tmp].index == 4)
                        return;
                    
                    if (a[tmp].index == 2)
                        g.DrawEllipse(a[tmp].Pen, a[tmp].khung);
                    else if (a[tmp].index == 7)
                        g.DrawRectangle(a[tmp].Pen, a[tmp].khung);
                    else if (a[tmp].index == 5)
                        g.DrawLine(a[tmp].Pen, a[tmp].khung.Left, a[tmp].khung.Top, a[tmp].khung.Right, a[tmp].khung.Bottom);
                    else if (a[tmp].index == 8)
                    {
                        // tam giac can
                        Point dinhA = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height);
                        Point dinhB = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height);
                        Point dinhC = new Point((a[tmp].khung.X + a[tmp].khung.Width + a[tmp].khung.X) / 2, a[tmp].khung.Y);
                        Point[] dinhArray = { dinhC, dinhA, dinhB };
                        g.DrawPolygon(a[tmp].Pen, dinhArray);
                    }
                    else if (a[tmp].index == 9)
                    {
                        Point dinhA = new Point(a[tmp].khung.X, a[tmp].khung.Y);
                        Point dinhB = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height);
                        Point dinhC = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height);
                        Point[] dinhArray = { dinhC, dinhA, dinhB };
                        g.DrawPolygon(a[tmp].Pen, dinhArray);
                    }
                    else if (a[tmp].index == 10)
                    {
                        int x = a[tmp].khung.X;
                        int y = a[tmp].khung.Y;
                        int lX = a[tmp].khung.X + a[tmp].khung.Width;
                        int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                        Point p1 = new Point(x + (a[tmp].khung.Width) / 4, y);
                        Point p2 = new Point(lX - (a[tmp].khung.Width) / 4, y);
                        Point p3 = new Point(lX, y + (a[tmp].khung.Height) / 2);
                        Point p4 = new Point(lX - (a[tmp].khung.Width) / 4, lY);
                        Point p5 = new Point(x + (a[tmp].khung.Width) / 4, lY);
                        Point p6 = new Point(x, y + (a[tmp].khung.Height) / 2);
                        Point[] pArray = { p1, p2, p3, p4, p5, p6 };

                        g.DrawPolygon(a[tmp].Pen, pArray);
                    }
                    else if (a[tmp].index == 11)
                    {    // mui ten phai
                        int x = a[tmp].khung.X;
                        int y = a[tmp].khung.Y;
                        int lX = a[tmp].khung.X + a[tmp].khung.Width;
                        int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                        Point p1 = new Point(lX, y + (a[tmp].khung.Height / 2));
                        Point p2 = new Point(lX - (a[tmp].khung.Width / 3), y);
                        Point p3 = new Point(lX - (a[tmp].khung.Width / 3), y + (a[tmp].khung.Height / 3));
                        Point p4 = new Point(x, y + (a[tmp].khung.Height / 3));
                        Point p5 = new Point(x, lY - (a[tmp].khung.Height / 3));
                        Point p6 = new Point(lX - (a[tmp].khung.Width / 3), lY - (a[tmp].khung.Height / 3));
                        Point p7 = new Point(lX - (a[tmp].khung.Width / 3), lY);
                        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

                        g.DrawPolygon(a[tmp].Pen, pArray);
                    }
                    else if (a[tmp].index == 12)
                    {
                        // Ngoi sao
                        int x = a[tmp].khung.X;
                        int y = a[tmp].khung.Y;
                        int lX = a[tmp].khung.X + a[tmp].khung.Width;
                        int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                        Point p1 = new Point(x + (a[tmp].khung.Width / 2), y);
                        Point p2 = new Point(lX - (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                        Point p3 = new Point(lX, y + (3 * (a[tmp].khung.Height) / 8));
                        Point p4 = new Point(lX - (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                        Point p5 = new Point(lX - (3 * a[tmp].khung.Width / 14), lY);
                        Point p6 = new Point(x + a[tmp].khung.Width / 2, lY - (3 * a[tmp].khung.Height / 14));
                        Point p7 = new Point(x + (3 * a[tmp].khung.Width / 14), lY);
                        Point p8 = new Point(x + (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                        Point p9 = new Point(x, y + (3 * (a[tmp].khung.Height) / 8));
                        Point p10 = new Point(x + (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

                        g.DrawPolygon(a[tmp].Pen, pArray);
                    }

                    if (a[tmp].index != 5)
                        g.DrawRectangle(resizePen, a[tmp].khung);
                    
                    if(a[tmp].index == 16)
                    {
                        a[tmp].text.Size = new Size(a[tmp].khung.Width - 12, a[tmp].khung.Height - 12);
                        a[tmp].text.Location = new Point(a[tmp].khung.X + 6, a[tmp].khung.Y + 6);
                    }
                    if (a[tmp].index == 5)
                    {
                        g.FillRectangle(Brushes.DarkRed, GetHandleRect(0));
                        g.FillRectangle(Brushes.DarkRed, GetHandleRect(4));
                    }
                    else if (a[tmp].index !=0)
                        for (int i = 0; i < 8; i++)
                            g.FillRectangle(Brushes.DarkRed, GetHandleRect(i));
                    //a[tmp].listBitmap[a[tmp].listBitmap.Count - 1] = new Bitmap(a[tmp].pictureBox.Image);
                }

            }

        }
        private void handleMouseUp(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;

            if (tmp < a.Count)
            {
                if (a[tmp].Paint && checkFirstDraw)
                {
                    a[tmp].listBitmap.Add(new Bitmap(a[tmp].pictureBox.Image));
                    a[tmp].iBitmap++;
                    checkFirstDraw = false;
                }
                if (a[tmp].Paint && a[tmp].index!=1 && a[tmp].index!=15)
                {
                    a[tmp].Paint = false;
                    a[tmp].resizeIndex = a[tmp].index;
                    a[tmp].isResize = true;
                }
                if (a[tmp].index == 3 && a[tmp].isResize)
                {
                    a[tmp].Paint = false;
                    a[tmp].isResize = true;
                    a[tmp].resizeIndex = a[tmp].index;
                    Bitmap croppedBitmap = a[tmp].bm.Clone(a[tmp].khung, a[tmp].bm.PixelFormat);
                    Clipboard.SetImage(croppedBitmap);
                }
                if (a[tmp].index == 4 && a[tmp].isResize)
                {
                    a[tmp].Paint = false;
                    a[tmp].isResize = true;
                    a[tmp].resizeIndex = a[tmp].index;
                    Image clipboardImage = Clipboard.GetImage();
                    if (clipboardImage != null)
                    {
                        a[tmp].G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        a[tmp].G.DrawImage(clipboardImage, a[tmp].khung);
                    }
                }
                a[tmp].pictureBox.Refresh();
            }
        }
        private void handleMouseMove(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (e.Button==MouseButtons.Left)
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
                            Rectangle rtg = new Rectangle();
                            rtg = new Rectangle(a[tmp].khungCu.Left - diffX, a[tmp].khungCu.Top - diffY,a[tmp].khungCu.Width + diffX, a[tmp].khungCu.Height + diffY);
                            if (a[tmp].resizeIndex == 5)
                                a[tmp].khung = rtg;
                            else
                                a[tmp].khung=updateKhung(rtg, a[tmp].khung);
                        }
                        else if (a[tmp].dragHandle == 1)
                        {
                            int diff = a[tmp].dragPoint.Y - e.Location.Y;
                            Rectangle rtg = new Rectangle();
                            rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top - diff, a[tmp].khungCu.Width, a[tmp].khungCu.Height + diff);
                            if (a[tmp].resizeIndex == 5)
                                a[tmp].khung = rtg;
                            else
                                a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                        }
                        else if (a[tmp].dragHandle == 2)
                        {
                            int diffY = a[tmp].dragPoint.Y - e.Location.Y;
                            int diffX = a[tmp].dragPoint.X - e.Location.X;
                            Rectangle rtg = new Rectangle();
                            rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top - diffY, a[tmp].khungCu.Width - diffX, a[tmp].khungCu.Height + diffY);
                            if (a[tmp].resizeIndex == 5)
                                a[tmp].khung = rtg;
                            else
                                a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                        }
                        else if (a[tmp].dragHandle == 3)
                        {
                            int diff = a[tmp].dragPoint.X - e.Location.X;
                            Rectangle rtg = new Rectangle();
                            rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top, a[tmp].khungCu.Width - diff, a[tmp].khungCu.Height);
                            if (a[tmp].resizeIndex == 5)
                                a[tmp].khung = rtg;
                            else
                                a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                        }
                        else if (a[tmp].dragHandle == 4)
                        {
                            int diffY = a[tmp].dragPoint.Y - e.Location.Y;
                            int diffX = a[tmp].dragPoint.X - e.Location.X;
                            Rectangle rtg = new Rectangle();
                            rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top, a[tmp].khungCu.Width - diffX,a[tmp].khungCu.Height - diffY);
                            if (a[tmp].resizeIndex == 5)
                                a[tmp].khung = rtg;
                            else
                                a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                        }
                        else if (a[tmp].dragHandle == 5)
                        {
                            int diff = a[tmp].dragPoint.Y - e.Location.Y;
                            Rectangle rtg = new Rectangle();
                            rtg = new Rectangle(a[tmp].khungCu.Left, a[tmp].khungCu.Top, a[tmp].khungCu.Width, a[tmp].khungCu.Height - diff);
                            if (a[tmp].resizeIndex == 5)
                                a[tmp].khung = rtg;
                            else
                                a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                        }
                        else if (a[tmp].dragHandle == 6)
                        {
                            int diffY = a[tmp].dragPoint.Y - e.Location.Y;
                            int diffX = a[tmp].dragPoint.X - e.Location.X;
                            Rectangle rtg = new Rectangle();
                            rtg = new Rectangle(a[tmp].khungCu.Left - diffX, a[tmp].khungCu.Top, a[tmp].khungCu.Width + diffX, a[tmp].khungCu.Height - diffY);
                            if (a[tmp].resizeIndex == 5)
                                a[tmp].khung = rtg;
                            else
                                a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                        }
                        else if (a[tmp].dragHandle == 7)
                        {
                            int diff = a[tmp].dragPoint.X - e.Location.X;
                            Rectangle rtg = new Rectangle();
                            rtg = new Rectangle(a[tmp].khungCu.Left - diff, a[tmp].khungCu.Top, a[tmp].khungCu.Width + diff, a[tmp].khungCu.Height);
                            if (a[tmp].resizeIndex == 5)
                                a[tmp].khung = rtg;
                            else
                                a[tmp].khung = updateKhung(rtg, a[tmp].khung);
                        }
                        if (a[tmp].dragHandle > -1)
                            a[tmp].pictureBox.Invalidate();
                        else
                        {
                            //handle move
                            
                            int newX = a[tmp].khung.Left + e.X - a[tmp].cX;
                            int newY = a[tmp].khung.Top + e.Y - a[tmp].cY;
                            a[tmp].khung = new Rectangle(newX, newY, a[tmp].khung.Width, a[tmp].khung.Height);

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
                if (a[tmp].resizeIndex == 3 || a[tmp].resizeIndex == 4)
                {
                    a[tmp].isResize = false;
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                }
                if(a[tmp].index != 6)
                {
                    a[tmp].Fill = false;
                }
                int checkODK = 0;
                for (int i = 0; i < 8; i++)
                    if (GetHandleRect(i).Contains(e.Location))
                        checkODK = 1;
                if (checkODK == 0 && !a[tmp].khung.IsEmpty  && !a[tmp].khung.Contains(e.Location))
                {
                    // ve chinh thuc
                    VeChinhThuc();
                    a[tmp].isText = !a[tmp].isText;
                    
                    a[tmp].isClear = false;
                    a[tmp].listBitmap[a[tmp].listBitmap.Count - 1] = new Bitmap(a[tmp].pictureBox.Image);
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
                    }

                }
                else if (a[tmp].index!=0)
                {
                    if(a[tmp].index == 16 && a[tmp].isText)
                    {
                        // tạo khung cho text
                        a[tmp].khung = new Rectangle(e.X, e.Y, 160, 47);
                        a[tmp].text.Show();
                    }
                    a[tmp].Paint = true;
                    a[tmp].py = e.Location;
                    a[tmp].cX = e.X;
                    a[tmp].cY = e.Y;
                    if(a[tmp].listBitmap.Count > 0)
                    {
                        XoaRedo();
                        a[tmp].listBitmap[a[tmp].listBitmap.Count - 1] = new Bitmap(a[tmp].pictureBox.Image);
                    }
                }
            }
        }
        private Rectangle updateKhung(Rectangle rtg,   Rectangle khung)
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

        private Rectangle GetHandleRect(int stt)
        {
            // trả về diện tích điểm điều khiển theo stt
            Point p = GetHandlePoint(stt);
            p.Offset(-2, -2);
            return new Rectangle(p, new Size(5, 5));
        }
        
        private void VeChinhThuc()
        {
            int tmp = tcMain.SelectedIndex;
            if (tmp < a.Count)
            {
                if (a[tmp].index==6)
                    a[tmp].isResize = false;
                if (a[tmp].resizeIndex == 7)
                {

                    a[tmp].isResize = false;
                    a[tmp].G.DrawRectangle(a[tmp].Pen, a[tmp].khung);
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);

                }
                else if (a[tmp].resizeIndex == 2)
                {
                    a[tmp].isResize = false;

                    a[tmp].G.DrawEllipse(a[tmp].Pen, a[tmp].khung);
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                }
                else if (a[tmp].resizeIndex == 5)
                {
                    a[tmp].isResize = false;

                    a[tmp].G.DrawLine(a[tmp].Pen, a[tmp].khung.Left, a[tmp].khung.Top, a[tmp].khung.Right, a[tmp].khung.Bottom); ;
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                }
                else if (a[tmp].resizeIndex == 8)
                {
                    a[tmp].isResize = false;
                    Point dinhA = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height);
                    Point dinhB = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height);
                    Point dinhC = new Point((a[tmp].khung.X + a[tmp].khung.Width + a[tmp].khung.X) / 2, a[tmp].khung.Y);
                    Point[] dinhArray = { dinhC, dinhA, dinhB };
                    a[tmp].G.DrawPolygon(a[tmp].Pen, dinhArray);
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                }
                else if (a[tmp].resizeIndex == 9)
                {
                    a[tmp].isResize = false;
                    Point dinhA = new Point(a[tmp].khung.X, a[tmp].khung.Y);
                    Point dinhB = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height);
                    Point dinhC = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height);
                    Point[] dinhArray = { dinhC, dinhA, dinhB };
                    a[tmp].G.DrawPolygon(a[tmp].Pen, dinhArray);
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                }
                else if (a[tmp].resizeIndex == 10)
                {
                    a[tmp].isResize = false;

                    int x = a[tmp].khung.X;
                    int y = a[tmp].khung.Y;
                    int lX = a[tmp].khung.X + a[tmp].khung.Width;
                    int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                    Point p1 = new Point(x + (a[tmp].khung.Width) / 4, y);
                    Point p2 = new Point(lX - (a[tmp].khung.Width) / 4, y);
                    Point p3 = new Point(lX, y + (a[tmp].khung.Height) / 2);
                    Point p4 = new Point(lX - (a[tmp].khung.Width) / 4, lY);
                    Point p5 = new Point(x + (a[tmp].khung.Width) / 4, lY);
                    Point p6 = new Point(x, y + (a[tmp].khung.Height) / 2);
                    Point[] pArray = { p1, p2, p3, p4, p5, p6 };
                    a[tmp].G.DrawPolygon(a[tmp].Pen, pArray);
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                }
                else if (a[tmp].resizeIndex == 11)
                {
                    a[tmp].isResize = false;
                    int x = a[tmp].khung.X;
                    int y = a[tmp].khung.Y;
                    int lX = a[tmp].khung.X + a[tmp].khung.Width;
                    int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                    Point p1 = new Point(lX, y + (a[tmp].khung.Height / 2));
                    Point p2 = new Point(lX - (a[tmp].khung.Width / 3), y);
                    Point p3 = new Point(lX - (a[tmp].khung.Width / 3), y + (a[tmp].khung.Height / 3));
                    Point p4 = new Point(x, y + (a[tmp].khung.Height / 3));
                    Point p5 = new Point(x, lY - (a[tmp].khung.Height / 3));
                    Point p6 = new Point(lX - (a[tmp].khung.Width / 3), lY - (a[tmp].khung.Height / 3));
                    Point p7 = new Point(lX - (a[tmp].khung.Width / 3), lY);
                    Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

                    a[tmp].G.DrawPolygon(a[tmp].Pen, pArray);
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                }
                else if (a[tmp].resizeIndex == 12)
                {
                    a[tmp].isResize = false;
                    int x = a[tmp].khung.X;
                    int y = a[tmp].khung.Y;
                    int lX = a[tmp].khung.X + a[tmp].khung.Width;
                    int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                    Point p1 = new Point(x + (a[tmp].khung.Width / 2), y);
                    Point p2 = new Point(lX - (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                    Point p3 = new Point(lX, y + (3 * (a[tmp].khung.Height) / 8));
                    Point p4 = new Point(lX - (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                    Point p5 = new Point(lX - (3 * a[tmp].khung.Width / 14), lY);
                    Point p6 = new Point(x + a[tmp].khung.Width / 2, lY - (3 * a[tmp].khung.Height / 14));
                    Point p7 = new Point(x + (3 * a[tmp].khung.Width / 14), lY);
                    Point p8 = new Point(x + (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                    Point p9 = new Point(x, y + (3 * (a[tmp].khung.Height) / 8));
                    Point p10 = new Point(x + (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                    Point[] pArray = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

                    a[tmp].G.DrawPolygon(a[tmp].Pen, pArray);
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                }
                else if (a[tmp].resizeIndex == 16)
                {
                    int maxWidth = a[tmp].text.Width - 5;
                    string text = a[tmp].text.Text;
                    Font font = a[tmp].text.Font;

                    List<string> linesToDraw = new List<string>();
                    string currentLine = "";

                    foreach (char character in text)
                    {
                        string testLine = currentLine + character;
                        SizeF size = a[tmp].G.MeasureString(testLine, font);

                        if (size.Width <= maxWidth || char.IsWhiteSpace(character))
                        {
                            currentLine += character;
                        }
                        else
                        {
                            linesToDraw.Add(currentLine);
                            currentLine = character.ToString();
                        }
                    }
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        linesToDraw.Add(currentLine);
                    }

                    int y = a[tmp].khung.Y + 8;

                    foreach (string line in linesToDraw)
                    {
                        a[tmp].G.DrawString(line, font, a[tmp].brush, new PointF(a[tmp].khung.X + 8, y)); 
                        y += (int)font.GetHeight() + 2; 
                    }

                   
                    a[tmp].isResize = false;
                    a[tmp].pictureBox.Refresh();
                    a[tmp].dragHandle = -1;
                    a[tmp].khung = new Rectangle(Top, 0, 0, 0);
                    a[tmp].text.Hide();
                    a[tmp].text.Text = "";
                }
            }
        }
        private void XoaRedo()
        {
            int tmp = tcMain.SelectedIndex;
            if (tmp >= 0 && tmp < a.Count && a[tmp].iBitmap >= 0 && a[tmp].iBitmap < a[tmp].listBitmap.Count)
            {
                int n = a[tmp].listBitmap.Count - a[tmp].iBitmap - 1;
                a[tmp].listBitmap.RemoveRange(a[tmp].iBitmap + 1, n);
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
        public void Fill( int x, int y, Color new_clr)
        {
            int tmp = tcMain.SelectedIndex;
            Color old_Color = a[tmp].bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            a[tmp].bm.SetPixel(x, y, new_clr);
            if (old_Color == new_clr) return;
            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < a[tmp].bm.Width - 1 && pt.Y < a[tmp].bm.Height - 1)
                {
                    validate(pixel, pt.X - 1, pt.Y, old_Color, new_clr);
                    validate(pixel, pt.X, pt.Y - 1, old_Color, new_clr);
                    validate(pixel, pt.X + 1, pt.Y, old_Color, new_clr);
                    validate(pixel, pt.X, pt.Y + 1, old_Color, new_clr);
                }
                
            }
        }
        private void validate( Stack<Point> sp, int x, int y, Color old_Color, Color new_Color)
        {
            int tmp = tcMain.SelectedIndex;
            Color cx = a[tmp].bm.GetPixel(x, y);
            if (cx == old_Color)
            {
                sp.Push(new Point(x, y));
                a[tmp].bm.SetPixel(x, y, new_Color);
            }
        }
        private void handleClickTextButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                a[tmp].index = 16;
                a[tmp].isText = true;
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

     
        private void handleClickLineButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 5;
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


        // Size Button
        private void handleClickSizeButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                ContextMenuStrip sizeMenu = new ContextMenuStrip();
                

                // Create ToolStripMenuItems for different sizes
                ToolStripMenuItem smallSizeItem = new ToolStripMenuItem();
                smallSizeItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
                smallSizeItem.Text = "3px";
                ToolStripMenuItem mediumSizeItem = new ToolStripMenuItem();
                mediumSizeItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
                mediumSizeItem.Text = "5px";
                ToolStripMenuItem largeSizeItem = new ToolStripMenuItem();
                largeSizeItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
                largeSizeItem.Text = "8px";


                // Add event handlers for menu item clicks
                smallSizeItem.Click += SizeMenuItem_Click;
                mediumSizeItem.Click += SizeMenuItem_Click;
                largeSizeItem.Click += SizeMenuItem_Click;

                // Add the ToolStripMenuItems to the dropdown menu
                sizeMenu.Items.Add(smallSizeItem);
                sizeMenu.Items.Add(mediumSizeItem);
                sizeMenu.Items.Add(largeSizeItem);

                // Show the context menu at the button's location
                sizeMenu.Show(clickedButton, new Point(-15, clickedButton.Height));
                
            }
        }
        private void SizeMenuItem_Click(object sender, EventArgs e)
        {
            // Handle size selection here
            int tmp = tcMain.SelectedIndex;
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            if (clickedItem.Text == "3px")
                a[tmp].Pen = new Pen(a[tmp].Pen.Color, 3f);
            if (clickedItem.Text == "5px")
                a[tmp].Pen = new Pen(a[tmp].Pen.Color, 5f);
            if (clickedItem.Text == "8px")
                a[tmp].Pen = new Pen(a[tmp].Pen.Color, 8f);
        }
        private void handleClickBrushButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                ContextMenuStrip brushMenu = new ContextMenuStrip();

                // Create ToolStripMenuItems for different sizes
                ToolStripMenuItem brush1Item = new ToolStripMenuItem(Properties.Resources.icons8_brush_48_blue);
                ToolStripMenuItem brush2Item = new ToolStripMenuItem(Properties.Resources.icons8_calligraphy_brush_64_blue);
                ToolStripMenuItem brush3Item = new ToolStripMenuItem(Properties.Resources.icons8_marker_pen_50_blue);
                // Set DisplayStyle to show only the image
                brush1Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                brush1Item.Text = "Brush";
                brush2Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                brush2Item.Text = "Brush";
                brush3Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                brush3Item.Text = "Brush";



                // Add event handlers for menu item clicks
                brush1Item.Click += BrushMenuItem_Click;
                brush2Item.Click += BrushMenuItem_Click;
                brush3Item.Click += BrushMenuItem_Click;

                // Add the ToolStripMenuItems to the dropdown menu
                brushMenu.Items.Add(brush1Item);
                brushMenu.Items.Add(brush2Item);
                brushMenu.Items.Add(brush3Item);
                
                // Show the context menu at the button's location
                brushMenu.Show(clickedButton, new Point(-15, clickedButton.Height));
            }
        }
        private void BrushMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void handleClickZoomIn(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            int w = (int)(1.2 * a[tmp].pictureBox.Width);
            int h = (int)(1.2 * a[tmp].pictureBox.Height);
            a[tmp].pictureBox.Size = new Size(w,h);
            Image originalImage = a[tmp].pictureBox.Image;

            Bitmap newBitmap = new Bitmap(w,h);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0,w,h);
            }
            a[tmp].bm = newBitmap;
            a[tmp].pictureBox.Image = a[tmp].bm;
            a[tmp].G = Graphics.FromImage(a[tmp].bm);
            a[tmp].pictureBox.Refresh();
        }
        private void handleClickZoomOut(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            int w = (int)(0.8 * a[tmp].pictureBox.Width);
            int h = (int)(0.8 * a[tmp].pictureBox.Height);
            a[tmp].pictureBox.Size = new Size(w, h);
            Image originalImage = a[tmp].pictureBox.Image;

            Bitmap newBitmap = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, w, h);
            }
            a[tmp].bm = newBitmap;
            a[tmp].pictureBox.Image = a[tmp].bm;
            a[tmp].G = Graphics.FromImage(a[tmp].bm);
            a[tmp].pictureBox.Refresh();
        }
        private void handleResetZoom(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            int w = a[tmp].sizeBitmap.Width;
            int h = a[tmp].sizeBitmap.Height;
            a[tmp].pictureBox.Size = new Size(w, h);
            Image originalImage = a[tmp].pictureBox.Image;

            Bitmap newBitmap = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, w, h);
            }
            a[tmp].bm = newBitmap;
            a[tmp].pictureBox.Image = a[tmp].bm;
            a[tmp].G = Graphics.FromImage(a[tmp].bm);
            a[tmp].pictureBox.Refresh();
        }
    }
}

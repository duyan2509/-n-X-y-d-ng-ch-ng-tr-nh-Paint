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
        private bool checkFirstDraw = false;
        private void handlePaint(object sender, PaintEventArgs e)
        {
            
            int tmp = tcMain.SelectedIndex;
            
            if (tmp < a.Count)
            {
                Graphics g = e.Graphics;
                if (a[tmp].index != 1 && a[tmp].index != 15)
                {
                    if (a[tmp].Paint)
                    {
                        a[tmp].currShape.Paint_Paint(ref g, a[tmp]);
                        checkFirstDraw = true;
                    }
                    if (a[tmp].isResize)
                        a[tmp].currShape.Paint_Resize(ref g, a[tmp]);
                }
                else
                    checkFirstDraw = true;
<<<<<<< HEAD

                // ve khung 
=======
               
                //Ve hinh khi dang nhan chuot
                //if (a[tmp].Paint)
                //{
                //    if (a[tmp].index == 2)
                //    {

                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        //draw elip
                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                //        g.DrawEllipse(a[tmp].Pen, a[tmp].khung);
                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                //    }
                //    if (a[tmp].index == 5)
                //    {
                //        //Ve line
                //        a[tmp].khung = new Rectangle(a[tmp].cX, a[tmp].cY, a[tmp].sX, a[tmp].sY);

                //        g.DrawLine(a[tmp].Pen, a[tmp].cX, a[tmp].cY, a[tmp].x, a[tmp].y);
                //    }
                //    if (a[tmp].index == 3)
                //    {
                //        //copy
                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                //        // ve khung
                //        g.DrawRectangle(resizePen, a[tmp].khung);
                //    }
                //    if (a[tmp].index == 17)
                //    {
                //        //select
                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                //        this.Cursor = Cursors.Cross;
                //        // ve khung
                //        g.DrawRectangle(resizePen, a[tmp].khung);
                //    }
                //    if (a[tmp].index == 4)
                //    {
                //        //paste
                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        Image clipboardImage = Clipboard.GetImage();
                //        if (clipboardImage != null)
                //        {
                //            a[tmp].khung = new Rectangle(0, 0, clipboardImage.Width, clipboardImage.Height);
                //            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //            g.DrawImage(clipboardImage, a[tmp].khung);
                //        }
                //        // ve khung
                //        g.DrawRectangle(resizePen, a[tmp].khung);
                //    }


                //    if (a[tmp].index == 7)
                //    {
                //        //Ve Hinh Chu Nhat
                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                //        g.DrawRectangle(a[tmp].Pen, a[tmp].khung);
                //    }
                //    if (a[tmp].index == 8)
                //    {
                //        //Ve Tam Giac Can
                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                //        int lY = Math.Max(a[tmp].cY, a[tmp].y);

                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));


                //        Point dinhA = new Point(lX, lY);
                //        Point dinhB = new Point(x, lY);
                //        Point dinhC = new Point((lX + x) / 2, y);
                //        Point[] dinhArray = { dinhC, dinhA, dinhB };
                //        g.DrawPolygon(a[tmp].Pen, dinhArray);

                //    }
                //    if (a[tmp].index == 9)
                //    {
                //        // Ve Tam Giac Vuong
                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                //        int lY = Math.Max(a[tmp].cY, a[tmp].y);
                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                //        Point dinhA = new Point(x, y);
                //        Point dinhB = new Point(x, lY);
                //        Point dinhC = new Point(lX, lY);

                //        Point[] dinhArray = { dinhA, dinhB, dinhC };

                //        g.DrawPolygon(a[tmp].Pen, dinhArray);
                //    }
                //    if (a[tmp].index == 10)
                //    {
                //        // Ve Hinh Luc Giac
                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                //        int lY = Math.Max(a[tmp].cY, a[tmp].y);
                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                //        // Calculate the points for the hexagon
                //        Point p1 = new Point(x + (a[tmp].khung.Width) / 4, y); // Top vertex
                //        Point p2 = new Point(lX - (a[tmp].khung.Width) / 4, y); // Top-right vertex
                //        Point p3 = new Point(lX, y + (a[tmp].khung.Height) / 2); // Right vertex
                //        Point p4 = new Point(lX - (a[tmp].khung.Width) / 4, lY); // Bottom-right vertex
                //        Point p5 = new Point(x + (a[tmp].khung.Width) / 4, lY); // Bottom-left vertex
                //        Point p6 = new Point(x, y + (a[tmp].khung.Height) / 2);  // Bottom-left vertex
                //        Point[] pArray = { p1, p2, p3, p4, p5, p6 };

                //        g.DrawPolygon(a[tmp].Pen, pArray);
                //    }
                //    if (a[tmp].index == 11)
                //    {
                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                //        int lY = Math.Max(a[tmp].cY, a[tmp].y);
                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));
                //        // Ve Mui Ten
                //        Point p1 = new Point(lX, y + (a[tmp].khung.Height / 2));
                //        Point p2 = new Point(lX - (a[tmp].khung.Width / 3), y);
                //        Point p3 = new Point(lX - (a[tmp].khung.Width / 3), y + (a[tmp].khung.Height / 3));
                //        Point p4 = new Point(x, y + (a[tmp].khung.Height / 3));
                //        Point p5 = new Point(x, lY - (a[tmp].khung.Height / 3));
                //        Point p6 = new Point(lX - (a[tmp].khung.Width / 3), lY - (a[tmp].khung.Height / 3));
                //        Point p7 = new Point(lX - (a[tmp].khung.Width / 3), lY);
                //        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

                //        g.DrawPolygon(a[tmp].Pen, pArray);
                //    }
                //    if (a[tmp].index == 12)
                //    {
                //        // Ve ngoi sao
                //        int x = Math.Min(a[tmp].cX, a[tmp].x);
                //        int y = Math.Min(a[tmp].cY, a[tmp].y);
                //        int lX = Math.Max(a[tmp].cX, a[tmp].x);
                //        int lY = Math.Max(a[tmp].cY, a[tmp].y);
                //        a[tmp].khung = new Rectangle(x, y, Math.Abs(a[tmp].sX), Math.Abs(a[tmp].sY));

                //        Point p1 = new Point(x + (a[tmp].khung.Width / 2), y);
                //        Point p2 = new Point(lX - (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                //        Point p3 = new Point(lX, y + (3 * (a[tmp].khung.Height) / 8));
                //        Point p4 = new Point(lX - (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                //        Point p5 = new Point(lX - (3 * a[tmp].khung.Width / 14), lY);
                //        Point p6 = new Point(x + a[tmp].khung.Width / 2, lY - (3 * a[tmp].khung.Height / 14));
                //        Point p7 = new Point(x + (3 * a[tmp].khung.Width / 14), lY);
                //        Point p8 = new Point(x + (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                //        Point p9 = new Point(x, y + (3 * (a[tmp].khung.Height) / 8));
                //        Point p10 = new Point(x + (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                //        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

                //        g.DrawPolygon(a[tmp].Pen, pArray);
                //    }
                //    checkFirstDraw = true;
                //}
                //if (a[tmp].isResize)
                //{
                //    if (a[tmp].index == 17)
                //    {
                //        Image clipboardImage = Clipboard.GetImage();
                //        if (clipboardImage != null)
                //            g.DrawImage(clipboardImage, a[tmp].khung);
                //    }
                //    else if (a[tmp].index == 4)
                //    {
                //        Image clipboardImage = Clipboard.GetImage();
                //        if (clipboardImage != null)
                //            g.DrawImage(clipboardImage, a[tmp].khung);
                //    }
                //    else if (a[tmp].index == 2)
                //        g.DrawEllipse(a[tmp].Pen, a[tmp].khung);
                //    else if (a[tmp].index == 7)
                //        g.DrawRectangle(a[tmp].Pen, a[tmp].khung);
                //    else if (a[tmp].index == 5)
                //        g.DrawLine(a[tmp].Pen, a[tmp].khung.Left, a[tmp].khung.Top, a[tmp].khung.Right, a[tmp].khung.Bottom);
                //    else if (a[tmp].index == 8)
                //    {
                //        // tam giac can
                //        Point dinhA = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height);
                //        Point dinhB = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height);
                //        Point dinhC = new Point((a[tmp].khung.X + a[tmp].khung.Width + a[tmp].khung.X) / 2, a[tmp].khung.Y);
                //        Point[] dinhArray = { dinhC, dinhA, dinhB };
                //        g.DrawPolygon(a[tmp].Pen, dinhArray);
                //    }
                //    else if (a[tmp].index == 9)
                //    {
                //        Point dinhA = new Point(a[tmp].khung.X, a[tmp].khung.Y);
                //        Point dinhB = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height);
                //        Point dinhC = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height);
                //        Point[] dinhArray = { dinhC, dinhA, dinhB };
                //        g.DrawPolygon(a[tmp].Pen, dinhArray);
                //    }
                //    else if (a[tmp].index == 10)
                //    {
                //        int x = a[tmp].khung.X;
                //        int y = a[tmp].khung.Y;
                //        int lX = a[tmp].khung.X + a[tmp].khung.Width;
                //        int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                //        Point p1 = new Point(x + (a[tmp].khung.Width) / 4, y);
                //        Point p2 = new Point(lX - (a[tmp].khung.Width) / 4, y);
                //        Point p3 = new Point(lX, y + (a[tmp].khung.Height) / 2);
                //        Point p4 = new Point(lX - (a[tmp].khung.Width) / 4, lY);
                //        Point p5 = new Point(x + (a[tmp].khung.Width) / 4, lY);
                //        Point p6 = new Point(x, y + (a[tmp].khung.Height) / 2);
                //        Point[] pArray = { p1, p2, p3, p4, p5, p6 };

                //        g.DrawPolygon(a[tmp].Pen, pArray);
                //    }
                //    else if (a[tmp].index == 11)
                //    {    // mui ten phai
                //        int x = a[tmp].khung.X;
                //        int y = a[tmp].khung.Y;
                //        int lX = a[tmp].khung.X + a[tmp].khung.Width;
                //        int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                //        Point p1 = new Point(lX, y + (a[tmp].khung.Height / 2));
                //        Point p2 = new Point(lX - (a[tmp].khung.Width / 3), y);
                //        Point p3 = new Point(lX - (a[tmp].khung.Width / 3), y + (a[tmp].khung.Height / 3));
                //        Point p4 = new Point(x, y + (a[tmp].khung.Height / 3));
                //        Point p5 = new Point(x, lY - (a[tmp].khung.Height / 3));
                //        Point p6 = new Point(lX - (a[tmp].khung.Width / 3), lY - (a[tmp].khung.Height / 3));
                //        Point p7 = new Point(lX - (a[tmp].khung.Width / 3), lY);
                //        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

                //        g.DrawPolygon(a[tmp].Pen, pArray);
                //    }
                //    else if (a[tmp].index == 12)
                //    {
                //        // Ngoi sao
                //        int x = a[tmp].khung.X;
                //        int y = a[tmp].khung.Y;
                //        int lX = a[tmp].khung.X + a[tmp].khung.Width;
                //        int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                //        Point p1 = new Point(x + (a[tmp].khung.Width / 2), y);
                //        Point p2 = new Point(lX - (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                //        Point p3 = new Point(lX, y + (3 * (a[tmp].khung.Height) / 8));
                //        Point p4 = new Point(lX - (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                //        Point p5 = new Point(lX - (3 * a[tmp].khung.Width / 14), lY);
                //        Point p6 = new Point(x + a[tmp].khung.Width / 2, lY - (3 * a[tmp].khung.Height / 14));
                //        Point p7 = new Point(x + (3 * a[tmp].khung.Width / 14), lY);
                //        Point p8 = new Point(x + (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                //        Point p9 = new Point(x, y + (3 * (a[tmp].khung.Height) / 8));
                //        Point p10 = new Point(x + (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                //        Point[] pArray = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

                //        g.DrawPolygon(a[tmp].Pen, pArray);
                //    }




>>>>>>> 27fec9669114948a82b644592b2aed784d51eaad
                if (a[tmp].index != 5 && a[tmp].index != 18)
                    g.DrawRectangle(resizePen, a[tmp].khung);

                // ve diem dieu khien
                if (a[tmp].index == 5)
                {
                    g.FillRectangle(Brushes.BlueViolet, GetHandleRect(0));
                    g.FillRectangle(Brushes.BlueViolet, GetHandleRect(4));
                }
                else if (a[tmp].index != 0 && a[tmp].index != 18)
                    for (int i = 0; i < 8; i++)
                        g.FillRectangle(Brushes.BlueViolet, GetHandleRect(i));
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
                if (a[tmp].Paint && a[tmp].index != 1 && a[tmp].index != 15 && a[tmp].index != 17)
                {
                    //index: 1 - Pen, 15 - Erase, 17 - Select
                    //doi mode Paint va Resize
                    a[tmp].Paint = false;
                    a[tmp].resizeIndex = a[tmp].index;
                    a[tmp].currResize = a[tmp].currShape;
                    a[tmp].isResize = true;
                }
                if (a[tmp].index == 17 && a[tmp].Paint)
                {
                    //doi mode Paint va Resize cho Select
                    a[tmp].Paint = false;
                    a[tmp].resizeIndex = a[tmp].index;
                    a[tmp].currResize = a[tmp].currShape;
                    a[tmp].isResize = true;
                    //Luu anh duoc crop vao Clipboard
                    Bitmap croppedBitmap;
                    if (a[tmp].khung.Width != 0 && a[tmp].khung.Height != 0)
                    {
                        croppedBitmap = a[tmp].bm.Clone(a[tmp].khung, a[tmp].bm.PixelFormat);
                        Clipboard.SetImage(croppedBitmap);
                        a[tmp].G.FillRectangle(Brushes.White, a[tmp].khung);
                    }
                }
                a[tmp].pictureBox.Refresh();
            }
        }
        private void handleMouseMove(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;

            if (e.Button == MouseButtons.Left)
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
                            a[tmp].isClear = false;
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
                        //Cap nhat khung khi an vao diem dieu khien de resize
                        updateFrameBaseOnHandlesPoint(e.Location);

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
                            a[tmp].pictureBox.Cursor = Cursors.SizeAll;
                        }
                    }

                    a[tmp].x = e.X;
                    a[tmp].y = e.Y;
                    a[tmp].sX = a[tmp].x - a[tmp].cX;
                    a[tmp].sY = a[tmp].y - a[tmp].cY;
                }


            }
            //Hover len cac diem dieu khien
            int handleIndex = GetHandleIndexUnderMouse(e.Location);



          
       
            if (a[tmp].isSelect)
            {
                
                if (handleIndex == 0)
                {
                    a[tmp].pictureBox.Cursor = Cursors.SizeNWSE;
                }
                else if (handleIndex == 1) { a[tmp].pictureBox.Cursor = Cursors.SizeNS; }
                else if (handleIndex == 2) { a[tmp].pictureBox.Cursor = Cursors.SizeNESW; }
                else if (handleIndex == 3) { a[tmp].pictureBox.Cursor = Cursors.SizeWE; }
                else if (handleIndex == 4) { a[tmp].pictureBox.Cursor = Cursors.SizeNWSE; }
                else if (handleIndex == 5) { a[tmp].pictureBox.Cursor = Cursors.SizeNS; }
                else if (handleIndex == 6) { a[tmp].pictureBox.Cursor = Cursors.SizeNESW; }
                else if (handleIndex == 7) { a[tmp].pictureBox.Cursor = Cursors.SizeWE; }
                else if (handleIndex == 9) { a[tmp].pictureBox.Cursor = Cursors.SizeAll; }
                else a[tmp].pictureBox.Cursor = Cursors.Cross;
            }
            else
            {
               a[tmp].pictureBox.Cursor = Cursors.Default;
            }
            
        }

        private void handleMouseDown(object sender, MouseEventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (tmp < a.Count)
            {
                if (a[tmp].index == 6)
                {
                    //fill
                    a[tmp].listBitmap.Add(new Bitmap(a[tmp].pictureBox.Image));
                    a[tmp].iBitmap++;
                    Bitmap bm = (Bitmap)a[tmp].pictureBox.Image;
                    new FillTool().FloodFill(ref bm, a[tmp].Pen.Color, new Point(e.X, e.Y));
                    a[tmp].pictureBox.Image = bm;
                    a[tmp].bm = bm;
                    a[tmp].G = Graphics.FromImage(a[tmp].bm);
                    a[tmp].listBitmap[a[tmp].listBitmap.Count - 1] = new Bitmap(a[tmp].pictureBox.Image);
                    a[tmp].isResize = false;
                }
                

                if (a[tmp].index == 17)
                    this.Cursor = Cursors.Cross;

                //kiem tra co dang click vao o dieu khien
                int checkODK = 0;
                for (int i = 0; i < 8; i++)
                    if (GetHandleRect(i).Contains(e.Location))
                        checkODK = 1;

                //Ve chinh thuc khi an ra ngoai
                if (checkODK == 0 && !a[tmp].khung.IsEmpty && !a[tmp].khung.Contains(e.Location) && a[tmp].index != 6)
                {
                    a[tmp].currResize.VeChinhThuc(a[tmp]);
                    a[tmp].isText = !a[tmp].isText;
<<<<<<< HEAD
=======
                    
                    
>>>>>>> 27fec9669114948a82b644592b2aed784d51eaad
                    a[tmp].isClear = false;
                    a[tmp].listBitmap[a[tmp].listBitmap.Count - 1] = new Bitmap(a[tmp].pictureBox.Image);
                   
                }

                if (a[tmp].isResize)
                {
                    //Kiem tra dragHandle nao duoc an
                    for (int i = 0; i < 8; i++)
                    {
                        if (GetHandleRect(i).Contains(e.Location))
                        {
                            a[tmp].dragHandle = i;
                            a[tmp].khungCu = a[tmp].khung;
                            a[tmp].dragPoint = GetHandlePoint(i);
                        }
                    }
                    if (checkODK == 0 && !a[tmp].khung.IsEmpty && a[tmp].khung.Contains(e.Location))
                    {
                        //reset dragHandle va cap nhat vi tri de handle move
                        a[tmp].dragHandle = -1;
                        a[tmp].cX = e.X;
                        a[tmp].cY = e.Y;
                    }

                }
                else if (a[tmp].index != 0 && a[tmp].index != 4 && a[tmp].index != 6)
                {
                    //index: 4 - Paste, 6 - Fill
                    a[tmp].Paint = true;
                    a[tmp].py = e.Location;
                    a[tmp].cX = e.X;
                    a[tmp].cY = e.Y;

                    if (a[tmp].index == 16 && a[tmp].isText)
                    {
                        // tạo khung cho text
                        a[tmp].khung = new Rectangle(e.X, e.Y, 160, 47);
                        a[tmp].text.Show();
                    }

                    if (a[tmp].listBitmap.Count > 0)
                    {
                        //Xoa Redo khi thuc hien ve hinh moi
                        XoaRedo();
                        a[tmp].listBitmap[a[tmp].listBitmap.Count - 1] = new Bitmap(a[tmp].pictureBox.Image);
                    }
                }
            }
        }
<<<<<<< HEAD
=======
        private void VeChinhThuc()
        {
            int tmp = tcMain.SelectedIndex;
            
            if (tmp < a.Count)
            {
               
                a[tmp].currResize.VeChinhThuc(a[tmp]);
                //if (a[tmp].resizeIndex == 7)
                //{

                    //    a[tmp].isResize = false;
                    //    a[tmp].G.DrawRectangle(a[tmp].Pen, a[tmp].khung);
                    //    a[tmp].pictureBox.Refresh();
                    //    a[tmp].dragHandle = -1;
                    //    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //}
                    //else if (a[tmp].resizeIndex == 17)
                    //{
                    //    a[tmp].isResize = false;
                    //    Image clipboardImage = Clipboard.GetImage();
                    //    if (clipboardImage != null)
                    //    {
                    //        a[tmp].G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    //        a[tmp].G.DrawImage(clipboardImage, a[tmp].khung);
                    //        a[tmp].pictureBox.Refresh();
                    //        a[tmp].dragHandle = -1;
                    //        a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //    }
                    //}
                    //else if (a[tmp].resizeIndex == 4)
                    //{
                    //    a[tmp].isResize = false;
                    //    Image clipboardImage = Clipboard.GetImage();
                    //    if (clipboardImage != null)
                    //    {
                    //        a[tmp].G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    //        a[tmp].G.DrawImage(clipboardImage, a[tmp].khung);
                    //        a[tmp].pictureBox.Refresh();
                    //        a[tmp].dragHandle = -1;
                    //        a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //        a[tmp].Paint = false;
                    //    }
                    //}
                    //else if (a[tmp].resizeIndex == 2)
                    //{
                    //    a[tmp].isResize = false;

                    //    a[tmp].G.DrawEllipse(a[tmp].Pen, a[tmp].khung);
                    //    a[tmp].pictureBox.Refresh();
                    //    a[tmp].dragHandle = -1;
                    //    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //}
                    //else if (a[tmp].resizeIndex == 5)
                    //{
                    //    a[tmp].isResize = false;

                    //    a[tmp].G.DrawLine(a[tmp].Pen, a[tmp].khung.Left, a[tmp].khung.Top, a[tmp].khung.Right, a[tmp].khung.Bottom); ;
                    //    a[tmp].pictureBox.Refresh();
                    //    a[tmp].dragHandle = -1;
                    //    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //}
                    //else if (a[tmp].resizeIndex == 8)
                    //{
                    //    a[tmp].isResize = false;
                    //    Point dinhA = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height);
                    //    Point dinhB = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height);
                    //    Point dinhC = new Point((a[tmp].khung.X + a[tmp].khung.Width + a[tmp].khung.X) / 2, a[tmp].khung.Y);
                    //    Point[] dinhArray = { dinhC, dinhA, dinhB };
                    //    a[tmp].G.DrawPolygon(a[tmp].Pen, dinhArray);
                    //    a[tmp].pictureBox.Refresh();
                    //    a[tmp].dragHandle = -1;
                    //    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //}
                    //else if (a[tmp].resizeIndex == 9)
                    //{
                    //    a[tmp].isResize = false;
                    //    Point dinhA = new Point(a[tmp].khung.X, a[tmp].khung.Y);
                    //    Point dinhB = new Point(a[tmp].khung.X, a[tmp].khung.Y + a[tmp].khung.Height);
                    //    Point dinhC = new Point(a[tmp].khung.X + a[tmp].khung.Width, a[tmp].khung.Y + a[tmp].khung.Height);
                    //    Point[] dinhArray = { dinhC, dinhA, dinhB };
                    //    a[tmp].G.DrawPolygon(a[tmp].Pen, dinhArray);
                    //    a[tmp].pictureBox.Refresh();
                    //    a[tmp].dragHandle = -1;
                    //    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //}
                    //else if (a[tmp].resizeIndex == 10)
                    //{
                    //    a[tmp].isResize = false;

                    //    int x = a[tmp].khung.X;
                    //    int y = a[tmp].khung.Y;
                    //    int lX = a[tmp].khung.X + a[tmp].khung.Width;
                    //    int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                    //    Point p1 = new Point(x + (a[tmp].khung.Width) / 4, y);
                    //    Point p2 = new Point(lX - (a[tmp].khung.Width) / 4, y);
                    //    Point p3 = new Point(lX, y + (a[tmp].khung.Height) / 2);
                    //    Point p4 = new Point(lX - (a[tmp].khung.Width) / 4, lY);
                    //    Point p5 = new Point(x + (a[tmp].khung.Width) / 4, lY);
                    //    Point p6 = new Point(x, y + (a[tmp].khung.Height) / 2);
                    //    Point[] pArray = { p1, p2, p3, p4, p5, p6 };
                    //    a[tmp].G.DrawPolygon(a[tmp].Pen, pArray);
                    //    a[tmp].pictureBox.Refresh();
                    //    a[tmp].dragHandle = -1;
                    //    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //}
                    //else if (a[tmp].resizeIndex == 11)
                    //{
                    //    a[tmp].isResize = false;
                    //    int x = a[tmp].khung.X;
                    //    int y = a[tmp].khung.Y;
                    //    int lX = a[tmp].khung.X + a[tmp].khung.Width;
                    //    int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                    //    Point p1 = new Point(lX, y + (a[tmp].khung.Height / 2));
                    //    Point p2 = new Point(lX - (a[tmp].khung.Width / 3), y);
                    //    Point p3 = new Point(lX - (a[tmp].khung.Width / 3), y + (a[tmp].khung.Height / 3));
                    //    Point p4 = new Point(x, y + (a[tmp].khung.Height / 3));
                    //    Point p5 = new Point(x, lY - (a[tmp].khung.Height / 3));
                    //    Point p6 = new Point(lX - (a[tmp].khung.Width / 3), lY - (a[tmp].khung.Height / 3));
                    //    Point p7 = new Point(lX - (a[tmp].khung.Width / 3), lY);
                    //    Point[] pArray = { p1, p2, p3, p4, p5, p6, p7 };

                    //    a[tmp].G.DrawPolygon(a[tmp].Pen, pArray);
                    //    a[tmp].pictureBox.Refresh();
                    //    a[tmp].dragHandle = -1;
                    //    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //}
                    //else if (a[tmp].resizeIndex == 12)
                    //{
                    //    a[tmp].isResize = false;
                    //    int x = a[tmp].khung.X;
                    //    int y = a[tmp].khung.Y;
                    //    int lX = a[tmp].khung.X + a[tmp].khung.Width;
                    //    int lY = a[tmp].khung.Y + a[tmp].khung.Height;
                    //    Point p1 = new Point(x + (a[tmp].khung.Width / 2), y);
                    //    Point p2 = new Point(lX - (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                    //    Point p3 = new Point(lX, y + (3 * (a[tmp].khung.Height) / 8));
                    //    Point p4 = new Point(lX - (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                    //    Point p5 = new Point(lX - (3 * a[tmp].khung.Width / 14), lY);
                    //    Point p6 = new Point(x + a[tmp].khung.Width / 2, lY - (3 * a[tmp].khung.Height / 14));
                    //    Point p7 = new Point(x + (3 * a[tmp].khung.Width / 14), lY);
                    //    Point p8 = new Point(x + (2 * a[tmp].khung.Width / 7), lY - (5 * a[tmp].khung.Height / 14));
                    //    Point p9 = new Point(x, y + (3 * (a[tmp].khung.Height) / 8));
                    //    Point p10 = new Point(x + (5 * a[tmp].khung.Width / 14), y + (3 * (a[tmp].khung.Height) / 8));
                    //    Point[] pArray = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

                    //    a[tmp].G.DrawPolygon(a[tmp].Pen, pArray);
                    //    a[tmp].pictureBox.Refresh();
                    //    a[tmp].dragHandle = -1;
                    //    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //}
                    //if (a[tmp].resizeIndex == 16)
                    //{
                    //    int maxWidth = a[tmp].text.Width - 5;
                    //    string text = a[tmp].text.Text;
                    //    Font font = a[tmp].text.Font;

                    //    List<string> linesToDraw = new List<string>();
                    //    string currentLine = "";

                    //    foreach (char character in text)
                    //    {
                    //        string testLine = currentLine + character;
                    //        SizeF size = a[tmp].G.MeasureString(testLine, font);

                    //        if (size.Width <= maxWidth || char.IsWhiteSpace(character))
                    //        {
                    //            currentLine += character;
                    //        }
                    //        else
                    //        {
                    //            linesToDraw.Add(currentLine);
                    //            currentLine = character.ToString();
                    //        }
                    //    }
                    //    if (!string.IsNullOrEmpty(currentLine))
                    //    {
                    //        linesToDraw.Add(currentLine);
                    //    }

                    //    int y = a[tmp].khung.Y + 8;

                    //    foreach (string line in linesToDraw)
                    //    {
                    //        a[tmp].G.DrawString(line, font, a[tmp].brush, new PointF(a[tmp].khung.X + 8, y));
                    //        y += (int)font.GetHeight() + 2;
                    //    }


                    //    a[tmp].isResize = false;
                    //    a[tmp].pictureBox.Refresh();
                    //    a[tmp].dragHandle = -1;
                    //    a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                    //    a[tmp].text.Hide();
                    //    a[tmp].text.Text = "";
                    //}
            }
        }
>>>>>>> 27fec9669114948a82b644592b2aed784d51eaad
        private void XoaRedo()
        {
            int tmp = tcMain.SelectedIndex;
            if (tmp >= 0 && tmp < a.Count && a[tmp].iBitmap >= 0 && a[tmp].iBitmap < a[tmp].listBitmap.Count)
            {
                int n = a[tmp].listBitmap.Count - a[tmp].iBitmap - 1;
                a[tmp].listBitmap.RemoveRange(a[tmp].iBitmap + 1, n);
            }
        }
    }
}

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

                // ve khung 
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
                            this.Cursor = Cursors.SizeAll;
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


            if (handleIndex == 0)
            {
                this.Cursor = Cursors.SizeNWSE;
            }
            else if (handleIndex == 1) { this.Cursor = Cursors.SizeNS; }
            else if (handleIndex == 2) { this.Cursor = Cursors.SizeNESW; }
            else if (handleIndex == 3) { this.Cursor = Cursors.SizeWE; }
            else if (handleIndex == 4) { this.Cursor = Cursors.SizeNWSE; }
            else if (handleIndex == 5) { this.Cursor = Cursors.SizeNS; }
            else if (handleIndex == 6) { this.Cursor = Cursors.SizeNESW; }
            else if (handleIndex == 7) { this.Cursor = Cursors.SizeWE; }


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

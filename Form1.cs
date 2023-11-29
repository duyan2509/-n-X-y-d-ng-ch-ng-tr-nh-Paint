using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace BT_Draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            bm=new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            G=Graphics.FromImage(bm);
            G.Clear(Color.White);
            pictureBox1.Image = bm;
            brush = new SolidBrush(Color.Black);
        }

        Bitmap bm;
        Graphics G;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 3f);
        int index;
        int x, y, cX, cY, sX, sY;
        ColorDialog dlg=new ColorDialog();
        Color newColor=Color.Black,preColor;
        List<Region> region = new List<Region>();
        bool fill = false;
        Brush brush;

        private void btTron_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void btLine_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void btDCong_Click(object sender, EventArgs e)
        {
            index = 6;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTypePen.SelectedIndex == 0)
                p.DashStyle = DashStyle.Solid;
            else if(cbbTypePen.SelectedIndex==1)
                p.DashStyle = DashStyle.Dash;
        }

        private void cbbTypePen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTypePen.SelectedIndex == 0)
                p.DashStyle = DashStyle.Solid;
            else if (cbbTypePen.SelectedIndex == 1)
                p.DashStyle = DashStyle.Dash;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g=e.Graphics;
            //Ve hinh khi dang nhan chuot
            if(paint)
            {
                if (index == 2)
                {
                    //draw elip
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                if (index == 3)
                {
                    //vuong: ve theo canh nho hon
                    int side = Math.Abs(sX);
                    if (Math.Abs(sX) > Math.Abs(sY))
                        side = Math.Abs(sY);
                    Point point1 = new Point(cX, cY);
                    Point point3 = new Point(cX, cY);
                    if (x > cX)
                        point3.X += side;
                    else if (x < cX)
                        point3.X -= side;
                    if (y > cY)
                        point3.Y += side;
                    else if (y < cY)
                        point3.Y -= side;
                    Point point2 = new Point(point1.X, point3.Y);
                    Point point4 = new Point(point3.X, point1.Y);
                    Point[] ptsArray = { point1, point2, point3, point4 };
                    g.DrawPolygon(p, ptsArray);
                }
                if (index == 4)
                {
                    //ve hinh tron
                    int side = 0;
                    if (Math.Abs(sX) > Math.Abs(sY))
                        side = Math.Abs(sY);
                    else
                        side = Math.Abs(sX);
                    int dauW = 1;
                    int dauH=1;
                    if (sX < 0)
                        dauW = -1;
                    if (sY < 0)
                        dauH = -1;
                    g.DrawEllipse(p, cX, cY, dauW * side, dauH * side);
                }
                if (index == 5)
                {
                    //Ve line
                    g.DrawLine(p, cX, cY, x, y);
                }

            }
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            dlg.ShowDialog();
            preColor = newColor;
            newColor=dlg.Color;
            p.Color = newColor;
            btShowColor.BackColor = newColor;
            if (cbbBrush.SelectedIndex == 1)
                brush = new HatchBrush(HatchStyle.DarkVertical, dlg.Color, Color.White);
            else if(cbbBrush.SelectedIndex == 0)
                brush = new SolidBrush(dlg.Color);
            else if (cbbBrush.SelectedIndex == 2)
                brush = new LinearGradientBrush(new Point(0, 0), new Point(0,700), preColor, newColor);
            index = 7;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(fill)
            {
                Point tmp = e.Location;
                int selectedShapeIndex = -1;
                for (int i = 0; i < region.Count; i++)
                {
                    if (region[i].IsVisible(tmp))
                    {
                        selectedShapeIndex = i; 
                        break;
                    }
                }

                if (selectedShapeIndex != -1)
                {
                    G.FillRegion(brush, region[selectedShapeIndex]); 
                    selectedShapeIndex = -1;
                }
                if(index<6)
                    fill = false;
            }
        }

        private void btFill_Click(object sender, EventArgs e)
        {
            fill = true;
            index = 6;
        }

        private void cbbBrush_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBrush.SelectedIndex == 1)
                brush = new HatchBrush(HatchStyle.DarkVertical, dlg.Color, preColor);
            else if (cbbBrush.SelectedIndex == 0)
                brush = new SolidBrush(dlg.Color);
            else if (cbbBrush.SelectedIndex == 2)
                brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 700), preColor, newColor);
            fill = true;
            index = 8;
        }

        private void btVuong_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void btEclipse_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py=e.Location;
            cX = e.X;
            cY = e.Y;   
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if(index==1)
                {
                    //pen
                    px = e.Location;
                    G.DrawLine(p,px,py);
                    py = px;
                }
            }
            pictureBox1.Refresh();

            x = e.X;
            y = e.Y;
            // Tinh sX,sY de truyen len control_Paint
            sX = x - cX;
            sY = y - cY;
        }

        private void btPen_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            //Ve hinh chinh thuc sau khi tha chuot
            if(index==2)
            {
                //draw elip
                G.DrawEllipse(p, cX, cY, sX, sY);
                //tao region
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(cX, cY, sX, sY);
                region.Add(new Region(path));
            }
            if(index==3)
            {
                //vuong: ve theo canh nho hon
                int side =Math.Abs(sX);
                if (Math.Abs(sX) >Math.Abs(sY))
                    side = Math.Abs(sY);
                Point point1=new Point(cX,cY);
                Point point3=new Point(cX,cY);
                if (x > cX)
                    point3.X += side;
                else if (x < cX)
                    point3.X -= side;
                if (y > cY)
                    point3.Y += side;
                else if (y < cY)
                    point3.Y -= side;
                Point point2 = new Point(point1.X, point3.Y);
                Point point4 = new Point(point3.X, point1.Y);
                Point[] ptsArray = { point1, point2, point3, point4 };
                G.DrawPolygon(p, ptsArray);
                //tao region
                GraphicsPath path = new GraphicsPath();
                path.AddPolygon(ptsArray);
                region.Add(new Region(path));
            }
            if (index==4)
            {
                //ve hinh tron
                int side = 0;
                if (Math.Abs(sX) > Math.Abs(sY))
                    side = Math.Abs(sY);
                else
                    side = Math.Abs(sX);
                int dauW = 1;
                int dauH = 1;
                if (sX < 0)
                    dauW = -1;
                if (sY < 0)
                    dauH = -1;
                G.DrawEllipse(p, cX, cY, dauW * side, dauH * side);
                //tao region
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(cX, cY, dauW * side, dauH * side);
                region.Add(new Region(path));

            }
            if(index==5)
            {
                //Ve line
                G.DrawLine(p, cX, cY, x, y);
            }

        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Shape
{
    public  class HinhChuNhat:HinhVe
    {
        public HinhChuNhat(PointF a, PointF b) :base()
        {
            nControl = 8;
            index = 7;
            startPoint = a;
            endPoint = b;
            CreateFrame();

        }
        public override void Ve(PointF startPoint, PointF endPoint, Graphics G)
        {
            //
        }
        public override void Mouse_Down(object sender, MouseEventArgs e)
        {
            for(int i=0;i<8;i++)
            {
                if (rect[i].Contains(e.Location))
                {
                    isResize = true;
                }
                //else if(true)
                //{
                //    isMove = true;
                //}
                else break;
            }
        }
        public override void Mouse_Up(object sender, MouseEventArgs e)
        {

        }
        public override void Mouse_Move(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if(isResize)
                {
                    //update point
                    

                    //update rect


                    //render lai

                }
                else if(isMove)
                {

                }

            }
        }
        public override void CreateFrame()
        {
            
            PointF[] tmp =
            {
                new PointF(startPoint.X,startPoint.Y),
                new PointF((startPoint.X+endPoint.X)/2,startPoint.Y),
                new PointF(endPoint.X,startPoint.Y),
                new PointF(endPoint.X,(startPoint.Y+endPoint.Y)/2),
                new PointF(endPoint.X,endPoint.Y),
                new PointF((startPoint.X+endPoint.X)/2,endPoint.Y),
                new PointF(startPoint.X,endPoint.Y),
                new PointF(startPoint.X,(endPoint.Y+startPoint.Y)/2),
            };
            frame = tmp;
        }
        public override void VeKhung(Graphics G)
        {
            // tam
            Pen p = new Pen(Color.Yellow, thickness-2);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            G.DrawPolygon(p,frame);
        }

        public override void VeDiemDieuKhien(Graphics G)
        {


            // Vẽ 8 hình vuông có tâm là các điểm trong mảng arrPoints
            foreach (PointF point in frame)
            {
                
                float squareSize = 10; // Kích thước hình vuông
                float halfSize = squareSize / 2;

                // Tính toán tọa độ để vẽ hình vuông có tâm là điểm hiện tại
                float x = point.X - halfSize;
                float y = point.Y - halfSize;
                Rectangle newRe = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(squareSize), Convert.ToInt32(squareSize));
                // Vẽ hình vuông
                G.FillRectangle(Brushes.Yellow,newRe);
                rect.Add(newRe);
            }
        }

    }
}

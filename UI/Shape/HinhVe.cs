using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI.Shape
{

//soDiemDieuKhien
//graphicsPath
//khuVuc
//viTriChuotSoVoiHinhVe
//diChuyen
//thayDoiKichThuoc
//VanBan
//loaiHinh
//hinhNen

    public abstract class HinhVe
    {
        protected Color color { get; set; }
        protected float thickness { get; set; }
        protected PointF startPoint { get; set; }
        protected PointF endPoint { get; set; }
        protected PointF currentPoint { get; set; }
        protected GraphicsPath path { get; set; }
        protected bool isMove { get; set; }
        protected bool isResize { get; set; }
        protected int index { get; set; }
        protected string text { get; set; }
        protected int nControl { get; set; }
        protected PointF[] frame { get; set; }
        protected List<Rectangle> rect { get; set; }
        public HinhVe()
        {
            color= Color.Black;
            thickness = 3.5f;
            isMove = false;
            isResize = false;
            rect=new List<Rectangle>();
        }

        public abstract void Ve(PointF startPoint, PointF endPoint, Graphics G);
        public abstract void Mouse_Down(object sender, MouseEventArgs e);
        public abstract void Mouse_Up(object sender, MouseEventArgs e);
        public abstract void Mouse_Move(object sender, MouseEventArgs e);
        public abstract void CreateFrame();
        public abstract void VeKhung(Graphics G);
        public abstract void VeDiemDieuKhien(Graphics G);
    }
}

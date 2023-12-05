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

namespace UI
{
    internal class DrawObject
    {
        public Pen Pen { get; set; }
        public Color color { get; set; }
        public int DoDam { get; set; }
        public bool Paint { get; set; }
        public Point px { get; set; }
        public Point py { get; set; }
        public int index { get; set; }
        public bool Fill { get; set; }
        public Brush brush { get; set; }
        public Color Color { get; set; }

        public List<Region> region = new List<Region>();
        //ColorDialog dlg = new ColorDialog();
        public int x { get; set; }
        public int y { get; set; }
        public int cX { get; set; }
        public int cY { get; set; }

        public int sX { get; set; }
        public int sY { get; set; }
        public Graphics G { get; set; }
        public Bitmap bm { get; set; }

        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public Guna2Button bt = new Guna2Button();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{

    public class HinhVe
    {
        protected Pen resizePen { get; set; } 
        public virtual void Paint_Paint(ref Graphics g,  DrawObject aa)
        {

        }
        public virtual void Paint_Resize(ref Graphics g,  DrawObject aa)
        {

        }
        public virtual void VeChinhThuc(DrawObject aa)
        {

        }
    }
}

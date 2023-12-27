using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class Text : HinhVe
    {
        public Text() : base()
        {

        }
        public override void Paint_Resize(ref Graphics g, DrawObject aa)
        {
            aa.text.Size = new Size(aa.khung.Width - 12, aa.khung.Height - 12);
            aa.text.Location = new Point(aa.khung.X + 6, aa.khung.Y + 6);
        }
        public override void VeChinhThuc(DrawObject aa)
        {

            int maxWidth = aa.text.Width - 5;
            string text = aa.text.Text;
            Font font = aa.text.Font;

            List<string> linesToDraw = new List<string>();
            string currentLine = "";

            foreach (char character in text)
            {
                string testLine = currentLine + character;
                SizeF size = aa.G.MeasureString(testLine, font);

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

            int y = aa.khung.Y + 8;

            foreach (string line in linesToDraw)
            {
                aa.G.DrawString(line, font, aa.brush, new PointF(aa.khung.X + 8, y));
                y += (int)font.GetHeight() + 2;
            }


            aa.isResize = false;
            aa.pictureBox.Refresh();
            aa.dragHandle = -1;
            aa.khung = new Rectangle(aa.pictureBox.Top, 0, 0, 0);
            aa.text.Hide();
            aa.text.Text = "";

        }
    }
}

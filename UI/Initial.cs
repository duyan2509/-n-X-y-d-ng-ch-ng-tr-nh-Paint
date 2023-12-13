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

namespace UI
{
    public partial class Form1 : Form
    {
        private void initDrawObject()
        {
            DrawObject tmp = new DrawObject();
            tmp.Color = Color.Black;
            tmp.Pen = new Pen(tmp.Color);
            tmp.Eraser = new Pen(Color.White, 10);
            tmp.DoDam = 10;
            tmp.py = new Point(0, 0);
            tmp.px = new Point(0, 0);
            tmp.Paint = false;
            tmp.Fill = false;
            tmp.brush = new SolidBrush(tmp.Color);
            tmp.index = 0;
            tmp.isResize = false;
            tmp.dragPoint = new Point(0, 0);
            tmp.khung = new Rectangle(0, 0, 0, 0);
            tmp.visibleFrame = false;
            a.Add(tmp);
        }
        private void initialPanel()
        {
            Panel newPanel = new Panel();
            newPanel.Dock = DockStyle.Left;
            newPanel.Size = new Size(227, newPanel.Height);
            newPanel.BackColor = Color.FromArgb(0, 120, 215);
            newPanel.AutoScroll = true;
            // Add two label 
            Label toolLabel = new Label();
            Label shapeLabel = new Label();
            toolLabel.Text = "Tools";
            toolLabel.ForeColor = Color.White;
            toolLabel.Font = new Font("Arial", 13, FontStyle.Bold);
            toolLabel.Location = new Point(70, 10);
            shapeLabel.Text = "Shapes";
            shapeLabel.ForeColor = Color.White;
            shapeLabel.Font = new Font("Arial", 13, FontStyle.Bold);
            shapeLabel.Location = new Point(70, 220);
            newPanel.Controls.Add(toolLabel);
            newPanel.Controls.Add(shapeLabel);


            //Add tool panel
            Panel toolPanel = new Panel();
            toolPanel.Location = new Point(70, 35);
            toolPanel.Size = new Size(140, 180);
            // Pen button
            Guna2Button penButton = new Guna2Button();
            penButton.Size = new Size(45, 45);
            penButton.Location = new Point(0, 0);
            penButton.FillColor = Color.FromArgb(94, 148, 255);
            penButton.BorderRadius = 20;
            penButton.Image = Properties.Resources.icons8_pencil_60_white;
            penButton.ImageSize = new Size(20, 20);
            penButton.Animated = true;
            penButton.Click += handleClickPenButton;
            penButton.Cursor = Cursors.Hand;
            toolPanel.Controls.Add(penButton);
            // Erase button
            Guna2Button eraseButton = new Guna2Button();
            eraseButton.Size = new Size(45, 45);
            eraseButton.Location = new Point(60, 0);
            eraseButton.FillColor = Color.FromArgb(94, 148, 255);
            eraseButton.BorderRadius = 20;
            eraseButton.Image = Properties.Resources.icons8_erase_60_white;
            eraseButton.ImageSize = new Size(20, 20);
            eraseButton.Animated = true;
            eraseButton.Click += handleClickEraseButton;
            eraseButton.Cursor = Cursors.Hand;
            toolPanel.Controls.Add(eraseButton);
            //Fill button
            Guna2Button fillButton = new Guna2Button();
            fillButton.Size = new Size(45, 45);
            fillButton.Location = new Point(0, 55);
            fillButton.FillColor = Color.FromArgb(94, 148, 255);
            fillButton.BorderRadius = 20;
            fillButton.Image = Properties.Resources.icons8_fill_color_60_white;
            fillButton.ImageSize = new Size(20, 20);
            fillButton.Animated = true;
            fillButton.Click += handleClickFillButton;
            fillButton.Cursor = Cursors.Hand;
            toolPanel.Controls.Add(fillButton);

            //Text button
            Guna2Button textButton = new Guna2Button();
            textButton.Size = new Size(45, 45);
            textButton.Location = new Point(60, 55);
            textButton.FillColor = Color.FromArgb(94, 148, 255);
            textButton.BorderRadius = 20;
            textButton.Image = Properties.Resources.icons8_text_60_white;
            textButton.ImageSize = new Size(20, 20);
            textButton.Animated = true;
            textButton.Click += handleClickTextButton;
            textButton.Cursor = Cursors.Hand;
            toolPanel.Controls.Add(textButton);

            //Brush button
            Guna2Button brushButton = new Guna2Button();
            brushButton.Size = new Size(45, 45);
            brushButton.Location = new Point(0, 110);
            brushButton.FillColor = Color.FromArgb(94, 148, 255);
            brushButton.BorderRadius = 20;
            brushButton.Image = Properties.Resources.icons8_brush_48_white;
            brushButton.ImageSize = new Size(20, 20);
            brushButton.Animated = true;
            brushButton.Click += handleClickBrushButton;
            brushButton.Cursor = Cursors.Hand;
            toolPanel.Controls.Add(brushButton);


            //Add shape panel
            Panel shapePanel = new Panel();
            shapePanel.Location = new Point(70, 250);
            shapePanel.Size = new Size(140, 520);
            // Hinh chu nhat
            Guna2Button rectangleButton = new Guna2Button();
            rectangleButton.Size = new Size(45, 45);
            rectangleButton.Location = new Point(0, 0);
            rectangleButton.FillColor = Color.FromArgb(94, 148, 255);
            rectangleButton.BorderRadius = 20;
            rectangleButton.Image = Properties.Resources.icons8_rectangle_48_white;
            rectangleButton.ImageSize = new Size(20, 20);
            rectangleButton.Animated = true;
            rectangleButton.Click += handleClickRectangleButton;
            rectangleButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(rectangleButton);


            // Hinh tron
            Guna2Button circleButton = new Guna2Button();
            circleButton.Size = new Size(45, 45);
            circleButton.Location = new Point(60, 0);
            circleButton.FillColor = Color.FromArgb(94, 148, 255);
            circleButton.BorderRadius = 20;
            circleButton.Image = Properties.Resources.icons8_circle_50_white;
            circleButton.ImageSize = new Size(20, 20);
            circleButton.Animated = true;
            circleButton.Click += handleClickCircleButton;
            circleButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(circleButton);
            // Hinh Tam Giac Can
            Guna2Button triangleButton = new Guna2Button();
            triangleButton.Size = new Size(45, 45);
            triangleButton.Location = new Point(0, 60);
            triangleButton.Image = Properties.Resources.icons8_triangle_48_white;
            triangleButton.ImageSize = new Size(20, 20);
            triangleButton.BorderRadius = 20;
            triangleButton.Animated = true;
            triangleButton.Click += handleClickTriangleButton;
            triangleButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(triangleButton);
            // Hinh Tam Giac Vuong 
            Guna2Button right_triangleButton = new Guna2Button();
            right_triangleButton.Size = new Size(45, 45);
            right_triangleButton.Location = new Point(60, 60);
            right_triangleButton.Image = Properties.Resources.icons8_right_triangle_48_white;
            right_triangleButton.ImageSize = new Size(20, 20);
            right_triangleButton.BorderRadius = 20;
            right_triangleButton.Animated = true;
            right_triangleButton.Click += handleClickright_TriangleButton;
            right_triangleButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(right_triangleButton);
            // Hinh Vuong
            Guna2Button squareButton = new Guna2Button();
            squareButton.Size = new Size(45, 45);
            squareButton.Location = new Point(0, 120);
            squareButton.Image = Properties.Resources.icons8_rounded_square_48_white;
            squareButton.ImageSize = new Size(20, 20);
            squareButton.BorderRadius = 20;
            squareButton.Animated = true;
            squareButton.Click += handleClickSquareButton;
            squareButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(squareButton);
            // Hinh Luc Giac
            Guna2Button hexagonButton = new Guna2Button();
            hexagonButton.Size = new Size(45, 45);
            hexagonButton.Location = new Point(60, 180);
            hexagonButton.Image = Properties.Resources.icons8_hexagon_48_white;
            hexagonButton.ImageSize = new Size(20, 20);
            hexagonButton.BorderRadius = 20;
            hexagonButton.Animated = true;
            hexagonButton.Click += handleClickHexagonButton;
            hexagonButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(hexagonButton);
            // Hinh Mui Ten
            Guna2Button arrowButton = new Guna2Button();
            arrowButton.Size = new Size(45, 45);
            arrowButton.Location = new Point(60, 120);
            arrowButton.Image = Properties.Resources.icons8_arrow_48_white;
            arrowButton.ImageSize = new Size(20, 20);
            arrowButton.BorderRadius = 20;
            arrowButton.Animated = true;
            arrowButton.Click += handleClickArrowButton;
            arrowButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(arrowButton);
            // Hinh Sao 5 Canh
            Guna2Button starButton = new Guna2Button();
            starButton.Size = new Size(45, 45);
            starButton.Location = new Point(0, 180);
            starButton.Image = Properties.Resources.icons8_star_48_white;
            starButton.ImageSize = new Size(20, 20);
            starButton.BorderRadius = 20;
            starButton.Animated = true;
            starButton.Click += handleClickStarButton;
            starButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(starButton);
            // Hinh Elip
            Guna2Button ellipseButton = new Guna2Button();
            ellipseButton.Size = new Size(45, 45);
            ellipseButton.Location = new Point(0, 240);
            ellipseButton.Image = Properties.Resources.icons8_ellipse_48_white;
            ellipseButton.ImageSize = new Size(20, 20);
            ellipseButton.BorderRadius = 20;
            ellipseButton.Animated = true;
            ellipseButton.Click += handleClickEllipseButton;
            ellipseButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(ellipseButton);
            // Hinh Duong Cung
            Guna2Button arcButton = new Guna2Button();
            arcButton.Size = new Size(45, 45);
            arcButton.Location = new Point(60, 240);
            arcButton.Image = Properties.Resources.icons8_half_circle_48_white;
            arcButton.ImageSize = new Size(20, 20);
            arcButton.BorderRadius = 20;
            arcButton.Animated = true;
            arcButton.Click += handleClickCircleButton;
            arcButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(arcButton);

            //Add color panel
            Panel colorPanel = new Panel();
            colorPanel.Location = new Point(0, 50);
            colorPanel.Size = new Size(60, 400);

            Guna2Button blackButton = new Guna2Button();
            blackButton.Size = new Size(45, 45);
            blackButton.Location = new Point(5, 0);
            blackButton.FillColor = Color.Black;
            blackButton.BorderRadius = 20;
            blackButton.ImageSize = new Size(20, 20);
            blackButton.Animated = true;
            //blackButton.Click += ;
            blackButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(blackButton);

            Guna2Button greenButton = new Guna2Button();
            greenButton.Size = new Size(45, 45);
            greenButton.Location = new Point(5, 55);
            greenButton.FillColor = Color.FromArgb(97, 197, 84);
            greenButton.BorderRadius = 20;
            greenButton.ImageSize = new Size(20, 20);
            greenButton.Animated = true;
            //greenButton.Click += ;
            greenButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(greenButton);

            Guna2Button redButton = new Guna2Button();
            redButton.Size = new Size(45, 45);
            redButton.Location = new Point(5, 110);
            redButton.FillColor = Color.FromArgb(237, 105, 94);
            redButton.BorderRadius = 20;
            redButton.ImageSize = new Size(20, 20);
            redButton.Animated = true;
            //redButton.Click += ;
            redButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(redButton);

            Guna2Button yellowButton = new Guna2Button();
            yellowButton.Size = new Size(45, 45);
            yellowButton.Location = new Point(5, 165);
            yellowButton.FillColor = Color.FromArgb(244, 191, 79);
            yellowButton.BorderRadius = 20;
            yellowButton.ImageSize = new Size(20, 20);
            yellowButton.Animated = true;
            //yellowButton.Click += ;
            yellowButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(yellowButton);

            Guna2Button blueButton = new Guna2Button();
            blueButton.Size = new Size(45, 45);
            blueButton.Location = new Point(5, 220);
            blueButton.FillColor = Color.FromArgb(77, 139, 183);
            blueButton.BorderRadius = 20;
            blueButton.ImageSize = new Size(20, 20);
            blueButton.Animated = true;
            //blueButton.Click += ;
            blueButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(blueButton);

            Guna2Button pickColorButton = new Guna2Button();
            pickColorButton.Size = new Size(45, 45);
            pickColorButton.Location = new Point(5, 275);
            pickColorButton.FillColor = Color.FromArgb(203, 213, 224);
            pickColorButton.BorderRadius = 20;
            pickColorButton.ImageSize = new Size(15, 15);
            pickColorButton.Animated = true;
            //pickColorButton.Click += ;
            pickColorButton.Image = Properties.Resources.icons8_plus_48;

            pickColorButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(pickColorButton);


            int tmp = tcMain.SelectedIndex;
            colorPanel.Controls.Add(a[tmp].bt);

            newPanel.Controls.Add(toolPanel);
            newPanel.Controls.Add(colorPanel);
            newPanel.Controls.Add(shapePanel);
            //


            //
            tcMain.SelectedPage.Controls.Add(newPanel);

        }
        private void initialPictureBox()
        {
            PictureBox backGround = new PictureBox();
            backGround.Dock = DockStyle.Right;
            backGround.Width = this.Width - 263;
            backGround.BackColor = Color.FromArgb(243, 243, 243);



            int tmp = tcMain.SelectedIndex;
            a[tmp].pictureBox = new Guna2PictureBox();

            a[tmp].pictureBox.MouseDown += handleMouseDown;
            a[tmp].pictureBox.MouseMove += handleMouseMove;
            a[tmp].pictureBox.MouseUp += handleMouseUp;
            a[tmp].pictureBox.MouseClick += handleMouseClick;//fill
            a[tmp].pictureBox.Paint += handlePaint;

            // Button ( trong DrawObject)
            a[tmp].bt.Size = new Size(45, 45);
            a[tmp].bt.FillColor = Color.White;
            a[tmp].bt.BorderRadius = 20;
            a[tmp].bt.Cursor = Cursors.Hand;
            a[tmp].bt.Location = new Point(5, 330);
            a[tmp].bt.Image = Properties.Resources.icons8_resize_48;
            a[tmp].bt.ImageSize = new Size(20, 20);
            a[tmp].bt.Animated = true;
            //tcMain.SelectedPage.Controls.Add(a[tmp].bt);
            //

            //size
            a[tmp].sizeX = 600;
            a[tmp].sizeY = 400;
            a[tmp].pictureBox.Size = new Size(a[tmp].sizeX, a[tmp].sizeY);
            a[tmp].bm = new Bitmap(a[tmp].pictureBox.Width, a[tmp].pictureBox.Height);
            a[tmp].pictureBox.Image = a[tmp].bm;
            a[tmp].G = Graphics.FromImage(a[tmp].bm);
            a[tmp].G.Clear(Color.White);
            a[tmp].pictureBox.Invalidate();
            this.SizeChanged += (sender, e) =>
            {
                backGround.Dock = DockStyle.Right;
                backGround.Width = this.Width - 270;
                backGround.BackColor = Color.FromArgb(243, 243, 243);
                a[tmp].pictureBox.Location = new Point((backGround.Width - a[tmp].pictureBox.Width) / 2, Math.Abs(this.Height - a[tmp].pictureBox.Height) / 2);
            };

            backGround.Controls.Add(a[tmp].pictureBox);
            a[tmp].pictureBox.Location = new Point((backGround.Width - a[tmp].pictureBox.Width) / 2, Math.Abs(this.Height - a[tmp].pictureBox.Height) / 2);



            resizeForm ResizeForm = new resizeForm();

            a[tmp].bt.Click += (s, args) =>
            {
                if (a[tmp].region.Count != 0)
                {
                    return;
                }
                else
                {
                    ResizeForm.ShowDialog();
                    int width = ResizeForm.width;
                    int height = ResizeForm.height;
                    if (ResizeForm.index == 1)
                    {
                        Image originalImage = a[tmp].pictureBox.Image;
                        Bitmap resizedImage = new Bitmap(originalImage, width, height);
                        a[tmp].bm = resizedImage;
                        a[tmp].pictureBox.Size = new Size(width, height);
                        a[tmp].pictureBox.Image = a[tmp].bm;
                        a[tmp].G = Graphics.FromImage(a[tmp].bm);
                        a[tmp].pictureBox.Location = new Point((backGround.Width - a[tmp].pictureBox.Width) / 2, Math.Abs(this.Height - a[tmp].pictureBox.Height) / 2);
                    }
                }
            };
            tcMain.SelectedPage.Controls.Add(backGround);


        }

    }
}

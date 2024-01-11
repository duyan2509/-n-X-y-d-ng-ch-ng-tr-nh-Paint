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
using UI;

namespace UI
{
    public partial class FormMain : Form
    {
        private void initDrawObject()
        {
            DrawObject tmp = new DrawObject();
            tmp.Pen = new Pen(Color.Black,3f);
            tmp.Pen.StartCap = LineCap.Round;
            tmp.oPen = new Pen(Color.Black, 3f);
            tmp.Eraser = new Pen(Color.White, 3f);
            tmp.Eraser.StartCap = LineCap.Round;
            tmp.py = new Point(0, 0);
            tmp.px = new Point(0, 0);
            tmp.Paint = false;
            tmp.brush = new SolidBrush(tmp.Pen.Color);
            tmp.index = 0;
            tmp.isResize = false;
            tmp.dragPoint = new Point(0, 0);
            tmp.khung = new Rectangle(0, 0, 0, 0);
            tmp.listBitmap = new List<Bitmap>();
            tmp.iBitmap = 0;
            tmp.isClear = true;
            tmp.filePath = "";
            tmp.fileName = "";
            fileName.Text = tmp.fileName;
            tmp.buttons = new List<Guna2Button>();
            tmp.currShape = new HinhVe();
            tmp.bt = new Guna2Button();
            a.Add(tmp);

        }
        private void initialPanel()
        {
            Panel newPanel = new Panel();
            newPanel.Dock = DockStyle.Left;
            newPanel.Size = new Size(227, newPanel.Height);
            newPanel.BackColor = Color.FromArgb(0, 120, 215);

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

            int tmp=tcMain.SelectedIndex;
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
            penButton.BorderColor = Color.White;
            penButton.Click += handleClickPenButton;
            penButton.Cursor = Cursors.Hand;
            toolPanel.Controls.Add(penButton);
            a[tmp].buttons.Add(penButton);
            // Erase button
            Guna2Button eraseButton = new Guna2Button();
            eraseButton.Size = new Size(45, 45);
            eraseButton.Location = new Point(60, 0);
            eraseButton.FillColor = Color.FromArgb(94, 148, 255);
            eraseButton.BorderRadius = 20;
            eraseButton.Image = Properties.Resources.icons8_erase_60_white;
            eraseButton.ImageSize = new Size(20, 20);
            eraseButton.Animated = true;
            eraseButton.BorderColor = Color.White;
            eraseButton.Click += handleClickEraseButton;
            eraseButton.Cursor = Cursors.Hand;
            toolPanel.Controls.Add(eraseButton);
            a[tmp].buttons.Add(eraseButton);
            //Fill button
            Guna2Button fillButton = new Guna2Button();
            fillButton.Size = new Size(45, 45);
            fillButton.Location = new Point(0, 55);
            fillButton.FillColor = Color.FromArgb(94, 148, 255);
            fillButton.BorderRadius = 20;
            fillButton.Image = Properties.Resources.icons8_fill_color_60_white;
            fillButton.ImageSize = new Size(20, 20);
            fillButton.Animated = true;
            fillButton.BorderColor=Color.White;
            fillButton.Click += handleClickFillButton;
            fillButton.Cursor = Cursors.Hand;
            toolPanel.Controls.Add(fillButton);
            a[tmp].buttons.Add(fillButton);
            //Text button
            Guna2Button textButton = new Guna2Button();
            textButton.Size = new Size(45, 45);
            textButton.Location = new Point(60, 55);
            textButton.FillColor = Color.FromArgb(94, 148, 255);
            textButton.BorderRadius = 20;
            textButton.Image = Properties.Resources.icons8_text_60_white;
            textButton.ImageSize = new Size(20, 20);
            textButton.Animated = true;
            textButton.BorderColor = Color.White;
            textButton.Click += handleClickTextButton;
            textButton.Cursor = Cursors.Hand;
            toolPanel.Controls.Add(textButton);
            a[tmp].buttons.Add(textButton);
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

            //Size Button 
            Guna2Button sizeButton = new Guna2Button();
            sizeButton.Size = new Size(45, 45);
            sizeButton.Location = new Point(60, 110);
            sizeButton.FillColor = Color.FromArgb(94, 148, 255);
            sizeButton.BorderRadius = 20;
            sizeButton.Image = Properties.Resources.icons8_line_width_50;
            sizeButton.ImageSize = new Size(20, 20);
            sizeButton.Animated = true;
            sizeButton.Click += handleClickSizeButton;
            sizeButton.Cursor = Cursors.Hand;

            toolPanel.Controls.Add(sizeButton);

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
            rectangleButton.BorderColor = Color.White;
            rectangleButton.Click += handleClickRectangleButton;
            rectangleButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(rectangleButton);
            a[tmp].buttons.Add(rectangleButton);

            // Hinh Line
            Guna2Button lineButton = new Guna2Button();
            lineButton.Size = new Size(45, 45);
            lineButton.Location = new Point(60, 0);
            lineButton.FillColor = Color.FromArgb(94, 148, 255);
            lineButton.BorderRadius = 20;
            lineButton.Image = Properties.Resources.icons8_line_48_white ;
            lineButton.ImageSize = new Size(20, 20);
            lineButton.Animated = true;
            lineButton.Click += handleClickLineButton;
            lineButton.Cursor = Cursors.Hand;
            lineButton.BorderColor=Color.White;
            shapePanel.Controls.Add(lineButton);
            a[tmp].buttons.Add(lineButton);
            // Hinh Tam Giac Can
            Guna2Button triangleButton = new Guna2Button();
            triangleButton.Size = new Size(45, 45);
            triangleButton.Location = new Point(0, 60);
            triangleButton.Image = Properties.Resources.icons8_triangle_48_white;
            triangleButton.ImageSize = new Size(20, 20);
            triangleButton.BorderRadius = 20;
            triangleButton.Animated = true;
            triangleButton.BorderColor = Color.White;
            triangleButton.Click += handleClickTriangleButton;
            triangleButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(triangleButton);
            a[tmp].buttons.Add(triangleButton);
            // Hinh Tam Giac Vuong 
            Guna2Button right_triangleButton = new Guna2Button();
            right_triangleButton.Size = new Size(45, 45);
            right_triangleButton.Location = new Point(60, 60);
            right_triangleButton.Image = Properties.Resources.icons8_right_triangle_48_white;
            right_triangleButton.ImageSize = new Size(20, 20);
            right_triangleButton.BorderRadius = 20;
            right_triangleButton.Animated = true;
            right_triangleButton.BorderColor = Color.White;
            right_triangleButton.Click += handleClickright_TriangleButton;
            right_triangleButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(right_triangleButton);
            a[tmp].buttons.Add(right_triangleButton);
            // Hinh Luc Giac
            Guna2Button hexagonButton = new Guna2Button();
            hexagonButton.Size = new Size(45, 45);
            hexagonButton.Location = new Point(60, 180);
            hexagonButton.Image = Properties.Resources.icons8_hexagon_48_white;
            hexagonButton.ImageSize = new Size(20, 20);
            hexagonButton.BorderRadius = 20;
            hexagonButton.Animated = true;
            hexagonButton.BorderColor = Color.White;
            hexagonButton.Click += handleClickHexagonButton;
            hexagonButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(hexagonButton);
            a[tmp].buttons.Add(hexagonButton);
            // Hinh Mui Ten
            Guna2Button arrowButton = new Guna2Button();
            arrowButton.Size = new Size(45, 45);
            arrowButton.Location = new Point(60, 120);
            arrowButton.Image = Properties.Resources.icons8_arrow_48_white;
            arrowButton.ImageSize = new Size(20, 20);
            arrowButton.BorderRadius = 20;
            arrowButton.Animated = true;
            arrowButton.BorderColor = Color.White;
            arrowButton.Click += handleClickArrowButton;
            arrowButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(arrowButton);
            a[tmp].buttons.Add(arrowButton);
            // Hinh Sao 5 Canh
            Guna2Button starButton = new Guna2Button();
            starButton.Size = new Size(45, 45);
            starButton.Location = new Point(0, 180);
            starButton.Image = Properties.Resources.icons8_star_48_white;
            starButton.ImageSize = new Size(20, 20);
            starButton.BorderRadius = 20;
            starButton.Animated = true;
            starButton.BorderColor = Color.White;
            starButton.Click += handleClickStarButton;
            starButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(starButton);
            a[tmp].buttons.Add(starButton);
            // Hinh Elip
            Guna2Button ellipseButton = new Guna2Button();
            ellipseButton.Size = new Size(45, 45);
            ellipseButton.Location = new Point(0, 120);
            ellipseButton.Image = Properties.Resources.icons8_ellipse_48_white;
            ellipseButton.ImageSize = new Size(20, 20);
            ellipseButton.BorderRadius = 20;
            ellipseButton.Animated = true;
            ellipseButton.BorderColor = Color.White;
            ellipseButton.Click += handleClickEllipseButton;
            ellipseButton.Cursor = Cursors.Hand;
            shapePanel.Controls.Add(ellipseButton);
            a[tmp].buttons.Add(ellipseButton);



            //Add color panel
            Guna2Panel colorPanel = new Guna2Panel();
            colorPanel.Location = new Point(5, 30);
            colorPanel.Size = new Size(60, 190);
            colorPanel.BorderColor = pnTitleBar.BackColor;
            colorPanel.BorderRadius = 20;
            colorPanel.BorderThickness = 2;            //Add design panel
            Guna2Panel designPanel = new Guna2Panel();
            designPanel.Location = new Point(5, 240);
            designPanel.Size = new Size(60, 225);
            designPanel.BorderColor = pnTitleBar.BackColor;
            designPanel.BorderRadius = 20;
            designPanel.BorderThickness = 2;

            Guna2Button pickingButton = new Guna2Button();
            pickingButton.Size = new Size(35, 35);
            pickingButton.Location = new Point(10, 15);
            pickingButton.FillColor = Color.Black;
            pickingButton.BorderRadius = 15;
            pickingButton.BorderThickness = 2;
            pickingButton.BorderColor=Color.White;
            pickingButton.ImageSize = new Size(10, 10);
            pickingButton.Animated = true;
            pickingButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(pickingButton);
            
            Guna2Button yellowButton = new Guna2Button();
            yellowButton.Size = new Size(35, 35);
            yellowButton.Location = new Point(10, 55);
            yellowButton.FillColor = Color.Yellow;
            yellowButton.BorderRadius = 15;
            yellowButton.ImageSize = new Size(10, 10);
            yellowButton.Animated = true;
            yellowButton.Click += (sender,e)=> 
            {
                if (sender is Guna2Button clickedButton)
                {
                    int stt = tcMain.SelectedIndex;
                    a[stt].Pen.Color = Color.Yellow;
                    pickingButton.FillColor=a[stt].Pen.Color;
                    if (a[stt].isResize)
                        a[stt].pictureBox.Refresh();
                }
            };
            yellowButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(yellowButton);

            Guna2Button redButton = new Guna2Button();
            redButton.Size = new Size(35, 35);
            redButton.Location = new Point(10, 95);
            redButton.FillColor = Color.Red;
            redButton.BorderRadius = 15;
            redButton.ImageSize = new Size(10, 10);
            redButton.Animated = true;
            redButton.Click += (sender,e)=>
            {
                if (sender is Guna2Button clickedButton)
                {
                    int stt = tcMain.SelectedIndex;
                    a[stt].Pen.Color = Color.Red;
                    pickingButton.FillColor = a[stt].Pen.Color;
                    if (a[stt].isResize)
                        a[stt].pictureBox.Refresh();
                }
            };
            redButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(redButton);

            //Button Color Pick
            Guna2Button pickColorButton = new Guna2Button();
            pickColorButton.Size = new Size(35, 35);
            pickColorButton.Location = new Point(10, 135);
            pickColorButton.FillColor = Color.FromArgb(203, 213, 224);
            pickColorButton.BorderRadius = 15;
            pickColorButton.ImageSize = new Size(18, 18);
            pickColorButton.Animated = true;
            pickColorButton.Click += (sender, e) =>
            {
                if (sender is Guna2Button clickedButton)
                {
                    dlgColor.ShowDialog();
                    int stt = tcMain.SelectedIndex;
                    a[stt].Pen.Color = dlgColor.Color;
                    pickingButton.FillColor=a[stt].Pen.Color;
                    if (a[stt].isResize)
                        a[stt].pictureBox.Refresh();
                }
            };

            pickColorButton.Image = Properties.Resources.icons8_plus_48;

            pickColorButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(pickColorButton);

            //Button Select
            selectButton = new Guna2Button();
            selectButton.Size = new Size(35, 35);
            selectButton.Location = new Point(10, 15);
            selectButton.FillColor = Color.FromArgb(203, 213, 224);
            selectButton.BorderRadius = 15;
            selectButton.ImageSize = new Size(18, 18);
            selectButton.Animated = true;
            selectButton.BorderColor = Color.FromArgb(94, 148, 255);
            selectButton.Image = Properties.Resources.icons8_select_cursor_48_blue;
            selectButton.Click += handleSelectButton;
            selectButton.Cursor = Cursors.Hand;
            a[tmp].buttons.Add(selectButton);
            designPanel.Controls.Add(selectButton);

            //Button zoom in
            Guna2Button zoomInButton = new Guna2Button();
            zoomInButton.Size = new Size(35, 35);
            zoomInButton.Location = new Point(10, 55);
            zoomInButton.FillColor = Color.FromArgb(203, 213, 224);
            zoomInButton.BorderRadius = 15;
            zoomInButton.ImageSize = new Size(18, 18);
            zoomInButton.Animated = true;
            zoomInButton.Image = Properties.Resources.icons8_zoom_in_30_blue;
            zoomInButton.Click += handleClickZoomIn;
            zoomInButton.Cursor = Cursors.Hand;
            designPanel.Controls.Add(zoomInButton);

            //Button zoom out
            Guna2Button zoomOutButton = new Guna2Button();
            zoomOutButton.Size = new Size(35, 35);
            zoomOutButton.Location = new Point(10, 95);
            zoomOutButton.FillColor = Color.FromArgb(203, 213, 224);
            zoomOutButton.BorderRadius = 15;
            zoomOutButton.ImageSize = new Size(18, 18);
            zoomOutButton.Animated = true;
            zoomOutButton.Image = Properties.Resources.icons8_zoom_out_30_blue;

            zoomOutButton.Click += handleClickZoomOut;
            zoomOutButton.Cursor = Cursors.Hand;
            designPanel.Controls.Add(zoomOutButton);

            //Button reset
            Guna2Button resetButton = new Guna2Button();
            resetButton.Size = new Size(35, 35);
            resetButton.Location = new Point(10, 175);
            resetButton.FillColor = Color.FromArgb(203, 213, 224);
            resetButton.BorderRadius = 15;
            resetButton.ImageSize = new Size(10, 10);
            resetButton.Animated = true;
            resetButton.Click += handleResetZoom;

            resetButton.Cursor = Cursors.Hand;
            designPanel.Controls.Add(resetButton);
            designPanel.Controls.Add(a[tmp].bt);


            newPanel.Controls.Add(toolPanel);
            newPanel.Controls.Add(colorPanel);
            newPanel.Controls.Add(shapePanel);
            newPanel.Controls.Add(designPanel);
            //

            //
            tcMain.SelectedPage.Controls.Add(newPanel);

        }
        private void initialPictureBox()
        {
            int tmp = tcMain.SelectedIndex;
            a[tmp].backGround.Dock = DockStyle.Right;
            a[tmp].backGround.AutoScroll = true;
            a[tmp].backGround.Width = this.Width - 263;
            a[tmp].backGround.BackColor = Color.FromArgb(243, 243, 243);



            a[tmp].pictureBox = new Guna2PictureBox();
            a[tmp].pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            a[tmp].pictureBox.MouseDown += handleMouseDown;
            a[tmp].pictureBox.MouseMove += handleMouseMove;
            a[tmp].pictureBox.MouseUp += handleMouseUp;
            a[tmp].pictureBox.Paint += handlePaint;            

            // Button (trong DrawObject) Resize
            a[tmp].bt.Size = new Size(35, 35);
            a[tmp].bt.FillColor = Color.White;
            a[tmp].bt.BorderRadius = 15;
            a[tmp].bt.Cursor = Cursors.Hand;
            a[tmp].bt.Location = new Point(10, 135);
            a[tmp].bt.Image = Properties.Resources.icons8_resize_50_black;
            a[tmp].bt.FillColor = Color.FromArgb(203, 213, 224);
            a[tmp].bt.ImageSize = new Size(18, 18);
            a[tmp].bt.Animated = true;
            //

            //size
            a[tmp].pictureBox.Size = new Size(600, 400);
            a[tmp].bm = new Bitmap(a[tmp].pictureBox.Width, a[tmp].pictureBox.Height);
            a[tmp].pictureBox.Image = a[tmp].bm;
            a[tmp].G = Graphics.FromImage(a[tmp].bm);
            a[tmp].G.Clear(Color.White);
            a[tmp].pictureBox.Invalidate();
            a[tmp].sizeBitmap = new Size(a[tmp].pictureBox.Width, a[tmp].pictureBox.Height);
            a[tmp].listBitmap.Add(new Bitmap(a[tmp].pictureBox.Image));
            this.SizeChanged += (sender, e) =>
            {
                int i = tcMain.SelectedIndex;
                if (i >= 0)
                {
                    a[i].backGround.Dock = DockStyle.Right;
                    a[i].backGround.Width = this.Width - 270;
                    a[i].backGround.BackColor = Color.FromArgb(243, 243, 243);
                    a[i].pictureBox.Location = new Point((a[i].backGround.Width - a[i].pictureBox.Width) / 2, Math.Abs(this.Height - a[i].pictureBox.Height) / 2);
                }
            };

            a[tmp].backGround.Controls.Add(a[tmp].pictureBox);
            a[tmp].pictureBox.Location = new Point((a[tmp].backGround.Width - a[tmp].pictureBox.Width) / 2, Math.Abs(this.Height - a[tmp].pictureBox.Height) / 2);
            



            a[tmp].bt.Click += (s, args) =>
            {
                resizeForm ResizeForm = new resizeForm();
                if (a[tmp].isClear)
                {
                    ResizeForm.ShowDialog();
                    int width = ResizeForm.width;
                    int height = ResizeForm.height;
                    if (ResizeForm.index == 1)
                    {
                        Image originalImage = a[tmp].pictureBox.Image;
                        Bitmap resizedImage;
                        Size sz=new Size(width, height);
                        if (width >= 2000 && height >= 2000)
                            sz = new Size(2000, 2000);
                        resizedImage = new Bitmap(originalImage, sz);
                        a[tmp].bm = resizedImage;
                        a[tmp].listBitmap.Add(a[tmp].bm);
                        a[tmp].pictureBox.Size = new Size(width, height);
                        a[tmp].pictureBox.Image = a[tmp].bm;
                        a[tmp].G = Graphics.FromImage(a[tmp].bm);
                        a[tmp].pictureBox.Location = new Point((a[tmp].backGround.Width - a[tmp].pictureBox.Width) / 2, Math.Abs(this.Height - a[tmp].pictureBox.Height) / 2);
                        a[tmp].sizeBitmap = new Size(width, height);
                    }
                }
            };

            // khởi tạo text cho picture box

            a[tmp].text.ForeColor = Color.Black;
            a[tmp].text.StateActive.Back.Color1 = Color.White;
            a[tmp].text.StateActive.Border.Width = 0;
            a[tmp].text.Hide();
            a[tmp].pictureBox.Controls.Add(a[tmp].text);
           
            tcMain.SelectedPage.Controls.Add(a[tmp].backGround);
        }

       
    }
}

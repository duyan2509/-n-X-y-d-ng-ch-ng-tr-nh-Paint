using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
//py: first point
//cX: xFirst
//cY: yFirst
//--> py
//x: xMove
//y: yMove
//sX: xMove-xFirst
//sY = yMove - yFirst
namespace UI
{

    public partial class Form1 : Form
    {

        private Rectangle normalBounds;
        private List<DrawObject> a=new List<DrawObject>();// mỗi  tab 1 phần tử

        public Form1()
        {
            InitializeComponent();
            normalBounds = this.Bounds;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, normalBounds.Width, normalBounds.Height, 20, 20));
            initialPanel();
            initialPictureBox();
            initDrawObject();
        }

        //delete border
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //radius
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
        );
        private void pnTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btMaxi_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Screen primaryScreen = Screen.PrimaryScreen;
                int screenWidth = primaryScreen.Bounds.Width;
                int screenHeight = primaryScreen.Bounds.Height;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, screenWidth, screenHeight, 20, 20));
                WindowState = FormWindowState.Maximized;
                //btMaxi.Image = Resource.NormalScreen;
            }
            else
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, normalBounds.Width, normalBounds.Height, 20, 20));
                WindowState = FormWindowState.Normal;
                //btMax.Image = Resource.NormalScreen;  
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            
            KryptonPage kryptonPage = new KryptonPage();
            kryptonPage.Text = (tcMain.Pages.Count + 1).ToString();
            ButtonSpecAny buttonX = new ButtonSpecAny();
            buttonX.Type = PaletteButtonSpecStyle.Close;
            buttonX.UniqueName = "btClose" + kryptonPage.Text;


            buttonX.Click += (s, args) =>
            {

                if (s is ButtonSpecAny closeButton)
                {
                    KryptonPage pageToRemove = tcMain.Pages.FirstOrDefault(page => page.ButtonSpecs.Contains(closeButton));
                    if (pageToRemove != null)
                    {
                        tcMain.Pages.Remove(pageToRemove);
                    }
                }
            };

            kryptonPage.ButtonSpecs.Add(buttonX);

            tcMain.Pages.Add(kryptonPage);
            tcMain.SelectedPage = kryptonPage;
            initDrawObject();
            initialPanel();
            initialPictureBox();
        }


        private void btClose1_Click(object sender, EventArgs e)
        {
            if (sender is ButtonSpecAny closeButton)
            {
                KryptonPage pageToRemove = tcMain.Pages.FirstOrDefault(page => page.ButtonSpecs.Contains(closeButton));
                if (pageToRemove != null)
                {
                    tcMain.Pages.Remove(pageToRemove);
                }
            }
        }

        private void menuStrip1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void initDrawObject()
        {
            DrawObject tmp = new DrawObject();
            tmp.Color = Color.Black;
            tmp.Pen = new Pen(tmp.Color);
            tmp.DoDam = 10;
            tmp.py=new Point(0,0);
            tmp.px=new Point(0,0);
            tmp.Paint = false;
            tmp.Fill = false;
            tmp.brush = new SolidBrush(tmp.Color);
            tmp.index = 0;

            a.Add(tmp);
        }
        private void initialPanel()
        {
            Panel newPanel = new Panel();
            newPanel.Dock = DockStyle.Left;
            newPanel.Size = new Size(227,newPanel.Height);
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
            triangleButton.Click += handleClickCircleButton;
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
            right_triangleButton.Click += handleClickCircleButton;
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
            squareButton.Click += handleClickCircleButton;
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
            hexagonButton.Click += handleClickCircleButton;
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
            arrowButton.Click += handleClickCircleButton;
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
            starButton.Click += handleClickCircleButton;
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
            ellipseButton.Click += handleClickCircleButton;
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
            greenButton.FillColor = Color.FromArgb(97,197,84);
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

            newPanel.Controls.Add(toolPanel);
            newPanel.Controls.Add(colorPanel);
            newPanel.Controls.Add(shapePanel);
            tcMain.SelectedPage.Controls.Add(newPanel);

        }
        private void initialPictureBox()
        {
            Guna2PictureBox pictureBox=new Guna2PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.FillColor = Color.Red;

            pictureBox.MouseDown += handleMouseDown;
            pictureBox.MouseMove += handleMouseMove;
            pictureBox.MouseUp += handleMouseUp;
            pictureBox.MouseClick += handleMouseClick;//fill
            pictureBox.Paint += handlePaint;
            tcMain.SelectedPage.Controls.Add(pictureBox);

        }
        private void handleMouseClick(object sender, MouseEventArgs e)
        {

        }
        private void handlePaint(object sender, EventArgs e)
        {

        }
        private void handleMouseUp(object sender, MouseEventArgs e)
        {

        }
        private void handleMouseMove(object sender, MouseEventArgs e)
        {

        }
        private void handleMouseDown(object sender, MouseEventArgs e)
        {
            int tmp=tcMain.SelectedIndex;
            if(tmp<a.Count)
            {
                a[tmp].Paint = true;
                a[tmp].py = e.Location;
                a[tmp].cX = e.X;
                a[tmp].cY = e.Y;
            }
        }
        private void handleClickPenButton(object sender, EventArgs e)
        {

        }
        private void handleClickEraseButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
               
            }
        }
        private void handleClickFillButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {

            }
        }
        private void handleClickTextButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {

            }
        }
        private void handleClickBrushButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {

            }
        }
        private void handleClickRectangleButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {

            }
        }
        private void handleClickCircleButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {

            }
        }

        class DrawObject
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
            public int x, y, cX, cY, sX, sY;
        }
    }
}

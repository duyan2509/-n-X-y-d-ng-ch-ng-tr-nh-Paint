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
namespace UI
{   
    
    public partial class Form1 : Form
    {
      
        private Rectangle normalBounds;
        public Form1()
        {
            InitializeComponent();
            normalBounds = this.Bounds;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, normalBounds.Width, normalBounds.Height, 20, 20));
            initialPanel();

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
            initialPanel();
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
        private void initialPanel()
        {
            Panel newPanel = new Panel();
            newPanel.Dock = DockStyle.Left;
            newPanel.Size = new Size(210,newPanel.Height);
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
            shapePanel.Size = new Size(140, 180);
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
            blackButton.Click += handleClickCircleButton;
            blackButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(blackButton);

            Guna2Button greenButton = new Guna2Button();
            greenButton.Size = new Size(45, 45);
            greenButton.Location = new Point(5, 55);
            greenButton.FillColor = Color.FromArgb(97,197,84);
            greenButton.BorderRadius = 20;
            greenButton.ImageSize = new Size(20, 20);
            greenButton.Animated = true;
            greenButton.Click += handleClickCircleButton;
            greenButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(greenButton);

            Guna2Button redButton = new Guna2Button();
            redButton.Size = new Size(45, 45);
            redButton.Location = new Point(5, 110);
            redButton.FillColor = Color.FromArgb(237, 105, 94);
            redButton.BorderRadius = 20;
            redButton.ImageSize = new Size(20, 20);
            redButton.Animated = true;
            redButton.Click += handleClickCircleButton;
            redButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(redButton);

            Guna2Button yellowButton = new Guna2Button();
            yellowButton.Size = new Size(45, 45);
            yellowButton.Location = new Point(5, 165);
            yellowButton.FillColor = Color.FromArgb(244, 191, 79);
            yellowButton.BorderRadius = 20;
            yellowButton.ImageSize = new Size(20, 20);
            yellowButton.Animated = true;
            yellowButton.Click += handleClickCircleButton;
            yellowButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(yellowButton);

            Guna2Button blueButton = new Guna2Button();
            blueButton.Size = new Size(45, 45);
            blueButton.Location = new Point(5, 220);
            blueButton.FillColor = Color.FromArgb(77, 139, 183);
            blueButton.BorderRadius = 20;
            blueButton.ImageSize = new Size(20, 20);
            blueButton.Animated = true;
            blueButton.Click += handleClickCircleButton;
            blueButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(blueButton);

            Guna2Button pickColorButton = new Guna2Button();
            pickColorButton.Size = new Size(45, 45);
            pickColorButton.Location = new Point(5, 275);
            pickColorButton.FillColor = Color.FromArgb(203, 213, 224);
            pickColorButton.BorderRadius = 20;
            pickColorButton.ImageSize = new Size(15, 15);
            pickColorButton.Animated = true;
            pickColorButton.Click += handleClickCircleButton;
            pickColorButton.Image = Properties.Resources.icons8_plus_48;

            pickColorButton.Cursor = Cursors.Hand;
            colorPanel.Controls.Add(pickColorButton);

            newPanel.Controls.Add(toolPanel);
            newPanel.Controls.Add(colorPanel);
            newPanel.Controls.Add(shapePanel);
            tcMain.SelectedPage.Controls.Add(newPanel);

        }
        private void handleClickPenButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {   
                
            }
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
    }
}

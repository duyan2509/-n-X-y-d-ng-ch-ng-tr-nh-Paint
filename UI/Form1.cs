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
using System.Reflection;
using System.Drawing.Text;
using static UI.DrawObject;
using System.IO;
using System.Drawing.Imaging;
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
        private List<DrawObject> a = new List<DrawObject>();// mỗi  tab 1 phần tử
        private Pen resizePen;
        public Form1()
        {
            InitializeComponent();
            normalBounds = this.Bounds;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, normalBounds.Width, normalBounds.Height, 20, 20));
            this.StartPosition = FormStartPosition.CenterScreen;
            resizePen = new Pen(Color.Black,1f);
            resizePen.DashPattern = new float[] {7,2 };
            btSuccess.Visible = false;
            btSuccess.BackColor = Color.FromArgb(0, 120, 215);
            initDrawObject();
            initialPictureBox();
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
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, screenWidth, screenHeight, 0, 0));
                WindowState = FormWindowState.Maximized;
                btMaxi.Image = Properties.Resources.icons8_minimize_50__1_;
            }
            else
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, normalBounds.Width, normalBounds.Height, 20, 20));
                WindowState = FormWindowState.Normal;
                btMaxi.Image = Properties.Resources.icons8_toggle_full_screen_50;
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

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int tmp = tcMain.SelectedIndex;
            if (a[tmp].isResize)
            {
                VeChinhThuc();
                a[tmp].listBitmap[a[tmp].listBitmap.Count - 1] = new Bitmap(a[tmp].pictureBox.Image);
            }
            if (a[tmp].iBitmap > 0)
                a[tmp].iBitmap--;
            a[tmp].bm = a[tmp].listBitmap[a[tmp].iBitmap];
            a[tmp].pictureBox.Image = a[tmp].bm;
            a[tmp].G = Graphics.FromImage(a[tmp].bm);
            a[tmp].pictureBox.Refresh();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            a[tmp].iBitmap++;
            if (a[tmp].iBitmap < a[tmp].listBitmap.Count)
            {
                a[tmp].bm = a[tmp].listBitmap[a[tmp].iBitmap];
                a[tmp].pictureBox.Image = a[tmp].bm;
                a[tmp].G = Graphics.FromImage(a[tmp].bm);
                a[tmp].pictureBox.Refresh();
            }
            else
                a[tmp].iBitmap = a[tmp].listBitmap.Count - 1;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (a[tmp].resizeIndex == 17)
                btSuccess.Visible = true;
            var action = new Action(() => {
                btSuccess.Visible = false;
            });

            SetTimeout(action, 100);
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            a[tmp].index = 4;
            a[tmp].Paint = true;
            a[tmp].pictureBox.Invalidate();

            //a[tmp].Paint = false;
            //a[tmp].resizeIndex = a[tmp].index;
            //a[tmp].isResize = true;
            //a[tmp].pictureBox.Invalidate();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (a[tmp].resizeIndex == 17)
            {
                a[tmp].resizeIndex = 0;
                a[tmp].index = 18;
                a[tmp].G.FillRectangle(Brushes.White, a[tmp].khung);
                a[tmp].pictureBox.Refresh();
                a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                a[tmp].index = 17;
                a[tmp].resizeIndex = 17;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            int tmp=tcMain.SelectedIndex;
            // Thiết lập các thuộc tính cho hộp thoại mở tệp
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            openFileDialog.Title = "Chọn một tệp hình ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load hình ảnh từ tệp đã chọn
                    string selectedFile = openFileDialog.FileName;
                    Image selectedImage = Image.FromFile(selectedFile);
                    Image image = selectedImage;
                    a[tmp].pictureBox.Size = new Size(selectedImage.Width, selectedImage.Height);
                    a[tmp].bm = new Bitmap(a[tmp].pictureBox.Width, a[tmp].pictureBox.Height);
                    // Hiển thị hình ảnh trong ứng dụng Paint của bạn (ví dụ PictureBox)
                    a[tmp].bm = (Bitmap)selectedImage;
                    a[tmp].pictureBox.Image = a[tmp].bm;
                    a[tmp].G = Graphics.FromImage(a[tmp].bm);
                    a[tmp].pictureBox.Refresh();
                    a[tmp].sizeBitmap = new Size(a[tmp].pictureBox.Width, a[tmp].pictureBox.Height);
                    a[tmp].listBitmap.Add(new Bitmap(a[tmp].pictureBox.Image));

                    Path.GetFileName(selectedFile);
                    a[tmp].fileName = Path.GetFileName(selectedFile);

                    fileName.Text= a[tmp].fileName;
                    a[tmp].filePath= selectedFile;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: Không thể mở tệp hình ảnh. Chi tiết lỗi: " + ex.Message);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (a[tmp].filePath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    a[tmp].filePath = saveFileDialog.FileName;
                    string filePath = saveFileDialog.FileName;
                    string extension = Path.GetExtension(filePath).ToLower();

                    ImageFormat imageFormat = ImageFormat.Png;
                    if (extension == ".jpg" || extension == ".jpeg")
                        imageFormat = ImageFormat.Jpeg;
                    else if (extension == ".bmp")
                        imageFormat = ImageFormat.Bmp;
                    else if (extension == ".gif")
                        imageFormat = ImageFormat.Gif;
                    a[tmp].pictureBox.Image.Save(a[tmp].filePath, imageFormat);
                }
            }
            else
            {
                try
                {
                    string filePath = a[tmp].filePath;
                    string extension = Path.GetExtension(filePath).ToLower();
                    ImageFormat imageFormat = ImageFormat.Png;

                    if (extension == ".jpg" || extension == ".jpeg")
                        imageFormat = ImageFormat.Jpeg;
                    else if (extension == ".bmp")
                        imageFormat = ImageFormat.Bmp;
                    else if (extension == ".gif")
                        imageFormat = ImageFormat.Gif;

                    a[tmp].pictureBox.Image.Save(filePath, imageFormat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu file: " + ex.Message);
                }
            }

        }

        private void tcMain_SelectedPageChanged(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if(tmp<a.Count)
                fileName.Text = a[tmp].fileName;
        }
    }
}

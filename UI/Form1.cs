using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
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
            int tmp = tcMain.SelectedIndex;
            if (tmp >= 0)
            {
                Close close = new Close();
                close.ShowDialog();
                if (close.CloseAll == 1)
                    CloseAllPages();
                else if (close.CloseAll == 0)
                    CloseCurrentPage();
            }
            else
                this.Close();
            
        }
        private void CloseAllPages()
        {
            for(int i=0;i<a.Count;i++)
                CloseCurrentPage();
        }

        private void CloseCurrentPage()
        {
            int tmp = tcMain.SelectedIndex;
            if (!a[tmp].isClear)
            {
                //save 
                Save sv = new Save(tcMain.SelectedIndex);
                sv.ShowDialog();
                if (sv.save == 1)
                    Save();
                else if (sv.save == -1)
                    return;
            }
            tcMain.Pages.RemoveAt(tmp);
            if (tmp == 0)            
                this.Close();
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
            AddTab();
        }
        private void AddTab()
        {
            KryptonPage kryptonPage = new KryptonPage();
            kryptonPage.Text = (tcMain.Pages.Count + 1).ToString();
            ButtonSpecAny buttonX = new ButtonSpecAny();
            buttonX.Type = PaletteButtonSpecStyle.Close;
            buttonX.UniqueName = "btClose" + kryptonPage.Text;


            buttonX.Click += (s, args) =>
            {
                int tmp = tcMain.SelectedIndex;
                if (s is ButtonSpecAny closeButton)
                {
                    KryptonPage pageToRemove = tcMain.Pages.FirstOrDefault(page => page.ButtonSpecs.Contains(closeButton));
                    if (pageToRemove != null)
                    {
                        if (!a[tmp].isClear)
                        {
                            Save sv = new Save(tmp);
                            sv.ShowDialog();
                            if (sv.save==1)
                                Save();
                            else if (sv.save == -1)
                                return;
                        }
                        tcMain.Pages.RemoveAt(tmp);
                        a.RemoveAt(tmp);
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
                int tmp = tcMain.SelectedIndex;
                if(tmp>=0  && tmp<a.Count)
                {
                    if (!a[tmp].isClear)
                    {
                        Save sv = new Save(tmp);
                        sv.ShowDialog();
                        if (sv.save==1)
                            Save();
                        else if (sv.save == -1)
                            return;
                    }
                    tcMain.Pages.RemoveAt(tmp);
                    a.RemoveAt(tmp);

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

            if (a[tmp].iBitmap == 0)
                a[tmp].isClear = true;

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
            {
                a[tmp].iBitmap = a[tmp].listBitmap.Count - 1;
                a[tmp].isClear = false;
            }
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
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            openFileDialog.Title = "Chọn một tệp hình ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFile = openFileDialog.FileName;
                    using(Bitmap bmb=new Bitmap(selectedFile))
                    {
                        MemoryStream m=new MemoryStream();
                        bmb.Save(m, ImageFormat.Bmp);
                        a[tmp].pictureBox.Size = new Size(bmb.Width, bmb.Height);
                        a[tmp].bm = new Bitmap(a[tmp].pictureBox.Width, a[tmp].pictureBox.Height);
                        a[tmp].bm = (Bitmap)Image.FromStream(m);
                        a[tmp].pictureBox.Image = a[tmp].bm;
                        a[tmp].G = Graphics.FromImage(a[tmp].bm);
                        a[tmp].pictureBox.Refresh();
                        a[tmp].sizeBitmap = new Size(a[tmp].pictureBox.Width, a[tmp].pictureBox.Height);
                        a[tmp].listBitmap.Add(new Bitmap(a[tmp].pictureBox.Image));

                        Path.GetFileName(selectedFile);
                        a[tmp].fileName = Path.GetFileName(selectedFile);

                        fileName.Text = a[tmp].fileName;
                        a[tmp].filePath = selectedFile;
                        m.Dispose();
                    }                
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: Không thể mở tệp hình ảnh. Chi tiết lỗi: " + ex.Message);
                }
            }
        }
        private void Save()
        {
            int tmp = tcMain.SelectedIndex;
            if (a[tmp].filePath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    a[tmp].filePath = saveFileDialog.FileName;
                    string extension = Path.GetExtension(a[tmp].filePath).ToLower();

                    ImageFormat imageFormat = ImageFormat.Png;
                    if (extension == ".jpg" || extension == ".jpeg")
                        imageFormat = ImageFormat.Jpeg;
                    else if (extension == ".bmp")
                        imageFormat = ImageFormat.Bmp;
                    else if (extension == ".gif")
                        imageFormat = ImageFormat.Gif;
                    Bitmap bm_sv = new Bitmap(a[tmp].pictureBox.Image, a[tmp].sizeBitmap);
                    bm_sv.Save(a[tmp].filePath, imageFormat);
                    bm_sv.Dispose();
                    a[tmp].isClear = true;
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


                    Bitmap bmb = (Bitmap)a[tmp].pictureBox.Image.Clone();
                    bmb.Save(filePath, imageFormat);
                    bmb = new Bitmap(bmb, a[tmp].sizeBitmap);
                    a[tmp].isClear = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu file: " + ex.Message);
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tcMain_SelectedPageChanged(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if(tmp>=0 && tmp<a.Count)
                fileName.Text = a[tmp].fileName;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
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
        private void handleClickZoomIn(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            int w = (int)(1.2 * a[tmp].pictureBox.Width);
            int h = (int)(1.2 * a[tmp].pictureBox.Height);
            if (w <2000 && h <2000)
            {
                a[tmp].pictureBox.Size = new Size(w, h);
                Image originalImage = a[tmp].pictureBox.Image;

                Bitmap newBitmap = new Bitmap(w, h);
                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(originalImage, 0, 0, w, h);
                }
                a[tmp].bm = newBitmap;
                a[tmp].pictureBox.Image = a[tmp].bm;
                a[tmp].G = Graphics.FromImage(a[tmp].bm);
                a[tmp].pictureBox.Refresh();
            }
        }
        private void handleClickZoomOut(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            int w = (int)(0.8 * a[tmp].pictureBox.Width);
            int h = (int)(0.8 * a[tmp].pictureBox.Height);
            if (w > 300 && h > 300)
            {
                a[tmp].pictureBox.Size = new Size(w, h);
                Image originalImage = a[tmp].pictureBox.Image;

                Bitmap newBitmap = new Bitmap(w, h);
                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(originalImage, 0, 0, w, h);
                }
                a[tmp].bm = newBitmap;
                a[tmp].pictureBox.Image = a[tmp].bm;
                a[tmp].G = Graphics.FromImage(a[tmp].bm);
                a[tmp].pictureBox.Refresh();
            }
        }
        private void handleResetZoom(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            int w = a[tmp].sizeBitmap.Width;
            int h = a[tmp].sizeBitmap.Height;
            a[tmp].pictureBox.Size = new Size(w, h);
            Image originalImage = a[tmp].pictureBox.Image;

            Bitmap newBitmap = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, w, h);
            }
            a[tmp].bm = newBitmap;
            a[tmp].pictureBox.Image = a[tmp].bm;
            a[tmp].G = Graphics.FromImage(a[tmp].bm);
            a[tmp].pictureBox.Refresh();
        }
        private void SetTimeout(Action action, int timeout)
        {
            var timer = new Timer();
            timer.Interval = timeout;
            timer.Tick += (s, e) =>
            {
                action();
                timer.Stop();
            };
            timer.Start();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab();
        }
    }
}

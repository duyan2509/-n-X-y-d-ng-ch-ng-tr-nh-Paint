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
using Guna.UI2.WinForms;

namespace UI
{

    public partial class FormMain : Form
    {

        private Rectangle normalBounds;
        private List<DrawObject> a = new List<DrawObject>();// mỗi  tab 1 phần tử
        private Guna2Button selectButton;
        public Pen resizePen { get; set; }
        
        public FormMain()
        {
            InitializeComponent();
            normalBounds = this.Bounds;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, normalBounds.Width, normalBounds.Height, 20, 20));
            this.StartPosition = FormStartPosition.CenterScreen;
            resizePen = new Pen(Color.Blue,1f);
            resizePen.DashPattern = new float[] {7,2 };
            btSuccess.Visible = false;
            btSuccess.BackColor = Color.FromArgb(0, 120, 215);
            initDrawObject();
            initialPictureBox();
            initialPanel();
            tcMain.StateNormal.Back.Color1= Color.FromArgb(0, 120, 215,255);
            tcMain.StateNormal.Tab.Back.Color1= Color.FromArgb(0, 120, 215, 255);
            tcMain.StateNormal.Tab.Border.Color1= Color.FromArgb(0, 120, 215, 255);
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
            guna2ComboBox2.SelectedIndexChanged += guna2ComboBox2_SelectedIndexChanged;
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
                int tmp;
                if (s is ButtonSpecAny closeButton)
                {
                    KryptonPage pageToRemove = tcMain.Pages.FirstOrDefault(page => page.ButtonSpecs.Contains(closeButton));
                    tmp=tcMain.Pages.IndexOf(pageToRemove);
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
                int tmp;
                KryptonPage pageToRemove = tcMain.Pages.FirstOrDefault(page => page.ButtonSpecs.Contains(closeButton));
                tmp = tcMain.Pages.IndexOf(pageToRemove);
                if (pageToRemove != null)
                {
                    if (!a[tmp].isClear)
                    {
                        Save sv = new Save(tmp);
                        sv.ShowDialog();
                        if (sv.save == 1)
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
            if (a[tmp].currResize == null && a[tmp].index!=1 && a[tmp].index!=15)
                return;
            if (a[tmp].isResize)
            {
                a[tmp].currResize.VeChinhThuc(a[tmp]);
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
            Image clipboardImage = Clipboard.GetImage();
            if (clipboardImage == null) return;

            foreach (Guna2Button button in a[tmp].buttons)
            {
                button.BorderThickness = 0;
                button.Refresh();
            }
            selectButton.BorderThickness = 2;
            selectButton.Refresh();

            a[tmp].listBitmap.Add(new Bitmap(a[tmp].pictureBox.Image));
            a[tmp].iBitmap++;
            a[tmp].index = 4;
            a[tmp].isSelect = true;
            a[tmp].currShape = new Paste();
            a[tmp].currResize = new Paste();
            a[tmp].Paint = true;
            a[tmp].pictureBox.Refresh();
            a[tmp].Paint = false;
            a[tmp].isResize = true;
            a[tmp].pictureBox.Refresh();
            a[tmp].listBitmap[a[tmp].listBitmap.Count - 1] = new Bitmap(a[tmp].pictureBox.Image);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            if (a[tmp].resizeIndex == 17)
            {
                a[tmp].resizeIndex = 0;
                a[tmp].index = 18;
                a[tmp].G.FillRectangle(Brushes.White, a[tmp].khung);
                a[tmp].khung = new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0);
                a[tmp].pictureBox.Refresh();
                a[tmp].index = 17;
                a[tmp].resizeIndex = 17;
                a[tmp].isResize = false;
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
                        a[tmp].khung=new Rectangle(a[tmp].pictureBox.Top,0,0,0);
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
            a[tmp].isSelect = false;
            int w = (int)(1.2 * a[tmp].pictureBox.Width);
            int h = (int)(1.2 * a[tmp].pictureBox.Height);
            a[tmp].Pen.Width = (float)(a[tmp].Pen.Width * 1.2);
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
            a[tmp].isSelect = false;
            int w = (int)(0.8 * a[tmp].pictureBox.Width);
            int h = (int)(0.8 * a[tmp].pictureBox.Height);
            a[tmp].Pen.Width= (float)(a[tmp].Pen.Width* 0.8);
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
                if (!a[tmp].khung.Equals(new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0)))
                    a[tmp].pictureBox.Refresh();
            }
        }
        private void handleResetZoom(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            a[tmp].isSelect = false;
            int w = a[tmp].sizeBitmap.Width;
            int h = a[tmp].sizeBitmap.Height;
            a[tmp].pictureBox.Size = new Size(w, h);
            Image originalImage = a[tmp].pictureBox.Image;
            a[tmp].Pen.Width = a[tmp].oPen.Width;
            Bitmap newBitmap = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, w, h);
            }
            a[tmp].bm = newBitmap;
            a[tmp].pictureBox.Image = a[tmp].bm;
            a[tmp].G = Graphics.FromImage(a[tmp].bm);
            if (!a[tmp].khung.Equals(new Rectangle(a[tmp].pictureBox.Top, 0, 0, 0)))
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

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgPrint.ShowDialog();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            // Use the stored font size
            int size = Convert.ToInt32(guna2ComboBox2.Text);
            // Set the font of textBoxReference using the stored font name and size
            a[tmp].text.Font = new Font(guna2ComboBox1.Text, size, FontStyle.Regular);
            a[tmp].text.SelectionFont = new Font(guna2ComboBox1.Text, size, FontStyle.Regular);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            string selectedFontName = guna2ComboBox1.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedFontName))
            {
                // Perform actions with the selected font name
                Font selectedFont = new Font(selectedFontName, Convert.ToInt32(guna2ComboBox2.Text), FontStyle.Regular);
                // Set the font of textBoxReference
                a[tmp].text.Font = selectedFont;
                a[tmp].text.SelectionFont = selectedFont;
                
            }
        }
    }
}

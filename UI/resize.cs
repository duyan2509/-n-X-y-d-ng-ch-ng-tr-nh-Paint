using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class resizeForm : Form
    {
        public int index { get; set; }
        public int width { get; private set; }
        public int height { get; private set; }
        public resizeForm()
        {
            InitializeComponent();
            width = 600;
            height = 400;
        }
       

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            index = 1;
            width = int.Parse(txt_Width.Text);
            height = int.Parse(txt_Height.Text);
            txt_Width.Text = width.ToString();
            txt_Height.Text = height.ToString();
            this.Close();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            index = 0;
            this.Close();
        }
    }
}

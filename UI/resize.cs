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
    public partial class resize : Form
    {
        public int index { get; set; }
        public int width { get; private set; }
        public int height { get; private set; }
        public resize()
        {
            InitializeComponent();
        }
       
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            index = 1;
            width = int.Parse(txt_Width.Text);
            height = int.Parse(txt_Height.Text);
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            index = 0;
            this.Close();
        }
    }
}

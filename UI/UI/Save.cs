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
    public partial class Save : Form
    {
        public int save { get; set; }
        public Save(int stt)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text+= (stt+1).ToString()+" ?";
            save = -1;
        }

        private void btYes_Click(object sender, EventArgs e)
        {
            save= 1;
            this.Close();
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            save = 0;
            this.Close();
        }

        private void Save_Load(object sender, EventArgs e)
        {

        }
    }
}

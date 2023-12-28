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
        public bool save { get; set; }
        public Save()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btYes_Click(object sender, EventArgs e)
        {
            save= true;
            this.Close();
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            save = false;
            this.Close();
        }

        private void Save_Load(object sender, EventArgs e)
        {

        }
    }
}

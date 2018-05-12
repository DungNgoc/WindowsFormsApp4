using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Start : Form
    {
        Timer time;
        public Start()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            time = new Timer();
            time.Interval = 33;
        }

       

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fplay = new Form1();
            fplay.ShowDialog();
            this.Show();
        }
    }
}

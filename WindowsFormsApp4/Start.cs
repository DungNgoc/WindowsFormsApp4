using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

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
            bunifuImageButton2.Visible = false;

        }

       

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form1 fplay = new Form1();
            fplay.ShowDialog();
            this.Show();
            bunifuImageButton1.Visible = false;
            bunifuImageButton2.Visible = true;
           
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fplay = new Form1();
            fplay.ShowDialog();
            this.Show();
        }

        
private void Start_Load(object sender, EventArgs e)
        {
            SoundPlayer audio1 = new SoundPlayer(WindowsFormsApp4.Properties.Resources._2); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            audio1.PlayLooping();
        }
    }
}

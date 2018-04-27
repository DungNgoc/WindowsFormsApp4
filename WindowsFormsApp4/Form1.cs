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
    public partial class Form1 : Form
    {
        bool bTracking;
        private Graphics g;
        Bitmap character;
        Point pCharacter;

        Timer time;
        Timer time2;

        Point ptMouse = Point.Empty;

        List<Leaves> leave1 = new List<Leaves>();
        List<Leaves> leave2 = new List<Leaves>();
        public Form1()
        {
            InitializeComponent();            
            this.DoubleBuffered = true;
            character = new Bitmap(Properties.Resources.right);

            time = new Timer();           
            time.Interval = 20;
            time.Tick += Update;
            time.Start();

            time2 = new Timer();
            time2.Interval = 33;
            time2.Tick += Paint;
            time2.Start();
            Bitmap ileave1 = new Bitmap(Properties.Resources.fall_leaf_collection_268134801);
            Bitmap ileave2 = new Bitmap(Properties.Resources.snowflakes3);
            for (int i = 0; i < 5; i++)
            {
                leave1.Add(new Leaves(ileave1));
                leave2.Add(new Leaves(ileave2));
            }
        }
        float timeShow = 0f;
        List<Point> pShow = new List<Point>();
        void Paint(object sender, EventArgs e)
        {
           this.Refresh();
        }
        void Update(object sender, EventArgs e)
        {
            
            if(timeShow > 3f)
            {
                if(pShow.Count >0)
                    pShow.Clear();
                timeShow = 0f;
            }
            else
            {
                timeShow += 0.033f;
            }
            foreach (var leave in leave1)
            {
                leave.Update();
            }
            foreach (var leave in leave2)
            {
                leave.Update();
            }
        }



        
        /* private void Form1_KeyDown(object sender, KeyEventArgs e)
         {
             if(e.KeyCode == Keys.Right)
             {
                 pictureCharacter.Location = new Point((int)(pictureCharacter.Location.X + 10), pictureCharacter.Location.Y);
             }
             if(e.KeyCode == Keys.Left)
             {
                 pictureCharacter.Location = new Point((int)(pictureCharacter.Location.X - 10), pictureCharacter.Location.Y);
             }
         }*/

        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(character, pCharacter);
            if(pShow.Count > 0)
                g.DrawPolygon(new Pen(Color.White), pShow.ToArray());
            foreach (var leave in leave1)
            {
                leave.Draw(g);
            }
            foreach (var leave in leave2)
            {
                leave.Draw(g);
            }
            base.OnPaint(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            bTracking = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (bTracking)
            {
                Point ptnew = new Point(e.X, e.Y);
                pShow.Add(ptnew);
            }
            base.OnMouseMove(e);

        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            bTracking = false;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            pCharacter = new Point(e.X - 116, e.Y - 135);
        }
    }
}

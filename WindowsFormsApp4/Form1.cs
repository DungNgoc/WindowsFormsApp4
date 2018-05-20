using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        #region Properties
        Timer time;
        Timer time2;
        Controller controller;
        DateTime timeStart;
        float timeLive;
        bool isLive;
        #endregion

        #region Construtor
        public Form1()
        {
            InitializeComponent();
            this.Capture = true;
            
            this.DoubleBuffered = true;
            controller = new Controller(lbScores);

            isLive = true;

            timeStart = DateTime.Now;
            
            #region Cố định thời gian update
            time = new Timer();
            time.Interval = 20;
            time.Tick += Update;
            time.Start();
            #endregion

            #region Cố định time vẽ lại
            time2 = new Timer();
            time2.Interval = 33;
            time2.Tick += PaintRefesh;
            time2.Start();
            #endregion

        }
       

        #endregion

        #region Method
        private void Update(TimeSpan gameTime)//gameTime là hiệu giữa now và before
        {
            if (isLive)
            {

                timeLive += (float)gameTime.TotalSeconds;
                if (timeLive < 240.0f)
                {
                    controller.Update(gameTime);
                    tb_Time.Value = (int)((timeLive / 240) * 100);
                }
                else 
                {
                    isLive = false;
                    MessageBox.Show("Game Over!");
                    this.Close();
                }
            }
        }

        private void Draw(Graphics graphics)
        {
            controller.Draw(graphics);
        }
        #endregion

        #region Event
        private void Update(object sender, EventArgs e)
        {
            TimeSpan timeGame = DateTime.Now.Subtract(timeStart);
            timeStart = DateTime.Now;

            Update(timeGame);
        }
        private void PaintRefesh(object sender, EventArgs e)
        {
            this.Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
            base.OnPaint(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            else
            {

                controller.isClick = !controller.isCheck;
                if (controller.isClick == true)
                    controller.Character.MouseDown(null, e);

                controller.BTracking = true;
                Point ptnew = new Point(e.X, e.Y);
                controller.PShow = new Rectangle(ptnew, controller.PShow.Size); // vẽ đầu
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (controller.BTracking)
            {
                Size ptnew = new Size(e.X, e.Y);
                controller.PShow = new Rectangle(controller.PShow.Location, ptnew); //vẽ đuôi rectangle
            }
            base.OnMouseMove(e);

        }
        protected override void OnMouseUp(MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (controller.isClick == true)
                {
                    controller.isClick = false;
                    controller.isCheck = true;
                    controller.timeCheck = 0;
                    controller.Character.MouseUp(this, e);
                }
                else
                {
                    controller.isCheck = false;
                }
            }
            controller.BTracking = false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            controller.Character.Location = new Point(e.X - 84, e.Y - 84);
            controller.Character.MouseMove(sender, e);
        }



        #endregion

       

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            
            isLive =! isLive;
            bunifuImageButton1.Visible = true;
            bunifuImageButton2.Visible = false;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            isLive = !isLive;
            bunifuImageButton1.Visible = false;
            bunifuImageButton2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

     
    }
}

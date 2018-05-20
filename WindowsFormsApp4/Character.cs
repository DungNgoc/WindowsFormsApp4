using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public class Character
    {

        #region properties
        private Bitmap character;
        public MouseEventHandler MouseDown;
        public MouseEventHandler MouseUp;
        public MouseEventHandler MouseMove;

        private Point index;
        private Point pcharacterPre;

        private Rectangle desRectCharacter; // chỉnh độ to nhỏ của hình (hình to)
        private Rectangle sourceRectCharcter; // khung cắt
        private bool check;//kiem tra co ve character khong

        private Rectangle bounds;

        private bool isClick;
        private bool isDrag;

        private float timeChange;
        private float timeKeep;

        public bool IsContains { get; set; }
        public Rectangle Bounds { get => bounds; }// Lấy giá trị
        public Point Location { set => desRectCharacter.Location = value; }
        public bool Visiable { get =>check; set => check = value; }
        #endregion

        #region contructor
        public Character()
        {
            character=  new Bitmap(Properties.Resources.rightleft);

            check = true;

            pcharacterPre = desRectCharacter.Location;

            index = Point.Empty;

            isClick = false;
            #region Hình chính
            desRectCharacter = new Rectangle();

            desRectCharacter.Location = Point.Empty;//ko quan tâm

            desRectCharacter.Size = new Size(166, 166);
            #endregion

            #region Cut image
            sourceRectCharcter = new Rectangle();

            sourceRectCharcter.Location = index;

            sourceRectCharcter.Size = desRectCharacter.Size;
            #endregion

            this.MouseDown += FM_MouseDown;
            MouseUp += FM_MouseUp;
            MouseMove += FM_MouseMove;
        }




        #endregion

        #region Method
        public void Update(TimeSpan gameTime)
        {
            timeKeep +=(float) gameTime.TotalMilliseconds;
            if (isDrag == true && timeKeep > 3000.0f)
            {
                isDrag = false;
                timeKeep = 0.0f;
                IsContains = false;
            }

            if (!Visiable) return;
            ExSource(gameTime);
        }
        public void Draw(Graphics graphics)
        {

            if (!Visiable) return;
            graphics.DrawImage(character, desRectCharacter, sourceRectCharcter, GraphicsUnit.Pixel);

            if (isClick == true || isDrag == true)
            {
                if(IsContains)
                {
                    graphics.DrawRectangle(new Pen(Color.Red), bounds);
                    
                }
                else
                {
                    graphics.DrawRectangle(new Pen(Color.White), bounds);
                }
            }

        }
        #endregion

        #region Event
        private void FM_MouseDown(object sender, MouseEventArgs e)
        {
            if(isClick  == false && isDrag == false)
            {
                bounds = new Rectangle(e.Location, Size.Empty);
                isClick = true;
            }
        }
        private void FM_MouseMove(object sender, MouseEventArgs e)
        {
            if(isClick && isDrag == false)
            {
                int x = (e.X < bounds.X) ? bounds.X - e.X : -bounds.X + e.X;
                int y = (e.Y < bounds.Y) ? bounds.Y - e.Y : -bounds.Y + e.Y;
                //if(e.X > bounds.X && e.Y > bounds.Y)
                bounds.Size = new Size(x, y);
            }
        }
        private void FM_MouseUp(object sender, MouseEventArgs e)
        {
            if (isClick == true)
            {
                isDrag = true;
                isClick = false;
            }
        }
        #endregion

        #region Private Method
        private void ExSource(TimeSpan gameTime)
        {
            ExX(gameTime);
            ExY(gameTime);
            int x = index.X * sourceRectCharcter.Width;
            int y = index.Y * sourceRectCharcter.Height;

            sourceRectCharcter.Location = new Point(x, y);
        }
        private void ExX(TimeSpan gameTime)
        {
            timeChange += (float)gameTime.TotalMilliseconds;
            if (timeChange >= 50)
            {
                if (index.X >= 1)
                {
                    index.X = 0;
                }
                else index.X++;
            }


        }
        private void ExY(TimeSpan gameTime)
        {
            if (pcharacterPre.X > desRectCharacter.X)
                index.Y = 1;
            else index.Y = 0;
            pcharacterPre = desRectCharacter.Location;
        }
        #endregion

    }
}

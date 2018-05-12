using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class Character
    {
        #region properties
        private Bitmap character;
        

        private Point index;
        private Point pcharacterPre;

        private Rectangle desRectCharacter; // chỉnh độ to nhỏ của hình (hình to)
        private Rectangle sourceRectCharcter; // khung cắt
        private bool check;//kiem tra co ve character khong

        private float timeChange;
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

        }


        #endregion


        #region Method
        public void Update(TimeSpan gameTime)
        {
            //if (!Visiable) return;
            //ExSource(gameTime);
        }
        public void Draw(Graphics graphics)
        {
            if (!Visiable) return;
            graphics.DrawImage(character, desRectCharacter, sourceRectCharcter, GraphicsUnit.Pixel);
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

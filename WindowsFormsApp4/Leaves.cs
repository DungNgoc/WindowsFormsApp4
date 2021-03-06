﻿using System;
using System.Drawing;
namespace WindowsFormsApp4
{
    public class Leaves
    {
        #region Properties
        private static Random ran = new Random();
        private Bitmap _skin;
        private Point _position;
        private Rectangle _desRectangle;
        private int g = 1;

        public bool IsContains { get; set; }
        public Rectangle Bounds { get => _desRectangle; } //lấy khung vuông của lá
        public Bitmap Skin
        {
            get { return _skin; }
            set { _skin = value; }
        }
        public Rectangle DesRectangle
        {
            get { return _desRectangle; }
            set { _desRectangle = value; }
        }
        public object Tag { get; set; }
        public int Scores
        {
            get
            {
                return 5;
            }
        }
        #endregion


        #region Constructor
        public Leaves() { }
        //public Leaves(Bitmap texture, Point point)
        //{
        //    _position = point;
        //    _skin = texture;
        //    _desRectangle = new Rectangle(_position.X, 0, 20, 20);
        //}
        public Leaves(Bitmap texture)
        {
            _skin = texture;
            _position = new Point(ran.Next(972), 0);
            _desRectangle = new Rectangle(_position.X, 0, 20, 20);
        }
        #endregion

        #region Method
        public void Update(TimeSpan gametime)
        {
            int x = ran.Next(-1, 2);
            _desRectangle = new Rectangle(_desRectangle.X - x, _desRectangle.Y + g, 70, 70);
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(_skin, _desRectangle);
            //graphics.DrawRectangle(new Pen(Color.White), _desRectangle);// vẽ hình xung quanh lá
        }
        public void ChangeSnow()
        {
            switch (ran.Next(1,5))
            {
                case 1:
                    _skin = Properties.Resources.snowflakes3;
                    _desRectangle.Size = _skin.Size;
                    break;
                case 2:
                    _skin = Properties.Resources.snowflakes1;
                    _desRectangle.Size = _skin.Size;
                    break;
                case 3:
                    _skin = Properties.Resources.snowflakes2;
                    _desRectangle.Size = _skin.Size;
                    break;
                case 4:
                    _skin = Properties.Resources.snowflakes4;
                    _desRectangle.Size = _skin.Size;
                    break;

                default:
                    break;
            }
            this.Tag = 0;         
        }
        #endregion

    }
}

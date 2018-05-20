using System;
using System.Collections.Generic;
using System.Drawing;
namespace WindowsFormsApp4
{
    public class Controller
    {
      
        
        #region Properties
        private static readonly Random random = new Random();

        bool bTracking;

        bool check= false;
        public bool Check { get => check; set => check = value; }


        Character character;
        Bitmap skinLeaves1;
        Bitmap skinLeaves2;

        Point ptMouse = Point.Empty;

        List<Leaves> leaves = new List<Leaves>();

       Rectangle pShow = Rectangle.Empty;

        float timeShow = 0f;

        public Rectangle PShow { get => pShow; set => pShow = value; }
        public bool BTracking { get => bTracking; set => bTracking = value; }
        public Character Character { get => character; }
        #endregion

        #region Constructor
        public Controller()
        {
            bTracking = false;

            skinLeaves1 = new Bitmap(Properties.Resources.fall_leaf_collection_268134801);
            skinLeaves2 = new Bitmap(Properties.Resources.leaf22);

            character = new Character();

        }
        #endregion

        #region Method
        public void Update(TimeSpan gameTime)
        {
            character.Update(gameTime);
            ChangeColor();
            Leaves leaves = RandomCreate();// tạo lá ngẫu nhiên

            if (leaves != null) //tạo thành công
            {
                this.leaves.Add(leaves);
            }

            if (timeShow > 3.0f)
            {

                timeShow = 0f;
            }
            else
            {
                timeShow += 0.033f;
            }
            foreach (var leave in this.leaves)
            {
                leave.Update(gameTime);
            }
        }
        public void Draw(Graphics graphics)
        {
            DrawCharacter(graphics);
            //if (pShow.Count > 0)
            //g.DrawPolygon(new Pen(Color.White), pShow.ToArray());
            //  g.DrawLines(new Pen(Color.White), pShow.ToArray());
            foreach (var leave in leaves)
            {
                leave.Draw(graphics);
            }
        }

        #endregion

        #region Private Method
        private void DrawCharacter(Graphics graphics)
        {
            character.Draw(graphics);
        }

        private Leaves RandomCreate()
        {
            if (random.Next(0, 30) == 5)
            {
                if (random.Next(0, 50) < 25)
                    return CreateLeaves1();
                else
                    return CreateLeaves2();
            }
            else
                return null;
        }
        private Leaves CreateLeaves1()
        {
            return new Leaves(skinLeaves1) { Tag = 1 };
        }
        private Leaves CreateLeaves2()
        {
            return new Leaves(skinLeaves2) { Tag = 2 };
        }

        /// <summary>
        /// kiem tra vi tri leaves and bounds
        /// </summary>
        /// <returns></returns>
        public int Collision()
        {
            
            int isLeaves1 = 0;
            int isLeaves2 = 0;

            if (check == true)
            {
                for (int i = 0; i < leaves.Count; i++)
                {
                    //if ((isLeaves1 + isLeaves2) > 0)
                    //    return 0;

                    if ((int)leaves[i].Tag == 1 && character.Bounds.Contains(leaves[i].Bounds))//character.Bounds.Contains(leaves[i].Bounds) == true)
                    {
                        isLeaves1 = 1;
                    }
                    else
                    if ((int)leaves[i].Tag == 2 && character.Bounds.Contains(leaves[i].Bounds))//character.Bounds.Contains(leaves[i].Bounds) == true)
                    {
                        isLeaves2 = 2;
                    }

                }

                
            }
            return (isLeaves1 + isLeaves2);
        }

        //private bool Contains(Rectangle a, Rectangle b)
        //{
        //    Rectangle rectangle = Rectangle.Intersect(a, b);
        //    if (!rectangle.IsEmpty)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private void ChangeColor()
        {
            switch (Collision())
            {
                case 1:
                    Character.IsContains = true;
                    for (int i = 0; i < leaves.Count; i++)
                        if ((int)leaves[i].Tag == 1 && character.Bounds.Contains(leaves[i].Bounds))//character.Bounds.Contains(leaves[i].Bounds) == true)
                        {
                            leaves[i].IsContains = true;
                        }
                    break;
                case 2:
                    Character.IsContains = false;
                    for (int i = 0; i < leaves.Count; i++)
                        if ((int)leaves[i].Tag == 2 && character.Bounds.Contains(leaves[i].Bounds))//character.Bounds.Contains(leaves[i].Bounds) == true)
                        {
                            leaves[i].IsContains = true;
                        }
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

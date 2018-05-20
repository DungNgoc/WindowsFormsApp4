using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp4
{


    public class Controller
    {
        SoundPlayer audio = new SoundPlayer(WindowsFormsApp4.Properties.Resources.chimes); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name

        #region Properties
        private static readonly Random random = new Random();
        private Scores scores;
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
        public bool isClick;
        public bool isCheck;
        public float timeCheck;
        Label lbScores;
        #endregion

        #region Constructor
        public Controller(Label lbScores)
        {
            this.lbScores = lbScores;
            scores = new Scores();
            //lbScores.DataBindings.Add(new Binding("Text", scores, "ScoresShow"));
            bTracking = false;

            skinLeaves1 = new Bitmap(Properties.Resources.leaf22);
            skinLeaves2 = new Bitmap(Properties.Resources.fall_leaf_collection_26813480ưq1);

            character = new Character();

        }
        #endregion

        #region Method
        public void Update(TimeSpan gameTime)
        {
            character.Update(gameTime);

            if(timeCheck>=1500)
            {
                timeCheck = 0;
                isCheck = false;
                isClick = false;
            }
            if (isCheck)
            {
                timeCheck += (float)gameTime.TotalMilliseconds;
                if (!isClick && isCheck)
                    ChangeColor();
            }



            Leaves leaves = RandomCreate();// tạo lá ngẫu nhiên

            if (leaves != null) //tạo thành công
            {
                this.leaves.Add(leaves);
            }

            if (timeShow > 2.0f)
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
            if (isClick && !isCheck)
                return 0;
            int isLeaves1 = 0;
            int isLeaves2 = 0;

            for (int i = 0; i < leaves.Count; i++)
            {
                if ((isLeaves1 + isLeaves2) > 3)
                    return 0;

                if ((int)leaves[i].Tag == 1 && character.Bounds.Contains(leaves[i].Bounds))
                {
                    isLeaves1 = 1;
                }
                else
                if ((int)leaves[i].Tag == 2 && character.Bounds.Contains(leaves[i].Bounds))
                {
                    isLeaves2 = 2;
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
                            leaves[i].ChangeSnow();
                           
                              audio.Play();
                            
                            scores.ScoresPlay += leaves[i].Scores;
                        }

                    break;
                case 2:
                    Character.IsContains = true;
                    for (int i = 0; i < leaves.Count; i++)
                        if ((int)leaves[i].Tag == 2 && character.Bounds.Contains(leaves[i].Bounds))//character.Bounds.Contains(leaves[i].Bounds) == true)
                        {
                            leaves[i].IsContains = true;
                            leaves[i].ChangeSnow();
                            //SoundPlayer audio = new SoundPlayer(WindowsFormsApp4.Properties.Resources.chimes); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
                            audio.Play();
                           
                            scores.ScoresPlay += leaves[i].Scores;
                        }
                    break;
                default:
                    Character.IsContains = false;

                            
                    break;
            }
            lbScores.Text = scores.ScoresShow;
        }
        #endregion
    }
}

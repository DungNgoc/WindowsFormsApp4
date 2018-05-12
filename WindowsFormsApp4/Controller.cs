using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp4
{
    public class Controller
    {
        #region Properties
        private static readonly Random random = new Random();
        bool bTracking;

        Character character;
        Bitmap skinLeaves1;
        Bitmap skinLeaves2;

        Point ptMouse = Point.Empty;

        List<Leaves> leave1 = new List<Leaves>();
        List<Leaves> leave2 = new List<Leaves>();

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
            skinLeaves2 = new Bitmap(Properties.Resources.snowflakes3);

            character = new Character();

        }
        #endregion

        #region Method
        public void Update(TimeSpan gameTime)
        {
            character.Update(gameTime);

            Leaves leaves = RandomCreate();// tạo lá ngẫu nhiên

            if(leaves != null) //tạo thành công
            {
                leave1.Add(leaves);
            }

            if (timeShow > 3.0f)
            {

                timeShow = 0f;
            }
            else
            {
                timeShow += 0.033f;
            }
            foreach (var leave in leave1)
            {
                leave.Update(gameTime);
            }
            foreach (var leave in leave2)
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
            foreach (var leave in leave1)
            {
                leave.Draw(graphics);
            }
            foreach (var leave in leave2)
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
            return new Leaves(skinLeaves1);
        }
        private Leaves CreateLeaves2()
        {
            return new Leaves(skinLeaves2);
        }
        #endregion
    }
}

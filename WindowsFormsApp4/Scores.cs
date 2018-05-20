using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp4
{

    public class Scores
    {
        private int scoresPlay;

        public int ScoresPlay { get => scoresPlay; set => scoresPlay = value; }
        public string ScoresShow { get => scoresPlay.ToString(); }
        public Scores() { }
      }
}

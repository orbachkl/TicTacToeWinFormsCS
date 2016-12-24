using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWinFormsCS
{
    class Player
    {
        private int sign;
        private int points;

        public Player()
        {

            sign = 1;
            points = 0;

        }
        public Player(int sign)
        {

            this.sign = sign;
            points = 0;
        }

        public int GetPoints()
        {
            return points;
        }
        public int GetSign()
        {
            return sign;
        }
        public void setPoints(int points)
        {
            this.points = points;
        }
        public void SetSign(int sign)
        {
            this.sign = sign;
        }


    }
}

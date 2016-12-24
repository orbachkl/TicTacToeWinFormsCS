using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWinFormsCS
{
    class Board
    {
        private int rows;


        private int cols;
        private int[,] mat;// check
        private bool isFull;

        public Board()
        {


        }
        public Board(int rows, int cols)
        {
            this.cols = cols;
            this.rows = rows;

            mat = new int[rows,cols];//check
            for (int i = 0; i < rows; i++)
            {
                //mat[i] = new List<int>();//check
                for (int j = 0; j < cols; j++)
                {
                    mat[i,j] = 0;
                }
            }


        }

        public override string ToString()
        {
            string output = "";
            char cell = '|';
            char newLine = '\n';
            for (int i = 0; i < this.rows; i++)
            {
                output += cell;
                for (int j = 0; j < this.cols; j++)
                {
                    //can add condition for sign instead of numbers
                    int sign = this.mat[i,j];
                    output += sign;
                    output += cell;
                }
                output += newLine;

            }
            return output;
        }



        public int Rows
        {
            get { return rows; }

        }


        public int Cols
        {
            get { return cols; }

        }




        public int GetCell(int x, int y)
        {
            return mat[x,y];


        }
        public void SetCell(int x, int y, int sign)
        {
            mat[x,y] = sign;

        }

        public bool CheckFull()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (mat[i,j] == 0)
                        return false;
                }

            }
            return true;

        }



    }
}

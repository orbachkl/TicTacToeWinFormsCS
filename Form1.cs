using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeWinFormsCS
{
    public partial class frmBoard : Form
    {
        //temporary data members
        Game g;
        string message;
        int current_player = 1;
        bool winFlag = false;
        bool fullBoardFlag = false;
        bool insertSucceed = false;
        const string SIGN1 = "X";
        const string SIGN2 = "O";
        int x = -1, y = -1;
        string btnName;
        int btnNum;

        public frmBoard()
        {
            InitializeComponent();
            ResetForm();

        }

       
        public void startGame()
        {
            Game g = new Game();
            // create empty board on the form
            //cout<<*g.GetBoard()<<endl;   

            bool winFlag;
            bool fullBoardFlag;
            bool insertSucceed;
            int choice = -1;
            int x = -1, y = -1;
            Player playerNum = g.GetCurrentPlayer();

            do
            {
                playerNum = g.GetCurrentPlayer();

                do
                {

                    // ask player for choose cell
                    //cout<<"player number "<<playerNum.GetSign() <<" choose an option according the numbers"<<endl;

                    //cin>>choice;
                    switch (choice)
                    {
                        case 1:
                            x = 0;
                            y = 0;

                            break;
                        case 2:
                            x = 0;
                            y = 1;
                            break;
                        case 3:
                            x = 0;
                            y = 2;
                            break;
                        case 4:
                            x = 1;
                            y = 0;
                            break;
                        case 5:
                            x = 1;
                            y = 1;
                            break;
                        case 6:
                            x = 1;
                            y = 2;
                            break;
                        case 7:
                            x = 2;
                            y = 0;
                            break;
                        case 8:
                            x = 2;
                            y = 1;
                            break;
                        case 9:
                            x = 2;
                            y = 2;
                            break;
                        default:
                            break;
                    }


                    insertSucceed = g.InsertToBoard(x, y);
                } while (!insertSucceed);

                //print current board
                //cout<<*g.GetBoard()<<endl;
                winFlag = g.CheckWin();
                fullBoardFlag = g.GetBoard().CheckFull();
                g.SwitchTurn();

            } while (!winFlag && !fullBoardFlag);

            //the end of the game output        
            //cout<< "the end of the game!"<<endl;
            //cout<< "the final board is:"<<endl;
            //cout<<*g.GetBoard()<<endl;
            if (winFlag)
            {

                //print the win player
                //cout<<"the winner is player number "<<playerNum.GetSign()<<endl;

            }
            else if (fullBoardFlag)
            {
                //print tie
                //cout<<"tie!!"<<endl;

            }






        }

        private void button_Click(object sender, EventArgs e)
        {
           
            Button btn = sender as Button;
            btnName = btn.Name;

            //gets the button number into string
            string strNum = new String(btnName.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());

            //another way
            //string strNum2 = new String(btnName.Where(Char.IsDigit).ToArray());



            btnNum = int.Parse(strNum);

            switch (btnNum)
            {
                case 1:
                    x = 0;
                    y = 0;

                    break;
                case 2:
                    x = 0;
                    y = 1;
                    break;
                case 3:
                    x = 0;
                    y = 2;
                    break;
                case 4:
                    x = 1;
                    y = 0;
                    break;
                case 5:
                    x = 1;
                    y = 1;
                    break;
                case 6:
                    x = 1;
                    y = 2;
                    break;
                case 7:
                    x = 2;
                    y = 0;
                    break;
                case 8:
                    x = 2;
                    y = 1;
                    break;
                case 9:
                    x = 2;
                    y = 2;
                    break;
                default:
                    break;
            }

            insertSucceed = g.InsertToBoard(x, y);

            CheckInsertionStatus(btn);


        }

        private void CheckInsertionStatus(Button btn)
        {
            int currPlayer = g.GetCurrentPlayer().GetSign();
            
            if (insertSucceed)
            {
               
                if (currPlayer == 1)
                    btn.Text = SIGN1;
                else
                    btn.Text = SIGN2;
             
                winFlag = g.CheckWin();
                if (winFlag)
                {
                    MessageBox.Show(string.Format("player {0} win!{1} click okay for start new game", g.GetCurrentPlayer().GetSign(), Environment.NewLine));
                    ResetForm();
                   
                }
                else
                {
                    fullBoardFlag = g.GetBoard().CheckFull();
                    if (fullBoardFlag)
                    {
                        MessageBox.Show("draw! {0}click okay for start new game", Environment.NewLine);
                        ResetForm();
                       
                    }
                    else
                    {
                        g.SwitchTurn();
                        this.lblMsg.Text = string.Format("player number {0} please choose cell", g.GetCurrentPlayer().GetSign());
                    }
                }
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

            this.lblMsg.Text = message;


        }


        private void ResetForm()
        {
            //DesignPart
            this.StartPosition = FormStartPosition.CenterScreen;
            foreach (var control in this.Controls)
            {
                var btn = control as Button;
                if (btn != null)
                {
                    btn.Text = "";
                    btn.BackColor = SystemColors.ControlDark;
                    btn.Font = new Font("Microsoft Sans Serif", 50F, FontStyle.Regular,GraphicsUnit.Point, ((byte)(177)));
                    btn.ForeColor = SystemColors.HotTrack;
                }
                
            }
            Label lbl = lblMsg;
            lbl.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(177)));
            lbl.ForeColor = SystemColors.HotTrack;
            
            
            //LogicPart
            current_player = 1;
            g = new Game();
            message = string.Format("lets start play! player number {0} please choose cell", current_player);
            this.lblMsg.Text = message;
            winFlag = false;
            fullBoardFlag = false;
            insertSucceed = false;


        }



    }
}

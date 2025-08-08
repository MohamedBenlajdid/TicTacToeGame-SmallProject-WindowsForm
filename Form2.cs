using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game_Project.Properties;

namespace Tic_Tac_Toe_Game_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1  , Player2 
        }
        enum enWinner
        {
            Player1 , Player2 , Draw , InProgress
        }
        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver ;
            public short GameCount ;
            
        }
        void EndGame()
        {
            lblTurn.Text = "Game Over";
            switch(GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player1";
                    break;
                case enWinner.Player2:
                    lblWinner.Text = "Player2";
                    break;
                default:
                    lblWinner.Text = "Draw";
                    break;
            }
            MessageBox.Show("Game Over","Game Over",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public bool CheckValues(Button btn1,Button btn2,Button btn3)
        {
            if(btn1.Tag.ToString() != "" && btn1.Tag.ToString() == btn2.Tag.ToString()
                && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;
                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
        }

        public void CheckWinner()
        {


            //checked rows
            //check Row1
            if (CheckValues(btn1, btn2, btn3))
                return;

            //check Row2
            if (CheckValues(btn4, btn5, btn6))
                return;

            //check Row3
            if (CheckValues(btn7, btn8, btn9))
                return;

            //checked cols
            //check col1
            if (CheckValues(btn1, btn4, btn7))
                return;

            //check col2
            if (CheckValues(btn2, btn5, btn8))
                return;

            //check col3
            if (CheckValues(btn3, btn6, btn9))
                return;

            //check Diagonal

            //check Diagonal1
            if (CheckValues(btn1, btn5, btn9))
                return;

            //check Diagonal2
            if (CheckValues(btn3, btn5, btn7))
                return;


        }
        public void ChangeImage(Button btn)
        {
            if(btn.Tag.ToString() == "?")
            {
                switch(PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.GameCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.GameCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                      
                }
               
            }

            else
            {
                MessageBox.Show("Wrong Choice","Wrong",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // At the end of ChangeImage method
            if (GameStatus.GameCount == 9 && !GameStatus.GameOver)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }

        }

        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;

        }
        private void RestartGame()
        {

            RestButton(btn1);
            RestButton(btn2);
            RestButton(btn3);
            RestButton(btn4);
            RestButton(btn5);
            RestButton(btn6);
            RestButton(btn7);
            RestButton(btn8);
            RestButton(btn9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.GameCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.InProgress;
            lblWinner.Text = "In Progress";

        }
        
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            ChangeImage(btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ChangeImage(btn2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ChangeImage(btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ChangeImage(btn4);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ChangeImage(btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            ChangeImage(btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            ChangeImage(btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            ChangeImage(btn9);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ChangeImage(btn5);
        }
    }
}

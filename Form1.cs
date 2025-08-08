using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsXTurn = true;
        private Button[,] board;
        private bool GameOver = false;
        int Player1Wins = 0, Player2Wins = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Button[3, 3]
            {
                {btn00,btn01,btn02 },
                {btn10,btn11,btn12 },
                {btn20,btn21,btn22 }
            };

            foreach(Button btn in board)
            {
                btn.Click += Button_Click;
            }
            button11_Click(sender, e);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (GameOver) return;
            Button Clickedbtn = (Button)sender;
            if (Clickedbtn.Text != "") return;
            Clickedbtn.Text = IsXTurn ? "X" : "O";
            Clickedbtn.Enabled = false;
            if(CheckWinner())
            {
                string WinnerText = (IsXTurn ? "X" : "O") + " Winner :-)";
                MessageBox.Show(WinnerText, "Congratulation", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GameOver = true;
                return;
            }
            if(IsBoardFull())
            {
                MessageBox.Show("Drawing Game :-)", "Drawing", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GameOver = true;
                return;
            }
            IsXTurn = !IsXTurn;

        }

        private void AddPlayerScore()
        {
            if (IsXTurn)
            {
                Player1Wins++;
                lblPlayer1Scoore.Text = Player1Wins.ToString();
            }
            else
            {
                Player2Wins++;
                lblPlayer2Scoore.Text = Player2Wins.ToString();
            }

        }

        private bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                //Rows
                if (board[i, 0].Text != "" && board[i, 0].Text == board[i, 1].Text &&
                    board[i, 1].Text == board[i, 2].Text)
                {
                    AddPlayerScore();
                    return true;
                }
                //Coloms
                if (board[0, i].Text != "" && board[0, i].Text == board[1, i].Text &&
                    board[1, i].Text == board[2, i].Text)
                {
                    AddPlayerScore();
                    return true;
                }

            }

                if (board[0, 0].Text != "" && board[0, 0].Text == board[1, 1].Text &&
                        board[1, 1].Text == board[2, 2].Text)
                {
                    AddPlayerScore();
                    return true;
                }
                if (board[0, 2].Text != "" && board[0, 2].Text == board[1, 1].Text &&
                        board[1, 1].Text == board[2, 0].Text)
                {
                    AddPlayerScore();
                    return true;
                }

                return false;
            
        }

        private bool IsBoardFull()
        {
            foreach(Button btn in board)
            {
                if (btn.Text == "") return false;
            }
            return true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Player1Wins = 0;
            Player2Wins = 0;
            lblPlayer1Scoore.Text = Player1Wins.ToString();
            lblPlayer2Scoore.Text = Player2Wins.ToString();
            button11_Click(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach(Button btn in board)
            {
                btn.Text = "";
                btn.Enabled = true;
            }
            GameOver = false;
            IsXTurn = true;
        }
    }
}

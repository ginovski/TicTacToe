using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turnX = true; //If it's true it's X turn, if it's false O turn
        int clickCounter = 0;
        bool isWinner = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutMenuClick(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Alexandar", "About");
        }

        private void exitMenuClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turnX)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turnX = !turnX;
            b.Enabled = false;
            clickCounter++;
            checkForWinner();
        }
        private void checkForWinner()
        {
            //horisontal check
            if (A1.Text == A2.Text && A2.Text == A3.Text && !A1.Enabled)
            {
                isWinner = true;
            }
            else if (B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled)
            {
                isWinner = true;
            }
            else if (C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled)
            {
                isWinner = true;
            }
            //vertical check
            else if (A1.Text == B1.Text && B1.Text == C1.Text && !A1.Enabled)
            {
                isWinner = true;
            }
            else if (A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled)
            {
                isWinner = true;
            }
            else if (A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled)
            {
                isWinner = true;
            }
            //diagonal check
            else if (A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled)
            {
                isWinner = true;
            }
            else if (A3.Text == B2.Text && B2.Text == C1.Text && !A3.Enabled)
            {
                isWinner = true;
            }
            winnerAlert();
        }

        private void winnerAlert()
        {
            if (isWinner && turnX)
            {
                disableButtons();
                MessageBox.Show("O wins!");
                
            }
            else if (isWinner && turnX == false)
            {
                disableButtons();
                MessageBox.Show("X wins!");
               
            }
            else if (isWinner == false && clickCounter == 9)
            {
                MessageBox.Show("Draw!");
            }
        }
        private void disableButtons()
        {
            try
            {
                foreach (Button c in Controls)
                {
                    c.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameClick(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = true;
                c.Text = "";
                clickCounter = 0;
                turnX = true;
                isWinner = false;
            }
        }
    }
}

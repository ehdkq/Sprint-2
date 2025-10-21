using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sprint_2
{
    public partial class Form1 : Form
    {
        private SOSGame game;
        private Button[,] gridButtons;

        public Form1()
        {
            InitializeComponent();
            game = new SOSGame();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            int boardSize = (int)numBoardSize.Value;

            var mode = simpleGameButton.Checked ? GameMode.Simple : GameMode.General;

            game.NewGame(boardSize);

            CreateBoardGrid(boardSize);

            UpdateTurnLabel();
        }
        
        private void CreateBoardGrid(int size)
        {
            pnlBoard.Controls.Clear();
            gridButtons = new Button[size, size];
            int buttonSize = pnlBoard.Width / size;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    var button = new Button
                    {
                        Width = buttonSize,
                        Height = buttonSize,
                        Left = col * buttonSize,
                        Top = row * buttonSize,
                        Tag = new Point(row, col)
                    };

                    button.Click += GridButton_Click;
                    pnlBoard.Controls.Add(button);
                    gridButtons[row, col] = button;
                }
            }
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Point position = (Point)clickedButton.Tag;

            Cell move; 

            if (game.CurrentTurn == Player.Blue)
            {
                move = blueSButton.Checked ? Cell.S : Cell.O;
            }
            else
            {
                move = redSButton.Checked ? Cell.S : Cell.O;
            }
            if (game.MakeMove(position.X, position.Y, move))
            {
                clickedButton.Text = move.ToString();
                clickedButton.Enabled = false;
                UpdateTurnLabel();
            }
        }

        private void UpdateTurnLabel()
        {
            lblTurn.Text = $"Current Turn: {game.CurrentTurn}";

            if (game.CurrentTurn == Player.Blue)
            {
                bluePlayer.Enabled = true ;
                redPlayer.Enabled = false;
            }
            else
            {
                bluePlayer.Enabled = false;
                redPlayer.Enabled = true ; 
            }
        }
        private void numBoardSize_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTurn_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void redOButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

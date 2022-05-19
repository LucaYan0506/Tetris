using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetriis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach(Control c in this.Controls)
            {
                c.KeyDown += this.keyDown;
                c.PreviewKeyDown += this.previewKeyDown;
            }
            scoreLbl.Text = score.ToString();
            speedLbl.Text = (1000 - speed).ToString();
            linesLbl.Text = lines.ToString();

        }

        public static PictureBox[,] table = new PictureBox[32,16];
        Random rnd = new Random();

        List<Image> images = new List<Image>
        {
            Properties.Resources.O_Tetromino1,
            Properties.Resources.I_Tetromino1,
            Properties.Resources.S_Tetromino1,
            Properties.Resources.Z_Tetromino1,
            Properties.Resources.L_Tetromino1,
            Properties.Resources.J_Tetromino1,
            Properties.Resources.T_Tetromino1,
        };
        Block block;
        int nextBlock;
        int delay = 1;
        int speed = 500;
        int score = 0;
        int lines = 0;
        bool gameStarted = false;

        public static bool outsideBounds(int i, int j)
        {
            return i < 0 | j < 0 | i >= table.GetLength(0)| j >= table.GetLength(1);
        }
        bool bLock_onRight()
        {
            foreach (PictureBox p in block.Items)
            {
                int i = p.Location.Y / 25;
                int j = p.Location.X / 25 + 1;
                if (outsideBounds(i, j))
                    return true;
                if (table[i,j] != null)
                    return true;
            }

            return false;
        }

        bool bLock_onLeft()
        {
            foreach (PictureBox p in block.Items)
            {
                int i = p.Location.Y / 25;
                int j = p.Location.X / 25 - 1;
                if (outsideBounds(i,j))
                    return true;
                if (table[i,j] != null)
                    return true;
            }

            return false;
        }
        bool bLock_onBottom()
        {
            foreach (PictureBox p in block.Items)
            {
                int i = p.Location.Y / 25 + 1;
                int j = p.Location.X / 25;
                if (outsideBounds(i,j))
                    return true;
                if (table[i,j] != null)
                    return true;
            }

            return false;
        }

        void checkLines()
        {
            List<int> completedLines = new List<int>();
           for (int i = table.GetLength(0) - 1; i >= 0; i--)
            {
                bool lineCompleted = true;
                for (int j = 0; j < table.GetLength(1); j++)
                    if (table[i,j] == null)
                    {
                        lineCompleted = false;
                        break;
                    }
                if (lineCompleted)
                {
                    completedLines.Add(i);
                    for (int j = 0; j < table.GetLength(1); j++)
                        blocksContainer.Controls.Remove(table[i, j]);
                }
            }
           //update lines and scores
            lines += completedLines.Count();
            linesLbl.Text = lines.ToString();
            score += completedLines.Count() * 100;
            scoreLbl.Text = score.ToString();


            PictureBox[,] temp = table;
            table = new PictureBox[32,16];
            int table_i = 31;
            for (int i = temp.GetLength(0) - 1; i >= 0 ; i--)
            {
                if (completedLines.Contains(i))
                    continue;
                    
                for (int j = 0; j < temp.GetLength(1); j++)
                    if (temp[i, j] != null)
                    {
                        table[table_i, j] = temp[i, j];
                        temp[i, j].Location = new Point(temp[i, j].Location.X, table_i * 25);
                    }
                table_i--;
            }
        }

        private void blockDown_Tick(object sender, EventArgs e)
        {
            if ((bLock_onBottom() | block.Location.Y + block.Size.Height == 800) & delay == 0)
            {
                //reset delay
                delay = 1;
                
                //forbit user to move the block now
                gameStarted = false;

                //set in the table that here there is a block
                foreach (PictureBox p in block.Items)
                {
                    int i = p.Location.Y / 25;
                    int j = p.Location.X / 25;

                    table[i,j] = p;
                }

                //check if there are any completed lines, if so remove it
                checkLines();

                //generate new block 
                block = new Block(blocksContainer, nextBlock);
                nextBlock = rnd.Next(7);
                next_blockImg.BackgroundImage = images[nextBlock];

                //allow user to move the block now
                gameStarted = true;

            }
            else if ((bLock_onBottom() | block.Location.Y + block.Size.Height == 800) & delay == 1)
                delay--;
            else
            {
                delay = 1;
                block.Location = new Point(block.Location.X, block.Location.Y + 25);
                if (speed > blockDown.Interval)
                {
                    score += 1;
                    scoreLbl.Text = score.ToString();
                    blockDown.Interval = speed;
                }
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            block = new Block(blocksContainer, rnd.Next(7));
            nextBlock = rnd.Next(7);
            next_blockImg.BackgroundImage = images[nextBlock];
            gameStarted = true;
            blockDown.Start();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (gameStarted)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        MessageBox.Show(block.Size.ToString());
                        break;
                    case Keys.D:
                    case Keys.Right:
                        if (!bLock_onRight())
                            block.Location = new Point(block.Location.X + 25, block.Location.Y);
                        break;

                    case Keys.A:
                    case Keys.Left:
                        if (!bLock_onLeft())
                            block.Location = new Point(block.Location.X - 25, block.Location.Y);
                        break;

                    case Keys.S:
                    case Keys.Down:
                        blockDown.Interval = speed / 50;
                        break;

                    case Keys.W:
                    case Keys.Up:
                        block.rotate();
                        break;

                    default:
                        break;
                }
            }
        }

        private void previewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            table = new PictureBox[32, 16];
            blocksContainer.Controls.Clear();
            playBtn.PerformClick();
        }
    }
}

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

            //create new block
            block = new Block(blocksContainer, rnd.Next(7));
            nextBlock = rnd.Next(7);

            //set next block to current one (only when we start)
            next_blockImg.BackgroundImage = images[block.Type];

            //hide block
            block.Visible = false;
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
            score += completedLines.Count() * (600 - speed);
            scoreLbl.Text = score.ToString();

            //check if need to increase speed 
            if (score >= 1000 && score < 2000)
                speed = Math.Min(400, speed);
            else if (score >= 2000 && score < 3000)
                speed = Math.Min(300, speed);
            else if (score >= 3000 && score < 4000)
                speed = Math.Min(200, speed);
            else if (score >= 4000 && score < 5000)
                speed = Math.Min(100, speed);
            else if (score >= 5000 && score < 6000)
                speed = Math.Min(90, speed);
            else if (score >= 6000 && score < 7000)
                speed = Math.Min(80, speed);
            else if (score >= 7000 && score < 8000)
                speed = Math.Min(70, speed);
            else if (score >= 8000 && score < 9000)
                speed = Math.Min(60, speed);
            else if (score >= 9000 && score < 11000)
                speed = Math.Min(50, speed);
            else if (score >= 10000 && score < 11000)
                speed = Math.Min(40, speed);
            else if (score >= 11000 && score < 12000)
                speed = Math.Min(30, speed);
            else if (score >= 12000 && score < 13000)
                speed = Math.Min(20, speed);
            else if (score >= 13000 && score < 14000)
                speed = Math.Min(10, speed);
            else if (score >= 14000 && score < 15000)
                speed = Math.Min(1, speed);
            speedLbl.Text = (1000 - speed).ToString();
            blockDown.Interval = speed;

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


        private void change_speedBtn_Click(object sender, EventArgs e)
        {
            if (speed - 100 <= 0)
            {
                speed -= 10;
                if (speed - 10 <= 0)
                    speed = 1;
            }
            else
                speed -= 100;
            speedLbl.Text = (1000 - this.speed).ToString();
            blockDown.Interval = this.speed;
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

                //lose condition
                if (bLock_onBottom())
                {
                    blockDown.Stop();
                    playBtn.Text = "Start";
                    gameStarted = false;
                    playBtn.Enabled = false;
                    timer1.Stop();
                    MessageBox.Show("You lost");
                }

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

                    //check if need to increase speed 
                    if (score >= 1000 && score < 2000)
                        speed = Math.Min(400, speed);
                    else if (score >= 2000 && score < 3000)
                        speed = Math.Min(300, speed);
                    else if (score >= 3000 && score < 4000)
                        speed = Math.Min(200, speed);
                    else if (score >= 4000 && score < 5000)
                        speed = Math.Min(100, speed);
                    else if (score >= 5000 && score < 6000)
                        speed = Math.Min(90, speed);
                    else if (score >= 6000 && score < 7000)
                        speed = Math.Min(80, speed);
                    else if (score >= 7000 && score < 8000)
                        speed = Math.Min(70, speed);
                    else if (score >= 8000 && score < 9000)
                        speed = Math.Min(60, speed);
                    else if (score >= 9000 && score < 11000)
                        speed = Math.Min(50, speed);
                    else if (score >= 10000 && score < 11000)
                        speed = Math.Min(40, speed);
                    else if (score >= 11000 && score < 12000)
                        speed = Math.Min(30, speed);
                    else if (score >= 12000 && score < 13000)
                        speed = Math.Min(20, speed);
                    else if (score >= 13000 && score < 14000)
                        speed = Math.Min(10, speed);
                    else if (score >= 14000 && score < 15000)
                        speed = Math.Min(1, speed);
                    speedLbl.Text = (1000 - speed).ToString();
                    blockDown.Interval = speed;
                }
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                if (!block.Visible)
                {
                    //show next block
                    next_blockImg.BackgroundImage = images[nextBlock];
                    //set current block visible
                    block.Visible = true;
                }

                blockDown.Start();
                timer1.Start();
                playBtn.Text = "Stop";
            }
            else
            {
                blockDown.Stop();
                timer1.Stop();
                playBtn.Text = "Start";
            }
            gameStarted = !gameStarted;
            blocksContainer.Focus();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (gameStarted)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        //forbit user to move the block now
                        gameStarted = false;

                        //move block down
                        while (!(bLock_onBottom() | block.Location.Y + block.Size.Height == 800))
                        {
                            block.Location = new Point(block.Location.X, block.Location.Y + 25);
                            score++;
                            scoreLbl.Text = score.ToString();
                        }

                        //set in the table that here there is a block
                        foreach (PictureBox p in block.Items)
                        {
                            int i = p.Location.Y / 25;
                            int j = p.Location.X / 25;

                            table[i, j] = p;
                        }

                        //check if there are any completed lines, if so remove it
                        checkLines();

                        //generate new block 
                        block = new Block(blocksContainer, nextBlock);
                        nextBlock = rnd.Next(7);
                        next_blockImg.BackgroundImage = images[nextBlock];

                        //allow user to move the block now
                        gameStarted = true;

                        //lose condition
                        if (bLock_onBottom())
                        {
                            blockDown.Stop();
                            timer1.Stop();
                            playBtn.Text = "Start";
                            gameStarted = false;
                            playBtn.Enabled = false;
                            MessageBox.Show("You lost");
                        }
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
            block = new Block(blocksContainer, rnd.Next(7));
            nextBlock = rnd.Next(7);
            next_blockImg.BackgroundImage = images[nextBlock];
            timeLbl.Text = "00 : 00 : 00";
            timer1.Start();
            blockDown.Start();
            if (!playBtn.Enabled)
                playBtn.Enabled = true;
            playBtn.Text = "Stop";
            gameStarted = true;
            score = 0;
            scoreLbl.Text = score.ToString();
            speed = 500;
            speedLbl.Text = speed.ToString();
            lines = 0;
            linesLbl.Text = lines.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int s = int.Parse(timeLbl.Text.Substring(10, 2)) + 1;
            int m = int.Parse(timeLbl.Text.Substring(5, 2));
            int h = int.Parse(timeLbl.Text.Substring(0, 2));

            if (s == 60)
            {
                s = 0;
                m++;
            }
            if (m == 60)
            {
                m = 0;
                h++;
            }

            timeLbl.Text = h.ToString("#0#") + " : " + m.ToString("#0#") + " : " + s.ToString("#0#");

        }
    }
}

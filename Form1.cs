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
        }

        bool[,] table = new bool[34, 18];

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
        bool gameStarted = false;

        bool bLock_onRight()
        {
            foreach (PictureBox p in block.items)
            {
                int i = p.Location.Y / 25;
                int j = p.Location.X / 25 + 1;
                if (table[i, j] == true)
                    return true;
            }

            return false;
        }

        bool bLock_onLeft()
        {
            foreach (PictureBox p in block.items)
            {
                int i = p.Location.Y / 25;
                int j = p.Location.X / 25 - 1;
                if (j < 0)
                    continue;
                if (table[i, j] == true)
                    return true;
            }

            return false;
        }
        bool bLock_onBottom()
        {
            foreach (PictureBox p in block.items)
            {
                int i = p.Location.Y / 25 + 1;
                int j = p.Location.X / 25;
                if (table[i, j] == true)
                    return true;
            }

            return false;
        }

        private void blockDown_Tick(object sender, EventArgs e)
        {
            block.Location = new Point(block.Location.X, block.Location.Y + 25);
            blockDown.Interval = 1000;

            if (bLock_onBottom())
            {
                foreach (PictureBox piece in block.items)
                {
                    table[piece.Location.Y / 25, piece.Location.X / 25] = true;
                }

                System.Threading.Thread.Sleep(2000);
                //generate new block
                block = new Block(blocksContainer, nextBlock);
                nextBlock = rnd.Next(7);
                next_blockImg.BackgroundImage = images[nextBlock];
                return;
            }
     

            if (block.Location.Y + block.Size.Height == 800)
            {
                textBox1.Text = "";
                foreach (PictureBox p in block.items)
                {
                    int i = p.Location.Y / 25;
                    int j = p.Location.X / 25;

                    table[i, j] = true;
                }

                System.Threading.Thread.Sleep(2000);
                //generate new block
                block = new Block(blocksContainer, nextBlock);
                nextBlock = rnd.Next(7);
                next_blockImg.BackgroundImage = images[nextBlock];
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
                        if (block.Location.X <= 375 - block.Size.Width && !bLock_onRight())
                            block.Location = new Point(block.Location.X + 25, block.Location.Y);
                        break;

                    case Keys.A:
                    case Keys.Left:
                        if (block.Location.X >= 25  && !bLock_onLeft())
                            block.Location = new Point(block.Location.X - 25, block.Location.Y);
                        break;

                    case Keys.S:
                    case Keys.Down:
                        blockDown.Interval = 100;
                        break;

                    case Keys.W:
                    case Keys.Up:
                        MessageBox.Show("Change direction");
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
    }
}

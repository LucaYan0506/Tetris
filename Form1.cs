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

        Block block;

        private void blockDown_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox p in block.items)
            {
                p.Location = new Point(p.Location.X, p.Location.Y + 50);
            }
            blockDown.Interval = 1000;
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            blockDown.Start();

        }

        private void keyDown(object sender, KeyEventArgs e)
        {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        MessageBox.Show(block.Size.ToString());
                        break;
                    case Keys.D:
                    case Keys.Right:
                        if (block.Location.X <= 350 - block.Size.Width)
                            block.Location = new Point(block.Location.X + 50, block.Location.Y);
                        break;

                    case Keys.A:
                    case Keys.Left:
                        if (block.Location.X >= 50)
                            block.Location = new Point(block.Location.X - 50, block.Location.Y);
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

        private void previewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = decimal.ToInt32(numericUpDown1.Value);
            block = new Block(blocksContainer, i);
        }
    }
}

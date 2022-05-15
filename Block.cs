using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Tetriis
{
    class Block
    {
        public Block(Panel container, int type)
        {
            generateBlock(container, type);
        }
        public List<PictureBox> items = new List<PictureBox>();
        public List<Image> images = new List<Image>
        {
            Properties.Resources.O_Tetromino,
            Properties.Resources.I_Tetromino,
            Properties.Resources.S_Tetromino,
            Properties.Resources.Z_Tetromino,
            Properties.Resources.L_Tetromino,
            Properties.Resources.J_Tetromino,
            Properties.Resources.T_Tetromino,
        };

        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                int diffX = value.X - location.X;
                int diffY = value.Y - location.Y;

                foreach (PictureBox item in items)
                {
                    item.Location = new Point(item.Location.X + diffX, item.Location.Y + diffY);
                }
                location = value;
            }
        }

        public Size Size
        {
            get
            {
                return size;
            }
        }

        Size size = new Size(0,0);
        Point location = new Point(int.MaxValue, int.MaxValue);
        List<List<Point>> locations = new List<List<Point>>{
            //block O
            new List<Point>
            {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 200, Y = 0 } ,
                new Point{ X = 150, Y = 50 } ,
                new Point{ X = 200, Y = 50 } ,
            },
            //block I
            new List<Point> {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 150, Y = 50 } ,
                new Point{ X = 150, Y = 100 } ,
                new Point{ X = 150, Y = 150 } ,
            },
            //block S
            new List<Point> {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 200, Y = 0 } ,
                new Point{ X = 150, Y = 50 } ,
                new Point{ X = 100, Y = 50 } ,
            },
            //block Z
            new List<Point>{
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 100, Y = 0 } ,
                new Point { X = 150, Y = 50 },
                new Point { X = 200, Y = 50 },
            },
            //block L
           new List<Point>{
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 150, Y = 50 } ,
                new Point { X = 150, Y = 100 },
                new Point { X = 200, Y = 100 },
            },
            //block J
            new List<Point> {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 150, Y = 50 } ,
                new Point { X = 150, Y = 100 },
                new Point { X = 100, Y = 100 },
            },
            //block T
            new List<Point> {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 150, Y = 50 } ,
                new Point { X = 200, Y = 50 },
                new Point { X = 100, Y = 50 },
            },
        };

        void generateBlock(Panel panel, int nBlock)
        {
            foreach (Point x in locations[nBlock])
            {
                location = new Point(Math.Min(location.X, x.X), Math.Min(location.Y, x.Y));
                size = new Size(Math.Max(size.Width, x.X), Math.Max(size.Height, x.Y));

                PictureBox p = new PictureBox();

                p.BackColor = Color.Transparent;
                p.Location = x;
                p.Size = new Size(50, 50);
                p.BackgroundImageLayout = ImageLayout.Stretch;
                p.BackgroundImage = images[nBlock];

                panel.Controls.Add(p);
                p.BringToFront();

                items.Add(p);
            }

            size = new Size(size.Width - location.X + 50, size.Height - location.Y + 50);
        }
    }
}

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
        List<PictureBox> items = new List<PictureBox>();
        Size size = new Size(0, 0);
        Point location = new Point(int.MaxValue, int.MaxValue);
        List<List<Point>> locations = new List<List<Point>>{
            //block O
            new List<Point>
            {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 175, Y = 0 } ,
                new Point{ X = 150, Y = 25 } ,
                new Point{ X = 175, Y = 25 } ,
            },
            //block I
            new List<Point> {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 150, Y = 25 } ,
                new Point{ X = 150, Y = 50 } ,
                new Point{ X = 150, Y = 75 } ,
            },
            //block S
            new List<Point> {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 175, Y = 0 } ,
                new Point{ X = 150, Y = 25 } ,
                new Point{ X = 125, Y = 25 } ,
            },
            //block Z
            new List<Point>{
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 125, Y = 0 } ,
                new Point { X = 150, Y = 25 },
                new Point { X = 175, Y = 25 },
            },
            //block L
           new List<Point>{
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 150, Y = 25 } ,
                new Point { X = 150, Y = 50 },
                new Point { X = 175, Y = 50 },
            },
            //block J
            new List<Point> {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 150, Y = 25 } ,
                new Point { X = 150, Y = 50 },
                new Point { X = 125, Y = 50 },
            },
            //block T
            new List<Point> {
                new Point{ X = 150, Y = 0 } ,
                new Point{ X = 150, Y = 25 } ,
                new Point { X = 175, Y = 0 },
                new Point { X = 125, Y = 0 },
            },
        };
        List<Image> images = new List<Image>
        {
            Properties.Resources.O_Tetromino,
            Properties.Resources.I_Tetromino,
            Properties.Resources.S_Tetromino,
            Properties.Resources.Z_Tetromino,
            Properties.Resources.L_Tetromino,
            Properties.Resources.J_Tetromino,
            Properties.Resources.T_Tetromino,
        };
        bool visible = true;
        int type = 0;

        public Block(Panel container, int type)
        {
            generateBlock(container, type);
        }
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

        public List<PictureBox> Items
        {
            get
            {
                return items;
            }
        }

        public List<Image> Images
        {
            get
            {
                return images;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }
        }

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;

                foreach (PictureBox item in items)
                    item.Visible = value;
            }
        }
        void generateBlock(Panel panel, int nBlock)
        {
            type = nBlock;
            foreach (Point x in locations[nBlock])
            {
                location = new Point(Math.Min(location.X, x.X), Math.Min(location.Y, x.Y));
                size = new Size(Math.Max(size.Width, x.X), Math.Max(size.Height, x.Y));

                PictureBox p = new PictureBox();

                p.BackColor = Color.Transparent;
                p.Location = x;
                p.Size = new Size(25, 25);
                p.BackgroundImageLayout = ImageLayout.Stretch;
                p.BackgroundImage = images[nBlock];

                panel.Controls.Add(p);
                p.BringToFront();

                items.Add(p);
            }

            size = new Size(size.Width - location.X + 25, size.Height - location.Y + 25);
        }

        int rotation = 0;
        public void rotate()
        {
            switch (type){
                case 0:
                    break;
                case 1:
                    if (rotation == 0 || rotation == 2)
                    {
                        Point l1 = new Point(items[0].Location.X + 25, items[0].Location.Y + 25);
                        Point l2 = new Point(items[2].Location.X - 25, items[2].Location.Y - 25);
                        Point l3 = new Point(items[3].Location.X - 50, items[3].Location.Y - 50);
                        if (canRotate(l1) & canRotate(l2) & canRotate(l3)) 
                        {
                            items[0].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else
                    {
                        Point l1 = new Point(items[0].Location.X - 25, items[0].Location.Y - 25);
                        Point l2 = new Point(items[2].Location.X + 25, items[2].Location.Y + 25);
                        Point l3 = new Point(items[3].Location.X + 50, items[3].Location.Y + 50);
                        if (canRotate(l1) & canRotate(l2) & canRotate(l3))
                        {
                            items[0].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    break;
                case 2:
                    if (rotation == 0 || rotation == 2)
                    {
                        Point l1 = new Point(items[1].Location.X - 25, items[1].Location.Y + 25);
                        Point l2 = new Point(items[2].Location.X - 25, items[2].Location.Y - 25);
                        Point l3 = new Point(items[3].Location.X, items[3].Location.Y - 50);
                        if (canRotate(l1) & canRotate(l2) & canRotate(l3))
                        {
                            items[1].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else
                    {
                        Point l1 = new Point(items[1].Location.X + 25, items[1].Location.Y - 25);
                        Point l2 = new Point(items[2].Location.X + 25, items[2].Location.Y + 25);
                        Point l3 = new Point(items[3].Location.X, items[3].Location.Y + 50);
                        if (canRotate(l1) & canRotate(l2) & canRotate(l3))
                        {
                            items[1].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    break;
                case 3:
                    if (rotation == 0 || rotation == 2)
                    {
                        Point l1 = new Point(items[1].Location.X + 25, items[1].Location.Y - 25);
                        Point l2 = new Point(items[2].Location.X - 25, items[2].Location.Y - 25);
                        Point l3 = new Point(items[3].Location.X - 50, items[3].Location.Y);
                        if (canRotate(l1) & canRotate(l2) & canRotate(l3))
                        {
                            items[1].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else
                    {
                        Point l1 = new Point(items[1].Location.X - 25, items[1].Location.Y + 25);
                        Point l2 = new Point(items[2].Location.X + 25, items[2].Location.Y + 25);
                        Point l3 = new Point(items[3].Location.X + 50, items[3].Location.Y);
                        if (canRotate(l1) & canRotate(l2) & canRotate(l3))
                        {
                            items[1].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    break;
                case 4:
                    if (rotation == 0)
                    {
                        Point l0 = new Point(items[0].Location.X + 25, items[0].Location.Y + 25);
                        Point l2 = new Point(items[2].Location.X - 25, items[2].Location.Y - 25);
                        Point l3 = new Point(items[3].Location.X - 50, items[3].Location.Y);
                        if (canRotate(l0) & canRotate(l2) & canRotate(l3))
                        {
                            items[0].Location = l0;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else if (rotation == 1)
                    {
                        Point l0 = new Point(items[0].Location.X - 25, items[0].Location.Y + 25);
                        Point l2 = new Point(items[2].Location.X + 25, items[2].Location.Y - 25);
                        Point l3 = new Point(items[3].Location.X, items[3].Location.Y - 50);
                        if (canRotate(l0) & canRotate(l2) & canRotate(l3))
                        {
                            items[0].Location = l0;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else if (rotation == 2)
                    {
                        Point l0 = new Point(items[0].Location.X - 25, items[0].Location.Y - 25);
                        Point l2 = new Point(items[2].Location.X + 25, items[2].Location.Y + 25);
                        Point l3 = new Point(items[3].Location.X + 50, items[3].Location.Y);
                        if (canRotate(l0) & canRotate(l2) & canRotate(l3))
                        {
                            items[0].Location = l0;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else if (rotation == 3)
                    {
                        Point l0 = new Point(items[0].Location.X + 25, items[0].Location.Y - 25);
                        Point l2 = new Point(items[2].Location.X - 25, items[2].Location.Y + 25);
                        Point l3 = new Point(items[3].Location.X, items[3].Location.Y + 50);
                        if (canRotate(l0) & canRotate(l2) & canRotate(l3))
                        {
                            items[0].Location = l0;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    break;
                case 5:
                    if (rotation == 0)
                    {
                        Point l0 = new Point(items[0].Location.X + 25, items[0].Location.Y + 25);
                        Point l2 = new Point(items[2].Location.X - 25, items[2].Location.Y - 25);
                        Point l3 = new Point(items[3].Location.X, items[3].Location.Y - 50);
                        if (canRotate(l0) & canRotate(l2) & canRotate(l3))
                        {
                            items[0].Location = l0;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else if (rotation == 1)
                    {
                        Point l0 = new Point(items[0].Location.X - 25, items[0].Location.Y + 25);
                        Point l2 = new Point(items[2].Location.X + 25, items[2].Location.Y - 25);
                        Point l3 = new Point(items[3].Location.X + 50, items[3].Location.Y);
                        if (canRotate(l0) & canRotate(l2) & canRotate(l3))
                        {
                            items[0].Location = l0;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else if (rotation == 2)
                    {
                        Point l0 = new Point(items[0].Location.X - 25, items[0].Location.Y - 25);
                        Point l2 = new Point(items[2].Location.X + 25, items[2].Location.Y + 25);
                        Point l3 = new Point(items[3].Location.X, items[3].Location.Y + 50);
                        if (canRotate(l0) & canRotate(l2) & canRotate(l3))
                        {
                            items[0].Location = l0;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else if (rotation == 3)
                    {
                        Point l0 = new Point(items[0].Location.X + 25, items[0].Location.Y - 25);
                        Point l2 = new Point(items[2].Location.X - 25, items[2].Location.Y + 25);
                        Point l3 = new Point(items[3].Location.X -50, items[3].Location.Y);
                        if (canRotate(l0) & canRotate(l2) & canRotate(l3))
                        {
                            items[0].Location = l0;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    break;
                case 6:
                    if (rotation == 0)
                    {
                        Point l1 = new Point(items[1].Location.X - 25, items[1].Location.Y - 25);
                        Point l2 = new Point(items[2].Location.X - 25, items[2].Location.Y + 25);
                        Point l3 = new Point(items[3].Location.X + 25, items[3].Location.Y - 25);
                        if (canRotate(l1) & canRotate(l2) & canRotate(l3))
                        {
                            items[1].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else if (rotation == 1)
                    {
                        Point l1 = new Point(items[1].Location.X + 25, items[1].Location.Y - 25);
                        Point l2 = new Point(items[2].Location.X - 25, items[2].Location.Y - 25);
                        Point l3 = new Point(items[3].Location.X + 25, items[3].Location.Y + 25);

                        if (canRotate(l1) & canRotate(l2) & canRotate(l3))
                        {
                            items[1].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else if (rotation == 2)
                    {
                        Point l1 = new Point(items[1].Location.X + 25, items[1].Location.Y + 25);
                        Point l2 = new Point(items[2].Location.X + 25, items[2].Location.Y - 25);
                        Point l3 = new Point(items[3].Location.X - 25, items[3].Location.Y + 25);
                        if (canRotate(l1) & canRotate(l2) & canRotate(l3))
                        {
                            items[1].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    else if (rotation == 3)
                    {
                        Point l1 = new Point(items[1].Location.X - 25, items[1].Location.Y + 25);
                        Point l2 = new Point(items[2].Location.X + 25, items[2].Location.Y + 25);
                        Point l3 = new Point(items[3].Location.X - 25, items[3].Location.Y - 25);
                        if (canRotate(l1) & canRotate(l2) & canRotate(l3))
                        {
                            items[1].Location = l1;
                            items[2].Location = l2;
                            items[3].Location = l3;
                            rotation = (rotation + 1) % 4;
                        }
                    }
                    break;
                default:
                    break;
            }

            //reset location and size
            size = new Size(0, 0);
            location = new Point(int.MaxValue, int.MaxValue);
            foreach (PictureBox item in items)
            {
                Point x = item.Location;
                location = new Point(Math.Min(location.X, x.X), Math.Min(location.Y, x.Y));
                size = new Size(Math.Max(size.Width, x.X), Math.Max(size.Height, x.Y));
            }
            size = new Size(size.Width - location.X + 25, size.Height - location.Y + 25);
        }

        bool canRotate(Point location)
        {
            int i = location.Y / 25;
            int j = location.X / 25;
            if (Form1.outsideBounds(i, j))
                return false;
            if (Form1.table[i,j] != null)
                return false;

            return true;
        }
    }
}

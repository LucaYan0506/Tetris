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
        Point location = new Point(353, 750);
        List<List<Tuple<Point, CustomPictureBox.BorderClass>>> locations = new List<List<Tuple<Point, CustomPictureBox.BorderClass>>>{
            //block O
            new List<Tuple<Point,CustomPictureBox.BorderClass>> {
                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 150, Y = 0 } ,
                    new CustomPictureBox.BorderClass(true, true,true,true) ),

                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 200, Y = 0 } ,
                    new CustomPictureBox.BorderClass (false, true,true,true) ),

                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 150, Y = 50 } ,
                    new CustomPictureBox.BorderClass (true, false,true,true) ),

                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 200, Y = 50 } ,
                    new CustomPictureBox.BorderClass (false, false,true,true) ),

            },
            //block I
            new List<Tuple<Point,CustomPictureBox.BorderClass>> {
                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 150, Y = 0 } ,
                    new CustomPictureBox.BorderClass(true, true,true,true) ),

                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 150, Y = 50 } ,
                    new CustomPictureBox.BorderClass (true, false,true,true) ),

                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 150, Y = 100 } ,
                    new CustomPictureBox.BorderClass (true, false,true,true) ),

                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 150, Y = 150 } ,
                    new CustomPictureBox.BorderClass (true, false,true,true) ),

            },
            //block S
            new List<Tuple<Point,CustomPictureBox.BorderClass>> {
                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 150, Y = 0 } ,
                    new CustomPictureBox.BorderClass(true, true,true,true) ),

                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 200, Y = 0 } ,
                    new CustomPictureBox.BorderClass (false, true,true,true) ),

                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 150, Y = 50 } ,
                    new CustomPictureBox.BorderClass (false, false,true,true) ),

                new Tuple<Point,CustomPictureBox.BorderClass> (
                    new Point{ X = 100, Y = 50 } ,
                    new CustomPictureBox.BorderClass (true, true,true,true) ),

            },
            //block Z
            new List<Tuple<Point, CustomPictureBox.BorderClass>> {
                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point{ X = 150, Y = 0 } ,
                    new CustomPictureBox.BorderClass(true, true,true,true) ),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point{ X = 100, Y = 0 } ,
                    new CustomPictureBox.BorderClass(true, true, false, true) ),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point { X = 150, Y = 50 },
                    new CustomPictureBox.BorderClass(true, false, true, true)),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point { X = 200, Y = 50 },
                    new CustomPictureBox.BorderClass(false, true, true, true)),

            },
            //block L
            new List<Tuple<Point, CustomPictureBox.BorderClass>> {
                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point{ X = 150, Y = 0 } ,
                    new CustomPictureBox.BorderClass(true, true,true,true) ),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point{ X = 150, Y = 50 } ,
                    new CustomPictureBox.BorderClass(true, false, true, true) ),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point { X = 150, Y = 100 },
                    new CustomPictureBox.BorderClass(true, false, true, true)),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point { X = 200, Y = 100 },
                    new CustomPictureBox.BorderClass(false, true, true, true)),

            },
            //block J
            new List<Tuple<Point, CustomPictureBox.BorderClass>> {
                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point{ X = 150, Y = 0 } ,
                    new CustomPictureBox.BorderClass(true, true,true,true) ),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point{ X = 150, Y = 50 } ,
                    new CustomPictureBox.BorderClass(true, false, true, true) ),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point { X = 150, Y = 100 },
                    new CustomPictureBox.BorderClass(true, false, true, true)),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point { X = 100, Y = 100 },
                    new CustomPictureBox.BorderClass(true, true, false, true)),

            },
            //block T
            new List<Tuple<Point, CustomPictureBox.BorderClass>> {
                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point{ X = 150, Y = 0 } ,
                    new CustomPictureBox.BorderClass(true, true,true,false) ),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point{ X = 150, Y = 50 } ,
                    new CustomPictureBox.BorderClass(true, true, true, true) ),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point { X = 200, Y = 50 },
                    new CustomPictureBox.BorderClass(false, true, true, true)),

                new Tuple<Point, CustomPictureBox.BorderClass>(
                    new Point { X = 100, Y = 50 },
                    new CustomPictureBox.BorderClass(true, true, false, true)),

            },
        };

        void generateBlock(Panel panel, int nBlock)
        {
            foreach (Tuple<Point, CustomPictureBox.BorderClass> x in locations[nBlock])
            {
                location = new Point(Math.Min(location.X, x.Item1.X), Math.Min(location.Y, x.Item1.Y));
                size = new Size(Math.Max(size.Width, x.Item1.X), Math.Max(size.Height, x.Item1.Y));

                CustomPictureBox p = new CustomPictureBox();

                p.BackColor = Color.Yellow;
                p.Location = x.Item1;
                p.Border = x.Item2;

                panel.Controls.Add(p);
                p.BringToFront();

                items.Add(p);
            }

            size = new Size(size.Width - location.X + 50, size.Height - location.Y + 50);
        }
    }
}

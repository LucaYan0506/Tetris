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
    public partial class CustomPictureBox : PictureBox
    {
        public class BorderClass
        {
            public bool Left = true;
            public bool Top = true;
            public bool Right = true;
            public bool Bottom = true;

            public BorderClass(bool left = true, bool top = true, bool right = true, bool bottom = true)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
           
        }
        BorderClass border;
        public BorderClass Border
        {
            get
            {
                return border;
            }
            set
            {
                border = value;
            }
        }
        public CustomPictureBox()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
            this.Size = new Size(50, 50);
            border = new BorderClass();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int left = 1;
            int top = 1;

            if (!border.Left)
                left = -1;
            if (!border.Top)
                top = -1;

            int right = -1 - left;
            int bottom = -1 - top;
            if (!border.Right)
                right = 0;
            if (!border.Bottom)
                bottom = 0;

            e.Graphics.DrawRectangle(new Pen(Color.Black, 2) , new Rectangle(left, top, ClientSize.Width + right, ClientSize.Height  + bottom));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetriis
{
    public partial class NonSelectableButton : System.Windows.Forms.Button
    {
        public NonSelectableButton()
        {
            SetStyle(System.Windows.Forms.ControlStyles.Selectable, false);
            InitializeComponent();
        }
    }
}

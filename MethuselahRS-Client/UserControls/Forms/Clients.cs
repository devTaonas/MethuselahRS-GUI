using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethuselahRS_Client.UserControls.Forms
{
    public partial class Clients : UserControl
    {
        public Clients()
        {
            InitializeComponent();
            
        }

        public void CenterLabelOnYAxis()
        {
            Size textSize = TextRenderer.MeasureText(this.label1.Text, this.label1.Font);
            int newX = (this.groupBox1.Width - textSize.Width) / 2;
            int currentY = this.label1.Location.Y;
            this.label1.Location = new Point(newX - 20, currentY);
        }
    }
}

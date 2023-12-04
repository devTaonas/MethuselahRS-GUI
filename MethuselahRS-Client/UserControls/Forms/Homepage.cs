using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethuselahRS_Client.UserControls.Forms
{
    public partial class Homepage : UserControl
    {
        public Homepage()
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

        private void Homepage_Load(object sender, EventArgs e)
        {

        }
    }
}

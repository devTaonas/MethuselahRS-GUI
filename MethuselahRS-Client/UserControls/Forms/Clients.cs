using MethuselahRS_Client.GUI;
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
        private static DynamicPanelCreator panelCreator;
        public Clients()
        {
            InitializeComponent();

            panelCreator = new DynamicPanelCreator();
            
        }

        public void CenterLabelOnYAxis()
        {
            Size textSize = TextRenderer.MeasureText(this.label1.Text, this.label1.Font);
            int newX = (this.groupBox1.Width - textSize.Width) / 2;
            int currentY = this.label1.Location.Y;
            this.label1.Location = new Point(newX - 20, currentY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelCreator = new DynamicPanelCreator();
            panel4.Controls.Add( panelCreator.CreatePanel(panel4));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panelCreator.CreatePanel(panel4);
        }
    }
}

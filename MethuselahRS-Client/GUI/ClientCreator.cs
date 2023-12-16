using MethuselahRS_Client.Controller.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MethuselahRS_Client.GUI
{
    public class ClientCreator
    {
        public Color PanelBackColor { get; set; } = Color.FromArgb(37, 37, 38);

        private int lastPanelX = 0;
        private int lastPanelY = 12; 
        public int HorizontalBuffer { get; set; } = 10;
        public int VerticalBuffer { get; set; } = 10;
        private int panelCounter = 0;

        public ClientCreator()
        {

        }

        public RS3Panel CreatePanel(Control parent)
        {
            Size panelSize = new Size(302, 100);

            if (panelCounter % 3 == 0 && panelCounter != 0)
            {
                lastPanelX = 0;
                lastPanelY += panelSize.Height + VerticalBuffer;
            }

            Panel panel2 = new Panel
            {
                BackColor = PanelBackColor,
                BorderStyle = BorderStyle.FixedSingle,
                Size = panelSize,
                Location = new Point(lastPanelX + HorizontalBuffer, lastPanelY)
            };

            Panel panel3 = new Panel
            {
                Dock = DockStyle.Top,
                Size = new Size(panel2.Width - 2, 28), 
                BackColor = Color.FromArgb(45, 45, 48)
            };
            panel2.Controls.Add(panel3);

            Label label2 = new Label
            {
                AutoSize = true,
                Font = new Font("Tahoma", 9.75F, FontStyle.Bold),
                ForeColor = Color.LightGray,
                Text = "View Client " + (panelCounter + 1),
                Location = new Point(108, 5),
                Tag = panelCounter,
            };
            panel3.Controls.Add(label2);

            RS3Panel rs3Panel = new RS3Panel(panel2, label2);

            lastPanelX += panel2.Width + HorizontalBuffer;
            panelCounter++;

            parent.Controls.Add(panel2);

            return rs3Panel;
        }
    }
}

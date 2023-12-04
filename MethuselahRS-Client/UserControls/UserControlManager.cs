using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethuselahRS_Client.UserControls
{
    public class UserControlManager
    {
        private readonly Dictionary<Type, UserControl> _panels;

        public UserControlManager(Dictionary<Type, UserControl> panels)
        {
            _panels = panels;
        }

        public UserControl GetPanel<T>() where T : UserControl
        {
            return _panels[typeof(T)];
        }

        public void SwitchPanel(Panel basePanel, Control newPanel)
        {
            basePanel.Controls.Clear();
            basePanel.Controls.Add(newPanel);
            newPanel.Dock = DockStyle.Fill;
            newPanel.BringToFront();
        }
    }

    public interface ICenterable
    {
        void CenterLabelOnYAxis();
    }
}

using MethuselahRS_Client.Natives;
using MethuselahRS_Client.UserControls;
using MethuselahRS_Client.UserControls.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MethuselahRS_Client
{
    public partial class Form1 : Form
    {
        private readonly UserControlManager _userControlManager;
        private static Control _currentlyActive;

        public Form1()
        {
            InitializeComponent();
            _userControlManager = new UserControlManager(new Dictionary<Type, UserControl>
            {
                { typeof(Homepage), new Homepage() },
                { typeof(Clients), new Clients() },
                { typeof(Scripts), new Scripts() },
                { typeof(AccountManager), new AccountManager() },
                { typeof(ControllerSettings), new ControllerSettings() },
                { typeof(DevelopmentEnvironment), new DevelopmentEnvironment() }
            });

            InitCustomComponents();
        }

        private void InitCustomComponents()
        {
            SwitchPanel<Homepage>();
            this.panel13.MouseDown += new MouseEventHandler(panel13_MouseDown);
            this.button2.Click += new System.EventHandler(this.GUISwitch);
            this.button3.Click += new System.EventHandler(this.GUISwitch);
            this.button4.Click += new System.EventHandler(this.GUISwitch);
            this.button5.Click += new System.EventHandler(this.GUISwitch);
            this.button6.Click += new System.EventHandler(this.GUISwitch);
            this.button8.Click += new System.EventHandler(this.GUISwitch);
        }


        private void GUISwitch(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                switch (clickedButton.Name)
                {
                    case "button8":
                        SwitchPanel<Clients>();
                        break;
                    case "button2":
                        SwitchPanel<Scripts>();
                        break;
                    case "button3":
                        SwitchPanel<AccountManager>();
                        break;
                    case "button4":
                        SwitchPanel<ControllerSettings>();
                        break;
                    case "button6":
                        SwitchPanel<Homepage>();
                        break;
                    case "button5":
                        SwitchPanel<DevelopmentEnvironment>();
                        break;
                }
            }
        }

        private void SwitchPanel<T>() where T : UserControl
        {
            var panel = _userControlManager.GetPanel<T>();
            if (_currentlyActive != panel)
            {
                _currentlyActive = panel;
                _userControlManager.SwitchPanel(basePanel, panel);
            }
        }

        private void panel13_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Methods.ReleaseCapture();
                Methods.SendMessage(this.Handle, Methods.WM_NCLBUTTONDOWN, Methods.HT_CAPTION, 0);
            }
        }
    }
}

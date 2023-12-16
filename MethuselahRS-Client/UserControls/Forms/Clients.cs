using MethuselahRS_Client.Controller.Models;
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
        private static ClientCreator panelCreator;
        private Controller.Binder.GameBinder binder;

        private static bool hidden = false;

        public Clients()
        {
            InitializeComponent();

            panelCreator = new ClientCreator();
            binder = new Controller.Binder.GameBinder();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            RS3Panel rs3Panel = panelCreator.CreatePanel(panel4);
            panel4.Controls.Add(rs3Panel.MainPanel);
            Form1._programController.rS3Panels.Add(rs3Panel);

            Task.Run(() =>
            {
                LaunchGameAsync(rs3Panel);
            });
        }

        private async Task LaunchGameAsync(RS3Panel rs3Panel)
        {
            Client.GameLauncher gameLauncher = new Client.GameLauncher();
            RS3Client rs3Game = gameLauncher.LaunchProcess();
            Form1._programController.rS3Clients.Add(rs3Game);

            await BindGame(rs3Panel, rs3Game);
            
        }

        private async Task BindGame(RS3Panel targetPanel, RS3Client game)
        {
            if (targetPanel.MainPanel.InvokeRequired)
            {
                targetPanel.MainPanel.Invoke(new MethodInvoker(async () => {
                    await binder.BindToPanel(game.GameClient.MainWindowHandle, targetPanel.MainPanel);
                    await Task.Delay(5000);
                    binder.HideWindow();
                    hidden = true;
                }));
            }
            else
            {
                await binder.BindToPanel(game.GameClient.MainWindowHandle, targetPanel.MainPanel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (hidden)
            {
                case true:
                    binder.ShowWindow();
                    hidden = false;
                    break;

                    case false:
                    binder.HideWindow();
                    hidden = true;
                    break;

                    default:
                    break;

            }
            
        }
    }
}

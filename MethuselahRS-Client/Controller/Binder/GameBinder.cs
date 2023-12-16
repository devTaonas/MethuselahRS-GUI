using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MethuselahRS_Client.Natives;

namespace MethuselahRS_Client.Controller.Binder
{
    public class GameBinder
    {

        private IntPtr externalAppHandle;

        public GameBinder()
        {

        }

        public async Task BindToPanel(IntPtr externalAppHandle, Panel panel)
        {
            this.externalAppHandle = externalAppHandle;

            Methods.SetParent(externalAppHandle, panel.Handle);
            Methods.SetWindowLong(externalAppHandle, Methods.GWL_STYLE, Methods.WS_CHILD);
            await ResizeEmbeddedApp(panel);
            HideWindow(); // Hide the window after binding
        }

        public async Task ResizeEmbeddedApp(Panel panel)
        {
            Methods.MoveWindow(externalAppHandle, 0, 0, panel.Width, panel.Height, true);
        }

        public void HideWindow()
        {
            foreach (var x in Form1._programController.rS3Clients)
            {
                Methods.ShowWindow(x.GameClient.MainWindowHandle, Methods.SW_HIDE);
            }
            
        }

        public void ShowWindow()
        {
            foreach (var x in Form1._programController.rS3Clients)
            {
                Methods.ShowWindow(x.GameClient.MainWindowHandle, Methods.SW_SHOW);
            }
        }

        public void ReapplyStyle(Panel panel)
        {
            Methods.SetParent(externalAppHandle, panel.Handle);
            int style = Methods.GetWindowLong(externalAppHandle, Methods.GWL_STYLE);
            Methods.SetWindowLong(externalAppHandle, Methods.GWL_STYLE, (style & ~Methods.WS_VISIBLE) | Methods.WS_CHILD);
            ResizeEmbeddedApp(panel);
        }

    }
}

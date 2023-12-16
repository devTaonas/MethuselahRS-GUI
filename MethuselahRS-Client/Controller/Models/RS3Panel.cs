using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethuselahRS_Client.Controller.Models
{
    public class RS3Panel
    {
        private Controller.Binder.GameBinder binder;

        public Panel MainPanel { get; set; }
        public Label FullscreenHeaderLabel { get; set; }

        public RS3Panel(Panel _min, Label _full) 
        {
            binder = new Controller.Binder.GameBinder();
            MainPanel = _min;
            FullscreenHeaderLabel = _full;
            FullscreenHeaderLabel.DoubleClick += (s, e) => { FullscreenRequested(s); };
        }

        public void FullscreenRequested(object sender)
        {
            Label clickedLabel = sender as Label;
            MessageBox.Show(clickedLabel.Tag.ToString());
        }

        private void Fullscreen()
        {

        }

        private void OriginalScreen()
        {

        }
    }
}

    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethuselahRS_Client.Controller.Models
{
    public class RS3Client
    {
        public Process GameClient { get; set; }
        public ProcessModule MainModule { get; set; }
        public IntPtr RSBaseAddress { get; set; } //Also used for RSExeStart
        public string RSExeFile { get; set; }
        public int RSExeSize { get; set; }
        public byte[] RSHash { get; set; }
        public string RSHashString { get; set; }
    }
}

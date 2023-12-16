using MethuselahRS_Client.Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethuselahRS_Client.Controller
{
    public class ProgramController
    {
        public List<RS3Client> rS3Clients;
        public List<RS3Panel> rS3Panels;

        public ProgramController() 
        {
            rS3Clients = new List<RS3Client>();
            rS3Panels = new List<RS3Panel>();
        }
    }
}

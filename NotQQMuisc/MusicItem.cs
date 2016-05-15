using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace NotQQMuisc
{
    public class MusicItem
    {
        public string albumpic_big { set; get; } 
        public string albumpic_small { set; get; }
        public string downUrl { set; get; }
        public string seconds { set; get; }
        public string albumname { set; get; }
        public string singername { set; get; }
        public string songname { set; get; }
    }
}

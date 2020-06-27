using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Richasy.Controls.UWP.Models.Event
{
    public class PaneStateChangedEventArgs:EventArgs
    {
        public bool IsOpen { get; set; }
        public PaneStateChangedEventArgs()
        {

        }
        public PaneStateChangedEventArgs(bool isOpen)
        {
            IsOpen = isOpen;
        }
    }
}

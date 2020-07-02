using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Richasy.Controls.UWP.Models.Event
{
    public class StageChangedEventArgs:EventArgs
    {
        public string StageName { get; set; }
        public Size CurrentSize { get; set; }
    }
}

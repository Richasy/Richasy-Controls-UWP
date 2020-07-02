using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Richasy.Controls.UWP.Models.Event
{
    public class AfterBackEventArgs:EventArgs
    {
        public Type NavigatePreviousType { get; set; }
        public object NavigatePreviousParameter { get; set; }
    }
}

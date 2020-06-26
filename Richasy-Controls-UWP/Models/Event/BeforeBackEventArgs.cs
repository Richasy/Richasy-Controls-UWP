using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Richasy.Controls.UWP.Models.Event
{
    public class BeforeBackEventArgs : CancelEventArgs
    {
        public bool IsSubPaneOpen { get; set; }
        public Type NavigatePreviousType { get; set; }
        public object NavigatePreviousParameter { get; set; }
        public BeforeBackEventArgs() : base()
        {

        }
        public BeforeBackEventArgs(bool isCancel, bool isSubPaneOpen) : base(isCancel)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Richasy.Controls.UWP.Models.Interface
{
    public interface IAppBarComboBoxItem
    {
        bool IsSelected { get; set; }
        IconElement Icon { get; set; }
        string Tag { get; set; }
        string Text { get; set; }
    }
}

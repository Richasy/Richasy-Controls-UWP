using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Richasy.Controls.UWP.Models.UI
{
    public class RichasyPage : Page
    {
        public Enum PageType { get; set; }
        public bool IsInit { get; set; }
        public static RichasyPage Current;
        public RichasyPage() : base()
        {
            NavigationCacheMode = NavigationCacheMode.Enabled;
            IsInit = false;
            Current = this;
        }
    }
}

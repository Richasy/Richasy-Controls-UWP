using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Richasy.Controls.UWP.Layout
{
    public class CustomListView : ListView
    {
        private ScrollViewer _scrollViewer;
        public CustomListView()
        {
            this.DefaultStyleKey = typeof(ListView);
        }
        public event EventHandler<ScrollViewerViewChangedEventArgs> ViewChanged;
        public event EventHandler ArriveBottom;
        protected override void OnApplyTemplate()
        {
            _scrollViewer = GetTemplateChild("ScrollViewer") as ScrollViewer;
            if (_scrollViewer != null)
                _scrollViewer.ViewChanged += ScrollViewer_ViewChanged;
            base.OnApplyTemplate();
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (_scrollViewer.ExtentHeight - _scrollViewer.ViewportHeight - _scrollViewer.VerticalOffset < 10)
            {
                ArriveBottom?.Invoke(sender, EventArgs.Empty);
            }
            ViewChanged?.Invoke(sender, e);
        }
    }
}

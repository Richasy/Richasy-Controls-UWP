using Richasy.Controls.UWP.Models.Event;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Richasy.Controls.UWP.Layout
{
    public partial class ThreeStageView
    {
        public List<Tuple<Type, object>> NavigateFrameHistoryList = new List<Tuple<Type, object>>();

        public event CancelEventHandler BeforeBack;
        public event EventHandler<AfterBackEventArgs> AfterBack;

        private void OnBackrequested(object sender, BackRequestedEventArgs e)
        {
            // 判断应用当前是否有页面可以回退，没有则继续冒泡
            bool result = Back();
            if (result)
                e.Handled = true;
        }
        public void NavigateToPage(Type type, object parameter = null, bool isBack = false, NavigationTransitionInfo transitionInfo = null)
        {
            if (SubSplitView.DisplayMode == SplitViewDisplayMode.CompactOverlay)
                IsSubPaneOpen = false;
            var last = NavigateFrameHistoryList.LastOrDefault();
            bool isRepeat = false;
            if (last != null && last.Item1 == type && last.Item2 == parameter)
                isRepeat = true;
            if (type != null)
            {
                if (transitionInfo == null)
                {
                    if (isBack)
                        transitionInfo = new EntranceNavigationTransitionInfo();
                    else
                        transitionInfo = new DrillInNavigationTransitionInfo();
                }
                NavigateFrame.Navigate(type, parameter, transitionInfo);
                if (!isBack)
                {
                    if (!isRepeat)
                    {
                        NavigateFrameHistoryList.Add(new Tuple<Type, object>(type, parameter));
                    }
                    if (NavigateFrameHistoryList.Count > 1)
                    {
                        CanGoBack = true;
                    }
                }
            }
        }
        public void ClearCache()
        {
            var cacheSize = NavigateFrame.CacheSize;
            NavigateFrame.CacheSize = 0;
            NavigateFrame.CacheSize = cacheSize;
        }

        public bool Back()
        {
            bool hasHistory = NavigateFrameHistoryList.Count <= 1;
            var beforeArgs = new BeforeBackEventArgs(false, IsSubPaneOpen);

            int c = NavigateFrameHistoryList.Count - 2;
            var last = hasHistory ? NavigateFrameHistoryList[c] : null;

            if (hasHistory)
            {
                beforeArgs.NavigatePreviousType = last.Item1;
                beforeArgs.NavigatePreviousParameter = last.Item2;
            }

            BeforeBack?.Invoke(this, beforeArgs);

            if (!beforeArgs.Cancel)
            {
                if (!hasHistory)
                    return false;
                NavigateFrameHistoryList.RemoveAt(NavigateFrameHistoryList.Count - 1);
                if (NavigateFrameHistoryList.Count <= 1)
                {
                    CanGoBack = false;
                }
                NavigateToPage(last.Item1, last.Item2, true);
                var afterArgs = new AfterBackEventArgs();
                afterArgs.NavigatePreviousType = last.Item1;
                afterArgs.NavigatePreviousParameter = last.Item2;
                AfterBack?.Invoke(this, afterArgs);
            }
            return true;
        }
    }
}

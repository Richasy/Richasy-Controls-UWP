using Richasy.Controls.UWP.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace Richasy.Controls.UWP.Layout
{
    [TemplatePart(Name = NavigateFrameName,Type = typeof(Frame))]
    [TemplatePart(Name = AppSplitViewName, Type = typeof(SplitView))]
    [TemplatePart(Name = SubSplitViewName, Type = typeof(SplitView))]
    public partial class ThreeStageView : Control
    {
        public Frame NavigateFrame;
        private SplitView AppSplitView;
        private SplitView SubSplitView;

        private const string NavigateFrameName = "NavigateFrame";
        private const string AppSplitViewName = "AppSplitView";
        private const string SubSplitViewName = "SubSplitView";
        private const string CompactStateName = "Compact";
        private const string DefaultStateName = "Default";
        private const string ExpandStateName = "Expand";

        public event EventHandler<StageChangedEventArgs> StageChanged;

        public ThreeStageView()
        {
            this.DefaultStyleKey = typeof(ThreeStageView);
            this.SizeChanged += ThreeStageView_SizeChanged;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackrequested;
        }
        protected override void OnApplyTemplate()
        {
            NavigateFrame = GetTemplateChild(NavigateFrameName) as Frame;
            AppSplitView = GetTemplateChild(AppSplitViewName) as SplitView;
            SubSplitView = GetTemplateChild(SubSplitViewName) as SplitView;
            AppSplitView.PaneClosed += AppSplitView_PaneClosed;
            AppSplitView.PaneOpened += AppSplitView_PaneOpened;
            SubSplitView.PaneClosed += SubSplitView_PaneClosed;
            SubSplitView.PaneOpened += SubSplitView_PaneOpened;
            base.OnApplyTemplate();
        }

        private void SubSplitView_PaneOpened(SplitView sender, object args)
        {
            if (!IsSubPaneOpen)
                IsSubPaneOpen = true;
        }

        private void SubSplitView_PaneClosed(SplitView sender, object args)
        {
            if (IsSubPaneOpen)
                IsSubPaneOpen = false;
        }

        private void AppSplitView_PaneOpened(SplitView sender, object args)
        {
            if (!IsAppPaneOpen)
                IsAppPaneOpen = true;
        }

        private void AppSplitView_PaneClosed(SplitView sender, object args)
        {
            if (IsAppPaneOpen)
                IsAppPaneOpen = false;
        }

        private void ThreeStageView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            string prevName = GetCurrentStateName(e.PreviousSize);
            string currentName = GetCurrentStateName(e.NewSize);
            VisualStateManager.GoToState(this, currentName, false);
            if (prevName != currentName)
            {
                var args = new StageChangedEventArgs();
                args.CurrentSize = e.NewSize;
                args.StageName = currentName;
                StageChanged?.Invoke(this, args);
            }
        }

        private string GetCurrentStateName(Size size)
        {
            double width = size.Width;
            string name = "";
            if (width <= CompactStateBreakpoint)
                name = CompactStateName;
            else if (width < ExpendStateBreakpoint)
                name = DefaultStateName;
            else
                name = ExpandStateName;
            return name;
        }
    }
}

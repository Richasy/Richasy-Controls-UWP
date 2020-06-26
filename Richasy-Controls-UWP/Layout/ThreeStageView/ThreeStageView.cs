using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        private const string ExpendStateName = "Extend";
        public ThreeStageView()
        {
            this.DefaultStyleKey = typeof(ThreeStageView);
            this.SizeChanged += ThreeStageView_SizeChanged;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackrequested;
        }

        private void ThreeStageView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = e.NewSize.Width;
            if (width <= CompactStateBreakpoint)
            {
                VisualStateManager.GoToState(this, CompactStateName, false);
            }
            else if (width < ExpendStateBreakpoint)
            {
                VisualStateManager.GoToState(this, DefaultStateName, false);
            }
            else
            {
                VisualStateManager.GoToState(this, ExpendStateName, false);
            }
        }

        protected override void OnApplyTemplate()
        {
            NavigateFrame = GetTemplateChild(NavigateFrameName) as Frame;
            AppSplitView = GetTemplateChild(AppSplitViewName) as SplitView;
            SubSplitView = GetTemplateChild(SubSplitViewName) as SplitView;
            base.OnApplyTemplate();
        }
    }
}

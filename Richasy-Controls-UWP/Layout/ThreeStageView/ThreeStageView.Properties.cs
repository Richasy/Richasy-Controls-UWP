using Richasy.Controls.UWP.Models.Event;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Richasy.Controls.UWP.Layout
{
    public partial class ThreeStageView
    {
        public event EventHandler<PaneStateChangedEventArgs> AppPaneStateChanged;
        public event EventHandler<PaneStateChangedEventArgs> SubPaneStateChanged;
        public object AppPane
        {
            get { return (object)GetValue(AppPaneProperty); }
            set { SetValue(AppPaneProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AppPane.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppPaneProperty =
            DependencyProperty.Register("AppPane", typeof(object), typeof(ThreeStageView), new PropertyMetadata(null));

        public object SubPane
        {
            get { return (object)GetValue(SubPaneProperty); }
            set { SetValue(SubPaneProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SubPane.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubPaneProperty =
            DependencyProperty.Register("SubPane", typeof(object), typeof(ThreeStageView), new PropertyMetadata(null));

        public Brush AppPaneBackground
        {
            get { return (Brush)GetValue(AppPaneBackgroundProperty); }
            set { SetValue(AppPaneBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AppPaneBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppPaneBackgroundProperty =
            DependencyProperty.Register("AppPaneBackground", typeof(Brush), typeof(ThreeStageView), new PropertyMetadata(null));

        public Brush SubPaneBackground
        {
            get { return (Brush)GetValue(SubPaneBackgroundProperty); }
            set { SetValue(SubPaneBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SubPaneBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubPaneBackgroundProperty =
            DependencyProperty.Register("SubPaneBackground", typeof(Brush), typeof(ThreeStageView), new PropertyMetadata(null));

        public Brush PageBackground
        {
            get { return (Brush)GetValue(PageBackgroundProperty); }
            set { SetValue(PageBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageBackgroundProperty =
            DependencyProperty.Register("PageBackground", typeof(Brush), typeof(ThreeStageView), new PropertyMetadata(null));



        public double AppPaneOpenLength
        {
            get { return (double)GetValue(AppPaneOpenLengthProperty); }
            set { SetValue(AppPaneOpenLengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AppPaneOpenLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppPaneOpenLengthProperty =
            DependencyProperty.Register("AppPaneOpenLength", typeof(double), typeof(ThreeStageView), new PropertyMetadata(310.0));

        public double AppPaneCompactWidth
        {
            get { return (double)GetValue(AppPaneCompactWidthProperty); }
            set { SetValue(AppPaneCompactWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AppPaneCompactWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppPaneCompactWidthProperty =
            DependencyProperty.Register("AppPaneCompactWidth", typeof(double), typeof(ThreeStageView), new PropertyMetadata(80.0));

        public double SubPaneOpenWidth
        {
            get { return (double)GetValue(SubPaneOpenWidthProperty); }
            set { SetValue(SubPaneOpenWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SubPaneOpenWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubPaneOpenWidthProperty =
            DependencyProperty.Register("SubPaneOpenWidth", typeof(double), typeof(ThreeStageView), new PropertyMetadata(400.0));

        public double SubPaneCompactWidth
        {
            get { return (double)GetValue(SubPaneCompactWidthProperty); }
            set { SetValue(SubPaneCompactWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SubPaneCompactWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubPaneCompactWidthProperty =
            DependencyProperty.Register("SubPaneCompactWidth", typeof(double), typeof(ThreeStageView), new PropertyMetadata(0.0));

        public bool IsAppPaneOpen
        {
            get { return (bool)GetValue(IsAppPaneOpenProperty); }
            set { SetValue(IsAppPaneOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAppPaneOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAppPaneOpenProperty =
            DependencyProperty.Register("IsAppPaneOpen", typeof(bool), typeof(ThreeStageView), new PropertyMetadata(true,new PropertyChangedCallback(IsAppPaneOpen_Changed)));

        private static void IsAppPaneOpen_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue is bool isopen && e.NewValue != e.OldValue)
            {
                var instance = d as ThreeStageView;
                instance.AppPaneStateChanged?.Invoke(instance, new PaneStateChangedEventArgs(isopen));
            }
        }

        public bool IsSubPaneOpen
        {
            get { return (bool)GetValue(IsSubPaneOpenProperty); }
            set { SetValue(IsSubPaneOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSubPaneOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSubPaneOpenProperty =
            DependencyProperty.Register("IsSubPaneOpen", typeof(bool), typeof(ThreeStageView), new PropertyMetadata(false,new PropertyChangedCallback(IsSubPaneOpen_Changed)));
        private static void IsSubPaneOpen_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool isopen && e.NewValue!=e.OldValue)
            {
                var instance = d as ThreeStageView;
                instance.SubPaneStateChanged?.Invoke(instance, new PaneStateChangedEventArgs(isopen));
            }
        }

        public double ExpendStateBreakpoint
        {
            get { return (double)GetValue(ExpendStateBreakpointProperty); }
            set { SetValue(ExpendStateBreakpointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExpendStateBreakpoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpendStateBreakpointProperty =
            DependencyProperty.Register("ExpendStateBreakpoint", typeof(double), typeof(ThreeStageView), new PropertyMetadata(1500.0));

        public double CompactStateBreakpoint
        {
            get { return (double)GetValue(CompactStateBreakpointProperty); }
            set { SetValue(CompactStateBreakpointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompactStateBreakpoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompactStateBreakpointProperty =
            DependencyProperty.Register("CompactStateBreakpoint", typeof(double), typeof(ThreeStageView), new PropertyMetadata(1000.0));

        public bool CanGoBack
        {
            get { return (bool)GetValue(CanGoBackProperty); }
            set { SetValue(CanGoBackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanGoBack.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanGoBackProperty =
            DependencyProperty.Register("CanGoBack", typeof(bool), typeof(ThreeStageView), new PropertyMetadata(false));



    }
}

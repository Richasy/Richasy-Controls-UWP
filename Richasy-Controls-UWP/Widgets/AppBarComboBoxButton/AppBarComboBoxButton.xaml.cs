using Richasy.Controls.UWP.Models.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Richasy.Controls.UWP.Widgets
{
    public sealed partial class AppBarComboBoxButton : AppBarButton
    {
        private bool _isItemInvoke = false;
        public AppBarComboBoxButton()
        {
            this.InitializeComponent();
        }
        public event EventHandler<List<IAppBarComboBoxItem>> SelectionChanged;

        public bool IsMultipleSelect
        {
            get { return (bool)GetValue(IsMultipleSelectProperty); }
            set { SetValue(IsMultipleSelectProperty, value); }
        }
        public static readonly DependencyProperty IsMultipleSelectProperty =
            DependencyProperty.Register("IsMultipleSelect", typeof(bool), typeof(AppBarComboBoxButton), new PropertyMetadata(false));


        public ICollection ItemsSource
        {
            get { return (ICollection)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ICollection), typeof(AppBarComboBoxButton), new PropertyMetadata(null, new PropertyChangedCallback(ItemsSource_Changed)));

        private static void ItemsSource_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue && e.NewValue is ICollection data)
            {
                var instance = d as AppBarComboBoxButton;
                instance.AppBarMenuFlyout.Items.Clear();
                foreach (var temp in data)
                {
                    var item = temp as IAppBarComboBoxItem;
                    if (!string.IsNullOrEmpty(item.Tag))
                    {
                        var toggle = new ToggleMenuFlyoutItem();
                        toggle.Text = item.Text;
                        toggle.Tag = item.Tag;
                        toggle.Icon = item.Icon;
                        toggle.FontFamily = instance.FontFamily;
                        toggle.Click += instance.ToggleItem_Click;
                        toggle.IsChecked = item.IsSelected;
                        instance.AppBarMenuFlyout.Items.Add(toggle);
                    }
                    else
                        instance.AppBarMenuFlyout.Items.Add(new MenuFlyoutSeparator());
                }
            }
        }

        private void ToggleItem_Click(object sender, RoutedEventArgs e)
        {
            var selectItem = sender as ToggleMenuFlyoutItem;
            var items = AppBarMenuFlyout.Items.OfType<ToggleMenuFlyoutItem>();
            if (IsMultipleSelect)
            {
                _isItemInvoke = true;
            }
            else
            {
                foreach (var item in items)
                {
                    item.IsChecked = false;
                }
                selectItem.IsChecked = true;
            }
            var temp = items.Where(p => p.IsChecked).Select(p => (p.Text, p.Tag)).ToList();
            if (temp.Count > 0)
            {
                var result = new List<IAppBarComboBoxItem>();
                foreach (var item in ItemsSource)
                {
                    var source = item as IAppBarComboBoxItem;
                    if (temp.Any(p => p.Tag.ToString() == source.Tag && p.Text == source.Text))
                    {
                        result.Add(source);
                    }
                }
                SelectionChanged?.Invoke(this, result);
            }
        }

        private void AppBarMenuFlyout_Closing(FlyoutBase sender, FlyoutBaseClosingEventArgs args)
        {
            if (IsMultipleSelect && _isItemInvoke)
            {
                args.Cancel = true;
                _isItemInvoke = false;
            }
        }
    }
}

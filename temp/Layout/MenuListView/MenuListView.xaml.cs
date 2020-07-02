using Richasy.Controls.UWP.Extensions;
using Richasy.Controls.UWP.Models.UI;
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

namespace Richasy.Controls.UWP.Layout
{
    public sealed partial class MenuListView : UserControl
    {
        private NavigateItemBase _selectedItem;
        public NavigateItemBase SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                MenuView.SelectedItem = value;
                SelectedItemChanged?.Invoke(this, value);
            }
        }
        public MenuListView()
        {
            this.InitializeComponent();
        }

        public event EventHandler<NavigateItemBase> SelectedItemChanged;

        private void MenuView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!e.ClickedItem.Equals(SelectedItem))
            {
                if (ItemsSource != null)
                {
                    foreach (var item in ItemsSource)
                    {
                        (item as NavigateItemBase).IsSelected = item.Equals(e.ClickedItem);
                    }
                }
                SelectedItem = e.ClickedItem as NavigateItemBase;
            }
        }

        public ICollection ItemsSource
        {
            get { return (ICollection)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ICollection), typeof(MenuListView), new PropertyMetadata(null));

        public DataTemplate ItemWideTemplate
        {
            get { return (DataTemplate)GetValue(ItemWideTemplateProperty); }
            set { SetValue(ItemWideTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemWideTemplateProperty =
            DependencyProperty.Register("ItemWideTemplate", typeof(DataTemplate), typeof(MenuListView), new PropertyMetadata(null));


        public DataTemplate ItemNarrowTemplate
        {
            get { return (DataTemplate)GetValue(ItemNarrowTemplateProperty); }
            set { SetValue(ItemNarrowTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemNarrowTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemNarrowTemplateProperty =
            DependencyProperty.Register("ItemNarrowTemplate", typeof(DataTemplate), typeof(MenuListView), new PropertyMetadata(null));



        public Style ListViewStyle
        {
            get { return (Style)GetValue(ListViewStyleProperty); }
            set { SetValue(ListViewStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListViewStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListViewStyleProperty =
            DependencyProperty.Register("ListViewStyle", typeof(Style), typeof(MenuListView), new PropertyMetadata(null));

        public string SignName
        {
            get { return (string)GetValue(SignNameProperty); }
            set { SetValue(SignNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SignName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SignNameProperty =
            DependencyProperty.Register("SignName", typeof(string), typeof(MenuListView), new PropertyMetadata(null,new PropertyChangedCallback(SignName_Changed)));

        private static void SignName_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue!=null && e.NewValue is string signName)
            {
                var instance = d as MenuListView;
                var view = instance.MenuView;
                IndicatorExtension.SetName(view, signName);
                IndicatorExtension.SetIsScaleEnabled(view, true);
            }
        }

        public bool IsNarrow
        {
            get { return (bool)GetValue(IsNarrowProperty); }
            set { SetValue(IsNarrowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsNarrow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsNarrowProperty =
            DependencyProperty.Register("IsNarrow", typeof(bool), typeof(MenuListView), new PropertyMetadata(false,new PropertyChangedCallback(IsNarrow_Changed)));

        private static void IsNarrow_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue is bool isNarrow)
            {
                var instance = d as MenuListView;
                instance.MenuView.ItemTemplate = isNarrow ? instance.ItemNarrowTemplate : instance.ItemWideTemplate;
            }
        }
    }
}

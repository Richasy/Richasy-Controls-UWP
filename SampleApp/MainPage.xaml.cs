using Richasy.Controls.UWP.Models.UI;
using Richasy.Font.UWP.Enums;
using SampleApp.Models.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : RichasyPage
    {
        private ObservableCollection<MenuItem> MenuItemCollection = new ObservableCollection<MenuItem>();
        public MainPage(): base()
        {
            this.InitializeComponent();
            var items = MenuItem.GetMenuItems();
            items.ForEach(p => MenuItemCollection.Add(p));
            IsInit = true;
        }

        private void MyView_BeforeBack(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void MyView_AfterBack(object sender, Richasy.Controls.UWP.Models.Event.AfterBackEventArgs e)
        {

        }

        private void MenuListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MenuListView.SelectedItem = MenuItemCollection.First();
            ExpandIcon.Symbol = MyView.IsAppPaneOpen ? FeatherSymbol.ChevronsLeft : FeatherSymbol.ChevronsRight;
        }

        private void MyView_AppPaneStateChanged(object sender, Richasy.Controls.UWP.Models.Event.PaneStateChangedEventArgs e)
        {
            ExpandIcon.Symbol = e.IsOpen ? FeatherSymbol.ChevronsLeft : FeatherSymbol.ChevronsRight;
        }

        private void ExpandButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MyView.IsAppPaneOpen = !MyView.IsAppPaneOpen;
        }

        private void MenuListView_SelectedItemChanged(object sender, NavigateItemBase e)
        {
            var item = e as MenuItem;
            Type pageType = null;

            switch (item.Type)
            {
                case Models.Enum.MenuItemType.TipPopup:
                    pageType = typeof(Pages.Popups.TipPopupPage);
                    break;
                case Models.Enum.MenuItemType.CenterPopup:
                    pageType = typeof(Pages.Popups.CenterPopupPage);
                    break;
                case Models.Enum.MenuItemType.ExtendButton:
                    pageType = typeof(Pages.Interaction.ButtonPage);
                    break;
                case Models.Enum.MenuItemType.ExtendInput:
                    pageType = typeof(Pages.Interaction.InputPage);
                    break;
                case Models.Enum.MenuItemType.Other:
                    break;
                default:
                    break;
            }
            MyView.NavigateToPage(pageType, null, false, new DrillInNavigationTransitionInfo());
        }
    }
}

using Richasy.Controls.UWP.Models.UI;
using Richasy.Font.UWP.Enums;
using SampleApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Models.UI
{
    public class MenuItem : NavigateItemBase
    {
        public new MenuItemType Type { get; set; }
        public FeatherSymbol Icon { get; set; }
        public MenuItem()
        {

        }
        public MenuItem(MenuItemType t, bool isSelected = false) : base(isSelected)
        {
            Type = t;
            switch (t)
            {
                case MenuItemType.TipPopup:
                    Name = "弹出提示";
                    Icon = FeatherSymbol.Tag;
                    break;
                case MenuItemType.CenterPopup:
                    Name = "弹出表单";
                    Icon = FeatherSymbol.Layout;
                    break;
                case MenuItemType.ExtendButton:
                    Name = "扩展按钮";
                    Icon = FeatherSymbol.MousePointer;
                    break;
                case MenuItemType.ExtendInput:
                    Name = "扩展文本框";
                    Icon = FeatherSymbol.PenTool;
                    break;
                case MenuItemType.Other:
                    Name = "其它";
                    Icon = FeatherSymbol.Share;
                    break;
                default:
                    break;
            }
        }

        public static List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem(MenuItemType.TipPopup,true),
                new MenuItem(MenuItemType.CenterPopup),
                new MenuItem(MenuItemType.ExtendButton),
                new MenuItem(MenuItemType.ExtendInput)
            };
        }
    }
}

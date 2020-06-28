using Richasy.Controls.UWP.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Richasy.Controls.UWP.Models.UI
{
    public class AppBarComboBoxItem : NotifyPropertyBase, IAppBarComboBoxItem
    {
        public string Text { get; set; }
        public string Tag { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }
        public IconElement Icon { get; set; }
        public static AppBarComboBoxItem Line = new AppBarComboBoxItem();
        public AppBarComboBoxItem()
        {

        }
        public AppBarComboBoxItem(string text, string tag, IconElement icon = null, bool isSelected = false)
        {
            Text = text;
            Tag = tag;
            Icon = icon;
            IsSelected = isSelected;
        }

        public override bool Equals(object obj)
        {
            return obj is AppBarComboBoxItem item &&
                   Text == item.Text &&
                   Tag == item.Tag;
        }

        public override int GetHashCode()
        {
            int hashCode = 1124388417;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tag);
            return hashCode;
        }
    }
}

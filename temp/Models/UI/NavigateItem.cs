using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Richasy.Controls.UWP.Models.UI
{
    public class NavigateItemBase : NotifyPropertyBase
    {
        public string Name { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }
        public NavigateItemBase()
        {

        }
        public NavigateItemBase(bool isSelected)
        {
            IsSelected = isSelected;
        }
        public NavigateItemBase(string name, bool isSelected = false)
        {
            Name = name;
            IsSelected = isSelected;
        }

        public override bool Equals(object obj)
        {
            return obj is NavigateItemBase @base &&
                   Name == @base.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}

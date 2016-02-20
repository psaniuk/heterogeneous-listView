using HeterogeneousListView.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HeterogeneousListView
{
    public class ProductTemplateSelector: DataTemplateSelector
    {
        public DataTemplate MilkTemplate { get; set; }
        public DataTemplate OrangeTemplate { get; set; }
        public DataTemplate CookieTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item.GetType() == typeof(Milk))
                return MilkTemplate;

            if (item.GetType() == typeof(Orange))
                return OrangeTemplate;

            if (item.GetType() == typeof(Cookie))
                return CookieTemplate;

            return base.SelectTemplateCore(item, container);
        }
    }
}

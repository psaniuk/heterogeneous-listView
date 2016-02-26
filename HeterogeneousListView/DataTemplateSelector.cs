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

        /*protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item.GetType() == typeof(Milk))
            {
                return MilkTemplate;
            }

            if (item.GetType() == typeof(Orange))
            {
                return OrangeTemplate;
            }

            if (item.GetType() == typeof(Cookie))
            {
                return CookieTemplate;
            }

            return base.SelectTemplateCore(item);
        }*/

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var listViewItem = (ListViewItem)container;

           /* System.Diagnostics.Debug.WriteLine("-");
            System.Diagnostics.Debug.WriteLine($"Container for: {listViewItem.Content ?? "empty"}");
            System.Diagnostics.Debug.WriteLine($"Data {item}");*/
            

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

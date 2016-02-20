using System;
using System.Collections.Generic;
using HeterogeneousListView.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HeterogeneousListView
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            List<object> dataSource = CreateRandomDataSource();
            ProductsListWithSelector.ItemsSource = dataSource;
            ProductList.ItemsSource = dataSource;
        }

        private List<object> CreateRandomDataSource()
        {
            var random = new Random();

            var dataSource = new List<object>();
            for(var i = 0; i < 100; i++)
            {
                int n = random.Next(1, 4);
                if (n == 1)
                    dataSource.Add(new Milk { Liters = i });
                else if (n == 2)
                    dataSource.Add(new Orange { Weight = i });
                else if (n == 3)
                    dataSource.Add(new Cookie { Pieces = i });
            }

            return dataSource;
        }

        private IDictionary<Type, string> _templatesMapping = new Dictionary<Type, string>()
        {
            {typeof(Milk), "MilkTemplate"},
            {typeof(Orange), "OrangeTemplate"},
            {typeof(Cookie), "CookieTemplate"}
        };
        

        private void ProductListChoosingItemContainer(ListViewBase sender, ChoosingItemContainerEventArgs args)
        {
            string templateName = _templatesMapping[args.Item.GetType()];

            if (args.ItemContainer != null)
                if (!string.Equals(templateName, args.ItemContainer.Tag))
                    args.ItemContainer = null;

            if (args.ItemContainer == null)
            {
                var itemPresenter = new ListViewItem();
                itemPresenter.ContentTemplate = (DataTemplate)Resources[templateName];
                itemPresenter.Tag = templateName;
                args.ItemContainer = itemPresenter;
            }

            args.IsContainerPrepared = true;
        }
    }
}

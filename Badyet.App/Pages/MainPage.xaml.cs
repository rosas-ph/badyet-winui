using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Badyet.App.Pages
{
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;
        Window window;
        public List<Scenario> Scenarios => this.scenarios;

        public MainPage()
        {
            window = MainWindow.Current;
            this.InitializeComponent();

            Current = this;
        }

        private void NaviView_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Scenario item in scenarios)
            {
                NaviView.MenuItems.Add(new NavigationViewItem
                {
                    Content = item.Title,
                    Tag = item.ClassName,
                });
            }

            // NavView doesn't load any page by default, so load home page.
            NaviView.SelectedItem = NaviView.MenuItems[1];

            // If navigation occurs on SelectionChanged, this isn't needed.
            // Because we use ItemInvoked to navigate, we need to call Navigate
            // here to load the home page.
            if (scenarios is not null && scenarios.Count > 0)
            {
                NaviView_Navigate(scenarios.First().ClassName, new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
            }
        }
    
        private void NaviView_Navigate(string navItemTag, Microsoft.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {
            Type page;

            if (navItemTag == nameof(SettingsPage))
            {
                page = typeof(SettingsPage);
            }
            else
            {
                Scenario item = scenarios.First(p => p.ClassName.Equals(navItemTag));
                page = Type.GetType(item.ClassName);
            }

            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if ((page is not null) && !Type.Equals(preNavPageType, page))
            {
                ContentFrame.Navigate(page, null, transitionInfo);
            }
        }
        private void NaviView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var naViewItemInvoked = (NavigationViewItem)args.InvokedItemContainer;

            if (args.IsSettingsInvoked)
            {
                NaviView_Navigate(nameof(SettingsPage), args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer is not null)
            {
                var navItemTag = args.InvokedItemContainer.Tag?.ToString();
                if (!string.IsNullOrEmpty(navItemTag))
                {
                    NaviView_Navigate(navItemTag, new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
                }
            }
        }

        //private void NaviView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        //{
        //    if (ContentFrame.CanGoBack)
        //    {
        //        ContentFrame.GoBack();
        //    }
        //}

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //NaviView.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType == typeof(SettingsPage))
            {
                NaviView.SelectedItem = (NavigationViewItem)NaviView.SettingsItem;
                NaviView.Header = "Settings";
            }
            else if (ContentFrame.SourcePageType != null)
            {
                var item = scenarios.First(p => p.ClassName == e.SourcePageType.FullName);
                var menuItems = NaviView.MenuItems;

                NaviView.SelectedItem = NaviView.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.ClassName));

                NaviView.Header =
                    ((NavigationViewItem)NaviView.SelectedItem)?.Content?.ToString();
            }
        }
    }
}

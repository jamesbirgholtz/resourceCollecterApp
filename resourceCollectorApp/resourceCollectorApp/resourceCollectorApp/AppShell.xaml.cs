using resourceCollectorApp.ViewModels;
using resourceCollectorApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace resourceCollectorApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

using resourceCollectorApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace resourceCollectorApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
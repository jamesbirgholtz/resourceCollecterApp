using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace resourceCollectorApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            CurrentPage = Children[2];
        }
    }
}
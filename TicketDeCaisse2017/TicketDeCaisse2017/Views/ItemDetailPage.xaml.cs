
using TicketDeCaisse2017.ViewModels;

using Xamarin.Forms;

namespace TicketDeCaisse2017.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        WarrantyDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(WarrantyDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }        
    }
}

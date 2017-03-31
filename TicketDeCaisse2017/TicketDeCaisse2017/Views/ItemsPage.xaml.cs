using System;

using TicketDeCaisse2017.Models;
using TicketDeCaisse2017.ViewModels;

using Xamarin.Forms;

namespace TicketDeCaisse2017.Views
{
    public partial class ItemsPage : ContentPage
    {
        WarrantyViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WarrantyViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Warranty;
            if (item == null)
                return;

            var itemVM = new ItemDetailViewModel(item);
            await itemVM.InitAsync();
            await Navigation.PushAsync(new ItemDetailPage(itemVM));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}

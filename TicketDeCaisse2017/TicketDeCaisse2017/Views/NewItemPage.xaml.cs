using System;

using TicketDeCaisse2017.Models;

using Xamarin.Forms;

namespace TicketDeCaisse2017.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Warranty Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Warranty
            {
                Name = "Nom",
                StoreName = "Nom du magasin"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
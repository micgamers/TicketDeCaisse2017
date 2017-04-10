using System;

using TicketDeCaisse2017.Models;

using Xamarin.Forms;

namespace TicketDeCaisse2017.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Warranty Warranty { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Warranty = new Warranty
            {
                Name = "Nom",
                StoreName = "Nom du magasin"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Warranty);
            await Navigation.PopToRootAsync();
        }
    }
}
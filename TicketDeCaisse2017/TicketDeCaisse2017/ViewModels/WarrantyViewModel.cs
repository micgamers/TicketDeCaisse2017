using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketDeCaisse2017.Helpers;
using TicketDeCaisse2017.Models;
using TicketDeCaisse2017.Services;
using TicketDeCaisse2017.Views;
using Xamarin.Forms;

namespace TicketDeCaisse2017.ViewModels
{
    class WarrantyViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Warranty> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public WarrantyViewModel()
        {
            Title = "Warranty List";
            Items = new ObservableRangeCollection<Warranty>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Warranty>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Warranty;
                Items.Add(_item);
                //await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await TDCServiceLocator.Instance.XSqliteService.GetListWarranty();
                //await DataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

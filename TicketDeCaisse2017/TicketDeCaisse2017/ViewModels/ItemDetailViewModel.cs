using TicketDeCaisse2017.Models;

namespace TicketDeCaisse2017.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Warranty Item { get; set; }
        public ItemDetailViewModel(Warranty item = null)
        {
            Title = item.Name;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
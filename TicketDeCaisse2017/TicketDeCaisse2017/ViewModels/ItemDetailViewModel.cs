using System.Threading.Tasks;
using TicketDeCaisse2017.Models;
using Xamarin.Forms;

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

        public ImageSource image { get; set; }


        public async Task InitAsync()
        {
            if (Item.Url.StartsWith("http"))
            {
                image = ImageSource.FromUri(new System.Uri(Item.Url));
            }
            else
            {
                var file = await PCLStorage.FileSystem.Current.GetFileFromPathAsync(Item.Url);
                var stream = await file.OpenAsync(PCLStorage.FileAccess.Read);
                image = ImageSource.FromStream(() => stream);
            }
        }
    }
}
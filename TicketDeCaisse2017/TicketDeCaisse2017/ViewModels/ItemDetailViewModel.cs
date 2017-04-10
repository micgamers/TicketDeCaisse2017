using System.Threading.Tasks;
using TicketDeCaisse2017.Models;
using Xamarin.Forms;

namespace TicketDeCaisse2017.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Warranty Warranty { get; set; }
        public ItemDetailViewModel(Warranty warranty = null)
        {
            Title = warranty.Name;
            Warranty = warranty;
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
            if (Warranty.Url.StartsWith("http"))
            {
                image = ImageSource.FromUri(new System.Uri(Warranty.Url));
            }
            else
            {
                var file = await PCLStorage.FileSystem.Current.GetFileFromPathAsync(Warranty.Url);
                var stream = await file.OpenAsync(PCLStorage.FileAccess.Read);
                image = ImageSource.FromStream(() => stream);
            }
        }
    }
}
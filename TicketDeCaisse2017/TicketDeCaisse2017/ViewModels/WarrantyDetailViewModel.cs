using System.Collections.Generic;
using System.Threading.Tasks;
using TicketDeCaisse2017.Helpers;
using TicketDeCaisse2017.Models;
using TicketDeCaisse2017.Services;
using Xamarin.Forms;

namespace TicketDeCaisse2017.ViewModels
{
    public class WarrantyDetailViewModel : BaseViewModel
    {
        public Warranty Warranty { get; set; }
        public WarrantyDetailViewModel(Warranty warranty = null)
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



        public ObservableRangeCollection<ImageWarranty> Images { get; set; }


        public async Task InitAsync()
        {
            Images = new ObservableRangeCollection<ImageWarranty>();

            Images.Clear();
            var items = await TDCServiceLocator.Instance.Database.GetListImageWarranty(Warranty);
            Images.AddRange(items);

            foreach (ImageWarranty source in Images)
            {
                await SetImageSource(source);
            }
            

        }

        private async Task SetImageSource(ImageWarranty source)
        {
            if (Warranty.Url.StartsWith("http"))
            {
                source.Image = ImageSource.FromUri(new System.Uri(source.Url));
            }
            else
            {
                var file = await PCLStorage.FileSystem.Current.GetFileFromPathAsync(source.Url);
                var stream = await file.OpenAsync(PCLStorage.FileAccess.Read);
                source.Image = ImageSource.FromStream(() => stream);
            }
        }
    }
}
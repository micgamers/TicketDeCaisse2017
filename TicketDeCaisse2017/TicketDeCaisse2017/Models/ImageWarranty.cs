using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TicketDeCaisse2017.Models
{
    public class ImageWarranty
    {
        [AutoIncrement]
        public int ID { get; set; }

        public string Url { get; set; }

        [Ignore]
        public ImageSource Image { get; set; }      

        public int IDWarranty { get; set; }

        public override string ToString()
        {
            return string.Format("[ImageWarranty: ID={0}, IDWarranty={1}]", ID, IDWarranty);
        }

    }
}

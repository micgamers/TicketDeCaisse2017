using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketDeCaisse2017.Models
{
    public class Warranty
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string StoreName { get; set; }

        public override string ToString()
        {
            return string.Format("[Warranty: ID={0}, Name={1}, StoreName={2}]", ID, Name, StoreName);
        }

    }
}

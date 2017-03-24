using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketDeCaisse2017.Models
{
    class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("[Person: ID={0}, FirstName={1}, LastName={2}]", ID, FirstName, LastName);
        }
    }
}

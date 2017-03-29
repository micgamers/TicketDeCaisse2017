using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;

namespace TicketDeCaisse2017.Services
{
    public class DatabaseManager
    {
        private SQLiteConnectionWithLock _Connection = null;

        

        private async Task<SQLiteConnectionWithLock> GetConnectionAsync()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
            string subFolderName = "DB";
            string path = Path.Combine(FileSystem.Current.LocalStorage.ToString(), subFolderName);
            string nameDatabase = "TicketDeCaisse2017DB.sqlite";

            string finalPath = Path.Combine(path, nameDatabase);
            if (_Connection == null)
            {
                //_Connection = new SQLiteConnectionWithLock(new SQLi, new SQLiteConnectionString(finalPath, storeDateTimeAsTicks: true));
                _Connection.BusyTimeout = new TimeSpan(0, 0, 1, 0);
#if DEBUG
                //_Connection.TraceListener = new TraceListener();
#endif
            }
            //_Connection.TraceListener = new DatabaseTraceListener();
            return _Connection;
        }

        public void CreateAllTable()
        {
            var conn = TDCServiceLocator.Instance.Database.GetConnectionAsync();
            //using (conn.Lock())
            //{
            //    conn.CreateTable<Models.Person>();
            //}

        }

    }
}

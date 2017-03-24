using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketDeCaisse2017.Services;
using Xamarin.Forms;
using TicketDeCaisse2017.UWP.Services;
using Windows.Storage;
using System.IO;

[assembly: Dependency(typeof(XSqliteServiceClient))]
namespace TicketDeCaisse2017.UWP.Services
{
    public class XSqliteServiceClient : IXSqliteService
    {
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            var dbPath = GetLocalFilePath("XamarinTemplate.db3");
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)));
            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);
            return asyncConnection;
        }

        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}

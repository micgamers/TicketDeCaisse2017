using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using System;
using Xamarin.Forms;
using TicketDeCaisse2017.UWP.Services;
using TicketDeCaisse2017.DependencyServices;
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

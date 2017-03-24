using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinIOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TicketDeCaisse2017.Services;
using Xamarin.Forms;
using TicketDeCaisse2017.iOS.Services;

[assembly: Dependency(typeof(XSqliteServiceClient))]
namespace TicketDeCaisse2017.iOS.Services
{
    public class XSqliteServiceClient : IXSqliteService
    {
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            const string sqliteFilename = "XamarinTemplate.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            var platform = new SQLitePlatformIOS();

            var connectionWithLock = new SQLiteConnectionWithLock(
            platform,
            new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}

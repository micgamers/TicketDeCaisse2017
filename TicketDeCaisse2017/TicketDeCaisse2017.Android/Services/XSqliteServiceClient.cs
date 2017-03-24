using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TicketDeCaisse2017.Services;
using TicketDeCaisse2017.Droid.Services;

[assembly: Dependency(typeof(XSqliteServiceClient))]
namespace TicketDeCaisse2017.Droid.Services
{
    public class XSqliteServiceClient : IXSqliteService
    {
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            const string sqliteFilename = "XamarinTemplate.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, sqliteFilename);

            var platform = new SQLitePlatformAndroid();

            var connectionWithLock = new SQLiteConnectionWithLock(
            platform,
            new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}
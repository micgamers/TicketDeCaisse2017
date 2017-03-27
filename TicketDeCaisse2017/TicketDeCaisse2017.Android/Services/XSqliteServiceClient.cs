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
using TicketDeCaisse2017.DependencyServices;
using TicketDeCaisse2017.Droid.Services;
using Xamarin.Forms;
using SQLite.Net.Async;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net;

[assembly: Dependency(typeof(XSqliteServiceClient))]
namespace TicketDeCaisse2017.Droid.Services
{
    public class XSqliteServiceClient : IXSqliteService
    {
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            const string sqliteFilename = "TicketDeCaisse2017DB.sqlite";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

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
﻿using SQLite;
using System;
using Xamarin.Forms;
using TicketDeCaisse2017.UWP.Services;
using TicketDeCaisse2017.DependencyServices;
using Windows.Storage;
using System.IO;

[assembly: Dependency(typeof(DatabaseClient))]
namespace TicketDeCaisse2017.UWP.Services
{
    public class DatabaseClient : IDatabaseService
    {
        public string GetAsyncConnection()
        {
            //var dbPath = GetLocalFilePath("XamarinTemplate.db3");
            //var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)));
            //var asyncConnection = new SQLiteAsyncConnection(connectionFactory);
            return GetLocalFilePath("TicketDeCaisse2017DB.sqlite"); 
        }

        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}

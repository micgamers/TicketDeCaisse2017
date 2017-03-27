using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketDeCaisse2017.DependencyServices;
using TicketDeCaisse2017.Models;
using Xamarin.Forms;

namespace TicketDeCaisse2017.Services
{
    public class XSqliteServiceClient : IXSqliteServiceClient
    {
        //private static readonly Lazy<XSqliteServiceClient> Lazy =
        //new Lazy<XSqliteServiceClient>(() => new XSqliteServiceClient());

        //public static IXSqliteServiceClient Instance => Lazy.Value;

        private SQLiteAsyncConnection _dbConnection;
        public SQLiteAsyncConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    LazyInitializer.EnsureInitialized(ref _dbConnection, DependencyService.Get<IXSqliteService>().GetAsyncConnection);
                }

                return _dbConnection;
            }
        }

        public void RunWithConnection(Action<SQLiteAsyncConnection> action)
        {
            var connection = _dbConnection;
            action.Invoke(connection);
        }

        //public async Task RunWithConnectionAsync(Action<SQLiteAsyncConnection> action)
        //{
        //    await AsyncExtensions.RunOnBackgroundThread(() =>
        //    {
        //        RunWithConnection(action);
        //    }).ConfigureAwait(false);
        //}

        public async void CreateDbIfNotExist()
        {
            await DbConnection.CreateTableAsync<Person>();
            Debug.WriteLine("Create db success!");
        }
    }
}

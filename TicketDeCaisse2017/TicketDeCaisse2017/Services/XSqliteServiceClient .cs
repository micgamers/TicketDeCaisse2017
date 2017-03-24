using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketDeCaisse2017.DependencyServices;
using Xamarin.Forms;

namespace TicketDeCaisse2017.Services
{
    public class XSqliteServiceClient : IXSqliteServiceClient
    {
        private static readonly Lazy<XSqliteServiceClient> Lazy =
        new Lazy<XSqliteServiceClient>(() => new XSqliteServiceClient());

        public static IXSqliteServiceClient Instance => Lazy.Value;

        private XSqliteServiceClient()
        {
        }

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

        public async void CreateDbIfNotExist()
        {
            await DbConnection.CreateTableAsync<YourModelHere>();
            Debug.WriteLine("Create db success!");
        }
    }
}

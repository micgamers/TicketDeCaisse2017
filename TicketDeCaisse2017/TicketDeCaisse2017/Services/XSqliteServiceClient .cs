using SQLite;
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
                    // LazyInitializer.EnsureInitialized(ref _dbConnection, DependencyService.Get<IXSqliteService>().GetAsyncConnection);

                    _dbConnection = new SQLiteAsyncConnection(DependencyService.Get<IXSqliteService>().GetAsyncConnection());                    

                    //var connectionWithLock = new SQLiteConnectionWithLock(
                    //platform,
                    //new SQLiteConnectionString(path, true));

                    //var connection = new SQLiteAsyncConnection(() => connectionWithLock);

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
            await DbConnection.CreateTableAsync<Warranty>();
            Debug.WriteLine("Create db success!");
        }

        public async void AddListPerson()
        {
            Person person1 = new Person()
            {
                FirstName = "Watrelot",
                LastName = "Mickael"
            };

            Person person2 = new Person()
            {
                FirstName = "Watrelot",
                LastName = "Robin"
            };

            Person person3 = new Person()
            {
                FirstName = "Dorchies",
                LastName = "Caroline"
            };

            List<Person> listPerson = new List<Person>();
            listPerson.Add(person1);
            listPerson.Add(person2);
            listPerson.Add(person3);

            await DbConnection.InsertAllAsync(listPerson);
        }

        public async void AddListWarranty()
        {
            Warranty warranty1 = new Warranty()
            {
                Name = "Watrelot",
                StoreName = "Boulanger"
            };

            Warranty warranty2 = new Warranty()
            {
                Name = "Watrelot",
                StoreName = "Auchan"
            };

            Warranty warranty3 = new Warranty()
            {
                Name = "Watrelot",
                StoreName = "Darty"
            };

            List<Warranty> listWarranty = new List<Warranty>();
            listWarranty.Add(warranty1);
            listWarranty.Add(warranty2);
            listWarranty.Add(warranty3);

            await DbConnection.InsertAllAsync(listWarranty);
        }

        public async void GetListPerson()
        {
            var result = await DbConnection.ExecuteScalarAsync<int>("select count(*) from Person");

            Debug.WriteLine(string.Format("Found '{0}' person items.", result));
        }

        public async Task<List<Warranty>> GetListWarranty()
        {
            List<Warranty> result = await DbConnection.ExecuteScalarAsync<List<Warranty>>("select * from Warranty");
            return result;            
        }
    }
}

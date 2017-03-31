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
        private static string CREATE_TABLE_WARRANTY = "CREATE TABLE IF NOT EXISTS Warranty (Name string, StoreName string, Url string, PRIMARY KEY(Name, StoreName))";
        private static string SELECT_ELEMENT_WARRANTY = "select * from Warranty";
        private SQLiteAsyncConnection _dbConnection;
        public SQLiteAsyncConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = new SQLiteAsyncConnection(DependencyService.Get<IXSqliteService>().GetAsyncConnection());                    
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

        public async Task CreateDbIfNotExist()
        {
            //await DbConnection.CreateTableAsync<Person>();
            //await DbConnection.CreateTableAsync<Warranty>();
            await DbConnection.ExecuteAsync(CREATE_TABLE_WARRANTY);

            Debug.WriteLine("Create db success!");
        }

        public async void AddListPerson()
        {
            Person person1 = new Person()
            {
                FirstName = "Watrelot",
                LastName = "Mickael"
            };

            await DbConnection.InsertOrReplaceAsync(person1);

            Person person2 = new Person()
            {
                FirstName = "Watrelot",
                LastName = "Robin"
            };

            await DbConnection.InsertOrReplaceAsync(person2);

            Person person3 = new Person()
            {
                FirstName = "Dorchies",
                LastName = "Caroline"
            };

            await DbConnection.InsertOrReplaceAsync(person3);
            
        }

        public async Task AddListWarranty()
        {
            Warranty warranty1 = new Warranty()
            {
                Name = "Watrelot",
                StoreName = "Boulanger",
                Url = @"C:\Users\occmo\Pictures\contenu\25_chat1280.jpg"
            };

            await DbConnection.InsertOrReplaceAsync(warranty1);


            Warranty warranty2 = new Warranty()
            {
                Name = "Watrelot",
                StoreName = "Auchan",
                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/ReceiptSwiss.jpg/200px-ReceiptSwiss.jpg"
            };

            await DbConnection.InsertOrReplaceAsync(warranty2);

            Warranty warranty3 = new Warranty()
            {
                Name = "Watrelot",
                StoreName = "Darty",
                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/ReceiptSwiss.jpg/200px-ReceiptSwiss.jpg"
            };

            await DbConnection.InsertOrReplaceAsync(warranty3);
        }

        public async Task AddWarranty(Warranty warranty)
        {
            await DbConnection.InsertOrReplaceAsync(warranty);
        }

        public async void GetListPerson()
        {
            var result = await DbConnection.Table<Person>().CountAsync();

            Debug.WriteLine(string.Format("Found '{0}' person items.", result));
        }

        public async Task<List<Warranty>> GetListWarranty()
        {
            try
            {
                List<Warranty> result = await DbConnection.Table<Warranty>().ToListAsync();
                return result;
            }
            catch(Exception e)
            {
                Debug.WriteLine(string.Format("Exception : '{0}'", e));
            }
            return null;
        }
    }
}

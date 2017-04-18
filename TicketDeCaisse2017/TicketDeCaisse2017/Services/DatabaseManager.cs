using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketDeCaisse2017.DependencyServices;
using TicketDeCaisse2017.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace TicketDeCaisse2017.Services
{
    public class DatabaseManager : IDatabaseManager
    {
        private static string CREATE_TABLE_WARRANTY = "CREATE TABLE IF NOT EXISTS Warranty (ID int, Name string, StoreName string, Url string, PRIMARY KEY(Name, StoreName))";
        private static string CREATE_TABLE_IMAGE_WARRANTY = "CREATE TABLE IF NOT EXISTS ImageWarranty (ID int, Url string, IDWarranty int, PRIMARY KEY(Url, IDWarranty))";
        private SQLiteAsyncConnection _dbConnection;
        public SQLiteAsyncConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = new SQLiteAsyncConnection(DependencyService.Get<IDatabaseService>().GetAsyncConnection());
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
            await DbConnection.ExecuteAsync(CREATE_TABLE_WARRANTY);
            await DbConnection.ExecuteAsync(CREATE_TABLE_IMAGE_WARRANTY); 
            Debug.WriteLine("Create db success!");
        }

        public async Task AddListWarranty()
        {
            Warranty warranty1 = new Warranty()
            {
                Name = "Watrelot",
                StoreName = "Boulanger",
                Url = @"C:\Users\micka\Pictures\20160319_175103.jpg"
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

        public async Task AddImageWarranty(Warranty warranty)
        {
            ImageWarranty warranty1 = new ImageWarranty()
            {
                IDWarranty = warranty.ID,
                Url = @"C:\Users\micka\Pictures\20160319_175103.jpg"
            };

            await DbConnection.InsertOrReplaceAsync(warranty1);

        }

        public async Task AddWarranty(Warranty warranty)
        {
            await DbConnection.InsertOrReplaceAsync(warranty);
        }

        public async Task<List<Warranty>> GetListWarranty()
        {
            try
            {
                List<Warranty> result = await DbConnection.Table<Warranty>().ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format("Exception : '{0}'", e));
            }
            return null;
        }

        public async Task<List<ImageWarranty>> GetListImageWarranty(Warranty warranty)
        {
            try
            {
                List<ImageWarranty> result = await DbConnection.Table<ImageWarranty>().Where(p => p.IDWarranty.Equals(warranty.ID)).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format("Exception : '{0}'", e));
            }
            return null;
        }

        public async Task<ImageWarranty> GetImageWarranty(Warranty warranty, int idImage)
        {                     
            try
            {
                ImageWarranty result = await DbConnection.Table<ImageWarranty>().Where(p => p.IDWarranty.Equals(warranty.ID) && p.ID.Equals(idImage)).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format("Exception : '{0}'", e));
            }
            return null;
        }
    }
}

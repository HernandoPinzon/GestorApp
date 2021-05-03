using Gestor.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.data
{
    public class DataBaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }
        public DataBaseContext(string path)
        {
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<Archivo>().Wait();
        }

        public async Task<int> InsertarItemAsync(Archivo item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<List<Archivo>> ObtenerItemsAsync()
        {
            return await Connection.Table<Archivo>().ToListAsync();
        }

        public async Task<int> EliminarItemAsync(Archivo item)
        {
            return await Connection.DeleteAsync(item);
        }

        public async Task<int> EliminarByKeyAsync(int key)
        {
            return await Connection.DeleteAsync<Archivo>(key);
        }
        
        public async Task<List<Archivo>> PruebaAsync(int Father)
        {
            //return await Connection.QueryAsync<Archivo>("select * FROM Archivo WHERE Father={0}",Father);
            return await Connection.Table<Archivo>().Where(v => v.Father==Father).ToListAsync();
        }
    }
}

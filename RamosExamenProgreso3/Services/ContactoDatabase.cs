using SQLite;
using RamosExamenProgreso3.Models;

namespace RamosExamenProgreso3.Services
{
    public class ContactoDatabase
    {
        SQLiteAsyncConnection _database;

        public ContactoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contacto>().Wait();
        }

        public Task<List<Contacto>> GetContactosAsync() =>
            _database.Table<Contacto>().ToListAsync();

        public Task<int> SaveContactoAsync(Contacto contacto) =>
            _database.InsertAsync(contacto);
    }
}

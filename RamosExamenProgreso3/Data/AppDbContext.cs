using SQLite;
using RamosExamenProgreso3.Models;

namespace RamosExamenProgreso3.Data
{
    public class AppDbContext
    {
        private readonly SQLiteAsyncConnection _database;

        public AppDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contacto>().Wait();
        }

        public Task<int> InsertContactoAsync(Contacto contacto)
            => _database.InsertAsync(contacto);

        public Task<List<Contacto>> GetContactosAsync()
            => _database.Table<Contacto>().ToListAsync();
    }
}

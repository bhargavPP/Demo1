using Demo1.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
 

namespace Demo1.Data
{
    public class DBInitializer : IDBInitializer
    {
        private readonly Demo1DbContext _db;

        public DBInitializer(Demo1DbContext db)
        {
            _db = db;
        }
        public async void Initialize()
        {
            //add pending migration if exists
            if (_db.Database.GetPendingMigrations().Count() > 0)
            { _db.Database.Migrate(); }

        }
    }
}

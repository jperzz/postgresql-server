using Microsoft.EntityFrameworkCore;
using postgresql_server.DataBase.Entities;
using PostgreSqlServer.Controllers;

namespace postgresql_server.DataBase;

public class MyDataBase : DbContext
{
    private const string DATABASE_FILENAME = "coches.db";
    public DbSet<Car> Cars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        options.UseSqlite($"DataSource={baseDir}{DATABASE_FILENAME}");
    }
}

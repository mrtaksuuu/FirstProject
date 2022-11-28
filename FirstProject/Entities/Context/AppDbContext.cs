using Microsoft.EntityFrameworkCore;

namespace FirstProject.Entities.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }

        //SqlDatabase için tablolar oluşturuldu. appsettings.json içerisine ConnectionStrings yapıldı. Program.cs içerisinde AddDbContext servislere eklendi

    }
}

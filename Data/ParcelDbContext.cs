using Belsis_Parselasyon_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Belsis_Parselasyon_Backend.Data
{
    public class ParcelDbContext : DbContext
    {
        public ParcelDbContext(DbContextOptions<ParcelDbContext> options) : base(options)
        {
        }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<City> Cities { get; set; }
    }


}

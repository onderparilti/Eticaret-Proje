using EticaretProje.Models;
using Microsoft.EntityFrameworkCore;

namespace EticaretProje.Data
{
    public class EticaretDBContext : DbContext
    {
        

        public EticaretDBContext(DbContextOptions<EticaretDBContext> options)
     : base(options)
        {
        }


        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Satis> Satis { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        

    }
}


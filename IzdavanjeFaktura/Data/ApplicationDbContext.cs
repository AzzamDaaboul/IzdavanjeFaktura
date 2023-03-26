using IzdavanjeFaktura.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IzdavanjeFaktura.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Faktura> Fakture { get; set; }
        public virtual DbSet<FakturaStavka> FakturaStavke { get; set; }
    }
}
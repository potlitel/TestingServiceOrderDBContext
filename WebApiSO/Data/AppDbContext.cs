using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Context;
using FSA.Core.ServiceOrders.Models;
using Microsoft.EntityFrameworkCore;
using WebApiSO.Models;

namespace WebApiSO.Data
{
    public class AppDbContext : ServiceOrderContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessorManager httpContextAccessorManager)
            : base(options, httpContextAccessorManager)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomServiceOrderTask>();

            modelBuilder.Entity<ServiceOrderTask>()
            .HasDiscriminator<string>("TypeEntity")
            .HasValue<CustomServiceOrderTask>("CustomServiceOrderTask");

            modelBuilder.Entity<CustomServiceOrder>(e =>
            {
            });

            modelBuilder.Entity<CustomServiceOrderRegister>(e =>
            {
            });

            //modelBuilder.Entity<CustomServiceOrderRegister>()
            //.HasOne(c => c.ServiceOrder)
            //.WithMany(c => c.)
            //.HasForeignKey(c => c.SpeakerId)
            //.OnDelete(DeleteBehavior.NoAction);
        }
    }
}

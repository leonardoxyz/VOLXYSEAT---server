using Microsoft.EntityFrameworkCore;
using VOLXYSEAT.DOMAIN.Core;
using VOLXYSEAT.DOMAIN.Models;
using MediatR;

namespace VOLXYSEAT.INFRASTRUCTURE.Data
{
    public class DataContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public const string DEFAULT_SCHEMA = "volxyseat";
        public DataContext(DbContextOptions<DataContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SubscriptionHistory> SubscriptionHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            modelBuilder.Entity<Subscription>()
                .HasMany(s => s.History)
                .WithOne()
                .HasForeignKey(h => h.SubscriptionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subscription_SubscriptionHistory");

        }
    }
}

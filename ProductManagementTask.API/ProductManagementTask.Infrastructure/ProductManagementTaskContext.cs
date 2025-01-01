using ProductManagementTask.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProductManagementTask.Domain.Entities.Common;
using System.Security.Claims;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.SharedKernal.Services;
using ProductManagementTask.Applications.Common.Interfaces;

namespace ProductManagementTask.Infrastructure
{
    public class ProductManagementTaskContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IProductManagementTaskDbContext
    {
        private readonly CurrentUserService _currentUserService;
        public ProductManagementTaskContext(DbContextOptions<ProductManagementTaskContext> options, CurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<T> GetDbSet<T>() where T : class  =>  Set<T>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Apply all IEntityTypeConfiguration implementations
            builder.ApplyConfigurationsFromAssembly(typeof(ProductManagementTaskContext).Assembly);

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            SetAuditColumns();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditColumns();
            return base.SaveChangesAsync(cancellationToken);
        }
        public override ValueTask DisposeAsync()
        {
            return base.DisposeAsync();
        }
        public override void Dispose()
        {
            base.Dispose();
        }
        private void SetAuditColumns()
        {
            var entries = ChangeTracker.Entries<BaseAuditEntity<long>>();
            var userId = _currentUserService.GetNameIdentifier();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = userId;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedAt = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = userId;
                }
            }
        }
    }
}

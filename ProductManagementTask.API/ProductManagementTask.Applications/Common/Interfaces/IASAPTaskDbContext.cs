using ProductManagementTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Common.Interfaces
{
    public interface IProductManagementTaskDbContext
    {
        public DbSet<ProductManagementTask.Domain.Entities.Product> Products { get; set; }
        DbSet<T> GetDbSet<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        ValueTask DisposeAsync();
        void Dispose();
    }
}

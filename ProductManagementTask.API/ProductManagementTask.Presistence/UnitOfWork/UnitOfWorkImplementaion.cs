using ProductManagementTask.Applications.Common.Interfaces;
using ProductManagementTask.Domain.Entities.Common;
using ProductManagementTask.Applications.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementTask.Presistence.Repositories.GenericRepo;

namespace ProductManagementTask.Presistence.UnitOfWork
{
    internal class UnitOfWorkImplementaion : IUnitOfWork
    {
        private readonly IProductManagementTaskDbContext _context;
        public UnitOfWorkImplementaion(IProductManagementTaskDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, object> repositories;
        public IGenericRepo<T,TType> Repository<T, TType>() where TType : struct where T : BaseEntity<TType>
        {
            if (repositories == null)
                repositories = new Dictionary<string, object>();

            string type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repositoryInstance = Activator.CreateInstance(typeof(GenericRepo<,>).MakeGenericType(typeof(T), typeof(TType)), _context);
                repositories.Add(type, repositoryInstance);
            }
            return (GenericRepo<T, TType>)repositories[type];
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

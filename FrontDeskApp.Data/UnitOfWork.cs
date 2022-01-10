using System.Threading.Tasks;
using FrontDeskApp.Core;
using FrontDeskApp.Core.Repositories;
using FrontDeskApp.Data.Repositories;

namespace FrontDeskApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FrontDeskAppDbContext _context;
        private CustomerRepository _customerRepository;
        private StorageRepository _storageRepository;
        private StorageFacilityRepository _storageFacilityRepository;

        public UnitOfWork(FrontDeskAppDbContext context)
        {
            this._context = context;
        }

        public IStorageRepository Storages => _storageRepository ??= new StorageRepository(_context);

        public IStorageFacilityRepository StorageFacilities => _storageFacilityRepository ??= new StorageFacilityRepository(_context);

        public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

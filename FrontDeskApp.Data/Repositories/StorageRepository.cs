using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrontDeskApp.Core.Models;
using FrontDeskApp.Core.Repositories;
using FrontDeskApp.Core.Extensions;

namespace FrontDeskApp.Data.Repositories
{
    public class StorageRepository : Repository<Storage>, IStorageRepository
    {
        public StorageRepository(FrontDeskAppDbContext context)
            : base(context)
        { }

        private FrontDeskAppDbContext FrontDeskAppDbContext
        {
            get { return Context as FrontDeskAppDbContext; }
        }

        public async Task<IEnumerable<Storage>> GetAllStorageAsync()
        {
            return await FrontDeskAppDbContext.Storages
                .Include(a => a.Customer)
                .Include(a => a.StorageFacility)
                .ToListAsync();
        }

        public async Task<Storage> GetAllStorageByCustomerIdAsync(int customerId)
        {
            return await FrontDeskAppDbContext.Storages
               .Include(a => a.StorageFacility)
               .SingleOrDefaultAsync(m => m.CustomerId == customerId);
        }

        public async Task<int> GetUsedStorageCount(int storageFacilityId)
        {
            return await FrontDeskAppDbContext.Storages
                .CountAsync(m => m.StorageFacilityId == storageFacilityId && m.StorageStatus == StatusTypes.Stored);
        }

        public async Task<Storage> GetWithStorageByIdAsync(int storageId)
        {
            return await FrontDeskAppDbContext.Storages
               .Include(a => a.Customer)
               .Include(a => a.StorageFacility)
               .SingleOrDefaultAsync(m => m.StorageId == storageId);
        }


    }
}

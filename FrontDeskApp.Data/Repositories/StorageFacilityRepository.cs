using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrontDeskApp.Core.Models;
using FrontDeskApp.Core.Repositories;
using FrontDeskApp.Core.Extensions;

namespace FrontDeskApp.Data.Repositories
{
    public class StorageFacilityRepository : Repository<StorageFacility>, IStorageFacilityRepository
    {
        public StorageFacilityRepository(FrontDeskAppDbContext context)
         : base(context)
        { }

        private FrontDeskAppDbContext FrontDeskAppDbContext
        {
            get { return Context as FrontDeskAppDbContext; }
        }

        public Task<IEnumerable<StorageFacility>> GetAllStorageFacilityAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<StorageFacility> GetStorageFacilityByFacilityIdAndStorageTypeAsync(int facilityId, StorageTypes storageType)
        {
            return await FrontDeskAppDbContext.StorageFacilities
              .SingleOrDefaultAsync(m => m.FacilityId == facilityId && m.StorageType == storageType.Description().ToString());
        }
    }
}

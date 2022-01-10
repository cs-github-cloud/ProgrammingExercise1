using System.Collections.Generic;
using System.Threading.Tasks;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Core.Repositories
{
    public interface IStorageFacilityRepository : IRepository<StorageFacility>
    {
        Task<IEnumerable<StorageFacility>> GetAllStorageFacilityAsync();
        Task<StorageFacility> GetStorageFacilityByFacilityIdAndStorageTypeAsync(int facilityId, StorageTypes storageType);

    }
}

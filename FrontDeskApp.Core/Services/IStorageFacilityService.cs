using System.Collections.Generic;
using System.Threading.Tasks;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Core.Services
{
    public interface IStorageFacilityService
    {
        Task<IEnumerable<StorageFacility>> GetAllWithStorageFacility();
        Task<StorageFacility> GetStorageFacilityById(int storageFacilityId);
    }
}

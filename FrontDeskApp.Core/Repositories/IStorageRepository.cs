using System.Collections.Generic;
using System.Threading.Tasks;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Core.Repositories
{
    public interface IStorageRepository : IRepository<Storage>
    {
        Task<IEnumerable<Storage>> GetAllStorageAsync();
        Task<Storage> GetWithStorageByIdAsync(int storageId);
        Task<Storage> GetAllStorageByCustomerIdAsync(int customerId);

        Task<int> GetUsedStorageCount(int storageFacilityId);
    }
}

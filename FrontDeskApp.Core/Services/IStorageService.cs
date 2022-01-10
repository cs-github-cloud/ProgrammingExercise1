using System.Collections.Generic;
using System.Threading.Tasks;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Core.Services
{
    public interface IStorageService
    {
        Task<IEnumerable<Storage>> GetAllWithStorage();
        Task<Storage> GetStorageById(int storageId);
        Task<Storage> GetWithStorageByCustomerId(int customerId);
        Task<Storage> CreateStorage(Storage newStorage);
        Task UpdateStorage(Storage storageToBeUpdated);
        Task DeleteStorage(Storage storage);

        Task<int> GetStorageCount(int facilityId, StorageTypes storageType);
    }
}

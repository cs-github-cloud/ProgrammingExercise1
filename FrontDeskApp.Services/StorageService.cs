using System.Collections.Generic;
using System.Threading.Tasks;
using FrontDeskApp.Core;
using FrontDeskApp.Core.Models;
using FrontDeskApp.Core.Services;

namespace FrontDeskApp.Services
{

    public class StorageService : IStorageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StorageService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Storage> CreateStorage(Storage newStorage)
        {
            newStorage.StorageStatus = StatusTypes.Stored;
            await _unitOfWork.Storages
               .AddAsync(newStorage);
            await _unitOfWork.CommitAsync();

            return newStorage;
        }

        public Task DeleteStorage(Storage storage)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Storage>> GetAllWithStorage()
        {
            return await _unitOfWork.Storages.GetAllAsync();
        }

        public async Task<Storage> GetStorageById(int storageId)
        {
            return await _unitOfWork.Storages.GetByIdAsync(storageId);
        }

        public async Task<Storage> GetWithStorageByCustomerId(int customerId)
        {
            return await _unitOfWork.Storages.GetAllStorageByCustomerIdAsync(customerId);
        }

        public async Task UpdateStorage(Storage storageToBeUpdated)
        {
            storageToBeUpdated.StorageStatus = StatusTypes.Retrieved;
            storageToBeUpdated.CustomerId = storageToBeUpdated.CustomerId;
            storageToBeUpdated.StorageFacilityId = storageToBeUpdated.StorageFacilityId;
            await _unitOfWork.CommitAsync();
        }

        public async Task<int> GetStorageCount(int facilityId, StorageTypes storageType)
        {
            var storageFacility = await _unitOfWork.StorageFacilities.GetStorageFacilityByFacilityIdAndStorageTypeAsync(facilityId, storageType);
            var usedStorageCount = await _unitOfWork.Storages.GetUsedStorageCount(storageFacility.StorageFacilityId);

            return storageFacility.SlotCount - usedStorageCount;
        }
    }
}

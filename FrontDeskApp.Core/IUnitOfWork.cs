using System;
using System.Threading.Tasks;
using FrontDeskApp.Core.Repositories;

namespace FrontDeskApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IStorageRepository Storages { get; }

        IStorageFacilityRepository StorageFacilities { get; }

        ICustomerRepository Customers { get; }

        Task<int> CommitAsync();
    }
}

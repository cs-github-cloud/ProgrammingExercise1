
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Api.Resources
{
    public class StorageResource
    {
        public int StorageId { get; set; }
        public int StorageFacilityId { get; set; }
        public StorageFacility StorageFacility { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public StatusTypes StorageStatus { get; set; }
    }
}

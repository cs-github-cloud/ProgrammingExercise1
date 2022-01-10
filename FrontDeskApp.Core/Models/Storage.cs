using System.ComponentModel;

namespace FrontDeskApp.Core.Models
{
    public class Storage
    {
        public int StorageId { get; set; }
        public int StorageFacilityId { get; set; }
        public StorageFacility StorageFacility { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public StatusTypes StorageStatus { get; set; }
    }

    public enum StatusTypes
    {
        [Description("Stored")]
        Stored = 1,
        [Description("Retrieved")]
        Retrieved = 2
    }
}

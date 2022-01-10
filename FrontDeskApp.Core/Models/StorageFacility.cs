using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace FrontDeskApp.Core.Models
{
    public class StorageFacility
    {
        public int StorageFacilityId { get; set; }
        public string StorageType { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int SlotCount { get; set; }

}

    public enum StorageTypes
    {
        [Description("Small")]
        Small = 1,
        [Description("Medium")]
        Medium = 2,
        [Description("Large")]
        Large = 3
    }


}

using System;
using System.Collections.Generic;

namespace eSya.ManageInventory.DL.Entities
{
    public partial class GtEiitcd
    {
        public GtEiitcd()
        {
            GtEipaits = new HashSet<GtEipait>();
        }

        public int ItemCode { get; set; }
        public int ItemGroup { get; set; }
        public int ItemCategory { get; set; }
        public int ItemSubCategory { get; set; }
        public string ItemDescription { get; set; } = null!;
        public int UnitOfMeasure { get; set; }
        public int PackSize { get; set; }
        public string InventoryClass { get; set; } = null!;
        public string ItemClass { get; set; } = null!;
        public string ItemSource { get; set; } = null!;
        public string ItemCriticality { get; set; } = null!;
        public bool IsBusinessLinked { get; set; }
        public bool IsHsnlinked { get; set; }
        public string? BarcodeCodeId { get; set; }
        public bool UsageStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; } = null!;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedTerminal { get; set; }

        public virtual ICollection<GtEipait> GtEipaits { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.DO
{
    public class DO_ItemServiceLink
    {
        public int BusinessKey { get; set; }
        public int ServiceClass { get; set; }
        public int ServiceID { get; set; }
        public int SKUID { get; set; }
        public string? SKUType { get; set; }
        public string? ItemDescription { get; set; }
        public double Quantity { get; set; }
        public bool ActiveStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.DO
{
    public class DO_UnitsofMeasure
    {
        public int UnitOfMeasure { get; set; }
        public string Uompurchase { get; set; }
        public string Uomstock { get; set; }
        public string Uompdesc { get; set; }
        public string Uomsdesc { get; set; }
        public decimal ConversionFactor { get; set; }
        public bool ActiveStatus { get; set; }
    }
}

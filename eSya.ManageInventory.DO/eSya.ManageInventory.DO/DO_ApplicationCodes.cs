using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.DO
{
    public class DO_ApplicationCodes
    {
        public int ApplicationCode { get; set; }
        public int CodeType { get; set; }
        public string CodeDesc { get; set; }
    }
    public class DO_UnitofMeasure
    {
        public int UnitOfMeasure { get; set; }
        public string UnitOfMeasureDesc { get; set; }
        public decimal ConversionFactor { get; set; }
        public bool ActiveStatus { get; set; }
    }
}

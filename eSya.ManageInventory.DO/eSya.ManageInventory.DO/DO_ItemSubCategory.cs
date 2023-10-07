﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.DO
{
    public class DO_ItemSubCategory
    {
        public int ItemGroupId { get; set; }
        public int ItemCategory { get; set; }
        public int? ItemSubCategory { get; set; }
        public string ItemSubCategoryDesc { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string TerminalID { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.DO
{
    public class DO_BusinessLocation
    {
        public int BusinessKey { get; set; }
        public string LocationDescription { get; set; }
    }

    public class DO_Services
    {
        public int ServiceClassId { get; set; }
        public string ServiceClassDesc { get; set; }

        public int ServiceId { get; set; }
        public string ServiceDesc { get; set; }
    }
}

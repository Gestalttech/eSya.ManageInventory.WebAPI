using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.DO
{
    public class DO_ItemStoreLink
    {
        public int BusinessKey { get; set; }
        public int ItemCode { get; set; }
        public int StoreCode { get; set; }
        public string? StoreId { get; set; }
        public string? StoreDesc { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        public List<DO_ItemStoreLink>? lst_itemStoreLink { get; set; }
    }
    public class DO_StoreBusinessLink
    {
        public int BusinessKey { get; set; }
        public int StoreCode { get; set; }
        public int PortfolioId { get; set; }
        public string? PortfolioDesc { get; set; }
        public bool ActiveStatus { get; set; }
    }
}

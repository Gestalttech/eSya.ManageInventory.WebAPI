using eSya.ManageInventory.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.IF
{
    public interface IItemCodesRepository
    {
        Task<List<DO_ItemCodes>> GetItemList();
        Task<List<DO_ItemCodes>> GetItemMaster(int ItemGroup, int ItemCategory, int ItemSubCategory);
        Task<List<DO_ItemCodes>> GetItemDetails(int ItemCode);
        Task<DO_ItemCodes> GetItemParameterList(int ItemCode);
        Task<DO_ReturnParameter> InsertItemCodes(DO_ItemCodes itemCodes);
        Task<DO_ReturnParameter> UpdateItemCodes(DO_ItemCodes itemCodes);
    }
}

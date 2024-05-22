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
        #region Item Master
        Task<List<DO_ItemCodes>> GetItemList();
        Task<List<DO_ItemCodes>> GetItemMaster(int ItemGroup, int ItemCategory, int ItemSubCategory);
        Task<List<DO_ItemCodes>> GetItemDetails(int ItemCode);
        Task<DO_ItemCodes> GetItemParameterList(int ItemCode);
        Task<DO_ReturnParameter> InsertItemCodes(DO_ItemCodes itemCodes);
        Task<DO_ReturnParameter> UpdateItemCodes(DO_ItemCodes itemCodes);
        #endregion Item Master

        #region Business Item Store Link
        Task<List<DO_ItemStoreLink>> GetBusinessItemStoreLink(int BusinessKey, int ItemCode);
        Task<List<DO_StoreBusinessLink>> GetPortfolioStoreInfo(int BusinessKey, int StoreCode);
        Task<DO_ReturnParameter> InsertOrUpdateBusinessItemStoreLink(List<DO_ItemStoreLink> obj);
        #endregion Business Item Store Link
    }
}

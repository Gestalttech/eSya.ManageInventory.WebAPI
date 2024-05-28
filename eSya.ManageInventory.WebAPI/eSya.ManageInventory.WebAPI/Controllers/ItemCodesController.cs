using eSya.ManageInventory.DO;
using eSya.ManageInventory.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSya.ManageInventory.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemCodesController : ControllerBase
    {
        private readonly IItemCodesRepository _ItemCodesRepository;
        public ItemCodesController(IItemCodesRepository itemCodesRepository)
        {
            _ItemCodesRepository = itemCodesRepository;
        }

        #region Item Master
        /// <summary>
        /// Getting  Item LIst.
        /// UI Reffered - Item Codes
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItemList()
        {
            var i_Codes = await _ItemCodesRepository.GetItemList();
            return Ok(i_Codes);
        }

        /// <summary>
        /// Getting  Selected Item Details.
        /// UI Reffered - Item Codes
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItemDetails(int ItemCode)
        {
            var i_Codes = await _ItemCodesRepository.GetItemDetails(ItemCode);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Getting  Item Master LIst.
        /// UI Reffered - Item Codes
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItemMaster(int ItemGroup, int ItemCategory, int ItemSubCategory)
        {
            var i_Codes = await _ItemCodesRepository.GetItemMaster(ItemGroup, ItemCategory, ItemSubCategory);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Getting  Item Parameter List.
        /// UI Reffered - Item Codes
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItemParameterList(int ItemCode)
        {
            var i_Codes = await _ItemCodesRepository.GetItemParameterList(ItemCode);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Insert Item Codes.
        /// UI Reffered - Item Codes
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertItemCodes(DO_ItemCodes ItemCodes)
        {
            var msg = await _ItemCodesRepository.InsertItemCodes(ItemCodes);
            return Ok(msg);
        }

        /// <summary>
        /// Update Item Codes.
        /// UI Reffered - Item Codes
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateItemCodes(DO_ItemCodes ItemCodes)
        {
            var msg = await _ItemCodesRepository.UpdateItemCodes(ItemCodes);
            return Ok(msg);

        }

        #endregion Item Master

        #region Business Item Store Link

        /// <summary>
        /// Getting  Store List, Business Key and Item Wise.
        /// UI Reffered - Item Store Link
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetBusinessItemStoreLink(int BusinessKey, int ItemCode)
        {
            var i_Codes = await _ItemCodesRepository.GetBusinessItemStoreLink(BusinessKey, ItemCode);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Getting  Store Portfolio.
        /// UI Reffered - Item Store Link
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPortfolioStoreInfo(int BusinessKey, int StoreCode)
        {
            var i_Codes = await _ItemCodesRepository.GetPortfolioStoreInfo(BusinessKey, StoreCode);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Insert Business Item Store Link.
        /// UI Reffered - Item Store Link
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateBusinessItemStoreLink(List<DO_ItemStoreLink> ItemStoreLink)
        {
            var msg = await _ItemCodesRepository.InsertOrUpdateBusinessItemStoreLink(ItemStoreLink);
            return Ok(msg);
        }
        #endregion Business Item Store Link

        #region Item Service Link
        /// <summary>
        /// Getting  Item List, Business Key and Service Wise.
        /// UI Reffered - Item Store Link
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetServiceItemLinkInfo(int BusinessKey, int ServiceClass, int ServiceId)
        {
            var i_Codes = await _ItemCodesRepository.GetServiceItemLinkInfo(BusinessKey, ServiceClass, ServiceId);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Insert Business Service Item Link.
        /// UI Reffered - Item Store Link
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateServiceItemLink(List<DO_ItemServiceLink> ServiceItemLink)
        {
            var msg = await _ItemCodesRepository.InsertOrUpdateServiceItemLink(ServiceItemLink);
            return Ok(msg);
        }
        #endregion Item Service Link
    }
}

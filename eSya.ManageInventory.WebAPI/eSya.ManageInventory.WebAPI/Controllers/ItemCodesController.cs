﻿using eSya.ManageInventory.DO;
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


    }
}

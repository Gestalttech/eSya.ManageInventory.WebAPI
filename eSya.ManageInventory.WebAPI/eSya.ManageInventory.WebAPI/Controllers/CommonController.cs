﻿using eSya.ManageInventory.DL.Repository;
using eSya.ManageInventory.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSya.ManageInventory.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonRepository _commonRepository;
        public CommonController(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        /// <summary>
        /// Getting  Application Codes.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetApplicationCodesByCodeType(int codeType)
        {
            var ds = await _commonRepository.GetApplicationCodesByCodeType(codeType);
            return Ok(ds);
        }
        /// <summary>
        /// Getting Get Unit of Measure.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUnitofMeasure()
        {
            var ds = await _commonRepository.GetUnitofMeasure();
            return Ok(ds);
        }
        /// <summary>
        /// Getting  Item Group.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItemGroup()
        {
            var ds = await _commonRepository.GetItemGroup();
            return Ok(ds);
        }

        /// <summary>
        /// Getting  Item Category.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItemCategory(int ItemGroup)
        {
            var ds = await _commonRepository.GetItemCategory(ItemGroup);
            return Ok(ds);
        }

        /// <summary>
        /// Getting  Item Sub Category.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItemSubCategory(int ItemCategory)
        {
            var ds = await _commonRepository.GetItemSubCategory(ItemCategory);
            return Ok(ds);
        }

        /// <summary>
        /// Get Business key.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBusinessKey()
        {
            var ds = await _commonRepository.GetBusinessKey();
            return Ok(ds);
        }

        /// <summary>
        /// Get ServiceClass.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetServiceClass()
        {
            var ds = await _commonRepository.GetServiceClass();
            return Ok(ds);
        }

        /// <summary>
        /// Getting  Store List, Business Key and Item Wise.
        /// UI Reffered - Item Store Link
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetServices(int BusinessKey, int ServiceClassId)
        {
            var i_Codes = await _commonRepository.GetServices(BusinessKey, ServiceClassId);
            return Ok(i_Codes);
        }
    }
}

using eSya.ManageInventory.DO;
using eSya.ManageInventory.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSya.ManageInventory.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryRulesController : ControllerBase
    {
        private readonly IInventoryRulesRepository _rulesRepository;
        public InventoryRulesController(IInventoryRulesRepository rulesRepository)
        {
            _rulesRepository = rulesRepository;
        }
        #region Unit of Measure
        /// <summary>
        /// Getting  Unit of Measure List.
        /// UI Reffered - Unit of Measure Grid
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUnitofMeasurements()
        {
            var unit_measures = await _rulesRepository.GetUnitofMeasurements();
            return Ok(unit_measures);
        }
        /// <summary>
        /// Insert Or Update Unit of Measure .
        /// UI Reffered -Unit of Measure
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateUnitofMeasurement(DO_UnitofMeasure uoms)
        {
            var msg = await _rulesRepository.InsertOrUpdateUnitofMeasurement(uoms);
            return Ok(msg);

        }
        /// <summary>
        /// Getting  Unit of Measure Purchase description by UOMP Code.
        /// UI Reffered - Unit of Measure
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUOMPDescriptionbyUOMP(string uomp)
        {
            var unit_measures = await _rulesRepository.GetUOMPDescriptionbyUOMP(uomp);
            return Ok(unit_measures);
        }
        /// <summary>
        /// Getting  Unit of Measure Stock description by UOMS Code.
        /// UI Reffered - Unit of Measure
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUOMSDescriptionbyUOMS(string uoms)
        {
            var unit_measures = await _rulesRepository.GetUOMSDescriptionbyUOMS(uoms);
            return Ok(unit_measures);
        }
        /// <summary>
        /// Active Or De Active Unit of Measurement.
        /// UI Reffered - Unit of Measurement
        /// </summary>
        /// <param name="status-unitId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ActiveOrDeActiveUnitofMeasure(bool status, int unitId)
        {
            var msg = await _rulesRepository.ActiveOrDeActiveUnitofMeasure(status, unitId);
            return Ok(msg);
        }
        #endregion
    }
}

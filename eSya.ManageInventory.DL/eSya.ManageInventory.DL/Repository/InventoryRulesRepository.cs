using eSya.ManageInventory.DL.Entities;
using eSya.ManageInventory.DO;
using eSya.ManageInventory.IF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.DL.Repository
{
    public class InventoryRulesRepository: IInventoryRulesRepository
    {
        private readonly IStringLocalizer<InventoryRulesRepository> _localizer;
        public InventoryRulesRepository(IStringLocalizer<InventoryRulesRepository> localizer)
        {
            _localizer = localizer;
        }
        #region Unit of Measure
        public async Task<List<DO_UnitofMeasure>> GetUnitofMeasurements()
        {
            try
            {
                using (eSyaEnterprise db = new eSyaEnterprise())
                {
                    var result = db.GtEciuoms

                                  .Select(u => new DO_UnitofMeasure
                                  {
                                      UnitOfMeasure = u.UnitOfMeasure,
                                      Uompurchase = u.Uompurchase,
                                      Uomstock = u.Uomstock,
                                      Uompdesc = u.Uompdesc,
                                      Uomsdesc = u.Uomsdesc,
                                      ConversionFactor = u.ConversionFactor,
                                      ActiveStatus = u.ActiveStatus
                                  }).OrderBy(o => o.UnitOfMeasure).ToListAsync();
                    return await result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateUnitofMeasurement(DO_UnitofMeasure uoms)
        {
            try
            {
                if (uoms.UnitOfMeasure != 0)
                {
                    return await UpdateUnitofMeasurement(uoms);
                }
                else
                {
                    return await InsertUnitofMeasurement(uoms);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DO_ReturnParameter> InsertUnitofMeasurement(DO_UnitofMeasure uoms)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEciuom isUompExists = db.GtEciuoms.FirstOrDefault(u => u.Uompurchase.ToUpper().Replace(" ", "") == uoms.Uompurchase.ToUpper().Replace(" ", "") &&
                        u.Uomstock.ToUpper().Replace(" ", "") == uoms.Uomstock.ToUpper().Replace(" ", ""));
                        if (isUompExists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0137", Message = string.Format(_localizer[name: "W0137"]) };
                        }

                        int maxval = db.GtEciuoms.Select(c => c.UnitOfMeasure).DefaultIfEmpty().Max();
                        int uomId = maxval + 1;
                        var objuom = new GtEciuom
                        {
                            UnitOfMeasure = uomId,
                            Uompurchase = uoms.Uompurchase,
                            Uomstock = uoms.Uomstock,
                            Uompdesc = uoms.Uompdesc,
                            Uomsdesc = uoms.Uomsdesc,
                            ConversionFactor = uoms.ConversionFactor,
                            ActiveStatus = uoms.ActiveStatus,
                            FormId = uoms.FormId,
                            CreatedBy = uoms.UserID,
                            CreatedOn = DateTime.Now,
                            CreatedTerminal = uoms.TerminalID
                        };
                        db.GtEciuoms.Add(objuom);
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, StatusCode = "S0001", Message = string.Format(_localizer[name: "S0001"]) };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateUnitofMeasurement(DO_UnitofMeasure uoms)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEciuom isUompExists = db.GtEciuoms.FirstOrDefault(u => u.Uompurchase.ToUpper().Replace(" ", "") == uoms.Uompurchase.ToUpper().Replace(" ", "") &&
                       u.Uomstock.ToUpper().Replace(" ", "") == uoms.Uomstock.ToUpper().Replace(" ", "") && u.UnitOfMeasure != uoms.UnitOfMeasure);
                        if (isUompExists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0137", Message = string.Format(_localizer[name: "W0137"]) };

                        }

                        GtEciuom objuoms = db.GtEciuoms.Where(x => x.UnitOfMeasure == uoms.UnitOfMeasure).FirstOrDefault();

                        objuoms.Uompurchase = uoms.Uompurchase;
                        objuoms.Uomstock = uoms.Uomstock;
                        objuoms.Uompdesc = uoms.Uompdesc;
                        objuoms.Uomsdesc = uoms.Uomsdesc;
                        objuoms.ConversionFactor = uoms.ConversionFactor;
                        objuoms.ActiveStatus = uoms.ActiveStatus;
                        objuoms.ModifiedBy = uoms.UserID;
                        objuoms.ModifiedOn = DateTime.Now;
                        objuoms.ModifiedTerminal = uoms.TerminalID;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter() { Status = true, StatusCode = "S0002", Message = string.Format(_localizer[name: "S0002"]) };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_UnitofMeasure> GetUOMPDescriptionbyUOMP(string uomp)
        {
            try
            {
                using (eSyaEnterprise db = new eSyaEnterprise())
                {

                    var result = db.GtEciuoms.Where(u => u.Uompurchase.ToUpper().Replace(" ", "") == uomp.ToUpper().Replace(" ", "")).Select(x => new DO_UnitofMeasure
                    {
                        Uompdesc = x.Uompdesc
                    }).FirstOrDefaultAsync();


                    return await result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_UnitofMeasure> GetUOMSDescriptionbyUOMS(string uoms)
        {
            try
            {
                using (eSyaEnterprise db = new eSyaEnterprise())
                {

                    var result = db.GtEciuoms.Where(u => u.Uomstock.ToUpper().Replace(" ", "") == uoms.ToUpper().Replace(" ", "")).Select(x => new DO_UnitofMeasure
                    {
                        Uomsdesc = x.Uomsdesc
                    }).FirstOrDefaultAsync();


                    return await result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> ActiveOrDeActiveUnitofMeasure(bool status, int unitId)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEciuom unit_mesure = db.GtEciuoms.Where(w => w.UnitOfMeasure == unitId).FirstOrDefault();
                        if (unit_mesure == null)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0138", Message = string.Format(_localizer[name: "W0138"]) };
                        }

                        unit_mesure.ActiveStatus = status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, StatusCode = "S0003", Message = string.Format(_localizer[name: "S0003"]) };
                        else
                            return new DO_ReturnParameter() { Status = true, StatusCode = "S0004", Message = string.Format(_localizer[name: "S0004"]) };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        #endregion
    }
}

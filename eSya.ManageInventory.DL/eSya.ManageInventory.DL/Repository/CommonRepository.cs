﻿using eSya.ManageInventory.DL.Entities;
using eSya.ManageInventory.DO;
using eSya.ManageInventory.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.DL.Repository
{
    public class CommonRepository: ICommonRepository
    {
        public static string GetValidationMessageFromException(DbUpdateException ex)
        {
            string msg = ex.InnerException == null ? ex.ToString() : ex.InnerException.Message;

            if (msg.LastIndexOf(',') == msg.Length - 1)
                msg = msg.Remove(msg.LastIndexOf(','));
            return msg;
        }
        public async Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcapcds
                        .Where(w => w.CodeType == codeType && w.ActiveStatus)
                        .Select(r => new DO_ApplicationCodes
                        {
                            ApplicationCode = r.ApplicationCode,
                            CodeDesc = r.CodeDesc
                        }).OrderBy(o => o.CodeDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public async Task<List<DO_ItemGroup>> GetItemGroup()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEiitgrs
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_ItemGroup
                        {
                            ItemGroupId = r.ItemGroup,
                            ItemGroupDesc = r.ItemGroupDesc
                        }).OrderBy(o => o.ItemGroupDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_ItemCategory>> GetItemCategory(int ItemGroup)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEiitgcs
                        .Where(w => w.ItemGroup == ItemGroup && w.ActiveStatus)
                        .Select(r => new DO_ItemCategory
                        {
                            ItemCategory = r.ItemCategory,
                            ItemCategoryDesc = r.ItemCategoryNavigation.ItemCategoryDesc,
                        }).OrderBy(o => o.ItemCategoryDesc).Distinct().ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_ItemSubCategory>> GetItemSubCategory(int ItemCategory)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEiitscs
                        .Where(w => w.ItemCategory == ItemCategory && w.ActiveStatus)
                        .Select(r => new DO_ItemSubCategory
                        {
                            ItemSubCategory = r.ItemSubCategory,
                            ItemSubCategoryDesc = r.ItemSubCategoryDesc,
                        }).OrderBy(o => o.ItemSubCategoryDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_UnitofMeasure>> GetUnitofMeasure()
        {
            try
            {
                using (eSyaEnterprise db = new eSyaEnterprise())
                {
                    var ds = db.GtEciuoms.Join
                    (db.GtEcapcds,
                    um => new { um.Uompurchase },
                    up => new { Uompurchase = up.ApplicationCode },
                    (um, up) => new { um, up }).
                    Join(db.GtEcapcds,
                    ums => new { ums.um.Uomstock },
                    us => new { Uomstock = us.ApplicationCode },
                    (ums, us) => new { ums, us })
                   .Where(x=>x.ums.um.ActiveStatus)
               .Select(r => new DO_UnitofMeasure
               {
                   UnitOfMeasure = r.ums.um.UnitOfMeasure,
                   UnitOfMeasureDesc = r.ums.up.CodeDesc+'-'+ r.us.CodeDesc,
                   ConversionFactor = r.ums.um.ConversionFactor,
               }).ToListAsync();
                  return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_BusinessLocation>> GetBusinessKey()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var bk = db.GtEcbslns
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_BusinessLocation
                        {
                            BusinessKey = r.BusinessKey,
                            LocationDescription = r.BusinessName + "-" + r.LocationDescription
                        }).ToListAsync();

                    return await bk;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_Services>> GetServiceClass()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var bk = db.GtEssrcls
                        .Where(w => w.ActiveStatus)
                        .Join(db.GtEspascs.Where(K=> K.ParameterId == 6 && K.ActiveStatus ),
                    a => new { a.ServiceClassId },
                    b => new { b.ServiceClassId },
                    (a, b) => new { a, b })
                        .Select(r => new DO_Services
                        {
                            ServiceClassId = r.a.ServiceClassId,
                            ServiceClassDesc = r.a.ServiceClassDesc
                        }).ToListAsync();

                    return await bk;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_Services>> GetServices(int BusinessKey, int ServiceClassId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var bk = db.GtEssrms
                        .Where(w => w.ActiveStatus && w.ServiceClassId == ServiceClassId)
                        .Join(db.GtEssrbls.Where(K => K.BusinessKey == BusinessKey && K.ActiveStatus),
                    a => new { a.ServiceId },
                    b => new { b.ServiceId },
                    (a, b) => new { a, b })
                        .Select(r => new DO_Services
                        {
                            ServiceId = r.a.ServiceId,
                            ServiceDesc = r.a.ServiceDesc
                        }).ToListAsync();

                    return await bk;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

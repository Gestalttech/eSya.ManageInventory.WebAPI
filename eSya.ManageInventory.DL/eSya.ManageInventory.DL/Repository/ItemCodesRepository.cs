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
    public class ItemCodesRepository: IItemCodesRepository
    {
        private readonly IStringLocalizer<ItemCodesRepository> _localizer;
        public ItemCodesRepository(IStringLocalizer<ItemCodesRepository> localizer)
        {
            _localizer = localizer;
        }
        public async Task<List<DO_ItemCodes>> GetItemList()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEiitcds
                        .Select(r => new DO_ItemCodes
                        {
                            ItemCode = r.ItemCode,
                            ItemDescription = r.ItemDescription
                        }).OrderBy(o => o.ItemDescription).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_ItemCodes>> GetItemMaster(int ItemGroup, int ItemCategory, int ItemSubCategory)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {

                    var result = await db.GtEiitcds.Join(db.GtEskucds,
                        x => x.ItemCode,
                        y => y.Skucode,
                        (x, y) => new { x, y })
                        .Select(r => new DO_ItemCodes
                        {
                            Skuid = r.y.Skuid,
                            ItemGroup = r.x.ItemGroup,
                            ItemCategory = r.x.ItemCategory,
                            ItemSubCategory = r.x.ItemSubCategory,
                            Skutype = r.y.Skutype,
                            ItemCode = r.x.ItemCode,
                            ItemDescription = r.x.ItemDescription,
                            UnitOfMeasure = r.x.UnitOfMeasure,
                            //PackUnit = r.x.PackUnit,
                            //PackUnitDesc = r.p.CodeDesc,
                            PackSize = r.x.PackSize,
                            InventoryClass = r.x.InventoryClass,
                            ItemClass = r.x.ItemClass,
                            ItemSource = r.x.ItemSource,
                            ItemCriticality = r.x.ItemCriticality,
                            BarCodeID = r.x.BarcodeCodeId,
                            UsageStatus = r.x.UsageStatus,
                            ActiveStatus = r.x.ActiveStatus,
                            Skucode = r.y.Skucode

                        }).ToListAsync();
                    foreach (var obj in result)
                    {
                        if (obj.InventoryClass == "S")
                        {
                            obj.InventoryClass = "Stockable";
                        }
                        else
                        {
                            obj.InventoryClass = "Non-Stockable";
                        }

                        if (obj.ItemClass == "B")
                        {
                            obj.ItemClass = "Bought Out";
                        }
                        else if (obj.ItemClass == "C")
                        {
                            obj.ItemClass = "Consignment";
                        }
                        else if (obj.ItemClass == "I")
                        {
                            obj.ItemClass = "In-House";
                        }
                        else
                        {
                            obj.ItemClass = "Sub Contract";
                        }

                        if (obj.ItemSource == "L")
                        {
                            obj.ItemSource = "Local";
                        }
                        else if (obj.ItemSource == "I")
                        {
                            obj.ItemSource = "Imported";
                        }
                        else
                        {
                            obj.ItemSource = "Out Station";
                        }

                        if (obj.ItemCriticality == "D")
                        {
                            obj.ItemCriticality = "Desirable";
                        }
                        else if (obj.ItemCriticality == "E")
                        {
                            obj.ItemCriticality = "Essential";
                        }
                        else
                        {
                            obj.ItemCriticality = "Vital";
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_ItemCodes>> GetItemDetails(int ItemCode)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {


                    var result = await db.GtEiitcds.Join(db.GtEskucds,
                         x => x.ItemCode,
                         y => y.Skucode,
                         (x, y) => new { x, y })
                         .Select(r => new DO_ItemCodes
                         {
                             Skuid = r.y.Skuid,
                             ItemGroup = r.x.ItemGroup,
                             ItemCategory = r.x.ItemCategory,
                             ItemSubCategory = r.x.ItemSubCategory,
                             Skutype = r.y.Skutype,
                             ItemCode = r.x.ItemCode,
                             ItemDescription = r.x.ItemDescription,
                             UnitOfMeasure = r.x.UnitOfMeasure,
                             //PackUnit = r.a.x.PackUnit,
                             //PackUnitDesc = r.p.CodeDesc,
                             PackSize = r.x.PackSize,
                             InventoryClass = r.x.InventoryClass,
                             ItemClass = r.x.ItemClass,
                             ItemSource = r.x.ItemSource,
                             ItemCriticality = r.x.ItemCriticality,
                             BarCodeID = r.x.BarcodeCodeId,
                             UsageStatus = r.x.UsageStatus,
                             ActiveStatus = r.x.ActiveStatus,
                             Skucode = r.y.Skucode

                         }).ToListAsync();
                    foreach (var obj in result)
                    {
                        if (obj.InventoryClass == "S")
                        {
                            obj.InventoryClass = "Stockable";
                        }
                        else
                        {
                            obj.InventoryClass = "Non-Stockable";
                        }

                        if (obj.ItemClass == "B")
                        {
                            obj.ItemClass = "Bought Out";
                        }
                        else if (obj.ItemClass == "C")
                        {
                            obj.ItemClass = "Consignment";
                        }
                        else if (obj.ItemClass == "I")
                        {
                            obj.ItemClass = "In-House";
                        }
                        else
                        {
                            obj.ItemClass = "Sub Contract";
                        }

                        if (obj.ItemSource == "L")
                        {
                            obj.ItemSource = "Local";
                        }
                        else if (obj.ItemSource == "I")
                        {
                            obj.ItemSource = "Imported";
                        }
                        else
                        {
                            obj.ItemSource = "Out Station";
                        }

                        if (obj.ItemCriticality == "D")
                        {
                            obj.ItemCriticality = "Desirable";
                        }
                        else if (obj.ItemCriticality == "E")
                        {
                            obj.ItemCriticality = "Essential";
                        }
                        else
                        {
                            obj.ItemCriticality = "Vital";
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DO_ItemCodes> GetItemParameterList(int ItemCode)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtEiitcds
                        .Where(w => w.ItemCode == ItemCode)
                        .Select(r => new DO_ItemCodes
                        {
                            l_FormParameter = r.GtEipaits.Select(p => new DO_eSyaParameter
                            {
                                ParameterID = p.ParameterId,
                                ParmAction = p.ParmAction,
                                ParmPerct = p.ParmPerc,
                                ParmDesc = p.ParmDesc,
                                ParmValue = p.ParmValue
                            }).ToList()
                        }).FirstOrDefaultAsync();

                    return await ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public async Task<DO_ReturnParameter> InsertItemCodes(DO_ItemCodes itemCodes)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEiitcd is_itemDescExists = db.GtEiitcds.FirstOrDefault(u => u.ItemDescription.ToUpper().Replace(" ", "") == itemCodes.ItemDescription.ToUpper().Replace(" ", ""));
                        if (is_itemDescExists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0127", Message = string.Format(_localizer[name: "W0127"]) };
                        }

                        int _itemCode = db.GtEiitcds.Select(c => c.ItemCode).DefaultIfEmpty().Max();
                        _itemCode = _itemCode + 1;

                        var b_Entity = new GtEiitcd
                        {
                            ItemCode = _itemCode,
                            ItemGroup = itemCodes.ItemGroup,
                            ItemCategory = itemCodes.ItemCategory,
                            ItemSubCategory = itemCodes.ItemSubCategory,
                            ItemDescription = itemCodes.ItemDescription,
                            UnitOfMeasure = itemCodes.UnitOfMeasure,
                            //PackUnit = itemCodes.PackUnit,
                            PackSize = itemCodes.PackSize,
                            InventoryClass = itemCodes.InventoryClass,
                            ItemClass = itemCodes.ItemClass,
                            ItemSource = itemCodes.ItemSource,
                            ItemCriticality = itemCodes.ItemCriticality,
                            IsBusinessLinked = false,
                            IsHsnlinked = false,
                            BarcodeCodeId = itemCodes.BarCodeID,
                            UsageStatus = false,
                            ActiveStatus = itemCodes.ActiveStatus,
                            FormId = itemCodes.FormID,
                            CreatedBy = itemCodes.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = itemCodes.TerminalID
                        };
                        db.GtEiitcds.Add(b_Entity);

                        foreach (DO_eSyaParameter ip in itemCodes.l_FormParameter)
                        {
                            var pMaster = new GtEipait
                            {
                                ItemCode = _itemCode,
                                ParameterId = ip.ParameterID,
                                ParmPerc = ip.ParmPerct,
                                ParmAction = ip.ParmAction,
                                ParmDesc = ip.ParmDesc,
                                ParmValue = ip.ParmValue,
                                ActiveStatus = ip.ActiveStatus,
                                FormId = itemCodes.FormID,
                                CreatedBy = itemCodes.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = itemCodes.TerminalID
                            };
                            db.GtEipaits.Add(pMaster);
                        }
                        await db.SaveChangesAsync();

                        int _skuid = db.GtEskucds.Select(c => c.Skuid).DefaultIfEmpty().Max();
                        _skuid = _skuid + 1;

                        var sku_Entity = new GtEskucd
                        {
                            Skuid = _skuid,
                            Skutype = itemCodes.Skutype,
                            Skucode = _itemCode,
                            ActiveStatus = itemCodes.ActiveStatus,
                            FormId = itemCodes.FormID,
                            CreatedBy = itemCodes.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = itemCodes.TerminalID
                        };
                        db.GtEskucds.Add(sku_Entity);
                        await db.SaveChangesAsync();

                        GtEciuom um = db.GtEciuoms.FirstOrDefault(be => be.UnitOfMeasure == itemCodes.UnitOfMeasure);
                        if (um != null)
                        {
                            um.UsageStatus = true;
                        }
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, StatusCode = "S0001", Message = string.Format(_localizer[name: "S0001"]) };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonRepository.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateItemCodes(DO_ItemCodes itemCodes)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEiitcd is_ItemExists = db.GtEiitcds.FirstOrDefault(be => be.ItemDescription.ToUpper().Replace(" ", "") == itemCodes.ItemDescription.ToUpper().Replace(" ", "") && be.ItemCode != itemCodes.ItemCode);
                        if (is_ItemExists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0127", Message = string.Format(_localizer[name: "W0127"]) };

                        }

                        GtEiitcd b_Entity = db.GtEiitcds.Where(be => be.ItemCode == itemCodes.ItemCode).FirstOrDefault();
                        
                        var ums = db.GtEiitcds.Where(be => be.ItemCode == itemCodes.ItemCode).ToList();
                        foreach (var u in ums)
                        {
                            GtEciuom uExist = db.GtEciuoms.FirstOrDefault(be => be.UnitOfMeasure == u.UnitOfMeasure);
                            if (uExist != null)
                            {
                                uExist.UsageStatus = false;
                            }

                        }
                        await db.SaveChangesAsync();
                        
                        if (b_Entity != null)
                        {
                            b_Entity.ItemGroup = itemCodes.ItemGroup;
                            b_Entity.ItemCategory = itemCodes.ItemCategory;
                            b_Entity.ItemSubCategory = itemCodes.ItemSubCategory;
                            b_Entity.ItemDescription = itemCodes.ItemDescription;
                            b_Entity.UnitOfMeasure = itemCodes.UnitOfMeasure;
                            //b_Entity.PackUnit = itemCodes.PackUnit;
                            b_Entity.PackSize = itemCodes.PackSize;
                            b_Entity.InventoryClass = itemCodes.InventoryClass;
                            b_Entity.ItemClass = itemCodes.ItemClass;
                            b_Entity.ItemSource = itemCodes.ItemSource;
                            b_Entity.ItemCriticality = itemCodes.ItemCriticality;
                            b_Entity.BarcodeCodeId = itemCodes.BarCodeID;
                            b_Entity.ActiveStatus = itemCodes.ActiveStatus;
                            b_Entity.ModifiedBy = itemCodes.UserID;
                            b_Entity.ModifiedOn = System.DateTime.Now;
                            b_Entity.ModifiedTerminal = itemCodes.TerminalID;

                            await db.SaveChangesAsync();

                            foreach (DO_eSyaParameter ip in itemCodes.l_FormParameter)
                            {
                                GtEipait sPar = db.GtEipaits.Where(x => x.ItemCode == itemCodes.ItemCode && x.ParameterId == ip.ParameterID).FirstOrDefault();
                                if (sPar != null)
                                {
                                    sPar.ParmAction = ip.ParmAction;
                                    sPar.ParmDesc = ip.ParmDesc;
                                    sPar.ParmPerc = ip.ParmPerct;
                                    sPar.ParmValue = ip.ParmValue;
                                    sPar.ActiveStatus = itemCodes.ActiveStatus;
                                    sPar.ModifiedBy = itemCodes.UserID;
                                    sPar.ModifiedOn = System.DateTime.Now;
                                    sPar.ModifiedTerminal = itemCodes.TerminalID;
                                }
                                else
                                {
                                    var pMaster = new GtEipait
                                    {
                                        ItemCode = itemCodes.ItemCode,
                                        ParameterId = ip.ParameterID,
                                        ParmPerc = ip.ParmPerct,
                                        ParmAction = ip.ParmAction,
                                        ParmDesc = ip.ParmDesc,
                                        ParmValue = ip.ParmValue,
                                        ActiveStatus = ip.ActiveStatus,
                                        FormId = itemCodes.FormID,
                                        CreatedBy = itemCodes.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = itemCodes.TerminalID
                                    };
                                    db.GtEipaits.Add(pMaster);
                                }
                                await db.SaveChangesAsync();
                            }
                            GtEskucd _sku = db.GtEskucds.FirstOrDefault(x => x.Skuid == itemCodes.Skuid && x.Skucode == itemCodes.Skucode);
                            if (_sku != null)
                            {
                                _sku.Skutype = itemCodes.Skutype;
                                _sku.Skucode = itemCodes.Skucode;
                                _sku.ActiveStatus = itemCodes.ActiveStatus;
                                _sku.ModifiedBy = itemCodes.UserID;
                                _sku.ModifiedOn = System.DateTime.Now;
                                _sku.ModifiedTerminal = itemCodes.TerminalID;
                            }
                            await db.SaveChangesAsync();

                            GtEciuom um = db.GtEciuoms.FirstOrDefault(be => be.UnitOfMeasure == itemCodes.UnitOfMeasure);
                            if (um != null)
                            {
                                um.UsageStatus = true;
                            }
                            await db.SaveChangesAsync();

                            dbContext.Commit();

                            return new DO_ReturnParameter() { Status = true, StatusCode = "S0002", Message = string.Format(_localizer[name: "S0002"]) };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0128", Message = string.Format(_localizer[name: "W0128"]) };

                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonRepository.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}

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

        #region Business Item Store Link
        public async Task<List<DO_ItemStoreLink>> GetBusinessItemStoreLink(int BusinessKey, int ItemCode)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {

                    var st = db.GtEcstrms.Join(
                        db.GtEastbls.Where(w => w.ActiveStatus && w.BusinessKey == BusinessKey),
                        s => Convert.ToInt32( s.StoreCode.ToString() + "" + s.StoreType.ToString()),
                        p => p.StoreCode,
                        (s, p) => new { s, p })
                        .Select(r => new
                        {
                            r.p.StoreCode,
                            r.s.StoreDesc,
                        });

                    var result = await st
                   .GroupJoin(db.GtEiitsts.Where(w => w.BusinessKey == BusinessKey && w.ItemCode == ItemCode),
                    s => s.StoreCode,
                    f => f.StoreCode,
                    (s, f) => new { s, f })
                   .SelectMany(z => z.f.DefaultIfEmpty(),
                    (a, b) => new DO_ItemStoreLink
                    {
                        BusinessKey = BusinessKey,
                        ItemCode = ItemCode,
                        StoreCode = a.s.StoreCode,
                        StoreDesc = a.s.StoreDesc,
                        ActiveStatus = b == null ? false : b.ActiveStatus
                    }).ToListAsync();
                    var DistinctItemstores = result.GroupBy(x => x.StoreCode).Select(y => y.First());
                    return DistinctItemstores.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_StoreBusinessLink>> GetPortfolioStoreInfo(int BusinessKey, int StoreCode)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = await db.GtEcspfms.Where(x => x.ActiveStatus)
                        .Select(r => new DO_StoreBusinessLink
                        {
                            PortfolioId = r.PortfolioId,
                            PortfolioDesc = r.PortfolioDesc,
                            ActiveStatus = false,
                        }).ToListAsync();

                    foreach (var obj in ds)
                    {
                        GtEcstpf pf = db.GtEcstpfs.Where(x => x.BusinessKey == BusinessKey && x.StoreCode == StoreCode && x.PortfolioId == obj.PortfolioId).FirstOrDefault();
                        if (pf != null)
                        {
                            obj.ActiveStatus = pf.ActiveStatus;
                        }
                        else
                        {
                            obj.ActiveStatus = false;

                        }
                    }

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DO_ReturnParameter> InsertOrUpdateBusinessItemStoreLink(List<DO_ItemStoreLink> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var is_ItemStoreLink = obj.Where(w => !String.IsNullOrEmpty(w.StoreCode.ToString())).Count();
                        if (is_ItemStoreLink <= 0)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0073", Message = string.Format(_localizer[name: "W0073"]) };
                        }

                        foreach (var sd in obj.Where(w => !String.IsNullOrEmpty(w.StoreCode.ToString())))
                        {
                            GtEiitst is_lk = db.GtEiitsts.Where(x => x.BusinessKey == sd.BusinessKey
                                            && x.ItemCode == sd.ItemCode && x.StoreCode == sd.StoreCode).FirstOrDefault();
                            if (is_lk == null)
                            {
                                var o_islk = new GtEiitst
                                {
                                    BusinessKey = sd.BusinessKey,
                                    ItemCode = sd.ItemCode,
                                    StoreCode = sd.StoreCode,
                                    ActiveStatus = sd.ActiveStatus,
                                    FormId = sd.FormId,
                                    CreatedBy = sd.UserID,
                                    CreatedOn = System.DateTime.Now,
                                    CreatedTerminal = sd.TerminalID
                                };
                                db.GtEiitsts.Add(o_islk);
                            }
                            else
                            {
                                is_lk.ActiveStatus = sd.ActiveStatus;
                                is_lk.ModifiedBy = sd.UserID;
                                is_lk.ModifiedOn = System.DateTime.Now;
                                is_lk.ModifiedTerminal = sd.TerminalID;
                            }
                            await db.SaveChangesAsync();
                        }

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

        #endregion Business Item Store Link

        #region Item Service Link
        public async Task<List<DO_ItemServiceLink>> GetServiceItemLinkInfo(int BusinessKey, int ServiceClass, int ServiceId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var st = db.GtEskucds.Where(x => x.ActiveStatus).
                        GroupJoin(db.GtEiitcds.Where(y => y.ActiveStatus),
                        p => p.Skucode,
                        q => q.ItemCode,
                        (p, q) => new { p, q})
                        .SelectMany(x => x.q.DefaultIfEmpty(),
                        (a, b) => new
                        {
                            a.p.Skuid,
                            a.p.Skutype,
                            a.p.Skucode,
                            b.ItemDescription
                        });

                    var result = await st
                    .GroupJoin(db.GtEisrits.Where(w => w.BusinessKey == BusinessKey && w.ServiceClass == ServiceClass && w.ServiceId == ServiceId ),
                     s => s.Skuid,
                     f => f.Skuid,
                     (s, f) => new { s, f })
                    .SelectMany(z => z.f.DefaultIfEmpty(),
                     (a, b) => new DO_ItemServiceLink
                     {
                         BusinessKey = BusinessKey,
                         ServiceClass = ServiceClass,
                         ServiceID = ServiceId,
                         SKUID = a.s.Skuid,
                         SKUType = a.s.Skutype,
                         ItemDescription = a.s.ItemDescription,
                         Quantity = b == null ? 0 : b.Quantity,
                         ActiveStatus = b == null ? false : b.ActiveStatus
                     }).ToListAsync();
                    var Distinctstores = result.GroupBy(x => x.SKUID).Select(y => y.First());
                    return Distinctstores.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateServiceItemLink(List<DO_ItemServiceLink> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var is_ItemSrviceLink = obj.Where(w => !String.IsNullOrEmpty(w.SKUID.ToString())).Count();
                        if (is_ItemSrviceLink <= 0)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0073", Message = string.Format(_localizer[name: "W0073"]) };
                        }

                        foreach (var sd in obj.Where(w => !String.IsNullOrEmpty(w.SKUID.ToString())))
                        {
                            GtEisrit is_lk = db.GtEisrits.Where(x => x.BusinessKey == sd.BusinessKey
                                            && x.ServiceClass == sd.ServiceClass && x.ServiceId == sd.ServiceID && x.Skuid == sd.SKUID).FirstOrDefault();
                            if (is_lk != null)
                            {
                                db.GtEisrits.Remove(is_lk);
                                db.SaveChanges();
                            }
                        }

                        foreach (var sd in obj.Where(w => !String.IsNullOrEmpty(w.SKUID.ToString()) && w.Quantity > 0))
                        {
                            GtEisrit is_lk = db.GtEisrits.Where(x => x.BusinessKey == sd.BusinessKey
                                            && x.ServiceClass == sd.ServiceClass && x.ServiceId == sd.ServiceID && x.Skuid == sd.SKUID).FirstOrDefault();
                            if (is_lk == null)
                            {
                                var o_islk = new GtEisrit
                                {
                                    BusinessKey = sd.BusinessKey,
                                    ServiceClass = sd.ServiceClass,
                                    ServiceId = sd.ServiceID,
                                    Skuid = sd.SKUID,
                                    Skutype = sd.SKUType,
                                    Quantity = sd.Quantity,
                                    ActiveStatus = sd.ActiveStatus,
                                    FormId = sd.FormId,
                                    CreatedBy = sd.UserID,
                                    CreatedOn = System.DateTime.Now,
                                    CreatedTerminal = sd.TerminalID
                                };
                                db.GtEisrits.Add(o_islk);
                            }
                            else
                            {
                                is_lk.Quantity = sd.Quantity;
                                //is_lk.ActiveStatus = sd.ActiveStatus;
                                is_lk.ModifiedBy = sd.UserID;
                                is_lk.ModifiedOn = System.DateTime.Now;
                                is_lk.ModifiedTerminal = sd.TerminalID;
                            }
                            await db.SaveChangesAsync();
                        }

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
        #endregion Item Service Link
    }
}

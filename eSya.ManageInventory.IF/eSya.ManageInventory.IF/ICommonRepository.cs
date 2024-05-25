using eSya.ManageInventory.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManageInventory.IF
{
    public interface ICommonRepository
    {
        Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType);
        Task<List<DO_UnitofMeasure>> GetUnitofMeasure();
        Task<List<DO_ItemGroup>> GetItemGroup();
        Task<List<DO_ItemCategory>> GetItemCategory(int ItemGroup);
        Task<List<DO_ItemSubCategory>> GetItemSubCategory(int ItemCategory);
        Task<List<DO_BusinessLocation>> GetBusinessKey();
        Task<List<DO_Services>> GetServiceClass();
        Task<List<DO_Services>> GetServices(int BusinessKey, int ServiceClassId);
    }
}

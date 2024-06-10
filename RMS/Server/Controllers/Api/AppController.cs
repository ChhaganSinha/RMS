
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using RMS.DataContext.Models;
using RMS.Dto;
using RMS.Dto.Dashboard;
using RMS.Repositories;
using System.Net.Http;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using Serilog.Core;



namespace RMS.Server.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
   /* [Authorize]*/
    public class AppController : ControllerBase
    {
        readonly AppRepository _appRepository;
        readonly ILogger _logger;
        readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public AppController(ILogger<AppController> logger, IConfiguration appConfig, IAppRepository appRepository, IWebHostEnvironment env) : base()
        {
            _appRepository = (AppRepository?)appRepository;
            _logger = logger;
            _configuration = appConfig;
            _env = env;
            // Retrieve username and roles in the constructor and store them in _userName and _userRoles

        }

        #region Details
        [HttpGet]
        [Route("details/{id}")]
        public async Task<Details> GetDetailsById(int id)
        {
            return await _appRepository.GetDetailsById(id);
        }

        [HttpGet]
        [Route("all-details")]
        [AllowAnonymous]
        public async Task<IEnumerable<Details>> GetAllDetails()
        {
            return await _appRepository.GetAllDetails();
        }

        [HttpPost]
        [Route("UpsertDetails")]
        public async Task<Details> UpsertDetails(Details details)
        {

            return await _appRepository.UpsertDetails(details);
        }
        #endregion

        #region Room Setion
        [HttpGet]
        [Route("RoomCategory/{id}")]
        public async Task<RoomCategories> GetRoomCategoryById(int id)
        {
            return await _appRepository.GetRoomCategoryById(id);
        }

        [HttpGet]
        [Route("all-room-category")]
        public async Task<IEnumerable<RoomCategories>> GetAllRoomCategory()
        {
            return await _appRepository.GetAllRoomCategory();
        }

        [HttpPost]
        [Route("UpsertRoomCategory")]
        public async Task<ApiResponse<RoomCategories>> UpsertRoomCategory(RoomCategories data)
        {
            return await _appRepository.UpsertRoomCategory(data);
        }
        [HttpPost]
        [Route("DeleteRoomCategory/{id}")]
        public async Task<ApiResponse<RoomCategories>> DeleteRoomCategory(int id)
        {
                return await _appRepository.DeleteRoomCategory(id);
        }



        [HttpGet]
        [Route("RoomFacility/{id}")]
        public async Task<RoomFacilities> GetRoomFacilityById(int id)
        {
            return await _appRepository.GetRoomFacilityById(id);
        }

        [HttpGet]
        [Route("all-room-facility")]
        public async Task<IEnumerable<RoomFacilities>> GetAllRoomFacility()
        {
            return await _appRepository.GetAllRoomFacility();
        }

        [HttpPost]
        [Route("UpsertRoomFacility")]
        public async Task<ApiResponse<RoomFacilities>> UpsertRoomFacility(RoomFacilities data)
        {
            return await _appRepository.UpsertRoomFacility(data);
        }

        [HttpGet]
        [Route("GetFacilitiesMappingByRoomId/{RoomId}")]
        public async Task<List<RoomFacilitiesMapping>> GetFacilitiesMappingByRoomId(int RoomId)
        {
            var data = await _appRepository.GetFacilitiesMappingByRoomId(RoomId);
            return data;
        }

        [HttpPost]
        [Route("UpsertRoomFacilitiesMapping")]
        public async Task<ApiResponse<string>> UpsertRoomFacilitiesMapping(Dictionary<int, List<int>> dict)
        {
            var result = new ApiResponse<string>();
            try
            {
                var outcome = await _appRepository.UpsertRoomFacilitiesMapping(dict);
                result.Message = "Success";
            }
            catch (Exception ex)
            {
               // Logger.LogError(ex, "Error while uploading data to TrainingCampIdMapping");
            }

            return result;
        }


        [HttpPost]
        [Route("DeleteRoomFacility/{id}")]
        public async Task<ApiResponse<RoomFacilities>> DeleteRoomFacility(int id)
        {
            return await _appRepository.DeleteRoomFacility(id);
        }



        [HttpGet]
        [Route("Room/{id}")]
        public async Task<Room> GetRoomById(int id)
        {
            return await _appRepository.GetRoomById(id);
        }

        [HttpGet]
        [Route("all-room")]
        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            return await _appRepository.GetAllRoom();
        }

        [HttpPost]
        [Route("UpsertRoom")]
        public async Task<ApiResponse<Room>> UpsertRoom(Room data)
        {
            return await _appRepository.UpsertRoom(data);
        }
        [HttpPost]
        [Route("DeleteRoom/{id}")]
        public async Task<ApiResponse<Room>> DeleteRoom(int id)
        {
            return await _appRepository.DeleteRoom(id);
        }
        #endregion

        #region Employee Setion
        [HttpGet]
        [Route("EmployeeDesignation/{id}")]
        public async Task<EmployeeDesignation> GetEmployeeDesignationById(int id)
        {
            return await _appRepository.GetEmployeeDesignationById(id);
        }

        [HttpGet]
        [Route("all-EmployeeDesignation")]
        public async Task<IEnumerable<EmployeeDesignation>> GetAllEmployeeDesignation()
        {
            return await _appRepository.GetAllEmployeeDesignation();
        }

        [HttpPost]
        [Route("UpsertEmployeeDesignation")]
        public async Task<ApiResponse<EmployeeDesignation>> UpsertEmployeeDesignation(EmployeeDesignation data)
        {
            return await _appRepository.UpsertEmployeeDesignation(data);
        }
        [HttpPost]
        [Route("DeleteEmployeeDesignation/{id}")]
        public async Task<ApiResponse<EmployeeDesignation>> DeleteEmployeeDesignation(int id)
        {
            return await _appRepository.DeleteEmployeeDesignation(id);
        }


        [HttpGet]
        [Route("EmployeeDepartment/{id}")]
        public async Task<EmployeeDepartment> GetEmployeeDepartmentById(int id)
        {
            return await _appRepository.GetEmployeeDepartmentById(id);
        }

        [HttpGet]
        [Route("all-EmployeeDepartment")]
        public async Task<IEnumerable<EmployeeDepartment>> GetAllEmployeeDepartment()
        {
            return await _appRepository.GetAllEmployeeDepartment();
        }

        [HttpPost]
        [Route("UpsertEmployeeDepartment")]
        public async Task<ApiResponse<EmployeeDepartment>> UpsertEmployeeDepartment(EmployeeDepartment data)
        {
            return await _appRepository.UpsertEmployeeDepartment(data);
        }
        [HttpPost]
        [Route("DeleteEmployeeDepartment/{id}")]
        public async Task<ApiResponse<EmployeeDepartment>> DeleteEmployeeDepartment(int id)
        {
            return await _appRepository.DeleteEmployeeDepartment(id);
        }


        [HttpGet]
        [Route("Employee/{id}")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _appRepository.GetEmployeeById(id);
        }

        [HttpGet]
        [Route("all-Employee")]
        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _appRepository.GetAllEmployee();
        }

        [HttpPost]
        [Route("UpsertEmployee")]
        public async Task<ApiResponse<Employee>> UpsertEmployee(Employee data)
        {
            return await _appRepository.UpsertEmployee(data);
        }
        [HttpPost]
        [Route("DeleteEmployee/{id}")]
        public async Task<ApiResponse<Employee>> DeleteEmployee(int id)
        {
            return await _appRepository.DeleteEmployee(id);
        }
        #endregion


        #region Hall Setion
        [HttpGet]
        [Route("HallCategory/{id}")]
        public async Task<HallCategories> GetHallCategoryById(int id)
        {
            return await _appRepository.GetHallCategoryById(id);
        }

        [HttpGet]
        [Route("all-hall-category")]
        public async Task<IEnumerable<HallCategories>> GetAllHallCategory()
        {
            return await _appRepository.GetAllHallCategory();
        }

        [HttpPost]
        [Route("UpsertHallCategory")]
        public async Task<ApiResponse<HallCategories>> UpsertHallCategory(HallCategories data)
        {
            return await _appRepository.UpsertHallCategory(data);
        }
        [HttpPost]
        [Route("DeleteHallCategory/{id}")]
        public async Task<ApiResponse<HallCategories>> DeleteHallCategory(int id)
        {
            return await _appRepository.DeleteHallCategory(id);
        }



        [HttpGet]
        [Route("HallFacility/{id}")]
        public async Task<HallFacilities> GetHallFacilityById(int id)
        {
            return await _appRepository.GetHallFacilityById(id);
        }

        [HttpGet]
        [Route("all-hall-facility")]
        public async Task<IEnumerable<HallFacilities>> GetAllHallFacility()
        {
            return await _appRepository.GetAllHallFacility();
        }

        [HttpPost]
        [Route("UpsertHallFacility")]
        public async Task<ApiResponse<HallFacilities>> UpsertHallFacility(HallFacilities data)
        {
            return await _appRepository.UpsertHallFacility(data);
        }

        [HttpGet]
        [Route("GetFacilitiesMappingByHallId/{RoomId}")]
        public async Task<List<HallFacilitiesMapping>> GetFacilitiesMappingByHallId(int HallId)
        {
            var data = await _appRepository.GetFacilitiesMappingByHallId(HallId);
            return data;
        }

        [HttpPost]
        [Route("UpsertHallFacilitiesMapping")]
        public async Task<ApiResponse<string>> UpsertHallFacilitiesMapping(Dictionary<int, List<int>> dict)
        {
            var result = new ApiResponse<string>();
            try
            {
                var outcome = await _appRepository.UpsertHallFacilitiesMapping(dict);
                result.Message = "Success";
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, "Error while uploading data to TrainingCampIdMapping");
            }

            return result;
        }

        [HttpPost]
        [Route("DeleteHallFacility/{id}")]
        public async Task<ApiResponse<HallFacilities>> DeleteHallFacility(int id)
        {
            return await _appRepository.DeleteHallFacility(id);
        }


        [HttpGet]
        [Route("Hall/{id}")]
        public async Task<Hall> GetHallById(int id)
        {
            return await _appRepository.GetHallById(id);
        }

        [HttpGet]
        [Route("all-hall")]
        public async Task<IEnumerable<Hall>> GetAllHall()
        {
            return await _appRepository.GetAllHall();
        }

        [HttpPost]
        [Route("UpsertHall")]
        public async Task<ApiResponse<Hall>> UpsertHall(Hall data)
        {
            return await _appRepository.UpsertHall(data);
        }
        [HttpPost]
        [Route("DeleteHall/{id}")]
        public async Task<ApiResponse<Hall>> DeleteHall(int id)
        {
            return await _appRepository.DeleteHall(id);
        }
        #endregion


        #region Product Section
        [HttpGet]
        [Route("ProductCategory/{id}")]
        public async Task<ProductCategories> GetProductCategoryById(int id)
        {
            return await _appRepository.GetProductCategoryById(id);
        }

        [HttpGet]
        [Route("all-product-category")]
        public async Task<IEnumerable<ProductCategories>> GetAllProductCategory()
        {
            return await _appRepository.GetAllProductCategory();
        }

        [HttpPost]
        [Route("UpsertProductCategory")]
        public async Task<ApiResponse<ProductCategories>> UpsertProductCategory(ProductCategories data)
        {
            return await _appRepository.UpsertProductCategory(data);
        }
        [HttpPost]
        [Route("DeleteProductCategory/{id}")]
        public async Task<ApiResponse<ProductCategories>> DeleteProductCategory(int id)
        {
            return await _appRepository.DeleteProductCategory(id);
        }



        [HttpGet]
        [Route("UnitNames/{id}")]
        public async Task<UnitNames> GetUnitNamesById(int id)
        {
            return await _appRepository.GetUnitNamesById(id);
        }

        [HttpGet]
        [Route("all-unit-names")]
        public async Task<IEnumerable<UnitNames>> GetAllUnitNames()
        {
            return await _appRepository.GetAllUnitNames();
        }

        [HttpPost]
        [Route("UpsertUnitNames")]
        public async Task<ApiResponse<UnitNames>> UpsertUnitNames(UnitNames data)
        {
            return await _appRepository.UpsertUnitNames(data);
        }
        [HttpPost]
        [Route("DeleteUnitNames/{id}")]
        public async Task<ApiResponse<UnitNames>> DeleteUnitNames(int id)
        {
            return await _appRepository.DeleteUnitNames(id);
        }



        [HttpGet]
        [Route("ProductList/{id}")]
        public async Task<ProductList> GetProductListById(int id)
        {
            return await _appRepository.GetProductListById(id);
        }

        [HttpGet]
        [Route("all-ProductList")]
        public async Task<IEnumerable<ProductList>> GetAllProductList()
        {
            return await _appRepository.GetAllProductList();
        }

        [HttpPost]
        [Route("UpsertProductList")]
        public async Task<ApiResponse<ProductList>> UpsertProductList(ProductList data)
        {
            return await _appRepository.UpsertProductList(data);
        }
        [HttpPost]
        [Route("DeleteProductList/{id}")]
        public async Task<ApiResponse<ProductList>> DeleteProductList(int id)
        {
            return await _appRepository.DeleteProductList(id);
        }




        [HttpGet]
        [Route("SupplierList/{id}")]
        public async Task<SupplierList> GetSupplierListById(int id)
        {
            return await _appRepository.GetSupplierListById(id);
        }

        [HttpGet]
        [Route("all-supplier-list")]
        public async Task<IEnumerable<SupplierList>> GetAllSupplierList()
        {
            return await _appRepository.GetAllSupplierList();
        }

        [HttpPost]
        [Route("UpsertSupplierList")]
        public async Task<ApiResponse<SupplierList>> UpsertSupplierList(SupplierList data)
        {
            return await _appRepository.UpsertSupplierList(data);
        }
        [HttpPost]
        [Route("DeleteSupplierList/{id}")]
        public async Task<ApiResponse<SupplierList>> DeleteSupplierList(int id)
        {
            return await _appRepository.DeleteSupplierList(id);
        }





        [HttpGet]
        [Route("DestroyedProducts/{id}")]
        public async Task<DestroyedProducts> GetDestroyedProductsById(int id)
        {
            return await _appRepository.GetDestroyedProductsById(id);
        }

        [HttpGet]
        [Route("all-DestroyedProducts")]
        public async Task<IEnumerable<DestroyedProducts>> GetAllDestroyedProducts()
        {
            return await _appRepository.GetAllDestroyedProducts();
        }

        [HttpPost]
        [Route("UpsertDestroyedProducts")]
        public async Task<ApiResponse<DestroyedProducts>> UpsertDestroyedProducts(DestroyedProducts data)
        {
            return await _appRepository.UpsertDestroyedProducts(data);
        }
        [HttpPost]
        [Route("DeleteDestroyedProducts/{id}")]
        public async Task<ApiResponse<DestroyedProducts>> DeleteDestroyedProducts(int id)
        {
            return await _appRepository.DeleteDestroyedProducts(id);
        }




        [HttpGet]
        [Route("DestroyedProducts/{id}")]
        public async Task<SaleProducts> GetSaleProductsById(int id)
        {
            return await _appRepository.GetSaleProductsById(id);
        }

        [HttpGet]
        [Route("all-SaleProducts")]
        public async Task<IEnumerable<SaleProducts>> GetAllSaleProducts()
        {
            return await _appRepository.GetAllSaleProducts();
        }

        [HttpPost]
        [Route("UpsertSaleProducts")]
        public async Task<ApiResponse<SaleProducts>> UpsertSaleProducts(SaleProducts data)
        {
            return await _appRepository.UpsertSaleProducts(data);
        }
        [HttpPost]
        [Route("DeleteSaleProducts/{id}")]
        public async Task<ApiResponse<SaleProducts>> DeleteSaleProducts(int id)
        {
            return await _appRepository.DeleteSaleProducts(id);
        }



        [HttpGet]
        [Route("PurchaseItem/{id}")]
        public async Task<PurchaseItem> GetPurchaseItemById(int id)
        {
            return await _appRepository.GetPurchaseItemById(id);
        }

        [HttpGet]
        [Route("all-PurchaseItem")]
        public async Task<IEnumerable<PurchaseItem>> GetAllPurchaseItem()
        {
            return await _appRepository.GetAllPurchaseItem();
        }

        [HttpPost]
        [Route("UpsertPurchaseItem")]
        public async Task<ApiResponse<PurchaseItem>> UpsertPurchaseItem(PurchaseItem data)
        {
            return await _appRepository.UpsertPurchaseItem(data);
        }
        [HttpPost]
        [Route("DeletePurchaseItem/{id}")]
        public async Task<ApiResponse<PurchaseItem>> DeletePurchaseItem(int id)
        {
            return await _appRepository.DeletePurchaseItem(id);
        }
        #endregion


        #region HouseKeeping

        [HttpGet]
        [Route("CheckList/{id}")]
        public async Task<CheckList> GetCheckListById(int id)
        {
            return await _appRepository.GetCheckListById(id);
        }

        [HttpGet]
        [Route("all-CheckList")]
        public async Task<IEnumerable<CheckList>> GetAllCheckList()
        {
            return await _appRepository.GetAllCheckList();
        }

        [HttpPost]
        [Route("UpsertCheckList")]
        public async Task<ApiResponse<CheckList>> UpsertCheckList(CheckList data)
        {
            return await _appRepository.UpsertCheckList(data);
        }
        [HttpPost]
        [Route("DeleteCheckList/{id}")]
        public async Task<ApiResponse<CheckList>> DeleteCheckList(int id)
        {
            return await _appRepository.DeleteCheckList(id);
        }



        [HttpGet]
        [Route("RoomCleaning/{id}")]
        public async Task<RoomCleaning> GetRoomCleaningId(int id)
        {
            return await _appRepository.GetRoomCleaningById(id);
        }

        [HttpGet]
        [Route("all-RoomCleaning")]
        public async Task<IEnumerable<RoomCleaning>> GetAllRoomCleaning()
        {
            return await _appRepository.GetAllRoomCleaning();
        }

        [HttpPost]
        [Route("UpsertRoomCleaning")]
        public async Task<ApiResponse<RoomCleaning>> UpsertRoomCleaning(RoomCleaning data)
        {
            return await _appRepository.UpsertRoomCleaning(data);
        }
        [HttpPost]
        [Route("DeleteRoomCleaning/{id}")]
        public async Task<ApiResponse<RoomCleaning>> DeleteRoomCleaning(int id)
        {
            return await _appRepository.DeleteRoomCleaning(id);
        }

        [HttpGet]
        [Route("PurchaseItemList/{id}")]
        public async Task<List<ItemDto>> GetPurchaseItemListById(int id)
        {
            return await _appRepository.GetPurchaseItemListById(id);
        }

        #endregion


    }


}

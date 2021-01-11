using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using BLL.Services;

namespace endBackStore.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InventoryController : ApiController
    {
        private IInventoryService _IIS;
        public InventoryController()
        {
            _IIS = new InventoryService();
        }

        [HttpGet]
        [Route("Inventory/GetInventory")]
        public IHttpActionResult GetInventory() => Ok(_IIS.GetInventory());

        [HttpPost]
        [Route("Inventory/SaveClothes")]
        public IHttpActionResult SaveClothes(List<List<InventoryDTO>> data) => Ok(_IIS.SaveClothes(data));
        public IHttpActionResult GetCompantnamebyid(int id)
        {
            return Ok(_IIS.GetCompanyNameById(id));
        }
        [Route("Inventory/getSeasonsOptions")]
        public IHttpActionResult getSeasonsOptions() => Ok(_IIS.getSeasonsOptions());
        [Route("Inventory/GetInventoryForCompany")]
        public IHttpActionResult GetInventoryForCompany(int CompanyId, int year, int seasonId) => Ok(_IIS.GetInventoryForCompany(CompanyId,  year, seasonId));
    }
}
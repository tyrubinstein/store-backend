using BLL.ModelDTO;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Services
{
    public interface IBillsService
    {
        List<BillsDTO> GetAllBills();

    }
    public class BillsService : IBillsService
    {
        private storesEntities db;


        public List<BillsDTO> GetAllBills()
        {
            using (db = new storesEntities())
            {
                return db.Bills.Select(b => new BillsDTO()
                {
                    BillID = b.BillID,
                    StoreId = b.StoreID,
                    BillPath = b.BillPath,
                    BilDate = b.BilDate
                }).ToList<BillsDTO>();

        }
    }
}
}

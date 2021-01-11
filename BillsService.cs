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
        List<ClothDTO> GetInventoryById(int id);
        List<BillsDTO> GetAllBillsById(int storeId);
        bool DeleteFile(string path);
        List<BillsDTO> SearchBillsInRange(DateTime d1, DateTime d2);
        List<BillsDTO> UpLoad(string filePath, string fileName);
    }
   
    public class BillsService : IBillsService
    {
        private storesEntities db;
        public  List<ClothDTO> GetInventoryById(int id)
        {
            InventoryService InventoryService = new InventoryService();
            List<ClothDTO> retval = null;

            try
            {
                using (db = new storesEntities())
                {
                    var list = db.Inventories.Where(inv => inv.StoreID == id).Select(i => i.ClothID).ToList();
                    if (list != null)
                    {
                        retval = new List<ClothDTO>();
                        List<Cloth> listcloth = db.Clothes.Where(c => list.Contains(c.ClothID)).Select(cloth => cloth).ToList<Cloth>();
                        foreach (var item in listcloth)
                        {
                            ClothDTO c = new ClothDTO();
                            c = c.ToDTO(item);
                            c.CompanyName = InventoryService.GetCompanyNameById(c.CompanyId);
                            retval.Add(c);
                        }
                       
                    } return retval;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }


        public List<BillsDTO> GetAllBillsById(int storeId)
        {
            using (db = new storesEntities())
            {
                try
                {
                    return db.Bills.Where(b => b.StoreID == storeId).Select(bb => new BillsDTO()
                    {
                        BillID = bb.BillID,
                        StoreId = bb.StoreID,
                        BillPath = bb.BillPath,
                        BilDate = bb.BilDate
                    }).ToList<BillsDTO>();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        public bool DeleteFile(string path)
        {
            using (db = new storesEntities())
            {
                try
                {
                    Bill b = db.Bills.First(bi => bi.BillPath == path);
                    db.Bills.Remove(b);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public List<BillsDTO> SearchBillsInRange(DateTime d1, DateTime d2)
        {
            try
            {
                using (db = new storesEntities())
                {
                    BillsDTO bdto = new BillsDTO();
                    List<BillsDTO> retList = new List<BillsDTO>();
                    List<Bill> billl = db.Bills.Where(b => b.BilDate >= d1 && b.BilDate <= d2).OrderBy(o => o.BilDate).ToList<Bill>();
                    foreach (Bill x in billl)
                    {
                        retList.Add(bdto.ToDTO(x));
                    }
                    return retList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<BillsDTO> UpLoad(string filePath, string fileName)
        {
            using (db = new storesEntities())
            {
                Bill b = new Bill();
                b.BilDate = DateTime.Now;
                b.BillPath = filePath;
                b.StoreID = Convert.ToInt32(fileName);
                db.Bills.Add(b);
                db.SaveChanges();
                return GetAllBillsById(Convert.ToInt32(fileName));
            }

        }
    }
}


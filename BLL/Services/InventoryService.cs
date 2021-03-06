﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IInventoryService
    {
        List<ClothDTO> GetInventory();
        string GetCompanyNameById(int id);
        bool SaveClothes(List<List<InventoryDTO>> data);
    }
    public class InventoryService : IInventoryService
    {
        private storesEntities DB;

        public string GetCompanyNameById(int id)
        {
            using (DB = new storesEntities())
            {
                return DB.Companys.Where(com => com.CompanyID == id).First().CompanyName;
            }
        }

        public List<ClothDTO> GetInventory()
        {
            List<ClothDTO> retval = new List<ClothDTO>();
            using (DB = new storesEntities())
            {
                try
                {
                    var list = DB.Clothes.Select(i => i).ToList<Cloth>();
                    if (list != null)
                    {
                        ClothDTO dto = new ClothDTO();
                        foreach (var item in list)
                        {
                            ClothDTO cloth = dto.ToDTO(item);
                            cloth.CompanyName = GetCompanyNameById(cloth.CompanyId);
                            retval.Add(cloth);
                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return retval;
            }
        }


        public bool SaveClothes(List<List<InventoryDTO>> data)
        {
            List<InventoryDTO> minus = data[0];
            List<InventoryDTO> plus = data[1];

            try
            {
                InventoryDTO inv = new InventoryDTO();
                using (DB = new storesEntities())
                {
                    foreach (var item in plus)
                    {


                        try
                        {
                            DB.Inventories.Add(inv.FromDTO(item));
                            DB.SaveChanges();

                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }
                    foreach (var item in minus)
                    {
                        try
                        {
                           Inventory obj= DB.Inventories.Where(i => i.ClothID==item.ClothID).FirstOrDefault();
                            DB.Inventories.Remove(obj);
                            DB.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            throw;
                        }

                    }
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }

        }
    }
}

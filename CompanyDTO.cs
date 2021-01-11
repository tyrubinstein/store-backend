using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CompanyDTO
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactMan { get; set; }
        public string ContactManCell { get; set; }
        public string Passwordcomp { get; set; }
        public string compnumOM { get; set; }
        public string City { get; set; }

        public Company FromDTO(CompanyDTO cdto)
        {
            Company company = new Company();

            company.Address = cdto.Address;
            company.ContactManCell = cdto.ContactManCell;
            company.ContactMan = cdto.ContactMan;
            company.City = cdto.City;
            company.Email = cdto.Email;
            company.compnumOM = cdto.compnumOM;
            company.Passwordcomp = cdto.Passwordcomp;
            company.CompanyName = cdto.CompanyName;


            return company;
        }
        public CompanyDTO ToDTO(Company s)
        {
            CompanyDTO cDTO = new CompanyDTO();
            cDTO.Address = s.Address;
            cDTO.ContactManCell = s.ContactManCell;
            cDTO.ContactMan = s.ContactMan;
            cDTO.City = s.City;
            cDTO.Email = s.Email;
            cDTO.Passwordcomp = s.Passwordcomp;
            cDTO.CompanyName = s.CompanyName;
            cDTO.compnumOM = s.compnumOM;
            return cDTO;
        }

    }


}

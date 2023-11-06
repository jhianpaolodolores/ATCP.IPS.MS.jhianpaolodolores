using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATCP.IPS.MS.jhianpaolodolores.Model.Dto;

namespace ATCP.IPS.MS.jhianpaolodolores.Core.Service.Contracts
{
    public interface ICustomerService
    {
        CustomerDto GetDtoById(int id);
        IList<CustomerDto> GetDto();
        void Insert(CustomerDto dto);
        void Delete(CustomerDto dto);
        void Delete(int id);
        void Update(CustomerDto dto);
        void Save();
    }


}

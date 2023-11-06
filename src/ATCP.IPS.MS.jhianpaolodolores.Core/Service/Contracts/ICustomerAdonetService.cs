using ATCP.IPS.MS.jhianpaolodolores.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCP.IPS.MS.jhianpaolodolores.Core.Service.Contracts
{
    public interface ICustomerAdoNetService
    {
        CustomerDto GetDtoById(int id);
        IList<CustomerDto> GetDto();
        void Insert(CustomerDto dto);
        void Delete(int id);
        void Update(CustomerDto dto);
    }

}

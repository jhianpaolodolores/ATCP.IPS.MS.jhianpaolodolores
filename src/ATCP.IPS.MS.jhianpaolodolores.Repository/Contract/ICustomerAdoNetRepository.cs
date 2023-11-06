using ATCP.IPS.MS.jhianpaolodolores.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCP.IPS.MS.jhianpaolodolores.Repository.Contract
{
    public interface ICustomerAdoNetRepository
    {
        Customer GetById(int id);
        IList<Customer> Get();
        void Insert(Customer entity);
        void Delete(int id);
        void Update(Customer entity);
    }
}

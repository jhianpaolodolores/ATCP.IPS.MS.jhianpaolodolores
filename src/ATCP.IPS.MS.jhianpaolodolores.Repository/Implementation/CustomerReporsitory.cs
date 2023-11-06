using ATCP.IPS.MS.jhianpaolodolores.Model.Entity;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCP.IPS.MS.jhianpaolodolores.Repository.Implementation
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IAppDbContext context) : base(context)
        {
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCP.IPS.MS.jhianpaolodolores.Repository
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();
        void Dispose(bool disposing);
    }
}

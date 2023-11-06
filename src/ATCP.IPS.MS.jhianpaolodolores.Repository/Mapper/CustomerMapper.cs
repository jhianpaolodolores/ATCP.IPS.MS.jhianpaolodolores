using ATCP.IPS.MS.jhianpaolodolores.Model.Dto;
using ATCP.IPS.MS.jhianpaolodolores.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCP.IPS.MS.jhianpaolodolores.Repository.Mapper
{
    public class CustomerMapper : MapperBase<Customer, CustomerDto>, ICustomerMapper
    {
        public override CustomerDto ConvertToDto(Customer entity, CustomerDto dto)
        {
            var mappedModel = dto ?? new CustomerDto();
            if (entity == null)
            {
                return mappedModel;
            }
            mappedModel.CustomerId = entity.CustomerId;
            mappedModel.FirstName = entity.FirstName;
            mappedModel.MiddleName = entity.MiddleName;
            mappedModel.LastName = entity.LastName;
            mappedModel.Address = entity.Address;
            mappedModel.Age = entity.Age;
            mappedModel.Gender = entity.Gender;
            mappedModel.CreatedBy = entity.CreatedBy;
            mappedModel.CreatedDttm = entity.CreatedDttm;
            mappedModel.UpdatedBy = entity.UpdatedBy;
            mappedModel.UpdatedDttm = entity.UpdatedDttm;
            return mappedModel;
        }
        public override Customer ConvertToEntity(CustomerDto dto, Customer entity)
        {
            var mappedModel = entity ?? new Customer();
            if (dto == null)
            {
                return mappedModel;
            }
            mappedModel.CustomerId = dto.CustomerId;
            mappedModel.FirstName = dto.FirstName;
            mappedModel.MiddleName = dto.MiddleName;
            mappedModel.LastName = dto.LastName;
            mappedModel.Address = dto.Address;
            mappedModel.Age = dto.Age;
            mappedModel.Gender = dto.Gender;
            mappedModel.CreatedBy = dto.CreatedBy;
            mappedModel.CreatedDttm = dto.CreatedDttm;
            mappedModel.UpdatedBy = dto.UpdatedBy;
            mappedModel.UpdatedDttm = dto.UpdatedDttm;
            return mappedModel;
        }

    }

}

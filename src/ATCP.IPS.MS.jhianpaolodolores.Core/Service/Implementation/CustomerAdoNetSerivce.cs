using ATCP.IPS.MS.jhianpaolodolores.Core.Service.Contracts;
using ATCP.IPS.MS.jhianpaolodolores.Model.Dto;
using ATCP.IPS.MS.jhianpaolodolores.Model.Entity;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Contract;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCP.IPS.MS.jhianpaolodolores.Core.Service.Implementation
{
    public class CustomerAdoNetService : ICustomerAdoNetService
    {
        private readonly ICustomerAdoNetRepository _customerRepository;
        private readonly IMapperBase<Customer, CustomerDto> _mapper;
        public CustomerAdoNetService(ICustomerAdoNetRepository customerRepository, ICustomerMapper
       mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }
        public IList<CustomerDto> GetDto()
        {
            return _mapper.ConvertToDtoList(_customerRepository.Get());
        }
        public CustomerDto GetDtoById(int id)
        {
            return _mapper.ConvertToDto(_customerRepository.GetById(id));
        }
        public void Insert(CustomerDto dto)
        {
            _customerRepository.Insert(_mapper.ConvertToEntity(dto));

        }
        public void Update(CustomerDto dto)
        {
            _customerRepository.Update(_mapper.ConvertToEntity(dto));

        }
    }

}

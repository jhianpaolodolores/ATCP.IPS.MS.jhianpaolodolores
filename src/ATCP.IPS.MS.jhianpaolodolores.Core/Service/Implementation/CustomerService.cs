using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ATCP.IPS.MS.jhianpaolodolores.Core.Service.Contracts;
using ATCP.IPS.MS.jhianpaolodolores.Model.Dto;
using ATCP.IPS.MS.jhianpaolodolores.Model.Entity;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Contract;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Mapper;
using ATCP.IPS.MS.jhianpaolodolores.Repository;

namespace ATCP.IPS.MS.jhianpaolodolores.Core.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _repository;
        private readonly IMapperBase<Customer, CustomerDto> _mapper;
        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository repository, ICustomerMapper
       mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }
        public void Delete(CustomerDto dto)
        {
            _repository.Delete(_mapper.ConvertToEntity(dto));
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public virtual IList<CustomerDto> GetDtoList(Expression<Func<Customer, bool>> filter = null,
        Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null,
        string includeProperties = "")
        {
            return _mapper.ConvertToDtoList(_repository.Get(filter, orderBy, includeProperties).ToList());
        }
        public IList<CustomerDto> GetDto()
        {
            return GetDtoList(null, null, "");
        }
        public virtual Customer GetById(int id)
        {
            return _repository.GetById(id);
        }
        public CustomerDto GetDtoById(int id)
        {
            return _mapper.ConvertToDto(GetById(id));

        }
        public void Insert(CustomerDto dto)
        {
            _repository.Insert(_mapper.ConvertToEntity(dto));
        }
        public void Save()
        {
            _unitOfWork.Save();
        }
        public void Update(CustomerDto dto)
        {
            _repository.Update(_mapper.ConvertToEntity(dto));

        }
    }
}


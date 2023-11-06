using ATCP.IPS.MS.jhianpaolodolores.Core.Service.Implementation;
using ATCP.IPS.MS.jhianpaolodolores.Model.Dto;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Contract;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Mapper;
using ATCP.IPS.MS.jhianpaolodolores.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATCP.IPS.MS.jhianpaolodolores.Model.Entity;
using System.Linq.Expressions;

namespace ATCP.IPS.MS.jhianpaolodolores.UnitTest.Service
{
    public class CustomerServiceTest
    {
        private CustomerService _service;
        private Mock<ICustomerRepository> _repository;
        private Mock<ICustomerMapper> _mapper;
        public CustomerServiceTest()
        {

            var customerDtoData = new List<CustomerDto>
            {
                 new CustomerDto {CustomerId = 1,FirstName="Juan",LastName="Dela Cruz",
                MiddleName="Cruz", Age = 31, Address = "QC", IsActive = true, Gender="Male"},
                 new CustomerDto {CustomerId = 2,FirstName="Maria Claria",
                LastName="De Los Santos",
                MiddleName="Santos", Age = 21, Address = "QC", IsActive = true, Gender="Female"},

                new CustomerDto {CustomerId = 3,FirstName="Padre",LastName="Damaso",
                MiddleName="Gomez", Age = 41, Address = "QC", IsActive = true, Gender="Male"},
            };

            _mapper = new Mock<ICustomerMapper>();
            _mapper.Setup(m => m.ConvertToDtoList(It.IsAny<IList<Customer>>())).
                Returns(customerDtoData).Verifiable();

            _repository = new Mock<ICustomerRepository>();

            var unitOfWork = new Mock<IUnitOfWork>();
            _service = new CustomerService(unitOfWork.Object, _repository.Object, _mapper.Object);
        }
        [Fact]
        public void CustomerService_GetDto_ReturnsCustomers()
        {
            var customerData = new List<Customer>
            {
                 new Customer {CustomerId = 1,FirstName="Juan",
                LastName="Dela Cruz",MiddleName="Cruz",
                Age = 31, Address = "QC", IsActive = true, Gender="Male"},
                 new Customer {CustomerId = 2,FirstName="Maria Claria",
                LastName="De Los Santos",MiddleName="Santos",
                Age = 21, Address = "QC", IsActive = true, Gender="Female"},
                 new Customer {CustomerId = 3,FirstName="Padre",
                LastName="Damaso",MiddleName="Gomez",
                Age = 41, Address = "QC", IsActive = true, Gender="Male"},
            };
            _repository.Setup(m => m.Get(It.IsAny<Expression<Func<Customer, bool>>>(),
            It.IsAny<Func<IQueryable<Customer>, IOrderedQueryable<Customer>>>(),
            It.IsAny<string>())).Returns(customerData).Verifiable();
            var actual = _service.GetDto();

            Assert.NotNull(actual);
            Assert.True(actual.Count() > 0);
        }
        [Fact]
        public void CustomerService_GetDto_ReturnsCustomerById()
        {
            var customerId = 3;
            var customer = new Customer
            {
                CustomerId = 3,
                FirstName = "Padre",
                LastName = "Damaso",
                MiddleName = "Gomez",
                Age = 41,
                Address = "QC",
                IsActive = true,
                Gender = "Male"
            };
            _repository.Setup(m => m.GetById(It.IsAny<int>())).Returns(customer).Verifiable();

            var actual = _service.GetById(customerId);

            Assert.NotNull(actual);
            Assert.True(actual.CustomerId == customerId);
        }
        [Fact]
        public void CustomerService_Delete()
        {
            var customerId = 3;
            var customer = new Customer
            {
                CustomerId = 3,
                FirstName = "Padre",
                LastName = "Damaso",
                MiddleName = "Gomez",
                Age = 41,
                Address = "QC",
                IsActive = true,
                Gender = "Male"
            };
            _repository.Setup(m => m.Delete(It.IsAny<Customer>()));
            _service.Delete(customerId);
            _repository.Verify(r => r.Delete(customerId));

        }
    }

}

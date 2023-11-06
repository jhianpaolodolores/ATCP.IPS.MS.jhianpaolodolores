using ATCP.IPS.MS.jhianpaolodolores.Core.Helpers;
using ATCP.IPS.MS.jhianpaolodolores.Core.Service.Contracts;
using ATCP.IPS.MS.jhianpaolodolores.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ATCP.IPS.MS.jhianpaolodolores.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<CustomerController>
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerAdoNetService _customerAdoNetService;

        public CustomerController(ICustomerService customerService, ICustomerAdoNetService
        customerAdoNetService)
        {
            _customerAdoNetService = customerAdoNetService;
            _customerService = customerService;

        }
        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>The <see cref="IEnumerable<CustomerDto>"/>.</returns>
        // GET: api/<CustomerController>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCustomers()
        {
            return Ok(_customerAdoNetService.GetDto());

        }

        /// <summary>
        /// Gets customers by id
        /// </summary>
        /// <returns>The <see cref="CustomerDto"/>.</returns>
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerService.GetDtoById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        /// <summary>
        /// Updates a customer
        /// </summary>
        /// <returns>The <see cref="IEnumerable<CustomerDto>"/>.</returns>
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutCustomer(int id, CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            try
            {
                _customerService.Update(customer);
                _customerService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_customerService.GetDto());
        }
        /// <summary>
        /// Adds a customer
        /// </summary>
        /// <returns>The <see cref="IEnumerable<CustomerDto>"/>.</returns>
        // POST: api/Customer
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        public IActionResult PostCustomer(CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _customerService.Insert(customer);
            _customerService.Save();
            return Ok(_customerService.GetDto());
        }
        /// <summary>
        /// Deletes a customer
        /// </summary>
        /// <returns>The <see cref="IEnumerable<CustomerDto>"/>.</returns>
        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        public IActionResult DeleteCustomer(int id)
        {
            CustomerDto customer = _customerService.GetDtoById(id);
            if (customer == null)
            {
                return NotFound();
            }
            _customerService.Delete(id);
            _customerService.Save();
            return Ok(_customerService.GetDto());
        }
        /// <summary>
        /// Checks if a customer exists
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>bool</returns>
        private bool CustomerExists(int id)
        {
            CustomerDto customer = _customerService.GetDtoById(id);
            return (customer == null) ? false : true;
        }
        /// <summary>
        /// Get customer's full name
        /// </summary>
        /// <param name="firstName">customer's firstname</param>
        /// <param name="lastName">customer's lastname</param>
        /// <returns></returns>
        [HttpGet("{lastName}/{firstName}")]
        public string GetFullName(string firstName, string lastName)
        {
            var customers = _customerAdoNetService.GetDto();
            Logger.Log(LogLevel.Information, "Customer Index");
            return StringUtility.Concatenate(firstName, lastName, string.Empty);
        }
        /// <summary>
        /// Get customer's full name
        /// </summary>
        /// <param name="firstName">customer's firstname</param>
        /// <param name="lastName">customer's lastname</param>
        /// <param name="comma">comma</param>
        /// <returns></returns>
        [HttpGet("{lastName}/{firstName}/{comma}")]
        public string GetFullNameWithComma(string firstName, string lastName, string comma)
        {
            string name = StringUtility.Concatenate(firstName, lastName, comma);
            return name;
        }
    }

}

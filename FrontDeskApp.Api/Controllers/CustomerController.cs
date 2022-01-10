using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FrontDeskApp.Api.Resources;
using FrontDeskApp.Api.Validators;
using FrontDeskApp.Core.Models;
using FrontDeskApp.Core.Services;
using AutoMapper;

namespace FrontDeskApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this._mapper = mapper;
            this._customerService = customerService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CustomerResource>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllWithCustomer();
            var customerResources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);

            return Ok(customerResources);
        }

        [HttpGet("{firstName}/{lastName}/{phoneNumber}")]
        public async Task<ActionResult<CustomerResource>> GetCustomercByNameAndPhoneNumber(string firstName, string lastName, string phoneNumber)
        {
            var customer = await _customerService.GetCustomerByFirstNameLastNamePhoneNumber(firstName, lastName, phoneNumber);
            var customerResource = _mapper.Map<Customer, CustomerResource>(customer);

            return Ok(customerResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CustomerResource>> CreateCustomer([FromBody] SaveCustomerResource saveCustomerResource)
        {
            var validator = new SaveCustomerResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCustomerResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var customerToCreate = _mapper.Map<SaveCustomerResource, Customer>(saveCustomerResource);

            var newCustomer = await _customerService.CreateCustomer(customerToCreate);

            var customer = await _customerService.GetCustomerById(newCustomer.CustomerId);

            var customerResource = _mapper.Map<Customer, CustomerResource>(customer);

            return Ok(customerResource);
        }
    }
}

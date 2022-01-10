using System.Collections.Generic;
using System.Threading.Tasks;
using FrontDeskApp.Core;
using FrontDeskApp.Core.Models;
using FrontDeskApp.Core.Services;

namespace FrontDeskApp.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            await _unitOfWork.Customers
               .AddAsync(newCustomer);
            await _unitOfWork.CommitAsync();

            return newCustomer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _unitOfWork.Customers.Remove(customer);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllWithCustomer()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByFirstNameLastNamePhoneNumber(string customerFirstName, string customerLastName, string customerPhoneNumber)
        {
            return await _unitOfWork.Customers.GetWithCustomerByCustomerNameAndPhoneNumberAsync(customerFirstName, customerLastName, customerPhoneNumber);
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _unitOfWork.Customers.GetByIdAsync(customerId);
        }

        public Task UpdateCustomer(Customer CustomerToBeUpdated, Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}

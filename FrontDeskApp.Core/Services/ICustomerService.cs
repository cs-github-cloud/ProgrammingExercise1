using System.Collections.Generic;
using System.Threading.Tasks;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllWithCustomer();
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> GetCustomerByFirstNameLastNamePhoneNumber(string customerFirstName, string customerLastName, string customerPhoneNumber);
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer CustomerToBeUpdated, Customer customer);
        Task DeleteCustomer(Customer customer);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllWithCustomerAsync();
        Task<Customer> GetWithCustomerByIdAsync(int customerId);
        Task<Customer> GetWithCustomerByCustomerNameAndPhoneNumberAsync(string customerFirstName, string customerLastName, string customerPhoneNumber);
    }
}

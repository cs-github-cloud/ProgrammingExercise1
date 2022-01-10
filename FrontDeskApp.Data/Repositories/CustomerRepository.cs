using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrontDeskApp.Core.Models;
using FrontDeskApp.Core.Repositories;

namespace FrontDeskApp.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FrontDeskAppDbContext context)
            : base(context)
        { }

        private FrontDeskAppDbContext FrontDeskAppDbContext
        {
            get { return Context as FrontDeskAppDbContext; }
        }

        public async Task<IEnumerable<Customer>> GetAllWithCustomerAsync()
        {
            return await FrontDeskAppDbContext.Customers
                .ToListAsync();
        }

        public async Task<Customer> GetWithCustomerByCustomerNameAndPhoneNumberAsync(string customerFirstName, string customerLastName, string customerPhoneNumber)
        {
            return await FrontDeskAppDbContext.Customers
                .SingleOrDefaultAsync(m => m.CustomerLastName.Contains(customerLastName) && m.CustomerFirstName.Contains(customerFirstName) && m.CustomerPhoneNumer.Contains(customerPhoneNumber));
        }

        public Task<Customer> GetWithCustomerByIdAsync(int customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}

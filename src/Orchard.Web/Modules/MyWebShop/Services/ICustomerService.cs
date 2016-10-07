using MyWebShop.Models;
using Orchard;
using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebShop.Services
{
    public interface ICustomerService : IDependency
    {
        CustomerPart CreateCustomer(string email, string phoneNumber, string password);
        AddressPart GetAddress(int customerId, string addressType);

        AddressPart GetAddress(int id);

        IEnumerable<AddressPart> GetAddresses(int customerId);
        AddressPart CreateAddress(int customerId, string addressType);

        IContentQuery<CustomerPart> GetCustomers();
        CustomerPart GetCustomer(int id);
    }

}

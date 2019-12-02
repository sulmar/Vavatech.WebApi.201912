using System;
using System.Collections.Generic;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.IServices
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get();
        IEnumerable<Customer> Get(string city, string street);
        Customer Get(int id);
        Customer Get(string pesel);
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(int id);

    }
}

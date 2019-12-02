using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WebApi.FakeServices;
using Vavatech.WebApi.IServices;

namespace Vavatech.WebApi.Api.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController()
            : this(new FakeCustomerService())
        {

        }

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IHttpActionResult Get()
        {
            var customers = customerService.Get();

            return Ok(customers);
        }

        public IHttpActionResult Get(int id)
        {
            var customer = customerService.Get(id);

            return Ok(customer);
        }

        public IHttpActionResult Get(string pesel)
        {
            var customer = customerService.Get(pesel);

            return Ok(customer);
        }

       
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WebApi.FakeServices;
using Vavatech.WebApi.IServices;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.Api.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService productService;

        public ProductsController()
            : this(new FakeProductService(new ProductFaker()))
        {
        }

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var products = productService.Get();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var product = productService.Get(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [Route("{color:alpha}")]
        public IHttpActionResult Get(string color)
        {
            var products = productService.Get(color);

            return Ok(products);
        }

        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            productService.Add(product);

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!productService.Exists(id))
                return NotFound();

            productService.Remove(id);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(decimal from, decimal to)
        {
            var products = productService.Get(from, to);

            return Ok(products);
        }
    }
}
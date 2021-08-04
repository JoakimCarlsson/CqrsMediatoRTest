using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsMediatoRTest.Product.Commands;
using CqrsMediatoRTest.Product.Commands.AddProduct;
using CqrsMediatoRTest.Product.Queries;
using CqrsMediatoRTest.Product.Queries.GetProduct;
using MediatR;

namespace CqrsMediatoRTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Models.Product product)
        {
            var newProduct = await _mediator.Send(new AddProductCommand(product));
            return CreatedAtRoute("GetProductById", new { id = newProduct.Id}, product);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }
    }
}

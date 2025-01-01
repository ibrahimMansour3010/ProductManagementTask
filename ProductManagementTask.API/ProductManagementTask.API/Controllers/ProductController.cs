using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementTask.API.Controllers;
using ProductManagementTask.Applications.Common.Interfaces;
using ProductManagementTask.Applications.Product.Commands.CreateProduct;
using ProductManagementTask.Applications.Product.Commands.CreateProduct.Dtos;
using ProductManagementTask.Applications.Product.Commands.UpdateProduct;
using ProductManagementTask.Applications.Product.Commands.UpdateProduct.Dtos;
using ProductManagementTask.Applications.Product.DeleteProduct;
using ProductManagementTask.Applications.Product.DeleteProduct.Dtos;
using ProductManagementTask.Applications.Product.Queries;
using ProductManagementTask.Applications.Product.Queries.Dtos;

namespace ProductManagementTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController :  BaseController
    {
        [HttpGet("GetProductList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(contentType: "application/json", Type = typeof(IResult<ProductListOutput>))]
        public async Task<IActionResult> GetProductList([FromQuery] ProductListQuery query)
            => Ok(await Mediator.Send(query));


        [HttpPost("CreateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(contentType: "application/json", Type = typeof(IResult<CreateProductOutput>))]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
            => Ok(await Mediator.Send(command));


        [HttpPut("UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(contentType: "application/json", Type = typeof(IResult<UpdateProductOutput>))]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
            => Ok(await Mediator.Send(command));

        [HttpDelete("DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(contentType: "application/json", Type = typeof(IResult<DeleteProductOutput>))]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
            => Ok(await Mediator.Send(command));
    }
}




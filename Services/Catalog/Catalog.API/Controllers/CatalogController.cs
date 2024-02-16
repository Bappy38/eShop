using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers;

public class CatalogController : ApiController
{
    private readonly IMediator _mediator;

	public CatalogController(IMediator mediator)
	{
		_mediator = mediator;
	}

    [HttpPost]
    [Route("CreateProduct")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody]CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Route("UpdateProduct")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateProduct([FromBody]UpdateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        var command = new DeleteProductByIdCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

	[HttpGet]
	[Route("[action]/{id}", Name = "GetProductById")]
	[ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
	public async Task<ActionResult<ProductResponse>> GetProductById(string id)
	{
		var query = new GetProductByIdQuery(id);
		var result = await _mediator.Send(query);
		return Ok(result);
	}

    [HttpGet]
    [Route("[action]/{productName}", Name = "GetProductsByProductName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductsByProductName(string productName)
    {
        var query = new GetProductByNameQuery(productName);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllProduct")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetAllProduct()
    {
        var query = new GetAllProductsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllBrand")]
    [ProducesResponseType(typeof(IList<BrandReponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<BrandReponse>>> GetAllBrand()
    {
        var query = new GetAllBrandsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("[action]/{brandName}", Name = "GetProductsByBrandName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductsByBrandName(string brandName)
    {
        var query = new GetProductsByBrandQuery(brandName);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllType")]
    [ProducesResponseType(typeof(IList<TypeResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<TypeResponse>>> GetAllType()
    {
        var query = new GetAllTypesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}

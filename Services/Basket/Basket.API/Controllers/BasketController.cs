using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Domain.Entities;
using MassTransit;
using MediatR;
using MessageBus.Events;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers;

public class BasketController : APIController
{
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _publishEndpoint;


    public BasketController(IMediator mediator, IPublishEndpoint publishEndpoint)
    {
        _mediator = mediator;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    [Route("[action]/{userName}", Name = "GetBasketByUserName")]
    [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> GetBasketByUserName(string userName)
    {
        var query = new GetBasketByUserNameQuery(userName);
        var basket = await _mediator.Send(query);
        return Ok(basket);
    }

    [HttpPost("CreateBasket")]
    [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] CreateBasketCommand createBasketCommand)
    {
        var basket = await _mediator.Send(createBasketCommand);
        return Ok(basket);
    }

    [HttpDelete]
    [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> DeleteBasketByUserName(string userName)
    {
        var command = new DeleteBasketByUserNameCommand(userName);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [Route("[action]")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Checkout([FromBody] Checkout checkout)
    {
        //TODO:: Need to refactor it and move all the business logic to a service. Also, need a wrapper over message bus
        var query = new GetBasketByUserNameQuery(checkout.UserName);
        var shoppingCart = await _mediator.Send(query);

        if (shoppingCart is null)
        {
            return BadRequest();
        }

        var eventMessage = BasketMapper.Mapper.Map<CheckedOutEvent>(checkout);
        eventMessage.TotalPrice = (double)shoppingCart.TotalPrice;

        await _publishEndpoint.Publish(eventMessage);

        var deleteQuery = new DeleteBasketByUserNameCommand(checkout.UserName);
        await _mediator.Send(deleteQuery);
        return Accepted();
    }
}

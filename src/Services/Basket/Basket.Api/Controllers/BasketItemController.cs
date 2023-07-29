// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Basket.Core.AggregatesModel.BasketItemAggregate.Commands;
using Basket.Core.AggregatesModel.BasketItemAggregate.Queries;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace Basket.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class BasketItemController
{
    private readonly IMediator _mediator;

    private readonly ILogger<BasketItemController> _logger;

    public BasketItemController(IMediator mediator,ILogger<BasketItemController> logger){
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update BasketItem",
        Description = @"Update BasketItem"
    )]
    [HttpPut(Name = "updateBasketItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateBasketItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateBasketItemResponse>> Update([FromBody]UpdateBasketItemRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create BasketItem",
        Description = @"Create BasketItem"
    )]
    [HttpPost(Name = "createBasketItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateBasketItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateBasketItemResponse>> Create([FromBody]CreateBasketItemRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get BasketItems",
        Description = @"Get BasketItems"
    )]
    [HttpGet(Name = "getBasketItems")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetBasketItemsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetBasketItemsResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetBasketItemsRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get BasketItem by id",
        Description = @"Get BasketItem by id"
    )]
    [HttpGet("{basketItemId:guid}", Name = "getBasketItemById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetBasketItemByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetBasketItemByIdResponse>> GetById([FromRoute]Guid basketItemId,CancellationToken cancellationToken)
    {
        var request = new GetBasketItemByIdRequest(){BasketItemId = basketItemId};

        var response = await _mediator.Send(request, cancellationToken);

        if (response.BasketItem == null)
        {
            return new NotFoundObjectResult(request.BasketItemId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete BasketItem",
        Description = @"Delete BasketItem"
    )]
    [HttpDelete("{basketItemId:guid}", Name = "deleteBasketItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteBasketItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteBasketItemResponse>> Delete([FromRoute]Guid basketItemId,CancellationToken cancellationToken)
    {
        var request = new DeleteBasketItemRequest() {BasketItemId = basketItemId };

        return await _mediator.Send(request, cancellationToken);
    }

}



// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Catalog.Core.CatalogItemAggregate.Commands;
using Catalog.Core.CatalogItemAggregate.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Net.Mime;

namespace Catalog.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class CatalogItemController
{
    private readonly IMediator _mediator;

    private readonly ILogger<CatalogItemController> _logger;

    public CatalogItemController(IMediator mediator,ILogger<CatalogItemController> logger){
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update CatalogItem",
        Description = @"Update CatalogItem"
    )]
    [HttpPut(Name = "updateCatalogItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateCatalogItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateCatalogItemResponse>> Update([FromBody]UpdateCatalogItemRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create CatalogItem",
        Description = @"Create CatalogItem"
    )]
    [HttpPost(Name = "createCatalogItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateCatalogItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateCatalogItemResponse>> Create([FromBody]CreateCatalogItemRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get CatalogItems",
        Description = @"Get CatalogItems"
    )]
    [HttpGet(Name = "getCatalogItems")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetCatalogItemsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetCatalogItemsRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get CatalogItem by id",
        Description = @"Get CatalogItem by id"
    )]
    [HttpGet("{catalogItemId:guid}", Name = "getCatalogItemById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetCatalogItemByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemByIdResponse>> GetById([FromRoute]Guid catalogItemId,CancellationToken cancellationToken)
    {
        var request = new GetCatalogItemByIdRequest(){CatalogItemId = catalogItemId};

        var response = await _mediator.Send(request, cancellationToken);

        if (response.CatalogItem == null)
        {
            return new NotFoundObjectResult(request.CatalogItemId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete CatalogItem",
        Description = @"Delete CatalogItem"
    )]
    [HttpDelete("{catalogItemId:guid}", Name = "deleteCatalogItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteCatalogItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteCatalogItemResponse>> Delete([FromRoute]Guid catalogItemId,CancellationToken cancellationToken)
    {
        var request = new DeleteCatalogItemRequest() {CatalogItemId = catalogItemId };

        return await _mediator.Send(request, cancellationToken);
    }

}



// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Basket.Core.AggregatesModel.BasketItemAggregate.Queries;

public class GetBasketItemsRequest: IRequest<GetBasketItemsResponse> { }

public class GetBasketItemsResponse
{
    public required List<BasketItemDto> BasketItems { get; set; }
}


public class GetBasketItemsRequestHandler: IRequestHandler<GetBasketItemsRequest,GetBasketItemsResponse>
{
    private readonly IBasketDbContext _context;

    private readonly ILogger<GetBasketItemsRequestHandler> _logger;

    public GetBasketItemsRequestHandler(ILogger<GetBasketItemsRequestHandler> logger,IBasketDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetBasketItemsResponse> Handle(GetBasketItemsRequest request,CancellationToken cancellationToken)
    {
        return new () {
            BasketItems = await _context.BasketItems.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}




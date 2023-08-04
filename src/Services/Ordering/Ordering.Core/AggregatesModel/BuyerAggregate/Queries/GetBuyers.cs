// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.BuyerAggregate.Queries;

public class GetBuyersRequest: IRequest<GetBuyersResponse> { }

public class GetBuyersResponse
{
    public required List<BuyerDto> Buyers { get; set; }
}


public class GetBuyersRequestHandler: IRequestHandler<GetBuyersRequest,GetBuyersResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<GetBuyersRequestHandler> _logger;

    public GetBuyersRequestHandler(ILogger<GetBuyersRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetBuyersResponse> Handle(GetBuyersRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Buyers = await _context.Buyers.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}




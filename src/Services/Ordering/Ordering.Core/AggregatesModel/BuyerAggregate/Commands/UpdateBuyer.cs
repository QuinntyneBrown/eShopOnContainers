// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.BuyerAggregate.Commands;

public class UpdateBuyerRequestValidator: AbstractValidator<UpdateBuyerRequest>
{
    public UpdateBuyerRequestValidator(){

        RuleFor(x => x.BuyerId).NotNull();

    }

}


public class UpdateBuyerRequest: IRequest<UpdateBuyerResponse>
{
    public guid BuyerId { get; set; }
}


public class UpdateBuyerResponse
{
    public required BuyerDto Buyer { get; set; }
}


public class UpdateBuyerRequestHandler: IRequestHandler<UpdateBuyerRequest,UpdateBuyerResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<UpdateBuyerRequestHandler> _logger;

    public UpdateBuyerRequestHandler(ILogger<UpdateBuyerRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateBuyerResponse> Handle(UpdateBuyerRequest request,CancellationToken cancellationToken)
    {
        var buyer = await _context.Buyers.SingleAsync(x => x.BuyerId == request.BuyerId);

        buyer.BuyerId = request.BuyerId;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Buyer = buyer.ToDto()
        };

    }

}




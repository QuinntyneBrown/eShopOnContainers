// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.BuyerAggregate.Commands;

public class DeleteBuyerRequestValidator: AbstractValidator<DeleteBuyerRequest>
{
    public DeleteBuyerRequestValidator(){

        RuleFor(x => x.BuyerId).NotNull();

    }

}


public class DeleteBuyerRequest: IRequest<DeleteBuyerResponse>
{
    public guid BuyerId { get; set; }
}


public class DeleteBuyerResponse
{
    public required BuyerDto Buyer { get; set; }
}


public class DeleteBuyerRequestHandler: IRequestHandler<DeleteBuyerRequest,DeleteBuyerResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<DeleteBuyerRequestHandler> _logger;

    public DeleteBuyerRequestHandler(ILogger<DeleteBuyerRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteBuyerResponse> Handle(DeleteBuyerRequest request,CancellationToken cancellationToken)
    {
        var buyer = await _context.Buyers.FindAsync(request.BuyerId);

        _context.Buyers.Remove(buyer);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Buyer = buyer.ToDto()
        };
    }

}




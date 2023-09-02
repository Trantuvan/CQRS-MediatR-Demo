using CQRSMediatRExample.Models;
using CQRSMediatRExample.Queries;
using MediatR;

namespace CQRSMediatRExample.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly FakeDataStore _fakeDataStore;

    public GetProductByIdQueryHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _fakeDataStore.GetProductByIdAsync(request.Id);
    }
}
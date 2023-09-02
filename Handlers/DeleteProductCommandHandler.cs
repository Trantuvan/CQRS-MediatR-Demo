using CQRSMediatRExample.Commands;
using CQRSMediatRExample.Models;
using MediatR;

namespace CQRSMediatRExample.Handlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly FakeDataStore _fakeDataStore;

    public DeleteProductCommandHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _fakeDataStore.DeleteProductAsync(request.Product);
    }
}

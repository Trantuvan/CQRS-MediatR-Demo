using CQRSMediatRExample.Models;
using MediatR;

namespace CQRSMediatRExample.Queries;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
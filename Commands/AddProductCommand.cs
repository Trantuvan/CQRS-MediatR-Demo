using CQRSMediatRExample.Models;
using MediatR;

namespace CQRSMediatRExample.Commands;

public record AddProductCommand(Product Product) : IRequest;
using Itmo.ObjectOrientedProgramming.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory.Models;

public sealed record OperationDto(Guid OperationId, decimal Amount, DateTime Time, OperationType OperationType);
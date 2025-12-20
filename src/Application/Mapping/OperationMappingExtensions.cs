using Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory.Models;
using Itmo.ObjectOrientedProgramming.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Application.Mapping;

public static class OperationMappingExtensions
{
    public static OperationDto MapToDto(this Operation operation)
        => new OperationDto(
            operation.Id,
            operation.TransactionAmount.Value,
            operation.TransactionTime,
            operation.Type);
}
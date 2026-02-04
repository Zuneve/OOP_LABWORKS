namespace Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory.Models;

public sealed record OperationDto(long OperationId, decimal Amount, DateTime Time, string OperationType);
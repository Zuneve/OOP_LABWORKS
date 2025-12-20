using Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory.Operations;

namespace Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory;

public interface IOperationHistoryService
{
    ShowOperationHistory.Response ShowOperationHistory(ShowOperationHistory.Request request);
}
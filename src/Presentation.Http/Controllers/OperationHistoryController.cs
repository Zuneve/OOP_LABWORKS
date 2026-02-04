using Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory;
using Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory.Models;
using Itmo.ObjectOrientedProgramming.Application.Contracts.OperationHistory.Operations;
using Microsoft.AspNetCore.Mvc;
using Presentation.Http.Models;
using System.Diagnostics;

namespace Presentation.Http.Controllers;

[ApiController]
[Route("/api/operations")]
public sealed class OperationHistoryController : ControllerBase
{
    private readonly IOperationHistoryService _operationHistoryService;

    public OperationHistoryController(IOperationHistoryService operationHistoryService)
    {
        _operationHistoryService = operationHistoryService;
    }

    [HttpPost("history")]
    public ActionResult<IReadOnlyCollection<OperationDto>> ShowOperationHistory(
        [FromQuery] ShowOperationHistoryRequest httpRequest)
    {
        var request = new ShowOperationHistory.Request(httpRequest.SessionId);
        ShowOperationHistory.Response response = _operationHistoryService.ShowOperationHistory(request);

        return response switch
        {
            ShowOperationHistory.Response.Success success => Ok(success.OperationHistory),
            ShowOperationHistory.Response.Failed failed => BadRequest("Account not valid"),
            _ => throw new UnreachableException(),
        };
    }
}
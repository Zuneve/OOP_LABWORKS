using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Operations;
using Microsoft.AspNetCore.Mvc;
using Presentation.Http.Models;
using System.Diagnostics;

namespace Presentation.Http.Controllers;

[ApiController]
[Route("/api/session")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("user")]
    public ActionResult<Guid> CreateUserSession([FromBody] CreateUserSessionRequest httpRequest)
    {
        var request = new CreateUserSession.Request(httpRequest.AccountId, httpRequest.PinCode);
        CreateUserSession.Response response = _sessionService.CreateUserSession(request);

        return response switch
        {
            CreateUserSession.Response.Success success => Ok(success.UserSession.SessionId),
            CreateUserSession.Response.Failed failed => BadRequest("Wrong AccountId or PinCode"),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("admin")]
    public ActionResult<Guid> CreateAdminSession([FromBody] CreateAdminSessionRequest httpRequest)
    {
        var request = new CreateAdminSession.Request(httpRequest.AdminPassword);
        CreateAdminSession.Response response = _sessionService.CreateAdminSession(request);

        return response switch
        {
            CreateAdminSession.Response.Success success => Ok(success.AdminSession.SessionId),
            CreateAdminSession.Response.Failed failed => BadRequest("Wrong password"),
            _ => throw new UnreachableException(),
        };
    }
}
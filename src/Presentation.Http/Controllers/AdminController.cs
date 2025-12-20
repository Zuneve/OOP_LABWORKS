using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Models;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Admin;
using Microsoft.AspNetCore.Mvc;
using Presentation.Http.Models;
using System.Diagnostics;

namespace Presentation.Http.Controllers;

[ApiController]
[Route("/api/admin")]
public sealed class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("create-account")]
    public ActionResult<AccountDto> CreateAccount([FromBody] CreateAccountRequest httpRequest)
    {
        var request = new CreateAccount.Request(httpRequest.SessionId, httpRequest.PinCode);
        CreateAccount.Response response = _adminService.CreateAccount(request);

        return response switch
        {
            CreateAccount.Response.Success success => Ok(success.AccountDto),
            CreateAccount.Response.Failed failed => BadRequest("Wrong password"),
            _ => throw new UnreachableException(),
        };
    }
}
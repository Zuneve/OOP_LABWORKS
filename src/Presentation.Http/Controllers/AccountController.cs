using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Application.Contracts.Accounts.Operations;
using Microsoft.AspNetCore.Mvc;
using Presentation.Http.Models;
using System.Diagnostics;

namespace Presentation.Http.Controllers;

[ApiController]
[Route("/api/account")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("balance")]
    public ActionResult<decimal> ShowBalance([FromQuery] ShowBalanceRequest httpRequest)
    {
        var request = new ShowBalanceAccount.Request(httpRequest.SessionId);
        ShowBalanceAccount.Response response = _accountService.ShowBalanceAccount(request);

        return response switch
        {
            ShowBalanceAccount.Response.Success success => Ok(success.Balance),
            ShowBalanceAccount.Response.Failed failed => BadRequest("Wrong password"),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<decimal> Deposit([FromBody] DepositRequest httpRequest)
    {
        var request = new Deposit.Request(httpRequest.SessionId, httpRequest.Amount);
        Deposit.Response response = _accountService.Deposit(request);

        return response switch
        {
            Deposit.Response.Success success => Ok(success.NewBalance),
            Deposit.Response.Failed failed => BadRequest("Wrong password"),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<decimal> Withdraw([FromBody] WithdrawRequest httpRequest)
    {
        var request = new Withdraw.Request(httpRequest.SessionId, httpRequest.Amount);
        Withdraw.Response response = _accountService.Withdraw(request);

        return response switch
        {
            Withdraw.Response.Success success => Ok(success.NewBalance),
            Withdraw.Response.Failed failed => BadRequest("Wrong password"),
            _ => throw new UnreachableException(),
        };
    }
}
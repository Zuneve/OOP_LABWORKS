using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Models;
using Itmo.ObjectOrientedProgramming.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Application.Mapping;

public static class UserSessionMappingExtensions
{
    public static UserSessionDto MapToDto(this UserSession account)
        => new UserSessionDto(account.SessionId);
}
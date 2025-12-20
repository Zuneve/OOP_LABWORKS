using Itmo.ObjectOrientedProgramming.Application.Contracts.Sessions.Models;
using Itmo.ObjectOrientedProgramming.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Application.Mapping;

public static class AdminSessionMappingExtensions
{
    public static AdminSessionDto MapToDto(this AdminSession account)
        => new AdminSessionDto(account.SessionId);
}
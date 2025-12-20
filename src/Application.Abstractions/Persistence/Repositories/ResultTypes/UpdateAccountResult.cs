namespace Application.Abstractions.Persistence.Repositories.ResultTypes;

public abstract record UpdateAccountResult
{
    private UpdateAccountResult() { }

    public sealed record Success() : UpdateAccountResult;

    public sealed record Failed() : UpdateAccountResult;
}
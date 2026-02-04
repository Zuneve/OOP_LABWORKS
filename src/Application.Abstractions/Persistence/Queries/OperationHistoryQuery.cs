using Itmo.ObjectOrientedProgramming.Domain.Accounts;
using SourceKit.Generators.Builder.Annotations;

namespace Application.Abstractions.Persistence.Queries;

[GenerateBuilder]
public sealed partial record OperationHistoryQuery(AccountId[] Ids);
using SourceKit.Generators.Builder.Annotations;

namespace Application.Abstractions.Persistence.Queries;

[GenerateBuilder]
public sealed partial record SessionQuery(Guid[] Ids);
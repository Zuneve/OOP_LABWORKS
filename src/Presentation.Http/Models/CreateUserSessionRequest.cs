using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Http.Models;

public sealed class CreateUserSessionRequest
{
    [Required]
    public Guid AccountId { get; set; }

    [NotNull]
    [Required]
    [MinLength(4)]
    public string? PinCode { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Http.Models;

public sealed class CreateAccountRequest
{
    [Required]
    public Guid SessionId { get; set; }

    [NotNull]
    [Required]
    [MinLength(4)]
    public string? PinCode { get; set; }
}
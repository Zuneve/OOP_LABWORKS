using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Http.Models;

public sealed class CreateAdminSessionRequest
{
    [NotNull]
    [Required]
    public string? AdminPassword { get; set; }
}
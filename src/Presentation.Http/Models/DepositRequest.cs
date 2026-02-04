using System.ComponentModel.DataAnnotations;

namespace Presentation.Http.Models;

public sealed class DepositRequest
{
    [Required]
    public Guid SessionId { get; set; }

    [Required]
    public decimal Amount { get; set; }
}
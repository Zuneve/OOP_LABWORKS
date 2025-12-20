using System.ComponentModel.DataAnnotations;

namespace Presentation.Http.Models;

public sealed class WithdrawRequest
{
    [Required]
    public Guid SessionId { get; set; }

    [Required]
    public decimal Amount { get; set; }
}
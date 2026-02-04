using System.ComponentModel.DataAnnotations;

namespace Presentation.Http.Models;

public sealed class ShowBalanceRequest
{
    [Required]
    public Guid SessionId { get; set; }
}
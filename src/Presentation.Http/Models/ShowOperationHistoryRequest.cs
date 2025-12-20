using System.ComponentModel.DataAnnotations;

namespace Presentation.Http.Models;

public sealed class ShowOperationHistoryRequest
{
    [Required]
    public Guid SessionId { get; set; }
}
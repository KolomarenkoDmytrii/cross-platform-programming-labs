namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;

public class RefStatus
{
    [Key]
    public string StatusCode { get; set; }
    public string StatusDescription { get; set; }
}

namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;

public class RefSize
{
    [Key]
    public string SizeCode { get; set; }
    public string SizeDescription { get; set; } // eg. Small, Medium, Large
}

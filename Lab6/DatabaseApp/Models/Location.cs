namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;

public class Location
{
    [Key]
    public int LocationID { get; set; }
    public string LocationDetails { get; set; }
}

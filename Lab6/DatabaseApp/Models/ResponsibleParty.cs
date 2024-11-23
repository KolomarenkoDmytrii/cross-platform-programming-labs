namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;

public class ResponsibleParty
{
    [Key]
    public int PartyID { get; set; }
    public string PartyDetails { get; set; }
}

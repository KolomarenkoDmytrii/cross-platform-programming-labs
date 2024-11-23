namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AssetLifeCycleEvent
{
    [Key]
    public int AssetLifeCycleEventID { get; set; }

    [ForeignKey("Asset")]
    public int AssetID { get; set; }
    public Asset Asset { get; set; }

    [ForeignKey("LifeCyclePhase")]
    public string LifeCycleCode { get; set; }
    public LifeCyclePhase LifeCyclePhase { get; set; }

    [ForeignKey("Location")]
    public int LocationID { get; set; }
    public Location Location { get; set; }

    [ForeignKey("ResponsibleParty")]
    public int PartyID { get; set; }
    public ResponsibleParty ResponsibleParty { get; set; }

    [ForeignKey("RefStatus")]
    public string StatusCode { get; set; }
    public RefStatus RefStatus { get; set; }

    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}

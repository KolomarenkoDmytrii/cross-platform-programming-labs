namespace DatabaseApp.Models;

public class SearchResult
{
    public int AssetID { get; set; }
    public string AssetName { get; set; }
    public string OtherDetails { get; set; }
    public int AssetLifeCycleEventID { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public string LifeCycleCode { get; set; }
    public string StatusCode { get; set; }
    public string LifeCycleName { get; set; }
    public string LocationDetails { get; set; }
    public string PartyDetails { get; set; }
}


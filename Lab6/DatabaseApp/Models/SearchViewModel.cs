namespace DatabaseApp.Models;

public class SearchViewModel
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<string> Statuses { get; set; }
    public string AssetNameStart { get; set; }
    public string AssetNameEnd { get; set; }
}

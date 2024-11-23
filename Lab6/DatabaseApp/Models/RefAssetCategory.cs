namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;

public class RefAssetCategory
{
    [Key]
    public string AssetCategoryCode { get; set; }
    public string AssetCategoryDescription { get; set; } // eg. Domestic
}

namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RefAssetSupertype
{
    [Key]
    public string AssetSupertypeCode { get; set; }

    [ForeignKey("RefAssetCategory")]
    public string AssetCategoryCode { get; set; }
    public RefAssetCategory RefAssetCategory { get; set; }

    public string AssetSupertypeDescription { get; set; } // eg. Cutlery
}

namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RefAssetType
{
    [Key]
    public string AssetTypeCode { get; set; }

    [ForeignKey("RefAssetSupertype")]
    public string AssetSupertypeCode { get; set; }
    public RefAssetSupertype RefAssetSupertype { get; set; }

    public string AssetTypeDescription { get; set; } // eg. Spoon
}

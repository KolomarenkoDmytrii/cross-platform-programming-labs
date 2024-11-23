namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Asset
{
    [Key]
    public int AssetID { get; set; }

    [ForeignKey("RefAssetType")]
    public string AssetTypeCode { get; set; }
    public RefAssetType RefAssetType { get; set; }

    [ForeignKey("RefSize")]
    public string SizeCode { get; set; }
    public RefSize RefSize { get; set; }

    public string AssetName { get; set; }
    public string OtherDetails { get; set; }
}

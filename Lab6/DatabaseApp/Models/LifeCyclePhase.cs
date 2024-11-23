namespace DatabaseApp.Models;

using System.ComponentModel.DataAnnotations;

public class LifeCyclePhase
{
    [Key]
    public string LifeCycleCode { get; set; }
    public string LifeCycleName { get; set; }
    public string LifeCycleDescription { get; set; }
}

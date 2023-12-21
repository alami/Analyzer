using System.ComponentModel.DataAnnotations;

namespace Analyzer.Models
{
    public enum Stages
    {
        Init = 1,
        Tester = 2,
        Analyser = 3,
        Calculate = 4,
        Result = 5,
    }
    public enum Сonclusions
    {
        ForOnHold = 1,
        For5050 = 2,
        ForParts = 3,
        BuyOnEconomics = 4,
    }
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Device Name")]
        public string Name { get; set; }
        [Display(Name = "S/N")]
        public string? SN { get; set; }        
        [Display(Name = "Model")]
        public string? Model { get; set; }

        [Display(Name = "Model Name")]
        public string? ModelName { get; set; }
        [Display(Name = "Comments with specs(from Tester)")]
        public string? Comments { get; set; }
        [Display(Name = "Other Comments for Tester")]
        public string? OtherComments { get; set; }

        [Display(Name = "Total Count of Laptops")]
        [Range(1, int.MaxValue)]
        public int? TotalCount { get; set; }
        
        [Display(Name = "Tester Time (min)")]
        [Range(1, int.MaxValue)]
        public int? TesterTime { get; set; }

        [Display(Name = "% Lost")]        
        public float? PersntLost { get; set; }

        [Display(Name = "% Result")]
        public float? PersntResult { get; set; }

        [Display(Name = "Result for 1 hold unit")]
        public float? Result { get; set; }
        public int Type { get; set; } = 1;

        [Display(Name = "Other Comments for Analyzer)")]
        public string? OtherCommentsAz { get; set; }

        [Display(Name = "Total All")]
        public float? TotalAll { get; set; }

        [Display(Name = "Different Result")]
        public float? DiffResult { get; set; }

        [Display(Name = "Final Conclusion")]
        public Сonclusions? Сonclusion { get; set; }
        public Stages? Stage { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Analyzer.Models
{
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
        [Display(Name = "Comments with specs(for Tester)")]
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

        [Display(Name = "Result")]
        public float? Result { get; set; }
        public int Type { get; set; } = 1;


    }
}

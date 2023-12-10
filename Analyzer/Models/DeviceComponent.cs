using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Analyzer.Models
{
    public enum Stage
    {
        Init = 1,
        Testing = 2,
        Analyze = 3,
        Result = 4,
        Noname = 5,
    }

    public class DeviceComponent
    {

        [Key]
        public int Id { get; set; }
        
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }

        public int ComponentId { get; set; }
        [ForeignKey("ComponentId")]
        public virtual Component Component { get; set; }

        public Stage Stage { get; set; }
        public int? Value { get; set; }
        public string? Comment{ get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Analyzer.Models
{
    public enum ComponentType
    {
        Evaluate = 1,
        Parts = 2,
        Accessories =3,
    }
    public class Component
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Comment { get; set; }
        public int? Price { get; set; }
        public int? Time { get; set; }
        public bool? Visible { get; set; }

        public int Pos { get; set; } = 1;
        public ComponentType Type { get; set; }

    }
}

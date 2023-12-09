using System.ComponentModel.DataAnnotations;

namespace Analyzer.Models
{
    public class Component
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Time { get; set; }

        public int Pos { get; set; } = 1;
        public int Type { get; set; } = 1;


    }
}

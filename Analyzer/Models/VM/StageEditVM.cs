using Microsoft.AspNetCore.Mvc.Rendering;

namespace Analyzer.Models.VM
{
    public class StageEditVM
    {
        public Device Device { get; set; }
        public List<DeviceComponent>? DevCompEvalList { get; set; }
        public List<DeviceComponent>? DevCompAssList { get; set; }
        public List<DeviceComponent>? DevCompPartsList { get; set; }
        public List<Component>? CompList { get; set; }
/*        public List<Component>? PartsList { get; set; }
        public List<Component>? EvaluateList { get; set; }
        public List<Component>? AccessoriesList { get; set; }*/
    }
}

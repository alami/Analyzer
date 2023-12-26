using Microsoft.AspNetCore.Mvc.Rendering;

namespace Analyzer.Models.VM
{
    public class StageAllVM
    {
        public Device Device { get; set; }
        public List<DeviceComponent>? DevCompEvalList { get; set; }
        public List<DeviceComponent>? DevCompAssList { get; set; }
        public List<DeviceComponent>? DevCompPartsList { get; set; }
        public List<DeviceComponent>? DevCompEval2List { get; set; }
        public List<DeviceComponent>? DevCompAss2List { get; set; }
        public List<DeviceComponent>? DevCompParts2List { get; set; }
        public List<Component>? CompList { get; set; }
    }
}

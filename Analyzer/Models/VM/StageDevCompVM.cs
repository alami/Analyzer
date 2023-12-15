﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Analyzer.Models.VM
{
    public class StageDevCompVM
    {
        public Stage Stage { get; set; }
        public Device? Device { get; set; }
        public List<DeviceComponent>? DevCompList { get; set; }
        public List<Component>? PartsList { get; set; }
        public List<Component>? EvaluateList { get; set; }
        public List<Component>? AccessoriesList { get; set; }
    }
}

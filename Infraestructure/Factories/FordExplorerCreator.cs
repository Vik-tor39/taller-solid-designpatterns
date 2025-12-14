using Best_Practices.ModelBuilders;
using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Infraestructure.Factories
{
    public class FordExplorerCreator : Creator
    {
        public override Vehicle Create()
        {
            return new CarBuilder()
                .SetBrand("Ford")
                .SetModel("Explorer")
                .SetColor("Black")
                .WithDefaults(new VehicleDefaults())
                .Build();
        }
    }
}

using Best_Practices.ModelBuilders;
using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Infraestructure.Factories
{
    public class FordMustangCreator : Creator
    {
        public override Vehicle Create()
        {
            return new CarBuilder()
                .SetBrand("Ford")
                .SetModel("Mustang")
                .SetColor("Red")
                .WithDefaults(new VehicleDefaults())
                .Build();
        }
    }
}

using System;
using Best_Practices.Models;

namespace Best_Practices.Infraestructure.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle Create(string type)
        {
            return type switch
            {
                "Mustang" => new FordMustangCreator().Create(),
                "Explorer" => new FordExplorerCreator().Create(),
                "Escape" => new FordEscapeCreator().Create(),
                _ => throw new ArgumentException("Invalid vehicle type")
            };
        }
    }
}
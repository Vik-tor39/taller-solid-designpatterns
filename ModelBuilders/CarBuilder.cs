using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.ModelBuilders
{
    public class CarBuilder
    {
        public string Brand = "Ford";
        public string Model = "Mustang";
        public string Color = "Red";
        private VehicleDefaults _defaults = new VehicleDefaults();

        public CarBuilder SetBrand(string brand)
        {
            Brand = brand;
            return this;
        }

        public CarBuilder SetModel(string model)
        {
            Model = model;
            return this;
        }

        public CarBuilder SetColor(string color)
        {
            Color = color;
            return this;
        }
        
        // Permite inyectar defaults (año actual, +20 properties futuras)
        public CarBuilder WithDefaults(VehicleDefaults defaults)
        {
            _defaults = defaults ?? new VehicleDefaults();
            return this;
        }

        public Car Build()
        {
            var car = new Car(Color, Brand, Model)
            {
                Year = _defaults.Year,
                Country = _defaults.Country,
                IsElectric = _defaults.IsElectric
            };

            return car;
        }
    }
}

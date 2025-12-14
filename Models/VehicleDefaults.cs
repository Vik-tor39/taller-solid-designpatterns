using System;

namespace Best_Practices.Models
{
    public class VehicleDefaults
    {
        // Definición de propiedades por default (a futuro implementación de + 20 proprties)
        public int Year { get; set; } = DateTime.Now.Year;  
        public string Country { get; set; } = "USA";
        public bool IsElectric { get; set; } = false;

    }
}

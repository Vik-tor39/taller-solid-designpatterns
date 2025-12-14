using Best_Practices.Models;

namespace Best_Practices.Infraestructure.Factories
{
    public interface IVehicleFactory
    {
        Vehicle Create(string type);
    }
}   
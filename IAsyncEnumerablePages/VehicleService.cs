using Bogus;

namespace IAsyncEnumerablePages
{
    /// Transform original data and add linked value
    public class VehicleService
    {
        private readonly Faker<Models.Vehicle> f = new Faker<Models.Vehicle>()
            .RuleFor(u => u.Vin, f => f.Vehicle.Vin())
            .RuleFor(u => u.Manufacturer, f => f.Vehicle.Manufacturer())
            .RuleFor(u => u.Model, f => f.Vehicle.Model())
            .RuleFor(u => u.Type, f => f.Vehicle.Type())
            .RuleFor(u => u.Fuel, f => f.Vehicle.Fuel());

        public async Task<Dictionary<string, (Models.Person Person, Models.Vehicle Vehicle)>> GetVehicle(
            Dictionary<string, Models.Person> people,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine("VehicleService");
            await Task.Delay(1000, cancellationToken);

            return people.ToDictionary(x => x.Key, x => (x.Value, f.Generate()));
        }
    }
}

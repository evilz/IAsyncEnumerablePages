using IAsyncEnumerablePages;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;
using BenchmarkDotNet.Configs;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<IAsyncBench>();
    }
}



public class IAsyncBench
{
    private PersonService personService = new PersonService();
    private VehicleService vehicleService = new VehicleService();
    private Dumper dumper = new Dumper();


    [Benchmark]
    public async Task SimpleIAsync()
    {
        /// Await Each page 
        await foreach (var page in personService.GetData())
        {
            var map = page.ToDictionary(x=>x.UserName, x => x);
            var processedPAge = await vehicleService.GetVehicle(map);
            await dumper.Display(processedPAge);
        }

    }

    [Benchmark]
    public async Task ParallelIAsync()
    {
        await Parallel.ForEachAsync(personService.GetData(), async (page, ct) =>
        {
            var map = page.ToDictionary(x => x.UserName, x => x);
            var processedPAge = await vehicleService.GetVehicle(map);
            await dumper.Display(processedPAge);
        });
    }

}

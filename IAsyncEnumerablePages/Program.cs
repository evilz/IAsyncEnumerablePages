using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using IAsyncEnumerablePages;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<IAsyncBench>();
    }
}

public class IAsyncBench
{
    private readonly PersonService personService = new();
    private readonly VehicleService vehicleService = new();
    private readonly Dumper dumper = new();

    [Benchmark]
    public async Task SimpleIAsync()
    {
        // Await each page
        await foreach (var page in personService.GetData())
        {
            var map = page.ToDictionary(x => x.UserName, x => x);
            var processedPage = await vehicleService.GetVehicle(map);
            await dumper.Display(processedPage);
        }
    }

    [Benchmark]
    public async Task ParallelIAsync()
    {
        await Parallel.ForEachAsync(personService.GetData(), async (page, ct) =>
        {
            var map = page.ToDictionary(x => x.UserName, x => x);
            var processedPage = await vehicleService.GetVehicle(map, ct);
            await dumper.Display(processedPage, ct);
        });
    }
}

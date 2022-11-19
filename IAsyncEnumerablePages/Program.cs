using IAsyncEnumerablePages;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<IAsyncBench>();
    }
}



public class IAsyncBench
{
    private ProducerA producerA = new ProducerA();
    private IsEven isEven = new IsEven();
    private Dumper dumper = new Dumper();


    [Benchmark]
    public async Task SimpleIAsync()
    {
        /// Await Each page 
        await foreach (var page in producerA.GetData())
        {
            var processedPAge = await isEven.GetIsEvenPage(page);
            await dumper.Display(processedPAge);
        }

    }

    [Benchmark]
    public async Task PArallelIAsync()
    {
        await Parallel.ForEachAsync(producerA.GetData(), async (page, ct) =>
        {
            var processedPAge = await isEven.GetIsEvenPage(page);
            await dumper.Display(processedPAge);
        });
    }

}

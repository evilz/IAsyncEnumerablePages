using IAsyncEnumerablePages;

Console.WriteLine("Hello, World!");

var producerA = new ProducerA();
var isEven = new IsEven();
var dumper = new Dumper();


/// Await Each page 
//await  foreach (var page in producerA.GetData())
//{
//    var processedPAge = await isEven.GetIsEvenPage(page);
//    await dumper.Display(processedPAge);
//}


/// Await all but run in Each page parallel
await Parallel.ForEachAsync(producerA.GetData(), async (page, ct) =>
    {
        var processedPAge = await isEven.GetIsEvenPage(page);
        await dumper.Display(processedPAge);
    });
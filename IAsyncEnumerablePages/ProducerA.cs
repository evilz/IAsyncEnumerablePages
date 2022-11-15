using IAsyncEnumerablePages.Model;

namespace IAsyncEnumerablePages
{
    // Generate Page of data
    public class ProducerA
    {
        public async IAsyncEnumerable<Page> GetData()
        {
            foreach (int value in Enumerable.Range(1, 10))
            {
                Console.WriteLine("PRODUCER");
                await Task.Delay(100);
                yield return new Page(Enumerable.Range(value * 100, 10).ToArray());
            }
        }
    }
}

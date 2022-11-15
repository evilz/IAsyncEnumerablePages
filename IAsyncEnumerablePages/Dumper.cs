namespace IAsyncEnumerablePages
{

    /// Kind of IO like save data in database
    public class Dumper
    {
        public async Task Display(Dictionary<int,bool> page)
        {
            Console.WriteLine("IO");
            await Task.Delay(1000);
            foreach (var item in page)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}

using Bogus;
using Bogus.DataSets;

namespace IAsyncEnumerablePages
{

    /// Kind of IO like save data in database
    public class Dumper
    {
        public async Task Display(Dictionary<string,(Models.Person,Models.Vehicle )> page)
        {
            Console.WriteLine("IO");
            await Task.Delay(1000);
            foreach (var item in page)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Item1.FirstName} : {item.Value.Item2.Manufacturer}");
            }
        }
    }
}

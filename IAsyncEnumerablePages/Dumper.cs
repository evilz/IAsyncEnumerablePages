namespace IAsyncEnumerablePages
{
    /// Kind of IO like saving data in a database
    public class Dumper
    {
        public async Task Display(
            Dictionary<string, (Models.Person Person, Models.Vehicle Vehicle)> page,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine("IO");
            await Task.Delay(1000, cancellationToken);

            foreach (var item in page)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Person.FirstName} : {item.Value.Vehicle.Manufacturer}");
            }
        }
    }
}

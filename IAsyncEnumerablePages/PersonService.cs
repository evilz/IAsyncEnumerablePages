
using Bogus;

namespace IAsyncEnumerablePages
{
    // Generate Page of data
    public class PersonService
    {

        private Faker<Models.Person> f = new Faker<Models.Person>()

            .RuleFor(u => u.Gender, f => f.PickRandom<Models.Gender>())
            .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
            .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
            .RuleFor(u => u.FullName, (f, u) => f.Name.FullName())
            .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.DateOfBirth, (f, u) => f.Date.Past());

        public PersonService(int numberOfPages = 10, int pageSize = 10 )
        {
            NumberOfPages = numberOfPages;
            PageSize = pageSize;
        }

        public int NumberOfPages { get; }
        public int PageSize { get; }

        public async IAsyncEnumerable<List<Models.Person>> GetData(CancellationToken cancellationToken = default)
        {
            foreach (int value in Enumerable.Range(0, NumberOfPages))
            {
                cancellationToken.ThrowIfCancellationRequested();
                Console.WriteLine("PRODUCER");
                await Task.Delay(100, cancellationToken);
                yield return f.Generate(PageSize);
            }
        }
    }
}

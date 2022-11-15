using IAsyncEnumerablePages.Model;

namespace IAsyncEnumerablePages
{
    /// Transform original data and add linked value
    public class IsEven
    {
        public async Task<Dictionary<int,bool>> GetIsEvenPage(Page page) 
        {
            Console.WriteLine("MODIFIER");
            await Task.Delay(1000);
            return page.Content.ToDictionary(x=>x, x =>x % 2 == 0);
        
        }
    }
}

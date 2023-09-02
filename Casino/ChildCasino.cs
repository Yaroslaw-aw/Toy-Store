using Toy_Store.Toys;

namespace Toy_Store.Casino
{
    internal class ChildCasino
    {
        Dictionary<int, Toy> prizes;
        public ChildCasino()
        {
            this.prizes = new Dictionary<int, Toy>();
        }

        public void ShowPrizes()
        {
            Console.WriteLine("\nВаши призы");
            foreach (var toy in prizes)
            {
                if (toy.Value is Toy)
                {
                    Console.WriteLine($"{toy.Value.GetType().Name} {toy.Value.Name}\n");
                }
            }
            
            
        }

        public void Add(Toy toy)
        {
            if (toy != null)
            {
                prizes.Add(toy.ToyId, toy);
            }
        }        
    }
}

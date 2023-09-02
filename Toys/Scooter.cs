namespace Toy_Store.Toys
{
    internal class Scooter : Toy
    {        
        public Scooter() : base() { this.Frequency = 60; }
        public Scooter(string name, int quantity) : base(name, quantity) { this.Frequency = 60; }
    }
}

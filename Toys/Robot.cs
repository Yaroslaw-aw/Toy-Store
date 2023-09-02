namespace Toy_Store.Toys
{
    internal class Robot : Toy
    {        
        public Robot() : base() { this.Frequency = 20; }
        public Robot(string name, int quantity) : base(name, quantity) { this.Frequency = 20; }        
    }
}

namespace Toy_Store.Toys
{
    internal class Gummi_Bear : Toy
    {        
        public Gummi_Bear() :base() { this.Frequency = 20; }
        public Gummi_Bear(string name, int quantity) : base(name, quantity) { this.Frequency = 150; }
    }
}

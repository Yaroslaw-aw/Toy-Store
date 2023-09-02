namespace Toy_Store.Toys
{
    internal abstract class Toy
    {
        protected static int id;
        protected static Random random;

        int frequency;
        public int Frequency { get { return frequency; } set { if (value > 0) frequency = value; } }

        protected int percentage;
        public int Percentage { get { return percentage; } set { if (value > 0) percentage = value; } }

        protected string name;
        protected int quantity;        
        protected readonly int toyId;
        public int ToyId { get { return toyId; } }
        int Id { get { return id; } }
        public string Name { get { return name; } set { name = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        

        static Toy()
        {
            id = 0;
            random = new Random();
        }

        public Toy()
        {
            Name = string.Format($"{GetType().Name} #{++id}");
            Quantity = random.Next(1, 5);
            toyId = Id;
        }
        public Toy(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            toyId = ++id;
        }

        public virtual string ToyInfo()
        {
            return string.Format($"{GetType().Name} id: {ToyId}, Name: {Name}, Количество: {Quantity},");
        }
    }
}

namespace Toy_Store.Toys
{
    internal abstract class Toy
    {
        protected static int id;
        protected static Random random;

        protected int frequency;
        public int Frequency { get { return frequency; } set { frequency = Math.Abs(value) > 0 ? Math.Abs(value) : 20; } }

        protected int percentage;
        public int Percentage { get { return percentage; } set { percentage = Math.Abs(value) > 0 ? Math.Abs(value) : 20; } }

        protected string name;
        protected int quantity;        
        protected readonly int toyId;
        public int ToyId { get { return toyId; } }
        int Id { get { return id; } }
        public string Name { get { return name; } set { name = value.Length < 2 ? string.Format($"{GetType().Name} #{++id}") : value; } }
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
            Frequency = 20;
            Percentage = 20;
        }
        public Toy(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            toyId = ++id;
        }

        public Toy(string name, int quantity, int frequency) : this(name, quantity)
        {
            this.Frequency = frequency;
        }

        public string ToyInfo()
        {
            return string.Format($"{GetType().Name} id: {ToyId}, Название: {Name}, Количество: {Quantity}, Процент выигрыша {this.Percentage}%, Частота(вес) {this.Frequency}");
        }
    }
}

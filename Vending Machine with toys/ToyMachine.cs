using Toy_Store.Toys;

namespace Toy_Store.Vending_Machine_with_toys
{
    internal class ToyMachine
    {
        protected Dictionary<int, Toy> toys;
        //protected List<Toy> prizes;
        protected int size;
        public int Size { get { return toys.Count; } }

        protected int[] prizeField;
        protected int totalPerctngages;

        public ToyMachine()
        {
            toys = new Dictionary<int, Toy>();
            //prizes = new List<Toy>();
            this.size = 0;
        }

        public ToyMachine(Dictionary<int, Toy> toys)
        {
            this.toys = toys;
            this.size = toys.Count;
            //prizes = new List<Toy>();
            totalPerctngages = SetPerctntages();
            prizeField = PrizeField(totalPerctngages);
        }

        /// <summary>
        /// Добавляет игрушку в машину
        /// </summary>
        /// <param name="toy"></param>
        public void AddToy(Toy toy)
        {
            toys.Add(toy.ToyId, toy);
            totalPerctngages = SetPerctntages();
            prizeField = PrizeField(totalPerctngages);
        }

        /// <summary>
        /// Определяет % выпадения каждой игрушки, исходя из её "веса" (читай, как значимость, любое положительное int число)
        /// </summary>
        /// <returns></returns>
        protected int SetPerctntages()
        {
            double totalWeight = 0;

            int totalPercentages = 0;

            foreach (KeyValuePair<int, Toy> toy in toys)
                totalWeight += toy.Value.Frequency;

            foreach (KeyValuePair<int, Toy> toy in toys)
            {
                double temp = (double)toy.Value.Frequency / (double)totalWeight * 100;
                toy.Value.Percentage = (int)Math.Round(temp);
                totalPercentages += toy.Value.Percentage;
            }
            return totalPercentages;
        }

        /// <summary>
        /// Генерирует призовое поле
        /// </summary>
        /// <param name="totalPercentage"></param>
        /// <returns></returns>
        protected int[] PrizeField(int totalPercentage)
        {
            int[] prizeField = new int[totalPercentage];
            int count = 0;

            foreach (KeyValuePair<int, Toy> toy in toys)
                for (int i = 0; i < toy.Value.Percentage; i++)
                {
                    prizeField[count] = toy.Key;
                    count++;
                }
            return prizeField;
        }

        /// <summary>
        /// Получает id выигранной игрушки
        /// </summary>
        /// <returns></returns>
        protected int prizeId()
        {
            if (prizeField.Length > 0)
            {
                int random = new Random().Next(prizeField.Length);
                return this.prizeField[random];
            }
            return 0;            
        }

        /// <summary>
        /// Выбирает случайную игрушку - главный метод :)
        /// </summary>
        /// <returns></returns>
        public Toy GetToy()
        {
            int prizeID = prizeId();

            foreach (KeyValuePair<int, Toy> toy in toys)
            {
                if (toy.Key == prizeID)
                {
                    if (toy.Value.Quantity > 0)
                    {
                        Console.WriteLine($"Поздравляем! Вы выиграли: {toy.Value.GetType().Name} {toy.Value.Name}");
                        toy.Value.Quantity--;
                        totalPerctngages = SetPerctntages();
                        prizeField = PrizeField(totalPerctngages);
                    }

                    if (toy.Value.Quantity == 0)
                    {
                        toys.Remove(toy.Key);
                        totalPerctngages = SetPerctntages();
                        prizeField = PrizeField(totalPerctngages);
                        this.size--;
                        return toy.Value;
                    }
                    return toy.Value;
                }                
            }
            return null;
        }

        public void ShowToys()
        {
            if (toys != null)
            {
                foreach (var toy in toys)
                {
                    Console.WriteLine(toy.Value.ToyInfo());
                }
            }
        }
    }
}


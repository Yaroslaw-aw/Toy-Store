using Toy_Store.Toys;

namespace Toy_Store.Vending_Machine_with_toys
{
    internal class ToyMachine2
    {
        Dictionary<int, Toy> toys;
        int size;
        public int Size { get { return toys.Count; } }

        int[] prizeField;
        int totalPerctngages;

        public ToyMachine2()
        {
            toys = new Dictionary<int, Toy>();
            this.size = 0;
        }

        public ToyMachine2(Dictionary<int, Toy> toys)
        {
            this.toys = toys;
            this.size = toys.Count;
            totalPerctngages = SetPerctntages();
            prizeField = PrizeField(totalPerctngages);
        }

        /// <summary>
        /// Добавляет игрушку в машину
        /// </summary>
        /// <param name="toy"></param>
        public void Add(Toy toy)
        {
            toys.Add(toy.ToyId, toy);
            totalPerctngages = SetPerctntages();
            prizeField = PrizeField(totalPerctngages);
        }

        /// <summary>
        /// Определяет % выпадения каждой игрушки, исходя из её "веса" (читай, как значимость, любое положительное int число)
        /// </summary>
        /// <returns></returns>
        int SetPerctntages()
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


        int[] PrizeField(int totalPercentage)
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


        int prizeId()
        {
            if (prizeField.Length > 0)
            {
                int random = new Random().Next(1, prizeField.Length);
                return this.prizeField[random];
            }
            return 0;            
        }


        public Toy GetToy()
        {
            int prizeID = prizeId();

            foreach (KeyValuePair<int, Toy> toy in toys)
            {
                if (toy.Key == prizeID)
                {
                    if (toy.Value.Quantity > 0)
                    {
                        Console.WriteLine($"Поздравляю, вы выиграли: {toy.Value.GetType().Name} {toy.Value.Name}");
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

        public void Show()
        {
            for (int i = 0; i < toys.Count; i++)
            {
                Console.WriteLine($"Процентаж игрушки {toys[i + 1].ToyId} {toys[i + 1].Percentage}%, Вес игрушки {toys[i + 1].Frequency}");
            }
            Console.WriteLine("Игровое поле:");
            Console.Write("[");
            Console.Write(String.Join($" ", prizeField));
            Console.WriteLine("]");
        }
    }
}


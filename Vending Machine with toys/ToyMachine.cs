using Toy_Store.Toys;

namespace Toy_Store.Vending_Machine_with_toys
{
    internal class ToyMachine
    {
        Dictionary<int, Toy> toys;

        int size; // Количество элементов в словаре с игрушками
        public int Size { get { return size; } }

        int[] prizeField;

        int totalPercentages;

        public ToyMachine()
        {
            toys = new Dictionary<int, Toy>();
            this.size = 0;
        }

        public ToyMachine(Dictionary<int, Toy> toys)
        {
            this.toys = toys;
            this.size = toys.Count;
            CalculatePrizeFieldAndPercentsOfWinning();
        }

        /// <summary>
        /// Добавляет игрушку в машину
        /// </summary>
        /// <param name="toy"></param>
        public void AddToy(Toy toy)
        {
            if (toy.Quantity > 0 && toy.Frequency > 0)
            {
                toys.Add(toy.ToyId, toy);
                size++;
                CalculatePrizeFieldAndPercentsOfWinning();
            }
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

        void CalculatePrizeFieldAndPercentsOfWinning()
        {
            totalPercentages = SetPerctntages();
            prizeField = PrizeField(totalPercentages);
        }

        /// <summary>
        /// Меняет вес игрушки
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weight"></param>
        public void SetWeight(int id, int weight)
        {
            if (toys.Count > 0)
            {
                toys[id].Frequency = weight;
                
                CalculatePrizeFieldAndPercentsOfWinning();
            }
            else
            {
                Console.WriteLine("В автомате нет игрушек ;(");
            }
        }


        /// <summary>
        /// Генерирует призовое поле
        /// </summary>
        /// <param name="totalPercentage"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получает id выигранной игрушки
        /// </summary>
        /// <returns></returns>
        int prizeId()
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

            if (toys.Count > 0)
            {
                Toy toy1 = toys[prizeID];
                if (toys[prizeID].Quantity > 0)
                {
                    Console.WriteLine($"Поздравляем! Вы выиграли: {toys[prizeID].GetType().Name} {toys[prizeID].Name}");
                    toys[prizeID].Quantity--;
                }
                if (toys[prizeID].Quantity == 0)
                {
                    toys.Remove(prizeID);
                    CalculatePrizeFieldAndPercentsOfWinning();
                    this.size--;
                    return toy1;
                }
                return toy1;                
            }
            return null;
        }

        public void ShowToys()
        {
            if (toys.Count > 0)
            {
                foreach (var toy in toys)
                {
                    Console.WriteLine(toy.Value.ToyInfo());
                }
            }
            else Console.WriteLine("Автомат с игрушками пуст ;(\nПриходите позже");
        }
    }
}


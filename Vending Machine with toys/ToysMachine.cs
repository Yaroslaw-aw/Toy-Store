using Toy_Store.Toys;

namespace Toy_Store.Vending_Machine_with_toys
{
    internal class ToysMachine
    {
        List<Toy> machine;


        int[] prizeField;

        int size; // Размер списка с игрушками
        public int Size { get { return size; } }

        public ToysMachine()
        {
            machine = new List<Toy>();
            this.size = 0;
        }

        public ToysMachine(List<Toy> machine)
        {
            this.machine = machine;
            size = machine.Count;
            this.prizeField = PrizeField();
        }

        public void AddToy(Toy baseToy)
        {
            machine.Add(baseToy);
            this.size++;
            this.prizeField = PrizeField();
        }

        int[] PrizeField()
        {
            double wGummi = 0;   // Вес мишек Гамми 
            double wScooter = 0; // Вес скутеров 
            double wRobot = 0;   // Вес роботов 

            foreach (Toy toy in machine)
            {
                if (toy.GetType().Name == "Gummi_Bear")
                    wGummi += toy.Frequency * toy.Quantity;

                if (toy.GetType().Name == "Scooter")
                    wScooter += toy.Frequency * toy.Quantity;

                if (toy.GetType().Name.ToString() == "Robot")
                    wRobot += toy.Frequency * toy.Quantity;
            }
            double weight = wGummi + wScooter + wRobot; // Общий вес

            double perGummi = wGummi / weight * 100;    // Процент на выигрыш исходя из доли веса в общем весе
            double perScooter = wScooter / weight * 100;
            double perRobot = wRobot / weight * 100;

            int pGummi = (int)perGummi;
            int pScooter = (int)perScooter;
            int pRobot = (int)perRobot;
            int aPers = pGummi + pScooter + pRobot;

            int[] prizeField = new int[aPers];  // Заполнение массива идентификаторами выигрывающей игрушки, где 0 - это мишки, 1 - скутеры, 2 - роботы
                                                // это цифры для индекса в списке, который в себе хранит игрушки


            // Заполнение призового поля
            if (pGummi > 0)
            {
                for (int i = 0; i < pGummi; i++)
                {
                    prizeField[i] = 0;
                }
            }

            if (pScooter > 0)
            {
                for (int i = pGummi; i < pGummi + pScooter; i++)
                {
                    prizeField[i] = 1;
                }
            }

            if (perRobot > 0)
            {
                for (int i = pGummi + pScooter; i < aPers; i++)
                {
                    prizeField[i] = 2;
                }
            }
            return prizeField;
        }

        // Получение индекса ячейки, которая содержит id выигранной игрушки из оставшихся в списке игрушек
        int prizeId()
        {
            int random = new Random().Next(1, prizeField.Length);

            return this.prizeField[random];
        }

        public Toy GetToy()
        {
            int id = prizeId();  

            Toy toy = machine[id];

            if (toy.Quantity > 0)
            {                
                Console.WriteLine($"Поздравляю, вы выиграли: {toy.GetType().Name} {toy.Name}");
                toy.Quantity--;
                this.prizeField = PrizeField(); // Пересчет игрового поля

                if (toy.Quantity == 0)
                {
                    machine.Remove(machine[id]);
                    this.prizeField = PrizeField(); 
                    this.size--;
                    return toy;
                }
                return toy;
            }            
            return null;            
        }

        /// <summary>
        /// Достать игрушку по id игрушки, например у каждого мишки свой id, хотя в списке выигрышей унего отдельный id - id списка со всеми игрушками
        /// </summary>
        /// <param name="id">id отдельно взятой игрушки</param>
        /// <returns></returns>
        public Toy GetToyByToyId(int id)
        {
            foreach (Toy toy in machine)
            {
                if (toy is Toy)
                {
                    Toy toy1 = toy;
                    if (toy.ToyId.Equals(id))
                    {
                        if (toy.Quantity > 0)
                        {
                            toy.Quantity--;

                            if (toy.Quantity == 0)
                            {
                                machine.Remove(toy);
                                this.prizeField = PrizeField();
                                this.size--;
                                return toy1;
                            }
                            return toy1;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Показывает оставшиеся игрушки
        /// </summary>
        public void MachineInfo()
        {
            foreach (Toy toy in machine)
            {
                Console.WriteLine(toy.ToyInfo());
            }
        }
    }
}

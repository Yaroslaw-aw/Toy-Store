using Toy_Store.Casino;
using Toy_Store.Toys;
using Toy_Store.Vending_Machine_with_toys;

namespace Toy_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Toy toy1 = new Gummi_Bear("Плюшевый", 4);
            Toy toy2 = new Scooter("Скутер", 5);
            Toy toy3 = new Robot("R2D2", 2);
            Toy toy4 = new Robot("C3PO", 3);

            #region
            //List<Toy> list = new List<Toy>();
            //list.Add(toy1);
            //list.Add(toy2);
            //list.Add(toy3);


            //Console.WriteLine(new string('-', 70));

            //ToysMachine machine1 = new ToysMachine(list) ;

            ////Console.WriteLine(toy2.ToyInfo());

            ////Console.WriteLine(new string('-', 70));

            //machine1.MachineInfo();
            //Console.WriteLine(new string('-', 70));

            //ChildCasino childCasino = new ChildCasino();

            //Toy prize = machine1.GetToy();

            //childCasino.Add(prize);

            //childCasino.ShowPrizes();
            //// machine1.prizeId();
            ////machine1.Random();
            //machine1.MachineInfo();
            #endregion

            ToyMachine2 machine2 = new ToyMachine2();
            machine2.Add(toy1);
            machine2.Add(toy2);
            machine2.Add(toy3);
            machine2.Add(toy4);

            Console.WriteLine(toy1.ToyInfo());
            Console.WriteLine(toy2.ToyInfo());
            Console.WriteLine(toy3.ToyInfo());
            Console.WriteLine(toy4.ToyInfo());

            Console.WriteLine(new string('-', 70));

            machine2.Show();

            for (int i = 0; i < 18; i++)
            {
                machine2.GetToy();
            }

        }
    }
}
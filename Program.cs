using Toy_Store.Casino;
using Toy_Store.Toys;
using Toy_Store.Vending_Machine_with_toys;

namespace Toy_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Toy toy1 = new Gummi_Bear("Плюшевый", 3);
            Toy toy2 = new Scooter("Скутер", 2);
            Toy toy3 = new Robot("R2D2", 2);
            Toy toy4 = new Robot("C3PO", 1);
            Toy toy5 = new Gummi_Bear("Сладкоежка", 1);

            ToyMachine machine2 = new ToyMachine();
            machine2.AddToy(toy1);
            machine2.AddToy(toy2);
            machine2.AddToy(toy3);
            machine2.AddToy(toy4);
            machine2.AddToy(toy5);

            ChildCasino childCasino = new ChildCasino(machine2);
            

            childCasino.The_Show_Must_Go_On();

        }
    }
}
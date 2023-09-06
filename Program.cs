using Toy_Store.Casino;
using Toy_Store.Toys;
using Toy_Store.Vending_Machine_with_toys;

namespace Toy_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Toy toy1 = new Toy("Плюшевый мишка", 3, 20);
            Toy toy2 = new Toy("Скутер", 2, 40);
            Toy toy3 = new Toy("Робот R2D2", 2, 72);
            Toy toy4 = new Toy("Робот C3PO", 1, 81);
            Toy toy5 = new Toy("Конструктор", 1, 32);

            ToyMachine machine2 = new ToyMachine();
            machine2.AddToy(toy1);
            machine2.AddToy(toy2);
            machine2.AddToy(toy3);
            machine2.AddToy(toy4);
            machine2.AddToy(toy5);

            ChildCasino childCasino = new ChildCasino(machine2);


            childCasino.The_Show_Must_Go_On();

            //ChildCasino childCasino1 = new ChildCasino();

            //childCasino1.The_Show_Must_Go_On();

            
        }
    }
}
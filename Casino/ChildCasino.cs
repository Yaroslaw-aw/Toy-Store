using Toy_Store.Toys;
using Toy_Store.Vending_Machine_with_toys;

namespace Toy_Store.Casino
{
    internal class ChildCasino
    {
        List<Toy> prizes;

        ToyMachine toysMachine;

        public ChildCasino()
        {
            toysMachine = new ToyMachine();
            this.prizes = new List<Toy>();
        }

        public ChildCasino(ToyMachine toys)
        {
            this.toysMachine = toys;
            this.prizes = new List<Toy>();
        }

        public void The_Show_Must_Go_On()
        {
            Console.Clear();
            Console.WriteLine($"Нажмите пункт меню:");
            Console.WriteLine($" 1. Показать список игрушек в автомате\n" +
                              $" 2. Попробовать выиграть игрушку ;)\n" +
                              $" 3. Добавить игрушку в автомат\n" +
                              $" 4. Забрать одну выигранную игрушку :)\n" +
                              $" 5. Забрать все выигранные игрушки! ))\n" +
                              $" 0. Попрощаться с игровым автоматом\n");
            ShowPrizes();

            int number = InputIntValue("");
            switch (number)
            {
                case 0:
                    {
                        Console.WriteLine("Рады были с вами поиграть! ;) приходите ещё )");
                        return;
                    }
                case 1:
                    {
                        ShowToys();
                        Console.WriteLine("\nНажмите клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        if (toysMachine.Size > 0)
                        {
                            prizes.Add(toysMachine.GetToy());
                            Console.WriteLine("\nНажмите клавишу для продолжения");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Автомат с игрушками пуст ;(");
                            Console.ReadKey();
                            break;
                        }
                    }
                case 3:
                    {
                        Console.WriteLine("Выберете, какую игрушку вы хотите добавить:");
                        Console.WriteLine($" 1. Мишка Gummi_Bear\n" +
                                          $" 2. Робот Robot\n" +
                                          $" 3. Самокат Scooter\n");
                        int choice = InputIntValue("");
                        switch (choice)
                        {
                            case 1:
                                {
                                    toysMachine.AddToy(MakeNewGummi_Bear());
                                    Console.WriteLine("Новый мишка добавлен. Нажмите любую клавишу для продолжения");
                                    Console.ReadKey();
                                    break;
                                }
                            case 2:
                                {
                                    toysMachine.AddToy(MakeNewRobot());
                                    Console.WriteLine("Новый робот добавлен. Нажмите любую клавишу для продолжения");
                                    Console.ReadKey();
                                    break;
                                }
                            case 3:
                                {
                                    toysMachine.AddToy(MakeNewScooter());
                                    Console.WriteLine("Новый самокат добавлен. Нажмите любую клавишу для продолжения");
                                    Console.ReadKey();
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Неверный ввод");
                                    break;
                                }
                        }
                        break;
                    }
                case 4:
                    {
                        GetPrize();
                        Console.WriteLine("\nНажмите клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    }
                case 5:
                    {
                        GetAllPrizes();
                        Console.WriteLine("\nНажмите клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nНеверная цифра, попробуйте ещё раз");
                        Console.WriteLine("Нажмите клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    }
            }
            The_Show_Must_Go_On();
        }

        /// <summary>
        /// Ребёнок забирает игрушку)
        /// </summary>
        public void GetPrize()
        {
            if (prizes.Count > 0)
            {
                Console.WriteLine($"Вы забрали игрушку {prizes[0].Name}! Она теперь ваша навсегда ;)");
                prizes.Remove(prizes[0]);
            }
        }
        /// <summary>
        /// Ребёнок забирает все игрушки, которые выиграл
        /// </summary>
        public void GetAllPrizes()
        {
            if (prizes.Count > 0)
            {
                Console.WriteLine("Поздравляем с выигрышем!");
                foreach (var prize in prizes)
                {
                    Console.WriteLine($"Вы забрали игрушку {prize.Name}! Она теперь ваша навсегда ;)");
                }
                prizes.Clear();
            }
        }

        /// <summary>
        /// Показывает уже выигранные игрушки, но их ещё не забрали
        /// </summary>
        public void ShowPrizes()
        {
            if (prizes.Count > 0)
            {
                Console.WriteLine("Ваши призы:");
                foreach (var toy in prizes)
                {
                    Console.WriteLine($"{toy.GetType().Name} {toy.Name}");
                }
            }
        }

        
        /// <summary>
        /// Показывает игрушки, которые есть в автомате
        /// </summary>
        public void ShowToys()
        {
            toysMachine.ShowToys();
        }

        /// <summary>
        /// Создаёт нового мишку гамми
        /// </summary>
        /// <returns></returns>
        Toy MakeNewGummi_Bear()
        {
            Toy toy = new Gummi_Bear();
            toy.Name = Input("Введите название мишки");
            toy.Quantity = InputIntValue("Введите количество мишек");
            toy.Frequency = InputIntValue("Введите \"вес\" мишек, от него будет зависеть шанс выпадения");

            return toy;
        }

        /// <summary>
        /// Создаёт нового робота
        /// </summary>
        /// <returns></returns>
        Toy MakeNewRobot()
        {
            Toy toy = new Robot();
            toy.Name = Input("Введите название мишки");
            toy.Quantity = InputIntValue("Введите количество мишек");
            toy.Frequency = InputIntValue("Введите \"вес\" мишек, от него будет зависеть шанс выпадения");

            return toy;
        }

        /// <summary>
        /// Создаёт новый скутер
        /// </summary>
        /// <returns></returns>
        Toy MakeNewScooter()
        {
            Toy toy = new Scooter();
            toy.Name = Input("Введите название мишки");
            toy.Quantity = InputIntValue("Введите количество мишек");
            toy.Frequency = InputIntValue("Введите \"вес\" мишек, от него будет зависеть шанс выпадения");

            return toy;
        }

        /// <summary>
        /// Ввод строкового значения
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        string Input(string s)
        {
            Console.WriteLine(s);
            return Console.ReadLine();
        }


        /// <summary>
        /// Ввод целочисленного значения с проверкой на корректность ввода
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        int InputIntValue(string s)
        {
            Console.WriteLine(s);
            bool isCorrectInput = int.TryParse(Console.ReadLine(), out int value);
            if (!isCorrectInput)
            {
                return InputIntValue("Некорректный ввод. Попробуйте ещё раз");
            }
            else return value;
        }
    }
}

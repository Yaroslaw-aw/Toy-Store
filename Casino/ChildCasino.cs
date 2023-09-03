using System.IO;
using System.Text;
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
                              $" 6. Изменить вес игрушки\n" +
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
                        toysMachine.AddToy(MakeNewToy());
                        Console.WriteLine("Новая игрушка добавлена. Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
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
                case 6:
                    {
                        ShowToys();
                        int id = InputIntValue("\nВведите id игрушки, вес которой надо поменять");
                        int weight = InputIntValue("\nВведите значение веса, которое надо установить");
                        toysMachine.SetWeight(id, weight);
                        Console.WriteLine($"У игрушки id {id} установлен вес {weight}. Нажмите любую клавишу для продолжения");
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
        public async void GetPrize()
        {
            string path = @".\Prizes.txt";

            if (prizes.Count > 0)
            {
                Console.WriteLine($"Вы забрали игрушку {prizes[0].Name}! Она теперь ваша навсегда ;)");
                try
                {
                    string text = $"{prizes[0].GetType().Name} {prizes[0].Name}\n";
                    using (FileStream fstream = new FileStream(path, FileMode.Append))
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(text);
                        await fstream.WriteAsync(buffer, 0, buffer.Length);
                        Console.WriteLine("\nПриз записан в файл. Нажмите клавишу для продолжения");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Не удалось создать файл\n" + e.Message);
                }

                prizes.Remove(prizes[0]);
            }
        }
        /// <summary>
        /// Ребёнок забирает все игрушки, которые выиграл
        /// </summary>
        public async void GetAllPrizes()
        {
            string path = @".\Prizes.txt";
            string text = string.Empty;

            if (prizes.Count > 0)
            {
                Console.WriteLine("Поздравляем с выигрышем!");

                foreach (var prize in prizes)
                {
                    text += ($"{prize.GetType().Name} {prize.Name}\n"); // Не знаю, как из СтрингБилдера потом в буфер вставить текст, нет времени разбираться
                    Console.WriteLine($"Вы забрали игрушку {prize.Name}! Она теперь ваша навсегда ;)");
                }

                using (FileStream fstream = new FileStream(path, FileMode.Append))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(text);
                    await fstream.WriteAsync(buffer, 0, buffer.Length);
                    Console.WriteLine("\nПризы записан в файл. Нажмите клавишу для продолжения");
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
        /// Создаёт новую игрушку
        /// </summary>
        /// <returns></returns>
        Toy MakeNewToy()
        {
            Toy toy = new Toy();
            toy.Name = Input("Введите название игрушки");
            toy.Quantity = InputIntValue("Введите количество игрушек");
            toy.Frequency = InputIntValue("Введите \"вес\" игрушек, от него будет зависеть шанс выпадения");

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

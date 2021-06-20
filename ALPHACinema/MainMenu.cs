using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPHACinema
{
    public class MainMenu
    {
        public CinemaHall hall; 
        private int rows;
        private int columns;

        public MainMenu(int rowsMin, int rowsMax, int columnsMin, int columnsMax)
        {
            Random rand = new Random();
            this.rows = rand.Next(rowsMin, rowsMax+1);
            this.columns = rand.Next(columnsMin, columnsMax + 1);
            hall = new CinemaHall(rows, columns);
        }

        public void CinemaWork()
        {
            string input = "";
            while (input != "0")
            {
                Console.WriteLine();
                Console.WriteLine("\nДоступные действия:\n1 - Вывести план зала\n2 - Купить места\n3 - Забронировать места\n4 - Отменить бронь мест\n5 - Проверить что места заняты\n0 - Завершить работу");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("\nПлан зала:");
                        hall.ShowCinemaHall();
                        break;
                    case "2":
                        Console.WriteLine("\n****Покупка мест****");
                        Manager(2);
                        break;
                    case "3":
                        Console.WriteLine("\n****Бронирование мест****");
                        Manager(3);
                        break;
                    case "4":
                        Console.WriteLine("\n****Отмена бронирования мест****");
                        Manager(4);
                        break;
                    case "5":
                        Console.WriteLine("\n****Проверить что места заняты****");
                        Manager(5);
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда. Повторите ввод.");
                        break;
                }
            }
            Console.WriteLine("Завершение работы кинотеатра...\nДо новых встреч!");
        }

        private bool ReadInput(string s, out int  row, out int column)
        {
            string[] seat = s.Split(' ');
            row = 0;
            column = 0;
            if (seat.Length != 2) 
            {
                Console.WriteLine($"Некорректный ввод места:{s}. Неправильное количество параметров.");
                return false;
            }

            try
            {
                row = Int32.Parse(seat[0]);
                column = Int32.Parse(seat[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Некорректный ввод:{s} принимаются только целочисленные значения.");
                return false;
            }

            if (row <= 0 || row > this.rows)
            {
                Console.WriteLine($"Некорректный ввод:{s}. Ряд должен быть больше 0 и меньше {this.rows + 1}.");
                return false;
            }
            if (column <= 0 || column > this.columns)
            {
                Console.WriteLine($"Некорректный ввод:{s}. Место должно быть больше 0 и меньше {this.columns + 1}.");
                return false;
            }

            return true;
        }
        private void Manager(short task)
        {
            Console.WriteLine("\nВведите места в формате: [Ряд Место;Ряд Место;...;Ряд Место]");
            String[] s = Console.ReadLine().Split(';');
            foreach (string seat in s)
            {
                int row, column;
                if (ReadInput(seat, out row, out column))
                {
                    switch (task)
                    {
                        case 2:
                            hall.BuySeat(row, column);
                            break;
                        case 3:
                            hall.ReserveSeat(row, column);
                            break;
                        case 4:
                            hall.FreeSeat(row, column);
                            break;
                        case 5:
                            hall.StateOfPlace(row, column);
                            break;
                    }
                }
            }

            
        }

    }

}

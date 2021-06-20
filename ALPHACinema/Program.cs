using System;
using System.Collections;

namespace ALPHACinema
{

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите объем зала.");
            Console.WriteLine("\nВведите минимальный размер зала в формате: Ряды Места");
            int rowsMin=0, columnsMin=0;
            string s;
            do
            {
                s = Console.ReadLine();
            }
            while (!CheckInput(s, out rowsMin, out columnsMin));

            Console.WriteLine("\nВведите максимальный размер зала в формате: Ряды Места");
            int rowsMax=0, columnsMax=0;
            do
            {
                s = Console.ReadLine();
            }
            while (!CheckInput(s, out rowsMax, out columnsMax));
            MainMenu cinema = new MainMenu(rowsMin, rowsMax, columnsMin, columnsMax);
            cinema.CinemaWork();
        }
        static public bool CheckInput(string s, out int row, out int column)
        {
            string[] seat = s.Split(' ');
            row = 0;
            column = 0;
            if (seat.Length != 2)
            {
                Console.WriteLine($"Некорректный ввод размера:{s}. Неправильное количество параметров.");
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

            if (row <= 0)
            {
                Console.WriteLine($"Некорректный ввод:{s}. Количество рядов должно быть больше 0.");
                return false;
            }
            if (column <= 0)
            {
                Console.WriteLine($"Некорректный ввод:{s}. Количество мест должно быть больше 0.");
                return false;
            }

            return true;
        }
    }

}

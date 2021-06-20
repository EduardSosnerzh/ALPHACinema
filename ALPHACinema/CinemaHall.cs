using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPHACinema
{
    public class CinemaHall : IEnumerable, IControlable
    {
        private Seat[] _seats;
        private int rows = 0;
        private int columns = 0;

        public CinemaHall(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            _seats = new Seat[columns * rows];

            for (int i = 0; i < rows * columns; i++)
            {
                _seats[i] = new Seat();
            }
        }

        private Seat GetSeat(int row, int column)
        {
            return _seats[this.columns * (row - 1) + column - 1];
        }

        public void BuySeat(int row, int column)
        {
            Seat curSeat = GetSeat(row, column);
            switch (curSeat.State)
            {
                case SeatState.Free:
                    curSeat.Buy();
                    Console.WriteLine("Успешная покупка места: ряд {0}, место {1}", row, column);
                    break;
                case SeatState.Busy:
                    Console.WriteLine("Невозможно совершить покупку места: ряд {0}, место {1}. Место уже куплено.", row, column);
                    break;
                case SeatState.Reserved:
                default:
                    curSeat.Buy();
                    Console.WriteLine("Успешная покупка забронированного места: ряд {0}, место {1}.", row, column);
                    break;
            }
        }

        public void ReserveSeat(int row, int column)
        {
            Seat curSeat = GetSeat(row, column);
            switch (curSeat.State)
            {
                case SeatState.Free:
                    curSeat.Reserve();
                    Console.WriteLine("Успешная бронь места: ряд {0}, место {1}", row, column);
                    break;
                case SeatState.Busy:
                    Console.WriteLine("Невозможно забронировать место: ряд {0}, место {1}. Место уже куплено.", row, column);
                    break;
                case SeatState.Reserved:
                default:
                    Console.WriteLine("Невозможно забронировать место: ряд {0}, место {1}. Место уже забронировано.", row, column);
                    break;
            }
        }

        public void FreeSeat(int row, int column)
        {
            Seat curSeat = GetSeat(row, column);
            switch (curSeat.State)
            {
                case SeatState.Free:
                    Console.WriteLine("Невозможно отменить бронь места: ряд {0}, место {1}. Оно свободно.", row, column);
                    break;
                case SeatState.Busy:
                    Console.WriteLine("Невозможно отменить бронь места: ряд {0}, место {1}. Место уже куплено.", row, column);
                    break;
                case SeatState.Reserved:
                default:
                    curSeat.Free();
                    Console.WriteLine("Успешно отменена бронь места: ряд {0}, место {1}. Место свободно.", row, column);
                    break;
            }
        }

        public void StateOfPlace(int row, int column)
        {
            Seat curSeat = GetSeat(row, column);
            switch (curSeat.State)
            {
                case SeatState.Free:
                    Console.WriteLine("Место: Ряд {0}, Место {1} -- СВОБОДНО.", row, column);
                    break;
                case SeatState.Busy:
                    Console.WriteLine("Место: Ряд {0}, Место {1} -- КУПЛЕНО.", row, column);
                    break;
                case SeatState.Reserved:
                    Console.WriteLine("Место: Ряд {0}, Место {1} -- ЗАРЕЗЕРВИРОВАНО.", row, column);
                    break;
                    
            }
        }
        public void ShowCinemaHall()
        {
            //- free
            //* busy
            //# reserved
            Console.WriteLine("\n'-' Место свободно\n'*' Место занято\n'#' Место забронировано");
            int i = 0;
            Console.Write("\t");
            for (int j = 0; j < columns; j++)
            {
                Console.Write("{0}\t", j + 1);
            }
            Console.WriteLine();
            foreach (Seat s in _seats)
            {
                if (i % columns == 0)
                {
                    Console.WriteLine();
                    Console.Write("{0}\t", i / columns + 1);
                }

                switch (s.State)
                {
                    case SeatState.Free:
                        Console.Write("-");
                        break;
                    case SeatState.Busy:
                        Console.Write("*");
                        break;
                    case SeatState.Reserved:
                    default:
                        Console.Write("#");
                        break;
                }
                Console.Write("\t");
                i++;
            }

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public SeatEnum GetEnumerator()
        {
            return new SeatEnum(_seats);
        }
    }
}

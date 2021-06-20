using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPHACinema
{
    interface IControlable
    {
        public void BuySeat(int row, int column);
        public void ReserveSeat(int row, int column);
        public void FreeSeat(int row, int column);
        public void StateOfPlace(int row, int column);
    }
}

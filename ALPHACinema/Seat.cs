using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPHACinema
{
    public enum SeatState
    {
        Free,
        Reserved,
        Busy
    }
    public class Seat
    {
        public SeatState State { get; private set; } = SeatState.Free;

        public void Reserve()
        {
            State = SeatState.Reserved;
        }

        public void Buy()
        {
            State = SeatState.Busy;
        }

        public void Free()
        {
            State = SeatState.Free;
        }
    }
}

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPHACinema
{
    public class SeatEnum : IEnumerator
    {
        public Seat[] _seats;

        int position = -1;

        public SeatEnum(Seat[] list)
        {
            _seats = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _seats.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Seat Current
        {
            get
            {
                try
                {
                    return _seats[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}

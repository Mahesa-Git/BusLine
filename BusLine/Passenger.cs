using System;
using System.Collections.Generic;
using System.Text;

namespace BusLine
{
    class Passenger
    {
        public bool IsChecked { get; set; }
        public bool IsRiding { get; set; }
        public int ExitsBusAt { get; set; }
        public int EntersBusAt { get; set; }
        public Passenger(int exitsBusAt, int entersBusAt, bool isRiding, bool isChecked)
        {
            ExitsBusAt = exitsBusAt;
            EntersBusAt = entersBusAt;
            IsRiding = isRiding;
            IsChecked = isChecked;
        }
    }
}

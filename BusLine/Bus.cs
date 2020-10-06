using System;
using System.Collections.Generic;
using System.Text;

namespace BusLine
{
    
    class Bus
    {
        public static int currentStation = 0;
        public static int BusIsFullMessage = 0;
        public static int leavingPassengers;
        public int PassengersOnBus { get; set; }
        public int MaxPassengers { get; set; }
        public Bus(int maxPassengers, int passengersOnBus)
        {
            MaxPassengers = maxPassengers;
            PassengersOnBus = passengersOnBus;
        }
    }
}

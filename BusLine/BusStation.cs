using System;
using System.Collections.Generic;
using System.Text;

namespace BusLine
{
    class BusStation
    {
        public string StationName { get; set; }
        public int WaitingPassengers { get; set; }
        public int StationID { get; set; }
        public int PassengerDestination { get; set; }
        public BusStation(string stationName, int waitingPassengers, int stationID)
        {
            StationName = stationName;
            WaitingPassengers = waitingPassengers;
            StationID = stationID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;

namespace BusLine
{
    class Program
    {
        public static Random rnd = new Random();
        public static List<BusStation> busStations = new List<BusStation>();
        public static List<Passenger> passengerList = new List<Passenger>();
        public static Bus bus = new Bus(20, 0);
        static void Main(string[] args)
        {
            BusStationGenerator();
            while (true)
            {
                PassengerGenerator(rnd.Next(5, 6 + 1));
                PrintAndConditions(Bus.currentStation);
            }
        }
        static void PrintAndConditions(int thisStationNow)
        {
            Console.WriteLine("*BUSSLINJEN*\n");
            for (int i = passengerList.Count - 1; i >= 0; i--)
            {
                if (thisStationNow == passengerList[i].EntersBusAt && passengerList[i].IsChecked == true)
                {
                    if (bus.PassengersOnBus < bus.MaxPassengers)
                    {
                        passengerList[i].IsRiding = true;
                        bus.PassengersOnBus++;
                    }
                    else
                        Bus.BusIsFullMessage++;
                }
                if (passengerList[i].IsRiding == true && passengerList[i].ExitsBusAt == thisStationNow)
                {
                    Bus.leavingPassengers++;
                    passengerList.RemoveAt(i);
                }
            }
            for (int i = 0; i < busStations.Count; i++)
            {
                if (i == thisStationNow)
                {
                    Console.WriteLine($"{busStations[i].StationName} Bussen är här och släpper av {Bus.leavingPassengers} passagerare " +
                                      $"{(Bus.BusIsFullMessage != 0 ? ($"och hämtar upp {(busStations[i].WaitingPassengers - Bus.BusIsFullMessage)}. {Bus.BusIsFullMessage} kunde inte åka med då bussen var full") : ($"och hämtar upp de {busStations[i].WaitingPassengers} väntande passagerarna."))}");
                    busStations[i].WaitingPassengers = 0;
                    busStations[i].WaitingPassengers += Bus.BusIsFullMessage;
                }
                else
                    Console.WriteLine($"{busStations[i].StationName} {busStations[i].WaitingPassengers} väntande passagerare");
            }
            bus.PassengersOnBus -= Bus.leavingPassengers;
            Console.WriteLine($"{(Bus.BusIsFullMessage == 0 ? ($"\nPassagerare på bussen: {bus.PassengersOnBus}") : "\nPassagerare på bussen: 20")}");
            Thread.Sleep(5000);
            Console.Clear();
            Bus.BusIsFullMessage = 0;
            Bus.leavingPassengers = 0;
            for (int i = 0; i < passengerList.Count; i++)
                passengerList[i].IsChecked = true;
            if (Bus.currentStation == busStations.Count - 1)
                Bus.currentStation = -1;

            Bus.currentStation++;
        }
        static void PassengerGenerator(int thisMany)
        {
            for (int i = 0; i < thisMany; i++)
            {
                int exitsBusAt;
                int entersBusAt;
                while (true)
                {
                    exitsBusAt = rnd.Next(0, 10);
                    entersBusAt = rnd.Next(0, 10);

                    if ((entersBusAt != Bus.currentStation + 1) && (entersBusAt != Bus.currentStation - 1) && (entersBusAt != Bus.currentStation))
                        break;
                }
                Passenger passenger = new Passenger(exitsBusAt, entersBusAt, false, false);
                passengerList.Add(passenger);
            }
            AssignNewWaitingPassengers(passengerList);
        }
        static void AssignNewWaitingPassengers(List<Passenger> thisList)
        {
            for (int i = 0; i < busStations.Count; i++)
            {
                for (int j = 0; j < thisList.Count; j++)
                {
                    if (thisList[j].EntersBusAt == busStations[i].StationID && thisList[j].IsChecked == false)
                        busStations[i].WaitingPassengers++;
                }
            }
        }
        static void BusStationGenerator()
        {
            for (int i = 0; i < 10; i++)
            {
                BusStation tempStop = new BusStation($"Hållplats {i + 1}: ", 0, i);
                busStations.Add(tempStop);
            }
        }
    }
}

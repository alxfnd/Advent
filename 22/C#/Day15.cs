using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    class Sensor
    {
        int sensorx, sensory, beaconx, beacony;
        public (int, int) beacon;
        public int distance;
        List<(int,int)> sensorArea = new();
        public void SetSensor(int x, int y, int beaconx, int beacony) 
        { 
            this.sensorx = x; this.sensory = y; this.beaconx = beaconx; this.beacony = beacony;
            distance = Math.Abs(sensorx - beaconx) + Math.Abs(sensory - beacony);
            beacon = (beaconx, beacony);
        }
        public void CalculateSensorArea()
        {
            for (int y = 0; y <= distance; y++)
            {
                //if (sensory + y != 2000000 && sensory - y != 2000000) continue;
                for (int x = ((0 - distance) + y); x <= (distance - y); x++)
                {
                    
                    (int, int) location = ((sensorx + x), (sensory + y));
                    if (!sensorArea.Contains(location)) sensorArea.Add(location);
                    location = ((sensorx + x), (sensory - y));
                    if (!sensorArea.Contains(location)) sensorArea.Add(location);
                }
            }
        }
        public List<int> CalculateSensorArea(int row, List<int> sensorLocations)
        {
            //If sensor doesn't reach destination row, return
            if (sensory + distance < row || sensory - distance > row) return sensorLocations;

            //Calculate the distance to destination and grab remainder distance to calculate coverage
            bool greater;
            int distanceRemainder;
            if (row > sensory) greater = true; else greater = false;
            int x = sensorx; int y;
            if (greater) { distanceRemainder = distance - (row - sensory); y = sensory + (distance - distanceRemainder); }
            else { distanceRemainder = distance - (sensory - row); y = sensory - (distance - distanceRemainder); }

            //Add the x values of destination row to the whole
            if (distanceRemainder == 0) sensorLocations.Add(sensorx);
            else sensorLocations.AddRange(Enumerable.Range((sensorx - distanceRemainder), ((distanceRemainder * 2) + 1)));
            //sensorLocations.AddRange(Enumerable.Range((sensorx - distanceRemainder), (sensorx + distanceRemainder)));
            return sensorLocations;
            /*
            for (int c = (0 - distanceRemainder); c <= distanceRemainder; c++)
            {
                int location = ((sensorx + c), (y));
                if (!sensorLocations.Contains(location)) sensorLocations.Add(location);
                //location = ((sensorx + c), (y));
                //if (!sensorArea.Contains(location)) sensorArea.Add(location);
            }
            return sensorLocations;
            */
        }
        public List<(int,int)> GetSensorArea()
        {
            return sensorArea;
        }
        public void DisplayArea()
        {
            sensorArea.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(sensorArea.Count);
        }
        public Sensor() { }
    }
    internal class Day15
    {
        readonly List<string> File = System.IO.File.ReadLines("C:\\tmp\\Advent\\Day15.txt").ToList();
        public List<int> ParseString(string line)
        {
            List<int> list = new();
            //Get sensor
            List<string> sensor = line.Split(':')[0].Replace("Sensor at ","").Split(", ").ToList();
            list.Add(int.Parse(sensor[0][2..]));
            list.Add(int.Parse(sensor[1][2..]));
            //Get beacon
            List<string> beacon = line.Split(':')[1].Replace(" closest beacon is at ", "").Split(", ").ToList();
            list.Add(int.Parse(beacon[0][2..]));
            list.Add(int.Parse(beacon[1][2..]));
            return list;
        }
        public Day15() 
        {
            /*
            List<int> values = ParseString(File[6]);
            Sensor one = new();
            one.SetSensor(values[0], values[1], values[2], values[3]);
            one.CalculateSensorArea();
            one.DisplayArea();
            Console.Write(one.distance);
            */
            int row = 2000000;
            List<(int, int)> fullSensorArea = new();
            List<int> numRanges = new();
            List<Sensor> allSensors = new();
            for (int i = 0; i < File.Count; i++)
            {
                List<int> currentValues = ParseString(File[i]);
                Sensor newSensor = new();
                newSensor.SetSensor(currentValues[0], currentValues[1], currentValues[2], currentValues[3]);
                //if (currentValues[1] + newSensor.distance > 2000000
                //    && currentValues[1] - newSensor.distance < 2000000)
                numRanges = newSensor.CalculateSensorArea(row, numRanges);
                    //fullSensorArea = newSensor.CalculateSensorArea(row, fullSensorArea);
                    //newSensor.GetSensorArea().ForEach(coord =>
                    //    { if (!fullSensorArea.Contains(coord)) { fullSensorArea.Add(coord); } });
                
                allSensors.Add(newSensor);
            }
            numRanges = numRanges.Distinct().ToList();
            /*
            for (int i = 0; i < numRanges.Count; i++)
            {
                (int, int) location = ((numRanges[i], row));
                if (!fullSensorArea.Contains(location)) fullSensorArea.Add(location);
            }
            */
            numRanges.Sort();
            List<(int, int)> allBeacons = new();
            allSensors.ForEach(b => allBeacons.Add(b.beacon));
            //allBeacons.ForEach(beacon => fullSensorArea.Remove(beacon));
            allBeacons.ForEach(beacon =>
                { if (beacon.Item2 == row) numRanges.Remove(beacon.Item1); } );
            //allBeacons.ForEach(x => Console.WriteLine(x));
            //fullSensorArea.Sort();
            Console.WriteLine(numRanges.Count);
            //Console.WriteLine(fullSensorArea.Where(x => x.Item2 == row).Count()); //.ToList().ForEach(y => Console.WriteLine(y));
            //fullSensorArea.ForEach(x => Console.WriteLine(x));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class IntelligenceGathering : Operation
    {
        public string CameraType { get; set; }
        public List<string> Route { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Plane> Planes { get; set; }

        public IntelligenceGathering(string name, string description, int planesNumber, string cameraType,
            List<string> route, DateTime startTime, DateTime endtTime)
        {
            operationNumber++;
            Code = operationNumber;
            Name = name;
            Description = description;
            PlanesNumber = planesNumber;
            CameraType = cameraType;
            Route = route;
            StartTime = startTime;
            EndTime = endtTime;
            Planes = new List<Plane>();
        }
        public override bool isOperationReady()
        {
            DateTime now = DateTime.Now;
            if (Planes.Count() >= PlanesNumber * 0.8 && StartTime > now && StartTime.AddHours(3.00) <= now)
                return true;
            return false;
        }
        public override void Print()
        {
            
            foreach (var prop in this.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name + ": " + prop.GetValue(this, null));
            }
            Console.WriteLine("The list of planes: ");
            foreach (Plane p in Planes)
            {
                if (p != null)
                {
                    Console.WriteLine(p.Name);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class AssaultOperation: Operation
    {
        public string ArmamentType { get; set; }
        public string Landmark { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Plane> Planes { get; set; }
        public AssaultOperation(string name,string description, int planesNumber,string armamentType,
            string landmark,  DateTime startTime, DateTime endtTime)
        {
            operationNumber++;
            Code = operationNumber;
            Name = name;
            Description = description;
            PlanesNumber = planesNumber;
            ArmamentType = armamentType;
            Landmark = landmark;
            StartTime = startTime;
            EndTime = endtTime;
            Planes = new List<Plane>();
        }
        public override bool isOperationReady()
        {
            DateTime now = DateTime.Now;
            if (Planes.Count() == PlanesNumber && StartTime>now && StartTime.AddHours(10.00)<=now)
                return true;
            return false;
        }
        public override void Print()
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name + ": " + prop.GetValue(this, null));
            }
        }
    }
}

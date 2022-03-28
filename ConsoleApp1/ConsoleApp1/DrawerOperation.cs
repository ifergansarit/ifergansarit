using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DrawerOperation: Operation
    {
        public string CameraType { get; set; }
        public List<string> Route { get; set; }
        public DrawerOperation(string name,string description,int planesNumber, string cameraType, List<string> route)
        {
            operationNumber++;
            Code = operationNumber;
            Name = name;
            Description = description;
            PlanesNumber = planesNumber;
            CameraType = cameraType;
            Route = route;
        }
        public override bool isOperationReady()
        {
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

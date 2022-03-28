using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Plane
    {
        private static int code;
        private readonly int tailNumber;
        public string Name { get; set; }
        public bool IsInUse { get; set; }
        public string OperationName { get; set; }

        public int TailNumber{
        get{ return tailNumber; }
        }

        static Plane()
        {
            code = 0;
        }
        public Plane(string name)
        {
            code++;           
            tailNumber = code;
            Name = name;
            IsInUse = false;
            OperationName = null;
        }

        //public bool IsInUse()
        //{

        //    return true;
        //}
    }
}

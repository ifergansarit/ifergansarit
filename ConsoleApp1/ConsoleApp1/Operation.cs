using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Operation
    {
        protected static int operationNumber;
        public  int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlanesNumber { get; set; }

        
        static  Operation()
        {
            operationNumber = 0;
        }
        public abstract bool isOperationReady();
        public abstract void Print();
    }
}

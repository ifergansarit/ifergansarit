using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AirForce
    {
        public List<Plane> Planes { get; set; }
        public List<Operation> Operations { get; set; }
        public List<DrawerOperation> DrawerOperations { get; set; }

        public AirForce()
        {
            Planes = new List<Plane>();
            for (int i = 0; i < 1000; i++)
            {
                Plane p = new Plane("sufa");
                Planes.Add(p);
            }
            Operations = new List<Operation>();
            DrawerOperations = new List<DrawerOperation>();
        }
        public void AddOperation(Operation op)
        {
            Operations.Add(op);
            if (op is DrawerOperation)
                DrawerOperations.Add(op as DrawerOperation);

        }

        //updating the IsAssignedForUse field in the planes in use
        public void UpdatingPlanes()
        {
            DateTime now = DateTime.Now;
            foreach (Operation op in Operations)
            {
                if (op != null)
                {
                    if (op is IntelligenceGathering)
                    {
                        for (int i = 0; i < (op as IntelligenceGathering).Planes.Count(); i++)
                        {
                            if ((op as IntelligenceGathering).Planes[i] != null)
                            {
                                if ((op as IntelligenceGathering).EndTime.AddHours(1) <= now)
                                {
                                    (op as IntelligenceGathering).Planes[i].IsInUse = false;
                                    (op as IntelligenceGathering).Planes[i].OperationName = null;
                                    Operations.Remove(op);
                                    i--;
                                }
                            }
                        }
                    }                    
                }
            }
        }

        //Otomatic Matching Planes in each operation
        public void OtomaticMatchingPlanes(Operation op)
        {
            if (op != null)
            {
                int planesNumber = 0;

                if (op is IntelligenceGathering)
                {
                    planesNumber = (op as IntelligenceGathering).PlanesNumber;
                }
                if (op is AssaultOperation)
                {
                    planesNumber = (op as AssaultOperation).PlanesNumber;
                }
                UpdatingPlanes();
                for (int i = 0; i < Planes.Count() && planesNumber > 0; i++)
                {
                    if (Planes[i] != null)
                    {
                        if (op is IntelligenceGathering)
                        {

                            if (Planes[i].IsInUse == false)
                            {
                                (op as IntelligenceGathering).Planes.Add(Planes[i]);
                                planesNumber--;
                                Planes[i].IsInUse = true;
                                Planes[i].OperationName = (op as IntelligenceGathering).Name;
                            }
                        }
                        if (op is AssaultOperation)
                        {
                            if (Planes[i].IsInUse == false)
                            {
                                (op as AssaultOperation).Planes.Add(Planes[i]);
                                planesNumber--;
                                Planes[i].IsInUse = true;
                                Planes[i].OperationName = (op as AssaultOperation).Name;
                            }
                        }
                    }
                }
            }
        }

        //selecting all operations within a certain time frame
        public List<Operation> OperationsWithinCertainTime(DateTime start, DateTime finish)
        {
            List<Operation> l = new List<Operation>();
            foreach (Operation op in Operations)
            {
                if (op is IntelligenceGathering)
                {
                    if ((op as IntelligenceGathering).StartTime <= start && (op as IntelligenceGathering).EndTime >= finish)
                    {
                        l.Add(op);
                    }
                }
                if (op is AssaultOperation)
                {
                    if ((op as AssaultOperation).StartTime <= start && (op as AssaultOperation).EndTime >= finish)
                    {
                        l.Add(op);
                    }
                }
            }
            return l;
        }
        //selecting all operations in x hours and which  aren't ready 
        public List<Operation> NotReadyOperations(double hours)
        {
            List<Operation> l = new List<Operation>();
            DateTime now = DateTime.Now;
            foreach (Operation op in Operations)
            {
                if (op is IntelligenceGathering)
                {
                    if (!(op as IntelligenceGathering).isOperationReady() && (op as IntelligenceGathering).StartTime == now.AddHours(hours))
                    {
                        l.Add(op);
                    }
                }
                if (op is AssaultOperation)
                {
                    if (!(op as AssaultOperation).isOperationReady() && (op as AssaultOperation).StartTime == now.AddHours(hours))
                    {
                        l.Add(op);
                    }
                }
            }
            return l;
        }
        //changing times of one operation
        public void ChangingTimesOfOneOperation(string name, DateTime startTime, DateTime endTime)
        {

            //Operation op = (Operation)Operations.Where(operation => operation.Name == name);
            foreach (Operation op in Operations)
            {
                if (op != null)
                {
                    if (op.Name == name)
                    {
                        IntelligenceGathering i=op as IntelligenceGathering;
                        if(i!=null){
                            foreach (Plane p in (i as IntelligenceGathering).Planes)
                            {
                                if (p != null)
                                {
                                    p.IsInUse = false;
                                    p.OperationName = null;                                   
                                }
                            }
                            (i as IntelligenceGathering).Planes.Clear();
                            (i as IntelligenceGathering).StartTime = startTime;
                            (i as IntelligenceGathering).EndTime = endTime;
                            OtomaticMatchingPlanes(i);
                            i.isOperationReady();
                            i.Print();
                        }                        
                    }
                    AssaultOperation a = op as AssaultOperation;
                    if (a != null)
                    {
                        foreach (Plane p in (a as AssaultOperation).Planes)
                        {
                            if (p != null)
                            {
                                p.IsInUse = false;
                                p.OperationName = null;
                            }
                        }
                        (a as AssaultOperation).Planes.Clear();
                        (a as AssaultOperation).StartTime = startTime;
                        (a as AssaultOperation).EndTime = endTime;
                        OtomaticMatchingPlanes(a);
                        a.isOperationReady();
                        a.Print();
                    }
                   
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //public enum CameraTypes { night, heat, wideLens }
    class Program
    {

        public static List<IntelligenceGathering> CreatingOperation(AirForce myAirForce, int code, string name, DateTime startTime, DateTime endTime)
        {
            List<IntelligenceGathering> opList = new List<IntelligenceGathering>();

            IntelligenceGathering op;
            try
            {
                if (myAirForce.DrawerOperations != null)
                {
                    for (int i = 0; i < myAirForce.DrawerOperations.Count(); i++)
                    {
                        if (myAirForce.DrawerOperations[i] != null)
                        {
                            if (myAirForce.DrawerOperations[i].Code == code)
                            {
                                op = new IntelligenceGathering(name, myAirForce.DrawerOperations[i].Description,
                                 myAirForce.DrawerOperations[i].PlanesNumber, myAirForce.DrawerOperations[i].CameraType, myAirForce.DrawerOperations[i].Route, startTime, endTime);
                                //i = myAirForce.DrawerOperations.Count();
                                opList.Add(op);
                            }
                        }
                    }

                }
                else
                    Console.WriteLine("There are no Drawer Operations");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return opList;
        }
        static void Main(string[] args)
        {
            try
            {
                AirForce myAirForce = new AirForce();
                bool finish = false;

                do
                {
                    Console.WriteLine("Choose an action");
                    string action = Console.ReadLine();
                    switch (action)
                    {
                        case "d":    //adding DrawerOperation
                            Console.WriteLine("enter name");
                            string name = Console.ReadLine();
                            Console.WriteLine("enter description");
                            string description = Console.ReadLine();
                            Console.WriteLine("enter num of planes");
                            int planesNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter camera type");
                            string cameraType = Console.ReadLine();
                            List<string> route = new List<string>();
                            Console.WriteLine("enter origion");
                            string origion = Console.ReadLine();
                            route.Add(origion);
                            Console.WriteLine("enter staitions");
                            string staitions = Console.ReadLine();
                            route.Add(staitions);
                            Console.WriteLine("enter destination");
                            string destination = Console.ReadLine();
                            route.Add(destination);
                            DrawerOperation drawerOperation = new DrawerOperation(name, description, planesNumber, cameraType, route);
                            drawerOperation.Print();
                            myAirForce.AddOperation(drawerOperation);
                            break;
                        case "i":       //adding IntelligenceGathering
                            Console.WriteLine("Is it an instance of DrawerOperation or not?");
                            string answer = Console.ReadLine();
                            switch (answer)
                            {
                                case "y":
                                    Console.WriteLine("enter code of a drawer operation you want to use");
                                    int code11 = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("enter name for the new operation");
                                    string name11 = Console.ReadLine();
                                    Console.WriteLine("enter startTime");
                                    DateTime startTime11 = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("enter endTime");
                                    DateTime endTime11 = Convert.ToDateTime(Console.ReadLine());
                                    List<IntelligenceGathering> opList = CreatingOperation(myAirForce, code11, name11, startTime11, endTime11);
                                    myAirForce.AddOperation(opList[0]);
                                    myAirForce.OtomaticMatchingPlanes(opList[0]);
                                    opList[0].Print();
                                    break;
                                case "n":
                                    Console.WriteLine("enter name");
                                    string name1 = Console.ReadLine();
                                    Console.WriteLine("enter description");
                                    string description1 = Console.ReadLine();
                                    Console.WriteLine("enter num of planes");
                                    int planesNumber1 = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("enter camera type");
                                    string cameraType1 = Console.ReadLine();
                                    List<string> route1 = new List<string>();
                                    Console.WriteLine("enter origion");
                                    string origion1 = Console.ReadLine();
                                    route1.Add(origion1);
                                    Console.WriteLine("enter staitions");
                                    string staitions1 = Console.ReadLine();
                                    route1.Add(staitions1);
                                    Console.WriteLine("enter destination");
                                    string destination1 = Console.ReadLine();
                                    route1.Add(destination1);
                                    Console.WriteLine("enter startTime");
                                    DateTime startTime = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("enter endTime");
                                    DateTime endTime = Convert.ToDateTime(Console.ReadLine());
                                    IntelligenceGathering IntelligenceGatheringOperation2 = new IntelligenceGathering(name1, description1, planesNumber1,
                                        cameraType1, route1, startTime, endTime);                                    
                                    myAirForce.AddOperation(IntelligenceGatheringOperation2);
                                    myAirForce.OtomaticMatchingPlanes(IntelligenceGatheringOperation2);
                                    IntelligenceGatheringOperation2.Print();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "a":      //adding AssaultOperation
                            Console.WriteLine("enter name");
                            string name2 = Console.ReadLine();
                            Console.WriteLine("enter description");
                            string description2 = Console.ReadLine();
                            Console.WriteLine("enter num of planes");
                            int planesNumber2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter armamentType");
                            string armamentType = Console.ReadLine();
                            Console.WriteLine("enter landmark");
                            string landmark = Console.ReadLine();
                            Console.WriteLine("enter startTime");
                            DateTime startTime2 = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("enter endTime");
                            DateTime endTime2 = Convert.ToDateTime(Console.ReadLine());
                            AssaultOperation assaultOperation = new AssaultOperation(name2, description2, planesNumber2
                                , armamentType, landmark, startTime2, endTime2);
                            assaultOperation.Print();
                            myAirForce.AddOperation(assaultOperation);
                            myAirForce.OtomaticMatchingPlanes(assaultOperation);
                            break;
                        case "s":     //selecting all operations within a certain time frame
                            Console.WriteLine("enter startTime");
                            DateTime startTime3 = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("enter endTime");
                            DateTime endTime3 = Convert.ToDateTime(Console.ReadLine());
                            List<Operation> specificOperations = myAirForce.OperationsWithinCertainTime(startTime3, endTime3);
                            foreach (Operation op in specificOperations)
                            {
                                if (op != null)
                                    op.Print();                               
                            }

                            break;
                        case "c":      //changing times of one operation
                            Console.WriteLine("enter name of operation for chaging its times");
                            string name4 = Console.ReadLine();
                            Console.WriteLine("enter startTime");
                            DateTime startTime4 = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("enter endTime");
                            DateTime endTime4 = Convert.ToDateTime(Console.ReadLine());
                            myAirForce.ChangingTimesOfOneOperation(name4, startTime4, endTime4);
                            break;
                        case "r":     //checking if one operation is ready
                            Console.WriteLine("enter a name of operation");
                            string name5 = Console.ReadLine();
                            foreach (Operation op in myAirForce.Operations)
                            {
                                if (op != null)
                                {
                                    Console.WriteLine(op.isOperationReady());
                                }
                            }

                            break;
                        case "nr":    //selecting all operations in x hours and which  aren't ready 
                            Console.WriteLine("enter num of hours");
                            int hours = Convert.ToInt32(Console.ReadLine());
                            List<Operation> l = myAirForce.NotReadyOperations(hours);
                            foreach (Operation op in l)
                            {
                                if (op != null)
                                {
                                    op.Print();
                                }
                            }
                            break;
                        case "f":
                            finish = true;
                            break;
                        default:
                            finish = true;
                            break;
                    }
                } while (finish != true);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
